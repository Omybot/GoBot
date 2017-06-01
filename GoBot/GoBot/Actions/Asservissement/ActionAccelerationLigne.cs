using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionAccelerationLigne : IAction
    {
        private int _accel;
        private int _decel;
        private Robot _robot;

        public ActionAccelerationLigne(Robot r, int accel, int decel)
        {
            _robot = r;
            _accel = accel;
            _decel = decel;
        }

        public override String ToString()
        {
            return _robot.Nom + " accélération ligne à " + _accel + " / " + _decel;
        }

        void IAction.Executer()
        {
            _robot.SpeedConfig.LineAcceleration = _accel;
            _robot.SpeedConfig.LineDeceleration = _decel;
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
