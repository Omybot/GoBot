using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class Accelerator : GameElementZone
    {
        private int _atomsCount;
        private bool _hasInitialAtom;

        public Accelerator(RealPoint position, Color color, int radius) : base(position, color, radius)
        {
            _atomsCount = 0;
            _hasInitialAtom = true;
        }

        public int AtomsCount
        {
            get { return _atomsCount; }
            set { _atomsCount = value; }
        }

        public bool HasInitialAtom
        {
            get { return _hasInitialAtom; }
            set { _hasInitialAtom = value; }
        }
        
        public override string ToString()
        {
            return "Accelerator";
        }
    }
}
