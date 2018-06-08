using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    class Log
    {
        //private int id;
        private string username;
        private DateTime timestamp;
        private string action;
        private string state;

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
