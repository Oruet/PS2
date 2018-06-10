using System;

namespace Shared
{
    public static class SharedVariables
    {

        public static bool Umplut { get; set; }
        public static bool Pornit { get; set; }
        public static bool Deschis { get; set; }
        public static bool Activat { get; set; }
        public static bool[] Senzori { get; set; }

        static SharedVariables()
        {
            Senzori = new bool[5];
            Senzori[0] = false;             //b1
            Senzori[1] = false;             //b2
            Senzori[2] = false;             //b3
            Senzori[3] = false;             //b4
            Senzori[4] = false;             //b5



        }
    }
}
