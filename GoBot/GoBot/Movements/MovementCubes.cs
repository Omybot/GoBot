using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using GoBot.Geometry;
using GoBot.Actionneurs;
using System.Threading;
using GoBot.Threading;

namespace GoBot.Movements
{
    abstract class MovementCubes : Movement
    {
        private CubesCross cubes;

        private static bool _firstCube = true;

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

        public override int Score
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
                double value = 5;

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

        private CubesCross.CubePlace MyLeft()
        {
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                return CubesCross.CubePlace.Left;
            else
                return CubesCross.CubePlace.Right;
        }

        private CubesCross.CubePlace MyRight()
        {
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                return CubesCross.CubePlace.Right;
            else
                return CubesCross.CubePlace.Left;
        }

        protected override void MovementCore()
        {
            CubesCross cross = (CubesCross)Element;

            Robots.GrosRobot.Avancer(50);


            if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.JVN))
            {
                if (_firstCube)
                {
                    Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Bottom);
                    
                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);

                    Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle);

                    _firstCube = false;
                }
                else
                {
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                    Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Center);

                    Robot.Avancer(58);
                    
                    Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                    Actionneur.Harvester.DoBuildWithBufferLeft();
                    Actionneur.Harvester.DoBuildWithBufferRight();
                }
            }
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.VJB))
            {
                if (_firstCube)
                {
                    _firstCube = false;
                }
                else
                {
                }
            }
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.BVO))
            {
                if (_firstCube)
                {
                    _firstCube = false;
                }
                else
                {
                }
            }

            else
            {
                if (_firstCube)
                {
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                    Robots.GrosRobot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);

                    Robots.GrosRobot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Right);

                    _firstCube = false;
                }
                else
                {
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                    Robots.GrosRobot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);

                    Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
                    Thread.Sleep(500);
                    Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionDroite);

                    Actionneur.Harvester.DoLeftArmOnLeftCube();
                    Config.CurrentConfig.MoteurPompeGauche.SendPosition(Config.CurrentConfig.MoteurPompeGauche.PositionAspire);
                    Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionPrise);
                    Thread.Sleep(600);
                    Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
                    Thread.Sleep(50);
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);
                    Actionneur.Dumper.InsertCube(Dumper.Slot.Right, cross.GetColor(CubesCross.CubePlace.Left));
                    cross.RemoveCube(CubesCross.CubePlace.Left);

                    Robots.GrosRobot.Avancer(58);

                    Actionneur.Harvester.DoArmOnCenterCube();
                    Config.CurrentConfig.MoteurPompeDroite.SendPosition(Config.CurrentConfig.MoteurPompeDroite.PositionAspire);
                    Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
                    Thread.Sleep(600);
                    Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
                    Thread.Sleep(50);
                    Actionneur.Dumper.InsertCube(Dumper.Slot.Middle, cross.GetColor(CubesCross.CubePlace.Top));
                    cross.RemoveCube(CubesCross.CubePlace.Top);

                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
                    Thread.Sleep(100);
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionGauche);
                }
            }

            Element.IsAvailable = false;
        }

        //if (Actionneur.Dumper.CanPickupCubes)
        //{
        //    Actionneur.Dumper.PickupCubes((CubesCross)Element, Actionneur.PatternReader.Pattern);
        //    //Element.IsAvailable = false;
        //}
    }

    class MovementsCubesFromLeft : MovementCubes
    {
        public MovementsCubesFromLeft(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(0, cubes.Position.Translation(-350, 0)));
        }
    }
    class MovementsCubesFromRigth : MovementCubes
    {
        public MovementsCubesFromRigth(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(180, cubes.Position.Translation(350, 0)));
        }
    }
    class MovementsCubesFromTop : MovementCubes
    {
        public MovementsCubesFromTop(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(90, cubes.Position.Translation(0, -350)));
        }
    }
    class MovementsCubesFromBottom : MovementCubes
    {
        public MovementsCubesFromBottom(CubesCross cubes) : base(cubes)
        {
            Positions.Add(new Position(-90, cubes.Position.Translation(0, 350)));
        }
    }
}
