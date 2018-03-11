using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using GoBot.Geometry;
using GoBot.Actionneurs;

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
                return cubes.IsAvailable && Actionneur.Dumper.CanPickupCubes;
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

                if (cubes.CubesCount < 5)
                    value /= 10;
                if (cubes.CubesCount < 4)
                    value /= 2;
                if (cubes.CubesCount < 3)
                    value /= 2;
                if (cubes.CubesCount < 2)
                    value /= 2;
                if (cubes.CubesCount < 1)
                    value = 0;

                return value;
            }
        }

        protected override void MovementBegin()
        {
            // TODO Préparer les bras ?
        }

        protected override void MovementCore()
        {
            if (Actionneur.Dumper.CanPickupCubes)
            {
                Actionneur.Dumper.PickupCubes((CubesCross)Element, Actionneur.PatternReader.Pattern);
                //Element.IsAvailable = false;
            }
            //Element.IsAvailable = false;
        }
    }

    class MovementsCubesFromLeft : MovementCubes
    {
        public MovementsCubesFromLeft(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(0, cubes.Position.Translation(-300, 0)));
        }
    }
    class MovementsCubesFromRigth : MovementCubes
    {
        public MovementsCubesFromRigth(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(180, cubes.Position.Translation(300, 0)));
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
            Positions.Add(new Position(-90, cubes.Position.Translation(0, 300)));
        }
    }
}
