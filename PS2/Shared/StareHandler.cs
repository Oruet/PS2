using DAL;
using PS2;
using System;

namespace Shared
{
    public static class StareHandler
    {
        public static void Tcp_StateChanged(object sender, CustomEventArgs e)
        {
            if(SharedVariables.Senzori[1] == true && e.AutomationState.b2 == false) {
                DBHelper.addUser("User1", DateTime.Now, "Golire", "Nivel 1");
            }

            if (SharedVariables.Senzori[4] == false && e.AutomationState.b5 == true)
            {
                DBHelper.addUser("User1", DateTime.Now, "Umplere", "Nivel 5");
            }

            SharedVariables.Umplut = e.AutomationState.s5;
            SharedVariables.Pornit = e.AutomationState.g1;
            SharedVariables.Deschis = e.AutomationState.k1;
            SharedVariables.Senzori[0] = e.AutomationState.b1;
            SharedVariables.Senzori[1] = e.AutomationState.b2;
            SharedVariables.Senzori[2] = e.AutomationState.b3;
            SharedVariables.Senzori[3] = e.AutomationState.b4;
            SharedVariables.Senzori[4] = e.AutomationState.b5;

            

        }
    }
}
