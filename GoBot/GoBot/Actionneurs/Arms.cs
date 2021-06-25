using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class Arms
    {
        protected ArmLeft _leftArm;
        protected ArmRight _rightArm;

        public Arms()
        {
            _leftArm = new ArmLeft();
            _rightArm = new ArmRight();
        }

        public void DoOpenLeft()
        {
            _leftArm.SendPosition(_leftArm.PositionOpen);
        }

        public void DoCloseLeft()
        {
            _leftArm.SendPosition(_leftArm.PositionClose);
        }

        public void DoOpenRight()
        {
            _rightArm.SendPosition(_rightArm.PositionOpen);
        }

        public void DoCloseRight()
        {
            _rightArm.SendPosition(_rightArm.PositionClose);
        }
    }
}
