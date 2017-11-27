﻿using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GoBot.GameElements
{
    public class CubesTower : GameElement
    {
        private List<CubesCross.CubeColor> cubes;

        public CubesTower(RealPoint position) : base(position, Color.White, 0)
        {
            cubes = new List<CubesCross.CubeColor>();
        }

        public void AddCube(CubesCross.CubeColor cube)
        {
            cubes.Add(cube);
        }

        public override bool ClickAction()
        {
            // Rien ?
            return true;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Point topLeft = scale.RealToScreenPosition(new RealPoint(position.X - CubesCross.KCubeSize * 0.5, position.Y - CubesCross.KCubeSize * 0.5));
            Size size = new Size(scale.RealToScreenDistance(CubesCross.KCubeSize), scale.RealToScreenDistance(CubesCross.KCubeSize));
            Point cubePosition = topLeft;

            for (int iCube = 0; iCube < cubes.Count; iCube++)
            {
                CubesCross.PaintCube(g, cubes[iCube], cubePosition, size, Color.Black);
                cubePosition.Y -= size.Height;
            }

            // TODO aller chercher le bon pattern
            CubesPattern pattern = new CubesPattern(CubesCross.CubeColor.Green, CubesCross.CubeColor.Yellow, CubesCross.CubeColor.Orange);

            int patternIndex = pattern.PatternPosition(cubes);

            if(patternIndex != -1)
            {
                using (Pen pen = new Pen(Color.Lime))
                {
                    Rectangle rct = new Rectangle(topLeft.X + 1, topLeft.Y - (patternIndex + 2) * size.Height + 1, size.Width - 2, size.Height * 3 - 2);
                    g.DrawRectangle(pen, rct);
                    g.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Lime, Color.Transparent), rct);
                }
            }
        }
    }
}
