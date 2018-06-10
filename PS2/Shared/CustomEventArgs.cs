using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS2
{
    public class CustomEventArgs : EventArgs
    {
        public byte[] Data { get; set; }

        public StareAutomat AutomationState;
    }
}
