using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Ponderations
{
    class PoidsBase : Poids
    {
        public PoidsBase()
        {
            PoidsPetitBougie = new double[20];
            PoidsGrosBougie = new double[20];
            PoidsPetitCadeau = new double[8];
            PoidsGrosCadeau = new double[8];

            PoidGlobalPetitBougie = 0;
            PoidGlobalPetitCadeau = 0;
            PoidGlobalGrosBougie = 1;
            PoidGlobalGrosCadeau = 0;

            // Poids petit robot

            // Bougies
            PoidsPetitBougie[1] = 1;
            PoidsPetitBougie[3] = 1;
            PoidsPetitBougie[5] = 1;
            PoidsPetitBougie[6] = 1;
            PoidsPetitBougie[7] = 10;
            PoidsPetitBougie[9] = 10;
            PoidsPetitBougie[19] = 10;
            PoidsPetitBougie[17] = 10;
            PoidsPetitBougie[16] = 1;
            PoidsPetitBougie[15] = 1;
            PoidsPetitBougie[13] = 1;
            PoidsPetitBougie[11] = 1;

            // Cadeaux
            PoidsPetitCadeau[0] = 1;
            PoidsPetitCadeau[1] = 1;
            PoidsPetitCadeau[2] = 1;
            PoidsPetitCadeau[3] = 1;
            PoidsPetitCadeau[4] = 1;
            PoidsPetitCadeau[5] = 1;
            PoidsPetitCadeau[6] = 1;
            PoidsPetitCadeau[7] = 1;

            // Poids grand robot

            // Bougies
            PoidsGrosBougie[0] = 10000;
            PoidsGrosBougie[1] = 1;
            PoidsGrosBougie[2] = 1;
            PoidsGrosBougie[2] = 1;
            PoidsGrosBougie[3] = 1;
            PoidsGrosBougie[4] = 1;
            PoidsGrosBougie[5] = 1;
            PoidsGrosBougie[6] = 1;
            PoidsGrosBougie[7] = 10;
            PoidsGrosBougie[8] = 10;
            PoidsGrosBougie[9] = 10;
            PoidsGrosBougie[10] = 10;
            PoidsGrosBougie[11] = 1;
            PoidsGrosBougie[12] = 1;
            PoidsGrosBougie[13] = 1;
            PoidsGrosBougie[14] = 1;
            PoidsGrosBougie[15] = 1;
            PoidsGrosBougie[16] = 1;
            PoidsGrosBougie[17] = 1;
            PoidsGrosBougie[18] = 1;
            PoidsGrosBougie[19] = 1;

            // Cadeaux
            PoidsGrosCadeau[0] = 1;
            PoidsGrosCadeau[1] = 1;
            PoidsGrosCadeau[2] = 1;
            PoidsGrosCadeau[3] = 1;
            PoidsGrosCadeau[4] = 1;
            PoidsGrosCadeau[5] = 1;
            PoidsGrosCadeau[6] = 1;
            PoidsGrosCadeau[7] = 1;
        }
    }
}
