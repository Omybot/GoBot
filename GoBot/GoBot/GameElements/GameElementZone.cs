﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry.Shapes;
using System.Drawing;
using Geometry;

namespace GoBot.GameElements
{
    public class GameElementZone : GameElement
    {
        /// <summary>
        /// Construit une zone de jeu à partir de sa position et de son rayon
        /// </summary>
        /// <param name="position">Position du centre de la zone de jeu</param>
        /// <param name="color">Couleur d'appartenance de la zone</param>
        /// <param name="radius">Rayon de la zone</param>
        public GameElementZone(RealPoint position, Color color, int radius) 
            : base(position, color, radius)
        {
            IsHover = false;
            Owner = color;
        }
        
        /// <summary>
        /// Peint l'élément sur le Graphic donné à l'échelle donnée
        /// </summary>
        /// <param name="g">Graphic sur lequel peindre</param>
        /// <param name="scale">Echelle de peinture</param>
        public override void Paint(Graphics g, WorldScale scale)
        {
            Pen pBlack = new Pen(Color.Black);
            Pen pWhite = new Pen(Color.White);
            Pen pWhiteBold = new Pen(Color.White);

            pWhite.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pWhiteBold.Width = 3;

            Rectangle rect = new Rectangle(scale.RealToScreenPosition(Position.Translation(-HoverRadius, -HoverRadius)), scale.RealToScreenSize(new SizeF(HoverRadius * 2, HoverRadius * 2)));

            if (IsHover)
            {
                g.DrawEllipse(pWhiteBold, rect);
            }
            else
            {
                //g.DrawEllipse(pBlack, rect);
                //g.DrawEllipse(pWhite, rect);
            }

            pBlack.Dispose();
            pWhite.Dispose();
            pWhiteBold.Dispose();
        }

        public bool Contains(RealPoint p)
        {
            return new Circle(_position, _hoverRadius).Contains(p);
        }
    }
}
