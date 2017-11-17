using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionCapteur : IAction
    {
        private String information;
        CapteurID capteur;
        private Robot robot;

        public ActionCapteur(Robot r, CapteurID ca, String info)
        {
            robot = r;
            information = info;
            capteur = ca;
        }

        public override String ToString()
        {
            return robot + " capteur " + NameFinder.GetName(capteur) + " voit " + information;
        }

        void IAction.Executer()
        {
            // Faire quelque chose ?
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.Motor16;  
            }
        }
    }
}
