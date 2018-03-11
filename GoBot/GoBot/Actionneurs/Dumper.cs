using GoBot.GameElements;
using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GoBot.Actionneurs.Dumper;
using static GoBot.GameElements.CubesCross;

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

            filling.LoadCube(cross.GetColor(CubePlace.Bottom), slot);
            cross.RemoveCube(CubePlace.Bottom);
            Thread.Sleep(500);

            filling.LoadCube(cross.GetColor(CubePlace.Left), slot);
            cross.RemoveCube(CubePlace.Left);
            Thread.Sleep(500);

            filling.LoadCube(cross.GetColor(CubePlace.Rigth), slot);
            cross.RemoveCube(CubePlace.Rigth);
            Thread.Sleep(500);

            filling.LoadCube(cross.GetColor(CubePlace.Top), slot);
            cross.RemoveCube(CubePlace.Top);
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

        public List<CubeColor> GetCubes(Slot slot)
        {
            return filling.GetCubes(slot);
        }

        public void Paint(Graphics g, WorldScale scale, RealPoint robotCenter)
        {
            int offset = 0;
            
            foreach (Dumper.Slot slot in Enum.GetValues(typeof(Dumper.Slot)))
            {
                CubesCross.PaintCubesInRow(g, filling.GetCubes(slot), robotCenter.Translation(-Robots.GrosRobot.Longueur / 2, -75 + offset), scale);
                offset += 75;
            }
        }
    }

    class CubesFilling
    {
        private Dictionary<Slot, List<CubeColor>> filling;

        public CubesFilling()
        {
            filling = new Dictionary<Slot, List<CubeColor>>();

            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                filling.Add(slot, new List<CubeColor>());
            }
        }

        public bool HasEmptySlot
        {
            get
            {
                bool freeSlot = false;
                foreach (Slot slot in Enum.GetValues(typeof(Slot)))
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
                foreach (Slot slot in Enum.GetValues(typeof(Slot)))
                {
                    fullSlot = fullSlot || filling[slot].Count == 4;
                }

                return fullSlot;
            }
        }

        public void Clear()
        {
            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                filling[slot].Clear();
            }
        }

        public Slot? GetFreeSlot()
        {
            Slot? freeSlot = null;

            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                if (filling[slot].Count == 0)
                    freeSlot = slot;
            }

            return freeSlot;
        }

        public void LoadCube(CubeColor cube, Slot slot)
        {
            filling[slot].Add(cube);
        }

        public List<CubeColor> GetCubes(Slot slot)
        {
            return filling[slot];
        }
    }
}
