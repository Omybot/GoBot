using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using GoBot.Actionneurs;
using Geometry.Shapes;
using static GoBot.Actionneurs.AtomHandler;

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

        public override double Value => Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 20 && _atom.IsAvailable && IsCorrectColor() && Actionneur.AtomStacker.CanStoreMore ? 10 : 0;

        public override GameElement Element => _atom;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color
        {
            get
            {
                return _atom.Position.X < 1500 ? Plateau.CouleurGaucheJaune : Plateau.CouleurDroiteViolet;
            }
        }

        protected override void MovementBegin()
        {
        }

        protected override void MovementCore()
        {
            GrabResult res = Actionneur.AtomHandler.DoGrabByDetect();

            if (res == GrabResult.GrabFail)
                res = Actionneur.AtomHandler.DoGrabByDetect();
            else if (res == GrabResult.AtomTooClose)
            {
                Robot.Reculer(50);
                res = Actionneur.AtomHandler.DoGrabByDetect();
            }

            _atom.IsAvailable = false;

            if (Actionneur.AtomStacker.CanStoreMore && Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 15)
            {
                if (_atom.Position.X < 1500)
                    Robot.PivotGauche(45);
                else
                    Robot.PivotDroite(45);

                res = Actionneur.AtomHandler.DoGrabByDetect();

                if (res == GrabResult.GrabFail)
                    res = Actionneur.AtomHandler.DoGrabByDetect();
                else if (res == GrabResult.AtomTooClose)
                {
                    Robot.Reculer(50);
                    res = Actionneur.AtomHandler.DoGrabByDetect();
                }
            }
        }

        protected override void MovementEnd()
        {
        }
    }
}
