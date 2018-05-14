using GoBot.GameElements;
using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GoBot.Actionneurs;
using GoBot.Threading;

namespace GoBot.Actionneurs
{
    class Dumper
    {
        private CubesFilling filling;
        
        public enum Slot : byte
        {
            Left,
            Middle,
            Right
        }

        public Dumper()
        {
            filling = new CubesFilling();
            filling.LoadCube(CubesCross.CubeColor.Joker, Slot.Middle);
            filling.LoadCube(CubesCross.CubeColor.Joker, Slot.Right);
        }

        public void DoOpenGates()
        {
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionOuvert);
        }

        public void DoCloseGates()
        {
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionFerme);
        }

        public void DoLibereTours()
        {
            Config.CurrentConfig.ServoBenneLiberation.SendPosition(Config.CurrentConfig.ServoBenneLiberation.PositionLiberation);
        }

        public void DoCoupeBenne()
        {
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.Neutre);
        }

        public void DoMaintienTours()
        {
            Config.CurrentConfig.ServoBenneLiberation.SendPosition(Config.CurrentConfig.ServoBenneLiberation.PositionMaintien);
        }

        public void DoDeploy()
        {
            DoForward();

            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.DeplacementDepose);
            Thread.Sleep(2000);
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.PositionDepose);
        }

        public void DoStore()
        {
            Config.CurrentConfig.ServoBenneLiberation.SendPosition(Config.CurrentConfig.ServoBenneLiberation.PositionMaintien);
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionFerme);
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.DeplacementRange);
            Thread.Sleep(2000);
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.PositionRange);
        }

        public void DoForward()
        {
            Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionAvant);
            Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionAvant);
            Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionAvant);
        }

        public void DoBackward()
        {
            Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionArriere);
            Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionArriere);
            Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionArriere);
        }

        public void DoDepose()
        {
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.DeplacementDepose);
            Thread.Sleep(2000);
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.Neutre);
            Robots.GrosRobot.Reculer(100);
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
            Thread.Sleep(500);
            Config.CurrentConfig.ServoBenneLiberation.SendPosition(Config.CurrentConfig.ServoBenneLiberation.PositionLiberation);
            Thread.Sleep(500);
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionOuvert);
            Thread.Sleep(1000);
            Robots.GrosRobot.Avancer(250);
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionFerme);
            Config.CurrentConfig.ServoBenneLiberation.SendPosition(Config.CurrentConfig.ServoBenneLiberation.PositionMaintien);
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.DeplacementRange);
            Thread.Sleep(2000);
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.PositionRange);
        }

        public void DoConvoyeurLoopCentre()
        {
            for (int i = 0; i < 4; i++)
            {
                Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionFerme);
                Thread.Sleep(200);
                Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionAvant);
                Thread.Sleep(400);
                Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
                Thread.Sleep(200);
                Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionArriere);
                Thread.Sleep(400);
            }

            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
            Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionAvant);
        }

        public void DoConvoyeurLoopGauche()
        {
            for (int i = 0; i < 4;  i++)
            {
                Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionFerme);
                Thread.Sleep(200);
                Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionAvant);
                Thread.Sleep(400);
                Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
                Thread.Sleep(200);
                Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionArriere);
                Thread.Sleep(400);
            }

            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
            Config.CurrentConfig.ServoConvoyeurGauche.SendPosition((Config.CurrentConfig.ServoConvoyeurGauche.PositionAvant + Config.CurrentConfig.ServoConvoyeurGauche.PositionArriere) / 2);
        }

        public void DoConvoyeurLoopDroite()
        {
            for (int i = 0; i < 4; i++)
            {
                Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionFerme);
                Thread.Sleep(200);
                Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionAvant);
                Thread.Sleep(400);
                Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
                Thread.Sleep(200);
                Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionArriere);
                Thread.Sleep(400);
            }

            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
            Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionAvant);
        }

        public void PickupCubes(CubesCross cross, CubesPattern pattern)
        {
            // TODO construction d'une tour
            Slot slot = filling.GetFreeSlot().Value;
            CubesCross.CubeColor color;

            color = cross.GetColor(CubesCross.CubePlace.Bottom);
            if(filling.CanLoadInSlot(slot) && color != CubesCross.CubeColor.Empty)
            {
                filling.LoadCube(color, slot);
                cross.RemoveCube(CubesCross.CubePlace.Bottom);
                Thread.Sleep(500);
            }

            color = cross.GetColor(CubesCross.CubePlace.Left);
            if (filling.CanLoadInSlot(slot) && color != CubesCross.CubeColor.Empty)
            {
                filling.LoadCube(color, slot);
                cross.RemoveCube(CubesCross.CubePlace.Left);
                Thread.Sleep(500);
            }

            color = cross.GetColor(CubesCross.CubePlace.Right);
            if (filling.CanLoadInSlot(slot) && color != CubesCross.CubeColor.Empty)
            {
                filling.LoadCube(color, slot);
                cross.RemoveCube(CubesCross.CubePlace.Right);
                Thread.Sleep(500);
            }

            color = cross.GetColor(CubesCross.CubePlace.Top);
            if (filling.CanLoadInSlot(slot) && color != CubesCross.CubeColor.Empty)
            {
                filling.LoadCube(color, slot);
                cross.RemoveCube(CubesCross.CubePlace.Top);
                Thread.Sleep(500);
            }

            color = cross.GetColor(CubesCross.CubePlace.Center);
            if (filling.CanLoadInSlot(slot) && color != CubesCross.CubeColor.Empty)
            {
                filling.LoadCube(color, slot);
                cross.RemoveCube(CubesCross.CubePlace.Center);
                Thread.Sleep(500);
            }
        }

        public void Clear()
        {
            filling.Clear();
        }

        public bool CanPickupCubes
        {
            get
            {
                return filling.HasEmptySlot;
            }
        }

        public bool CanBuildTower
        {
            get
            {
                return filling.HasFullSlot;
            }
        }

        public List<CubesCross.CubeColor> GetCubes(Dumper.Slot slot)
        {
            return filling.GetCubes(slot);
        }

        public void Paint(Graphics g, WorldScale scale, RealPoint robotCenter)
        {
            int offset = 0;
            
            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                CubesCross.PaintCubesInRow(g, filling.GetCubes(slot), robotCenter.Translation(-Robots.GrosRobot.Longueur / 2, -75 + offset), scale, true);
                offset += 75;
            }
        }

        public void AddCube(Slot slot, CubesCross.CubeColor color)
        {
            filling.LoadCube(color, slot);
        }

        public void InsertCube(Slot slot, CubesCross.CubeColor color)
        {
            filling.InsertCube(color, slot);
        }

    }

    class CubesFilling
    {
        private Dictionary<Dumper.Slot, List<CubesCross.CubeColor>> filling;

        public CubesFilling()
        {
            filling = new Dictionary<Dumper.Slot, List<CubesCross.CubeColor>>();

            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                filling.Add(slot, new List<CubesCross.CubeColor>());
            }
        }

        public bool HasEmptySlot
        {
            get
            {
                bool freeSlot = false;
                foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
                {
                    freeSlot = freeSlot || IsFreeSlot(slot);
                }

                return freeSlot;
            }
        }

        public bool IsFreeSlot(Dumper.Slot slot)
        {
            return filling[slot].Count == 0 || (filling[slot].Count == 1 && filling[slot][0] == CubesCross.CubeColor.Joker);
        }

        public bool HasFullSlot
        {
            get
            {
                bool fullSlot = false;
                foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
                {
                    fullSlot = fullSlot || filling[slot].Count >= 4;
                }

                return fullSlot;
            }
        }

        public void Clear()
        {
            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                filling[slot].RemoveRange(0, Math.Min(filling[slot].Count, 5));
            }
        }

        public Dumper.Slot? GetFreeSlot()
        {
            Dumper.Slot? freeSlot = null;

            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                if (IsFreeSlot(slot))
                    freeSlot = slot;
            }

            if(freeSlot == null)
            {
                foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
                {
                    if (filling[slot].Count < 4)
                        freeSlot = slot;
                }
            }

            return freeSlot;
        }

        public void LoadCube(CubesCross.CubeColor cube, Dumper.Slot slot)
        {
            filling[slot].Add(cube);
        }

        public void InsertCube(CubesCross.CubeColor cube, Dumper.Slot slot)
        {
            filling[slot].Insert(0, cube);
        }

        public List<CubesCross.CubeColor> GetCubes(Dumper.Slot slot)
        {
            return filling[slot];
        }

        public bool CanLoadInSlot(Dumper.Slot slot)
        {
            return filling[slot].Count < 4;
        }
    }
}
