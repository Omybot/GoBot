﻿using GoBot.GameElements;
using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GoBot.Actionneurs;

namespace GoBot.Actionneurs
{
    class Dumper
    {
        private CubesFilling filling;

        public enum Arm : byte
        {
            Left,
            Rigth
        }

        public enum Slot : byte
        {
            Left,
            Middle,
            Rigth
        }

        public Dumper()
        {
            filling = new CubesFilling();
            filling.LoadCube(CubesCross.CubeColor.Joker, Slot.Left);
            filling.LoadCube(CubesCross.CubeColor.Joker, Slot.Rigth);
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

            color = cross.GetColor(CubesCross.CubePlace.Rigth);
            if (filling.CanLoadInSlot(slot) && color != CubesCross.CubeColor.Empty)
            {
                filling.LoadCube(color, slot);
                cross.RemoveCube(CubesCross.CubePlace.Rigth);
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
                filling[slot].Clear();
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