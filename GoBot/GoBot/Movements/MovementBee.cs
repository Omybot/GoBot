using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using System.Threading;

namespace GoBot.Movements
{
    class MovementBee : Movement
    {
        private Flower _flower;

        public MovementBee(Flower flower)
        {
            _flower = flower;

            if (flower.Color == Plateau.CouleurGaucheVert)
                Positions.Add(new Geometry.Position(90, new Geometry.Shapes.RealPoint(250, 1750)));
            else
                Positions.Add(new Geometry.Position(90, new Geometry.Shapes.RealPoint(3000 - 250, 1750)));
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

        }

        protected override void MovementCore()
        {
            // Finir d'ouvrir le bras (on est face à l'abeille)

            Robot.PivotDroite(180);
            Robot.Reculer(60);
            Robot.Lent();

            Robot.Recallage(SensAR.Arriere);

            Robot.Rapide();
            Robot.Avancer(100);
            Robot.PivotDroite(180);

            if (_flower.Color == Plateau.CouleurGaucheVert)
            {

                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
                Thread.Sleep(500);
                Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
            }
            else
            {
                Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheHaute);
                Thread.Sleep(500);
                Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);
                
                Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
                Thread.Sleep(500);
            }

            if (_flower.Color == Plateau.CouleurGaucheVert) Robot.PivotDroite(45); else Robot.PivotGauche(45);
            Robot.Avancer(50);
            if (_flower.Color == Plateau.CouleurGaucheVert) Robot.PivotGauche(45); else Robot.PivotDroite(45);
            
            if (_flower.Color == Plateau.CouleurGaucheVert)
            {
                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
                Config.CurrentConfig.ServoPoignetDroite.SendPosition((Config.CurrentConfig.ServoPoignetDroite.Minimum + Config.CurrentConfig.ServoPoignetDroite.Maximum) / 2);
                Thread.Sleep(400);

                Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionGauche);
                Thread.Sleep(600);

                Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionRange);
            }
            else
            {
                Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
                Config.CurrentConfig.ServoPoignetGauche.SendPosition((Config.CurrentConfig.ServoPoignetGauche.Minimum + Config.CurrentConfig.ServoPoignetGauche.Maximum) / 2);
                Thread.Sleep(400);

                Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
                Thread.Sleep(600);

                Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
                Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionRange);
            }

            Robot.Rapide();

            Robot.Reculer(200);
            if (_flower.Color == Plateau.CouleurGaucheVert) Robot.PivotGauche(90); else Robot.PivotDroite(90);
            Robot.Avancer(100);

            Actionneurs.Actionneur.Harvester.DoInitArms();

            // Pousser l'abeille

            Plateau.Score += Score;

            //Robot.Reculer(150);

            Robot.Rapide();

            _flower.IsAvailable = false;
        }
    }
}
