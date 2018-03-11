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
            
            Positions.Add(new Position(90, zone.Position.Translation(0, 170)));
        }

        public override bool CanExecute => Actionneur.Dumper.CanBuildTower && constructionZone.TowersCount == 0;

        public override double Score
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
                    double value = Score / 100;

                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 90)
                        value *= 2;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 80)
                        value *= 2;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 70)
                        value *= 2;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 60)
                        value *= 2;
                    if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds < 50)
                        value *= 2;

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
        }

        protected override void MovementCore()
        {
            // TODO Décharger

            Robot.Lent();
            Robot.Reculer(50);

            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                CubesTower tower = new CubesTower(Actionneur.Dumper.GetCubes(slot));
                constructionZone.AddTower(tower);
                Plateau.Score += tower.Score;
            }

            Actionneur.Dumper.Clear();

            Thread.Sleep(500);
            Robot.Lent();
            Robot.Avancer(175);
            Robot.Rapide();
        }
    }
}
