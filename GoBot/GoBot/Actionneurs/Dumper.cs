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
        }

        public void PickupCubes(CubesCross cross, CubesPattern pattern)
        {
            // TODO construction d'une tour
            Slot slot = filling.GetFreeSlot().Value;

            filling.LoadCube(cross.GetColor(CubesCross.CubePlace.Bottom), slot);
            cross.RemoveCube(CubesCross.CubePlace.Bottom);
            Thread.Sleep(500);

            filling.LoadCube(cross.GetColor(CubesCross.CubePlace.Left), slot);
            cross.RemoveCube(CubesCross.CubePlace.Left);
            Thread.Sleep(500);

            filling.LoadCube(cross.GetColor(CubesCross.CubePlace.Rigth), slot);
            cross.RemoveCube(CubesCross.CubePlace.Rigth);
            Thread.Sleep(500);

            filling.LoadCube(cross.GetColor(CubesCross.CubePlace.Top), slot);
            cross.RemoveCube(CubesCross.CubePlace.Top);
            Thread.Sleep(500);
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
                    freeSlot = freeSlot || filling[slot].Count == 0;
                }

                return freeSlot;
            }
        }

        public bool HasFullSlot
        {
            get
            {
                bool fullSlot = false;
                foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
                {
                    fullSlot = fullSlot || filling[slot].Count == 4;
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
                if (filling[slot].Count == 0)
                    freeSlot = slot;
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
    }
}
