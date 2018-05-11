using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using System.Threading;
using GoBot.Threading;

namespace GoBot.Movements
{
    class MovementBee : Movement
    {
        private Flower _flower;

        public MovementBee(Flower flower)
        {
            _flower = flower;

            if (flower.Color == Plateau.CouleurGaucheVert)
                Positions.Add(new Geometry.Position(-90, new Geometry.Shapes.RealPoint(250, 1750)));
            else
                Positions.Add(new Geometry.Position(-90, new Geometry.Shapes.RealPoint(3000 - 250, 1750)));
        }

        public override bool CanExecute => _flower.IsAvailable;

        public override int Score => 50;

        public override double Value => Score;

        public override GameElement Element => _flower;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _flower.Color;

        protected override void MovementBegin()
        {
            // Préparer le bras pour pousser l'abeille mais sans géner le déplacement

            Actionneurs.Actionneur.Dumper.DoBackward();
        }

        protected override void MovementCore()
        {
            // Finir d'ouvrir le bras (on est face à l'abeille)

            Robot.Lent();
            Robot.Recallage(SensAR.Arriere);
            Robot.Rapide();
            
            Robot.Avancer(65);

            if (_flower.Color == Plateau.CouleurGaucheVert)
            {
                Robot.PivotDroite(90);
            }
            else
            {
                Robot.PivotGauche(90);
            }

            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheStockage);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheStockage);

            Robot.Lent();
            Robot.Recallage(SensAR.Arriere);
            Robot.Rapide();
            
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);

            Robot.Avancer(90);

            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionRange);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionRange);
            
            if (_flower.Color == Plateau.CouleurGaucheVert)
            {
                Robot.PivotDroite(100);
            }
            else
            {
                Robot.PivotGauche(100);
            }

            if (_flower.Color == Plateau.CouleurGaucheVert)
            {
                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionAbeille);
                Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionAbeille);
            }
            else
            {
                Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionAbeille);
                Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionAbeille);
            }

            Thread.Sleep(300);

            if (_flower.Color == Plateau.CouleurGaucheVert)
            {
                Robot.PivotGauche(10);
            }
            else
            {
                Robot.PivotDroite(10);
            }
            
            if (_flower.Color == Plateau.CouleurGaucheVert)
            {
                Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionGauche);
                Thread.Sleep(600);
            }
            else
            {
                Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
                Thread.Sleep(600);
            }

            Robot.Rapide();

            Robot.Reculer(200);

            ThreadManager.CreateThread(link => Actionneurs.Actionneur.Harvester.DoInitArms()).StartThread();

            if (_flower.Color == Plateau.CouleurGaucheVert) Robot.PivotGauche(90); else Robot.PivotDroite(90);
            Robot.Avancer(100);

            // Pousser l'abeille

            Plateau.Score += Score;

            //Robot.Reculer(150);

            Robot.Rapide();

            _flower.IsAvailable = false;
        }
    }
}
