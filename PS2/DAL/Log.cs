using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Log
    {
        //private int id;
        public string username { get; set; }
        public DateTime timestamp { get; set; }
        public string action { get; set; }
        public string state { get; set; }

        public Log(string username, DateTime timestamp, string action, string state)
        {
            //this.id = id;
            this.username = username;
            this.timestamp = timestamp;
            this.action = action;
            this.state = state;
        }
    }
}
