using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionAccelerationPivot : IAction
    {
        private int _accel;
        private int _decel;
        private Robot _robot;

        public ActionAccelerationPivot(Robot r, int accel, int decel)
        {
            _robot = r;
            _accel = accel;
            _decel = decel;
        }

        public override String ToString()
        {
            return _robot.Name + " accélération pivot à " + _accel + " / " + _decel;
        }

        void IAction.Executer()
        {
            _robot.SpeedConfig.PivotAcceleration = _accel;
            _robot.SpeedConfig.PivotDeceleration = _decel;
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.Speed16;  
            }
        }
    }
}
