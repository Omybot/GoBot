using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using GoBot.Actionneurs;
using System.Threading;
using Geometry;
using Geometry.Shapes;

namespace GoBot.Movements
{
    class MoveAccelerator : Movement
    {
        private AtomUnloader _unloader;
        
        private Accelerator _accelerator;

        public MoveAccelerator(Accelerator accelerator)
        {
            _accelerator = accelerator;
            
            if (_accelerator.Owner == Plateau.CouleurDroiteViolet)
            {
                Positions.Add(new Position(90, new RealPoint(1290 + 30, Robot.Longueur / 2 + 150)));
                _unloader = Actionneur.AtomUnloaderLeft;
            }
            else
            {
                Positions.Add(new Position(90, new RealPoint(1710 - 30, Robot.Longueur / 2 + 150)));
                _unloader = Actionneur.AtomUnloaderRight;
            }
        }


        public override bool CanExecute => _accelerator.AtomsCount < 10;

        public override int Score => 0;

        public override double Value => IsCorrectColor() ? 1 : 0;

        public override GameElement Element => _accelerator;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _accelerator.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementCore()
        {
            _unloader.DoCalibrationExit();
            _unloader.DoLauncherOutside();
            _unloader.DoLauncherPrepare();


            Robot.Lent();
            Robot.Recallage(SensAR.Arriere);
            Robot.Rapide();

            if (_accelerator.HasInitialAtom)
            {
                _unloader.DoLauncherLaunch();
                Thread.Sleep(500);
                _unloader.DoLauncherPrepare();

                _accelerator.HasInitialAtom = false;
                Plateau.Strategy.GoldFree = true;

                Plateau.Score += 10; // Atome bleu dans l'accélérateur
                Plateau.Score += 10; // Goldenium découvert
            }

            // Deverser les palets stockés

            Robot.Avancer(150);
            _unloader.DoLauncherInside();
            _unloader.DoCalibrationStore();
        }
    }
}
