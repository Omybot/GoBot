using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Ponderations
{
    class PoidsTest : Poids
    {
        public PoidsTest()
        {
            PoidsPetitBougie = new double[20];
            PoidsGrosBougie = new double[20];
            PoidsPetitCadeau = new double[8];
            PoidsGrosCadeau = new double[8];
            PoidsGrosAssiette = new double[10];

            /* À savoir :
            
            - Tant qu'on a une assiette accrochée, la priorité d'accrochage est à 0
            - Tant qu'on a pas de balles à lancer, la priorité de lancement est à 0
            - Tant qu'on a pas de balles à lancer, la priorité d'accrochage est à 0
            
            - Si il reste moins de 30 secondes de match et que le robot contient des cerises, la priorité de lancement est x10
            - Si il reste moins de 30 secondes de match l'aspiration de balles est /10
            - Si il reste moins de 18 secondes de match l'aspiration de balles est /1000
            - Si il reste moins de 30 secondes de match, l'accochage d'assiette est réduit à 0
             
             */

            PoidGlobalPetitBougie = 0;
            PoidGlobalPetitCadeau = 0;

            PoidGlobalGrosBougie = 0;
            PoidGlobalGrosCadeau = 1;
            PoidGlobalGrosAspireAssiette = 0;
            PoidGlobalGrosAccrocheAssiette = 0;
            // Poids de l'aspiration de l'assiette accrochée si aucune balle n'est chargée
            PoidGlobalGrosAspireAssietteAccrochee = 10000;
            // Poids du lancage de balles si aucune assiette n'est accrochée
            PoidGlobalGrosLancerBallesSansAssietteAccrochee = 150;
            // Poids du lancage de balles si une assiette est accrochée
            PoidGlobalGrosLancerBallesAvecAssietteAccrochee = 10000;

            // Poids petit robot

            // Bougies
            PoidsPetitBougie[1] = 1;
            PoidsPetitBougie[3] = 1;
            PoidsPetitBougie[5] = 1;
            PoidsPetitBougie[6] = 1;
            PoidsPetitBougie[7] = 1;
            PoidsPetitBougie[9] = 1;
            PoidsPetitBougie[19] = 1;
            PoidsPetitBougie[17] = 1;
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
            PoidsGrosBougie[0] = 2;
            PoidsGrosBougie[1] = 1;
            PoidsGrosBougie[2] = 1;
            PoidsGrosBougie[2] = 1;
            PoidsGrosBougie[3] = 1;
            PoidsGrosBougie[4] = 1;
            PoidsGrosBougie[5] = 1;
            PoidsGrosBougie[6] = 1;
            PoidsGrosBougie[7] = 1;
            PoidsGrosBougie[8] = 1;
            PoidsGrosBougie[9] = 1;
            PoidsGrosBougie[10] = 2;
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
            PoidsGrosCadeau[1] = 4;
            PoidsGrosCadeau[2] = 1;
            PoidsGrosCadeau[3] = 8;
            PoidsGrosCadeau[4] = 1;
            PoidsGrosCadeau[5] = 12;
            PoidsGrosCadeau[6] = 1;
            PoidsGrosCadeau[7] = 16;

            // Assiettes
            PoidsGrosAssiette[0] = 1;
            PoidsGrosAssiette[1] = 1;
            PoidsGrosAssiette[2] = 1;
            PoidsGrosAssiette[3] = 1;
            PoidsGrosAssiette[4] = 1;
            PoidsGrosAssiette[5] = 1;
            PoidsGrosAssiette[6] = 1;
            PoidsGrosAssiette[7] = 1;
            PoidsGrosAssiette[8] = 1;
            PoidsGrosAssiette[9] = 1;
        }
    }
}
