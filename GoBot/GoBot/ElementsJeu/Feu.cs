﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GoBot.Calculs;
using GoBot.Calculs.Formes;

namespace GoBot.ElementsJeu
{
    public class Feu : ElementJeu
    {
        public bool Debout { get; set; }
        public Color Couleur { get; set; }
        public Angle Angle { get; set; }

        public Feu(PointReel position, Color couleur, bool debout, Angle angle)
            : base(position)
        {
            Debout = debout;
            Couleur = couleur;
            Angle = angle;
        }
    }
}