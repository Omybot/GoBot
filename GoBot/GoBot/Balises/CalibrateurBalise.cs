using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs;
using System.Threading;

namespace GoBot.Balises
{
    class CalibrateurBalise
    {
        public Balise Balise { get; private set; }

        public CalibrateurBalise(Balise balise)
        {
            Balise = balise;
        }

        public void CalibrationDistance()
        {
            int distanceMin = 500;
            int distanceMax = 2500;
            int intervalle = 100;
            int nbMesuresParPoint = 20;

            MessageBox.Show("Placez le robot à exactement " + distanceMin + "mm de la balise (distance bord balise active <-> centre balise passive)." + Environment.NewLine
            + "Le robot doit pouvoir avancer en ligne droite sur " + (distanceMax - distanceMin) + "mm, et sa ligne de axe doit passer par le centre de la balise active." + Environment.NewLine
            + "Une fois le placement terminé, cliquez sur Ok pour lancer la calibration.");

            int nombreMesures = (distanceMax - distanceMin) / intervalle;
            DetectionBalise[] mesures = new DetectionBalise[nombreMesures];

            for (int i = 0; i < nombreMesures; i++)
            {
                mesures[i] = Balise.MoyennerMesures(nbMesuresParPoint);
                Robots.GrosRobot.Avancer(intervalle);
                Thread.Sleep(1000);
            }
        }
    }
}
