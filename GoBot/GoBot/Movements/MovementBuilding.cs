using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using GoBot.Actionneurs;
using static GoBot.GameElements.CubesCross;
using GoBot.Geometry;

namespace GoBot.Movements
{
    class MovementBuilding : Movement
    {
        private ConstructionZone constructionZone;

        public MovementBuilding(ConstructionZone zone)
        {
            constructionZone = zone;

            Positions.Add(new Position(90, zone.Position.Translation(0, 100)));
        }

        public override bool CanExecute => Actionneur.Dumper.CanBuildTower;

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
                return Score;
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

            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                CubesTower tower = new CubesTower(Actionneur.Dumper.GetCubes(slot));
                constructionZone.AddTower(tower);
                Plateau.Score += tower.Score;
            }

            Actionneur.Dumper.Clear();
        }
    }
}
