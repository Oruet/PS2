using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS2
{
    public class StareAutomat
    {
        public bool s0 { get; set; }
        public bool s5 { get; set; }
        public bool b1 { get; set; }
        public bool b2 { get; set; }
        public bool b3 { get; set; }
        public bool b4 { get; set; }
        public bool b5 { get; set; }
        public bool g1 { get; set; }
        public bool k1 { get; set; }

        public StareAutomat(bool s0, bool s5, bool b1, bool b2, bool b3, bool b4, bool b5, bool g1, bool k1)
        {
            this.s0 = s0;
            this.s5 = s5;
            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.b4 = b4;
            this.b5 = b5;
            this.g1 = g1;
            this.k1 = k1;
        }

    }
}
