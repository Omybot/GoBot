﻿using System;
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

        protected override void MovementCore()
        {
            CubesCross cross = (CubesCross)Element;

            Robots.GrosRobot.Avancer(50);

            if (_firstCube)
            {
                Actionneur.Harvester.DoTakeCenterCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopCentre()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Middle, cross.GetColor(CubesCross.CubePlace.Bottom));
                cross.RemoveCube(CubesCross.CubePlace.Bottom);

                Robots.GrosRobot.Avancer(58);

                Actionneur.Harvester.DoTakeCenterCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopCentre()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Middle, cross.GetColor(CubesCross.CubePlace.Center));
                cross.RemoveCube(CubesCross.CubePlace.Center);

                Actionneur.Harvester.DoTakeRightCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopCentre()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Middle, cross.GetColor(CubesCross.CubePlace.Rigth));
                cross.RemoveCube(CubesCross.CubePlace.Rigth);

                Actionneur.Harvester.DoTakeLeftCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopCentre()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Middle, cross.GetColor(CubesCross.CubePlace.Left));
                cross.RemoveCube(CubesCross.CubePlace.Left);

                Robots.GrosRobot.Avancer(58);
                Actionneur.Harvester.DoTakeCenterCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Rigth, cross.GetColor(CubesCross.CubePlace.Top));
                cross.RemoveCube(CubesCross.CubePlace.Top);

                _firstCube = false;
            }
            else
            {
                Actionneur.Harvester.DoTakeCenterCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Rigth, cross.GetColor(CubesCross.CubePlace.Bottom));
                cross.RemoveCube(CubesCross.CubePlace.Bottom);

                Robots.GrosRobot.Avancer(58);

                Actionneur.Harvester.DoTakeCenterCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Rigth, cross.GetColor(CubesCross.CubePlace.Center));
                cross.RemoveCube(CubesCross.CubePlace.Center);

                Actionneur.Harvester.DoTakeRightCube();
                ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                Actionneur.Dumper.AddCube(Dumper.Slot.Rigth, cross.GetColor(CubesCross.CubePlace.Rigth));
                cross.RemoveCube(CubesCross.CubePlace.Rigth);

                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
                Thread.Sleep(500);
                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionDroite);

                Actionneur.Harvester.DoLeftArmOnLeftCube();
                Config.CurrentConfig.MoteurPompeGauche.SendPosition(Config.CurrentConfig.MoteurPompeGauche.PositionAspire);
                Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionPrise);
                Thread.Sleep(500);
                Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
                Thread.Sleep(50);
                Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);
                Actionneur.Dumper.InsertCube(Dumper.Slot.Rigth, cross.GetColor(CubesCross.CubePlace.Left));
                cross.RemoveCube(CubesCross.CubePlace.Left);

                Robots.GrosRobot.Avancer(58);

                Actionneur.Harvester.DoArmOnCenterCube();
                Config.CurrentConfig.MoteurPompeDroite.SendPosition(Config.CurrentConfig.MoteurPompeDroite.PositionAspire);
                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
                Thread.Sleep(500);
                Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
                Thread.Sleep(50);
                Actionneur.Dumper.InsertCube(Dumper.Slot.Middle, cross.GetColor(CubesCross.CubePlace.Top));
                cross.RemoveCube(CubesCross.CubePlace.Top);

                Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
                Thread.Sleep(100);
                Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionGauche);
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
