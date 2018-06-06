﻿using GoBot.GameElements;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoBot.Actionneurs
{
    class Harvester
    {
        private int _cubesOnRight, _cubesOnCenter;

        public enum Arm : byte
        {
            Left,
            Rigth
        }

        public void DoTestSpeed()
        {
            CubesCross cross = new CubesCross(new Geometry.Shapes.RealPoint(), true);

            // 1er cube

            Stopwatch sw = Stopwatch.StartNew();

            Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Bottom, Dumper.Slot.Middle);

            Robots.GrosRobot.Avancer(58, false);

            //Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Left);
            Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Left, Dumper.Slot.Middle);
            Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Center, Dumper.Slot.Middle);
            //Actionneur.Harvester.DoStoreBufferLeft(Dumper.Slot.Middle);
            Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Right, Dumper.Slot.Middle);

            Robots.GrosRobot.Avancer(58, false);

            Actionneur.Harvester.DoTakeCubeInSlot(cross, CubesCross.CubePlace.Top, Dumper.Slot.Middle);
            //Actionneur.Harvester.DoBufferLeft(cross, CubesCross.CubePlace.Top);

            // 2eme cube

            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public void DoTakeCubeOnLeftArm()
        {
            // On approche
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Thread.Sleep(400);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            Thread.Sleep(400);

            // On prend le cube
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionPrise);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            Thread.Sleep(400);

            // On cache le cube dans le bras
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.Minimum);
            Thread.Sleep(400);

            // On remonte
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheHaute);
            Thread.Sleep(400);

            // On retourne
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionStockage);
            Thread.Sleep(400);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionPrise);
            Thread.Sleep(450);

            // On l'approche devant le convoyeur
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheStockage);
            Thread.Sleep(250);

            // On le rentre dans le convoyeur
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionFinStockage);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionFinStockage);
            Thread.Sleep(200);

            // On lache on pousse et on recule
            Actionneur.Harvester.DoLeftPumpDisable();
            Thread.Sleep(200);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheStockage);

        }

        private void SetOnFreeSpace()
        {
            if (_cubesOnCenter < 4)
            {
                Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
                _cubesOnCenter++;
            }
            else
            {
                Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
                _cubesOnRight++;
            }
        }

        public void DoTakeCubeOnRightArm()
        {
            ThreadLink link = ThreadManager.CreateThread(l => Actionneur.Dumper.DoConvoyeurLoopCentre());
            link.StartInfiniteLoop(new TimeSpan(0));

            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);

            Actionneur.Harvester.DoRightPumpEnable();

            // On approche
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Thread.Sleep(500);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Thread.Sleep(800);

            // On prend le cube
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Thread.Sleep(400);

            // On cache le cube dans le bras
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.Maximum);
            Thread.Sleep(400);

            // On remonte
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(400);
            SetOnFreeSpace();
            Thread.Sleep(400);

            // On retourne
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionStockage);
            Thread.Sleep(250);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
            Thread.Sleep(450);

            // On l'approche devant le convoyeur
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheStockage);
            Thread.Sleep(250);

            // On le rentre dans le convoyeur
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionFinStockage);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionFinStockage);
            Thread.Sleep(200);

            // On lache on pousse et on recule
            Actionneur.Harvester.DoRightPumpDisable();
            Thread.Sleep(300);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheStockage);

            link.Cancel();
        }

        public void DoTakeCross()
        {

        }

        public void DoLeftPumpEnable()
        {
            Config.CurrentConfig.MoteurPompeGauche.SendPosition(Config.CurrentConfig.MoteurPompeGauche.PositionAspire);
            Config.CurrentConfig.ValveGauche.SendPosition(Config.CurrentConfig.ValveGauche.PositionFerme);
        }

        public void DoLeftPumpDisable()
        {
            Config.CurrentConfig.MoteurPompeGauche.SendPosition(Config.CurrentConfig.MoteurPompeGauche.PositionStop);
            Config.CurrentConfig.ValveGauche.SendPosition(Config.CurrentConfig.ValveGauche.PositionOuvert);
            ThreadManager.CreateThread(link => Config.CurrentConfig.ValveGauche.SendPosition(Config.CurrentConfig.ValveGauche.PositionFerme)).StartDelayedThread(new TimeSpan(0, 0, 0, 0, 500));
        }

        public void DoRightPumpEnable()
        {
            Config.CurrentConfig.MoteurPompeDroite.SendPosition(Config.CurrentConfig.MoteurPompeDroite.PositionAspire);
            Config.CurrentConfig.ValveDroite.SendPosition(Config.CurrentConfig.ValveDroite.PositionFerme);
        }

        public void DoRightPumpDisable()
        {
            Config.CurrentConfig.MoteurPompeDroite.SendPosition(Config.CurrentConfig.MoteurPompeDroite.PositionStop);
            Config.CurrentConfig.ValveDroite.SendPosition(Config.CurrentConfig.ValveDroite.PositionOuvert);
            ThreadManager.CreateThread(link => Config.CurrentConfig.ValveDroite.SendPosition(Config.CurrentConfig.ValveDroite.PositionFerme)).StartDelayedThread(new TimeSpan(0, 0, 0, 0, 500));
        }

        public void DoStoreArms()
        {
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Thread.Sleep(300);

            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionRange);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionRange);
            Thread.Sleep(500);

            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
            Thread.Sleep(500);

            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionRange);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionRange);
        }

        public void DoInitArms()
        {
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Thread.Sleep(300);
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            Thread.Sleep(300);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionRange);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionRange);
        }

        public void DoArmOnRightCube()
        {
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(300);
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCubeDroite);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Thread.Sleep(800);
        }

        public void DoArmOnLeftCube()
        {
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(200);
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCubeGauche);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Thread.Sleep(700);
        }

        public void DoLeftArmOnLeftCube()
        {
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheHaute);
            Thread.Sleep(200);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCubeGauche);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            Thread.Sleep(700);
        }

        public void DoLeftArmOnCenterCube()
        {
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheHaute);
            Thread.Sleep(200);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            Thread.Sleep(700);
        }

        public void DoArmOnCenterCube()
        {
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(200);
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Thread.Sleep(700);
        }

        public void DoTakeCube(Dumper.Slot slot)
        {
            Actionneur.Harvester.DoRightPumpEnable();

            // On prend le cube
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
            Thread.Sleep(400);
            
            // On cache le cube dans le bras
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.Maximum);
            Thread.Sleep(300);

            // On remonte
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(300);
            switch(slot)
            {
                case Dumper.Slot.Right:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
                    break;
                case Dumper.Slot.Middle:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
                    break;
                case Dumper.Slot.Left:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionGauche);
                    break;
            }
            Thread.Sleep(300);
        }

        public void DoTakeCentralCube()
        {
            Actionneur.Harvester.DoRightPumpEnable();

            // On prend le cube
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
            Thread.Sleep(400);

            // On cache le cube dans le bras
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.Maximum);
            Thread.Sleep(300);

            // On remonte
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(300);
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
            Thread.Sleep(300);
        }

        public void DoStoreCubeRightArm()
        {
            // On retourne
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionStockage);
            Thread.Sleep(250);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
            Thread.Sleep(450);

            // On l'approche devant le convoyeur
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheStockage);
            Thread.Sleep(200);

            // On le rentre dans le convoyeur
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionFinStockage);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionFinStockage);
            Thread.Sleep(200);

            // On lache on pousse et on recule
            Actionneur.Harvester.DoRightPumpDisable();
            Thread.Sleep(200);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheStockage);
        }

        public void DoDemoCube()
        {
            DoTakeCentralCube();
            DoStoreCubeRightArm();
        }

        public void DoStoreCubeLeftArm()
        {
            // On retourne
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionStockage);
            Thread.Sleep(250);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionPrise);
            Thread.Sleep(450);

            // On l'approche devant le convoyeur
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheStockage);
            Thread.Sleep(200);

            // On le rentre dans le convoyeur
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionFinStockage);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionFinStockage);
            Thread.Sleep(200);

            // On lache on pousse et on recule
            Actionneur.Harvester.DoLeftPumpDisable();
            Thread.Sleep(300);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheStockage);
        }

        CubesCross.CubeColor _bufferLeft, _bufferRight;

        public void DoBufferLeft(CubesCross cross, CubesCross.CubePlace place)
        {
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);

            switch(place)
            {
                case CubesCross.CubePlace.Bottom:
                case CubesCross.CubePlace.Center:
                case CubesCross.CubePlace.Top:
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
                    break;
                case CubesCross.CubePlace.Left:
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionGauche);
                    break;
                case CubesCross.CubePlace.Right:
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionDroite);
                    break;
            }
            Thread.Sleep(600);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheHaute);
            Thread.Sleep(200);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            Thread.Sleep(800);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionPrise);
            Actionneur.Harvester.DoLeftPumpEnable();
            Thread.Sleep(500);
            
            // On cache le cube dans le bras
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.Minimum);
            Thread.Sleep(300);

            // On remonte
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheHaute);
            Thread.Sleep(300);

            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);

            _bufferLeft = cross.GetColor(place);
            cross.RemoveCube(place);
        }

        public void DoBufferRight(CubesCross cross, CubesCross.CubePlace place)
        {
            switch (place)
            {
                case CubesCross.CubePlace.Bottom:
                case CubesCross.CubePlace.Center:
                case CubesCross.CubePlace.Top:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
                    break;
                case CubesCross.CubePlace.Left:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionGauche);
                    break;
                case CubesCross.CubePlace.Right:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
                    break;
            }

            Thread.Sleep(600);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(300);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Thread.Sleep(800);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionPrise);
            Actionneur.Harvester.DoRightPumpEnable();
            Thread.Sleep(500);
            
            // On cache le cube dans le bras
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.Maximum);
            Thread.Sleep(300);

            // On remonte
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(500);

            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);

            _bufferRight = cross.GetColor(place);
            cross.RemoveCube(place);
        }

        public void DoBuildWithBufferLeft()
        {
            Actionneur.Dumper.InsertCube(Dumper.Slot.Right, _bufferLeft);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionGauche);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
        }

        public void DoBuildWithBufferRight()
        {
            Actionneur.Dumper.InsertCube(Dumper.Slot.Middle, _bufferRight);
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheBasse);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
        }

        public void DoStoreBufferLeft(Dumper.Slot slot)
        {
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);

            switch (slot)
            {
                case Dumper.Slot.Middle:
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
                    break;
                case Dumper.Slot.Left:
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionGauche);
                    break;
                case Dumper.Slot.Right:
                    Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionDroite);
                    break;
            }

            DoStoreCubeLeftArm();

            ConvoyeurStuff(slot);
            Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

            Thread.Sleep(300);

            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);

            Actionneur.Dumper.AddCube(slot, _bufferLeft);
        }

        public void DoStoreBufferRight(Dumper.Slot slot)
        {
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);

            switch (slot)
            {
                case Dumper.Slot.Middle:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionCentre);
                    break;
                case Dumper.Slot.Left:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionGauche);
                    break;
                case Dumper.Slot.Right:
                    Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
                    break;
            }

            DoStoreCubeRightArm();

            ConvoyeurStuff(slot);
            Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));

            Actionneur.Dumper.AddCube(slot, _bufferRight);
        }

        public void DoTakeCubeInSlot(CubesCross cross, CubesCross.CubePlace place, Dumper.Slot slot)
        {
            switch(place)
            {
                case CubesCross.CubePlace.Bottom:
                case CubesCross.CubePlace.Center:
                case CubesCross.CubePlace.Top:
                    DoTakeCenterCube(slot);
                    break;
                case CubesCross.CubePlace.Left:
                    DoTakeLeftCube(slot);
                    break;
                case CubesCross.CubePlace.Right:
                    DoTakeRightCube(slot);
                    break;
            }

            Actionneur.Dumper.AddCube(slot, cross.GetColor(place));
            cross.RemoveCube(place);
        }

        public void ConvoyeurStuff(Dumper.Slot slot)
        {
            switch(slot)
            {
                case Dumper.Slot.Left:
                    ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopGauche()).StartThread();
                    break;
                case Dumper.Slot.Middle:
                    ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopCentre()).StartThread();
                    break;
                case Dumper.Slot.Right:
                    ThreadManager.CreateThread(link => Actionneur.Dumper.DoConvoyeurLoopDroite()).StartThread();
                    break;
            }
        }

        public void DoTakeCenterCube(Dumper.Slot slot)
        {
            DoArmOnCenterCube();
            DoTakeCube(slot);
            DoStoreCubeRightArm();
            ConvoyeurStuff(slot);
            Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));
        }

        public void DoTakeRightCube(Dumper.Slot slot)
        {
            DoArmOnRightCube();
            DoTakeCube(slot);
            DoStoreCubeRightArm();
            ConvoyeurStuff(slot);
            Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));
        }

        public void DoTakeLeftCube(Dumper.Slot slot)
        {
            DoArmOnLeftCube();
            DoTakeCube(slot);
            DoStoreCubeRightArm();
            ConvoyeurStuff(slot);
            Actionneur.Harvester.DoThreadShaking(new TimeSpan(0, 0, 2));
        }

        public void DoThreadShaking(TimeSpan during)
        {
            ThreadManager.CreateThread(link =>
            {
                Config.CurrentConfig.MoteurShaker.SendPosition(Config.CurrentConfig.MoteurShaker.Maximum);
                Thread.Sleep(during);
                Config.CurrentConfig.MoteurShaker.SendPosition(Config.CurrentConfig.MoteurShaker.Minimum);
            }).StartThread();
        }

        public void DoStopShaking()
        {
            Config.CurrentConfig.MoteurShaker.SendPosition(Config.CurrentConfig.MoteurShaker.Minimum);
        }
    }
}