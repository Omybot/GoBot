﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Ponderations
{
    public abstract class Poids
    {
        public double[] PoidsPetitBougie { get; set; }
        public double[] PoidsGrosBougie { get; set; }
        public double[] PoidsPetitCadeau { get; set; }
        public double[] PoidsGrosCadeau { get; set; }
        public double PoidGlobalPetitBougie { get; set; }
        public double PoidGlobalGrosBougie { get; set; }
        public double PoidGlobalPetitCadeau { get; set; }
        public double PoidGlobalGrosCadeau { get; set; }
    }
}
