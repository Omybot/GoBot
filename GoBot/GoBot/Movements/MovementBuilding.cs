using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using GoBot.Actionneurs;
using GoBot.Geometry;
using System.Threading;

namespace GoBot.Movements
{
    class MovementBuilding : Movement
    {
        private ConstructionZone constructionZone;

        public MovementBuilding(ConstructionZone zone)
        {
            constructionZone = zone;
            
            Positions.Add(new Position(-90, zone.Position.Translation(0, 225)));
        }

        public override bool CanExecute => Actionneur.Dumper.CanBuildTower && constructionZone.TowersCount == 0;

        public override int Score
        {
            get
            {
                int total = 0;

                foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
                {
                    total += new CubesTower(Actionneur.Dumper.GetCubes(slot)).Score;
                }
                return total;
            }
        }

        public override double Value
        {
            get
            {
                if (Color == Plateau.NotreCouleur)
                {
                    double value = Score / 10;

                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 90)
                        value *= 1.5;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 80)
                        value *= 1.5;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 70)
                        value *= 1.5;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 60)
                        value *= 1.5;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 50)
                        value *= 1.5;

                    return value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override GameElement Element => constructionZone;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => constructionZone.Color;

        protected override void MovementBegin()
        {
            // TODO Préparer le déchargement ?
            Robot.Lent();
        }

        protected override void MovementCore()
        {
            // TODO Décharger
            
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionPrise);

            Thread.Sleep(500);

            Actionneur.Harvester.DoLeftPumpDisable();
            Actionneur.Harvester.DoRightPumpDisable();

            Thread.Sleep(500);

            Actionneur.Harvester.DoInitArms();

            Robot.Reculer(100);
            Robot.PivotDroite(180);

            Actionneur.Dumper.DoDeploy();

            Robot.Lent();

            Robot.Reculer(100);
            Actionneur.Dumper.DoLibereTours();
            Thread.Sleep(500);
            Actionneur.Dumper.DoOpenGates();
            Thread.Sleep(500);

            Robot.Avancer(150);

            Actionneur.Dumper.DoStore();
            
            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                if (slot != Dumper.Slot.Left)
                {
                    CubesTower tower = new CubesTower(Actionneur.Dumper.GetCubes(slot));
                    constructionZone.AddTower(tower);
                    Plateau.Score += tower.Score;
                }
            }

            Actionneur.Dumper.Clear();
        }
    }
}
