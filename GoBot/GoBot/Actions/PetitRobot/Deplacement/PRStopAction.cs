using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRStopAction : IAction
    {
        private StopMode mode;

        public PRStopAction(StopMode m)
        {
            mode = m;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " stop " + mode;
        }

        void IAction.Executer()
        {
            PetitRobot.Stop(mode);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.stopPetit;  
            }
        }
    }
}
