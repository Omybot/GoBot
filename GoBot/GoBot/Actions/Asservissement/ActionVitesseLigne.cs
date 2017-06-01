using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionVitesseLigne : IAction
    {
        private int _speed;
        private Robot _robot;

        public ActionVitesseLigne(Robot r, int speed)
        {
            _robot = r;
            _speed = speed;
        }

        public override String ToString()
        {
            return _robot.Nom + " vitesse ligne à " + _speed;
        }

        void IAction.Executer()
        {
            _robot.SpeedConfig.LineSpeed = _speed;
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.IconeVitesse;  
            }
        }
    }
}
