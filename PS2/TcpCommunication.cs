using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

namespace PS2
{
    public class TcpCommunication
    {
        static Byte[] state = new Byte[16];
        static Byte[] com = new Byte[16];
        static  string error;
        static NetworkStream ns;
        static TcpClient client;
        static byte[] buffers;
        public event EventHandler<CustomEventArgs> StateChanged;
        public StareAutomat st;

        public void StartTcp()
        {
            try
            {
                Int32 port = 2000;
                IPAddress localIP = IPAddress.Parse("192.168.0.190");
                client = new TcpClient(localIP.ToString(), port);
                ns = client.GetStream();
                Thread t = new Thread(Read);
                t.Start();

            }
            catch(Exception e)
            {
                error = e.Message;
            }

        }
        public async void Read()
        {
            int count;
            while(client.Client.Connected)
            {
                count = await ns.ReadAsync(buffers, 0, 16);
                if (count == 16)
                {
                    if(state!=buffers)
                    {
                        state = buffers;
                        var bits = new BitArray(buffers);
                        //s0,s5,b1,b2,b3,b4,b5,g1,k1
                        //16,17,0, 1, 2, 3, 4, 32,33 indexs in bits
                        StareAutomat st = new StareAutomat(bits[16],bits[17], bits[0], bits[1], bits[2], bits[3],bits[4],bits[33],bits[32]);
                        OnStateChanged(new CustomEventArgs() { Data = buffers, AutomationState = st});                        
                    }
                }
            }

        }
        public  void Write(byte[] command)
        {            
            if(ns.CanWrite)
            {

                //ns.Write(command, 0, command.Length);
                ns.WriteAsync(command, 0, command.Length).Wait();
            }
        }

        public void On()
        {
            com = new byte[16];
            com[0] = 1;
            Write(com);
        }
        public void Off()
        {
            com = new byte[16];
            com[0] = 0;
            Write(com);

        }
        public void Umplere()
        {
            com = new byte[16];
            com[2] = 1;
            Write(com);
        }
        public void Golire()
        {
            com = new byte[16];
            com[2] = 2;
            Write(com);
        }

        public void StopTcp()
        {
            ns.Close();
            client.Close();
        }

        public void OnStateChanged(CustomEventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, e);
        }
        


    }
}
