using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using GoBot.Actionneurs;
using Geometry.Shapes;

namespace GoBot.Movements
{
    class MoveAtomGrab : Movement
    {
        LayingAtom _atom;

        public MoveAtomGrab(LayingAtom atom)
        {
            _atom = atom;

            if (_atom.Position.X < 1500)
                Positions.Add(new Geometry.Position(180, new RealPoint(atom.Position.X + 350, atom.Position.Y)));
            else
                Positions.Add(new Geometry.Position(0, new RealPoint(atom.Position.X - 350, atom.Position.Y)));
        }

        public override bool CanExecute => _atom.IsAvailable;

        public override int Score => 0;

        public override double Value => Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 20 && _atom.IsAvailable && Actionneur.AtomStacker.CanStoreMore ? 10 : 0;

        public override GameElement Element => _atom;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _atom.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementCore()
        {
            Actionneur.AtomHandler.DoGrabByDetect();
            _atom.IsAvailable = false;

            if (Actionneur.AtomStacker.AtomsCount < Actionneur.AtomStacker.AtomsCountMax)
            {
                if (_atom.Position.X < 1500)
                    Robot.PivotGauche(45);
                else
                    Robot.PivotDroite(45);

                Actionneur.AtomHandler.DoGrabByDetect();
            }
        }

        protected override void MovementEnd()
        {
        }
    }
}
