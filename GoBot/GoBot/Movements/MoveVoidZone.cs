using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;
using System.Threading;
using static GoBot.Actionneurs.AtomHandler;

namespace GoBot.Movements
{
    public class MoveVoidZone : Movement
    {
        VoidZone _zone;

        public MoveVoidZone(VoidZone zone)
        {
            int distance = 410;
            _zone = zone;

            for(int i = 0; i < 360; i += 45)
            {
                double rad = i / 180.0 * Math.PI;
                Positions.Add(new Position(i + 180, new RealPoint(_zone.Position.X + distance * Math.Cos(rad), _zone.Position.Y + distance * Math.Sin(rad))));
            }
        }

        public override bool CanExecute => _zone.IsAvailable && _zone.AtomsCount > 0 && Actionneur.AtomStacker.CanStoreMore;

        public override int Score => 0;

        public override double Value => Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 25 ? Math.Max(_zone.AtomsCount,  4 - Actionneur.AtomStacker.AtomsCount) * 10 : 1;

        public override GameElement Element => _zone;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _zone.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementCore()
        {
            //Actionneur.GoldGrabberLeft.DoWiperSide();
            //Thread.Sleep(500);

            bool retry = true;
            int fails = 0;
            int maxFails = 5;

            Accelerator accel = Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? Plateau.Elements.AcceleratorViolet : Plateau.Elements.AcceleratorYellow;
            
            while(retry && Actionneur.AtomStacker.CanStoreMore && _zone.AtomsCount > 0 && Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 15)
            {
                GrabResult res = Actionneur.AtomHandler.DoGrabByDetect();
                
                switch (res)
                {
                    case GrabResult.AtomGrabbed:
                        _zone.AtomsCount -= 1;
                        retry = true;
                        break;
                    case GrabResult.AtomTooClose:
                        fails++;
                        if (fails < maxFails)
                        {
                            Robot.Lent();
                            Robots.GrosRobot.Reculer(50);
                            Robot.Rapide();
                            retry = true;
                        }
                        else
                        {
                            retry = false;
                        }
                        break;
                    case GrabResult.GrabFail:
                        fails++;
                        retry = fails < maxFails;
                        break;
                    case GrabResult.NoAtomDetected:
                        retry = false;
                        break;
                }
            }

            if(fails >= maxFails)
                _zone.AtomsCount = 0;

            //Actionneur.GoldGrabberLeft.DoWiperStore();
        }

        protected override void MovementEnd()
        {
        }
    }
}
