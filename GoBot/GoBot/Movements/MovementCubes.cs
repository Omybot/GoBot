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
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                {
                    if (_firstCube)
                    {
                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Bottom);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);

                        Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle);

                        _firstCube = false;
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Center);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
                else
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

                        ThreadManager.CreateThread(link => Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle)).StartThread();

                        _firstCube = false;
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Center);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
            } // Vert
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.JNB))
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                {
                    if (_firstCube)
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Center);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle);

                        _firstCube = false;
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Center);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
                else
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Bottom);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);

                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
            } // Vert et orange
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.ONV))
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                {
                    if (_firstCube)
                    {
                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Bottom);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);

                        Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);

                        _firstCube = false;
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoBufferLeft(cross, MyLeft());
                        Actionneur.Harvester.DoBufferRight(cross, MyRight());

                        ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                        Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

                        Robot.Lent();
                        Robot.PivotGauche(45);
                        Robot.Avancer(300);
                        Robot.PivotDroite(45);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
                else
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Bottom);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Right);
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);
                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Left);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Right);

                        ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                        Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

                        Robot.Lent();
                        Robot.PivotGauche(45);
                        Robot.Avancer(300);
                        Robot.PivotDroite(45);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
            } // Vert et orange
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.NJO))
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                {
                    if (_firstCube)
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Left);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Left);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Right);

                        _firstCube = false;
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Middle);

                        ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopCentre()).StartThread();
                        Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
                else
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Bottom);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);
                        Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
                        Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
                        Thread.Sleep(600);
                        Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle);

                        ThreadManager.CreateThread(link => Actionneur.Harvester.DoInitArms());
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Left);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
            } // Vert et orange
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.BON))
            {
                if (_firstCube)
                {
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Middle);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                    _firstCube = false;
                }
                else
                {
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Top);

                    Actionneur.Harvester.DoBuildWithBufferLeft();
                    Actionneur.Harvester.DoBuildWithBufferRight();
                }
            } // Vert et orange
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.BVO))
            {
                if (_firstCube)
                {
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                    _firstCube = false;
                }
                else
                {
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Top);

                    Actionneur.Harvester.DoBuildWithBufferLeft();
                    Actionneur.Harvester.DoBuildWithBufferRight();
                }
            } // Vert et orange à tester
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.OBJ))
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Left);

                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
                else
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Center);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();

                    }
                }
            } // Vert et orange
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.VJB))
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Left);

                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Right);

                        Robot.Avancer(58);

                        ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                        Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
                else
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Top);

                        ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                        Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
            } // Vert et orange
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.NBV))
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Right);

                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }
                }
                else
                {
                    if (_firstCube)
                    {
                        _firstCube = false;

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Right);
                    }
                    else
                    {
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Right);

                        Robot.Avancer(58);

                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Right);
                        Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);
                        Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Left);
                        
                        Robot.Avancer(58);

                        Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

                        Actionneur.Harvester.DoBuildWithBufferLeft();
                        Actionneur.Harvester.DoBuildWithBufferRight();
                    }

                }
            } // Vert
            else if (Actionneur.PatternReader.Pattern.IsSame(PatternReader.VOJ))
            {
                // Orange à tester
                if (_firstCube)
                {
                    _firstCube = false;

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Left);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Middle);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);
                }
                else
                {
                    Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Bottom);

                    Robot.Avancer(58);

                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyLeft(), Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, MyRight(), Dumper.Slot.Right);
                    Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Right);

                    Robot.Avancer(58);

                    ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                    Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

                    Actionneur.Harvester.DoBufferRight(cross, CubesCross.CubePlace.Top);

                    Actionneur.Harvester.DoBuildWithBufferLeft();
                    Actionneur.Harvester.DoBuildWithBufferRight();
                }
            } // Vert et orange à tester
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
