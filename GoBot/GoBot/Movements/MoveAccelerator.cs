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
        private ServoCalibration _servoCalibration;
        private ServoExitLauncher _servoExitLauncher;
        private ServoLauncher _servoLauncher;
        
        private Accelerator _accelerator;

        public MoveAccelerator(Accelerator accelerator)
        {
            _accelerator = accelerator;
            
            if (_accelerator.Owner == Plateau.CouleurDroiteViolet)
            {
                Positions.Add(new Position(90, new RealPoint(1290 + 30, Robot.Longueur / 2 + 150)));
                _servoCalibration = Config.CurrentConfig.ServoCalibrationLeft;
                _servoExitLauncher = Config.CurrentConfig.ServoExitLauncherLeft;
                _servoLauncher = Config.CurrentConfig.ServoLauncherLeft;
            }
            else
            {
                Positions.Add(new Position(90, new RealPoint(1710 - 30, Robot.Longueur / 2 + 150)));
                _servoCalibration = Config.CurrentConfig.ServoCalibrationRight;
                _servoExitLauncher = Config.CurrentConfig.ServoExitLauncherRight;
                _servoLauncher = Config.CurrentConfig.ServoLauncherRight;
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
            _servoCalibration.SendPosition(_servoCalibration.PositionCalibration);
            _servoExitLauncher.SendPosition(_servoExitLauncher.PositionOutside);
            _servoLauncher.SendPosition(_servoLauncher.PositionStored);

            Robot.Lent();
            Robot.Recallage(SensAR.Arriere);
            Robot.Rapide();

            if (_accelerator.HasInitialAtom)
            {
                _servoLauncher.SendPosition(_servoLauncher.PositionLaunch);
                Thread.Sleep(500);
                _servoLauncher.SendPosition(_servoLauncher.PositionStored);
                _accelerator.HasInitialAtom = false;
                Plateau.Strategy.GoldFree = true;

                Plateau.Score += 10; // Atome bleu dans l'accélérateur
                Plateau.Score += 10; // Goldenium découvert
            }

            // Deverser les palets stockés

            Robot.Avancer(150);
            _servoExitLauncher.SendPosition(_servoExitLauncher.PositionInside);
            _servoCalibration.SendPosition(_servoCalibration.PositionStored);
        }
    }
}
