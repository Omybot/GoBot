using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRStopAction : IAction
    {
        private StopMode mode;

        public GRStopAction(StopMode m)
        {
            mode = m;
        }

        String IAction.ToString()
        {
            return GrosRobot.Nom + " stop " + mode;
        }

        void IAction.Executer()
        {
            GrosRobot.Stop(mode);
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
