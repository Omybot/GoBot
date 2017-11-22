using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using GoBot.Geometry;

namespace GoBot.Movements
{
    abstract class MovementCubes : Movement
    {
        private CubesCross cubes;

        public MovementCubes(CubesCross cubes)
        {
            this.cubes = cubes;
        }

        public override Color Color
        {
            get
            {
                return Color.White;
            }
        }

        public override GameElement Element
        {
            get
            {
                return cubes;
            }
        }

        public override bool CanExecute
        {
            get
            {
                // TODO tester si il y a de la place dans le stockage
                return Element.IsAvailable;
            }
        }

        public override Robot Robot
        {
            get
            {
                return Robots.GrosRobot;
            }
        }

        public override double Score
        {
            get
            {
                return 0;
            }
        }

        public override double Value
        {
            get
            {
                double value = 1;

                if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 90)
                    value *= 2;
                if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 80)
                    value *= 2;
                if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 70)
                    value *= 2;
                if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 60)
                    value *= 2;
                if (Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 50)
                    value *= 2;

                return value;
            }
        }

        protected override void MovementBegin()
        {
            // TODO Préparer les bras ?
        }

        protected override void MovementCore()
        {
            // TODO avaler la croix
            Element.IsAvailable = false;
        }
    }

    class MovementsCubesFromLeft : MovementCubes
    {
        public MovementsCubesFromLeft(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(90, cubes.Position.Translation(-300, 0)));
        }
    }
    class MovementsCubesFromRigth : MovementCubes
    {
        public MovementsCubesFromRigth(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(90, cubes.Position.Translation(300, 0)));
        }
    }
    class MovementsCubesFromTop : MovementCubes
    {
        public MovementsCubesFromTop(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(90, cubes.Position.Translation(0, -300)));
        }
    }
    class MovementsCubesFromBottom : MovementCubes
    {
        public MovementsCubesFromBottom(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(90, cubes.Position.Translation(0, 300)));
        }
    }
}
