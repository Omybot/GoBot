using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;

namespace GoBot.Balises
{
    public class BaliseStats
    {
        public Balise Balise { get; private set; }

        private DateTime DatePremierMessage { get; set; }
        private DateTime DateDernierMessage { get; set; }

        public TimeSpan TempsMoyenInterMessage 
        {
            get
            {
                // Retourne le temps passé entre le premier et le dernier message divisé par le nombre de messages recus (-1 pour compter le nombre d'intervalles)
                return new TimeSpan(0, 0, 0, 0, (int)((DateDernierMessage - DatePremierMessage).TotalMilliseconds / (NombreMessagesRecus - 1.0)));
            }
        }

        public int NombreMessagesRecus { get; private set; }

        public List<double> AnglesMesures { get; private set; }
        public double StabiliteAngle
        {
            get
            {
                return 100 - 100 * Maths.EcartType(AnglesMesures) / AnglesMesures.Average();
            }
        }
        public double EcartTypeAngle
        {
            get
            {
                return  Maths.EcartType(AnglesMesures);
            }
        }

        public List<double> DistancesMesures { get; private set; }
        public double StabiliteDistance
        {
            get
            {
                return 100 - 100 * Maths.EcartType(DistancesMesures) / DistancesMesures.Average();
            }
        }
        public double EcartTypeDistance
        {
            get
            {
                return Maths.EcartType(DistancesMesures);
            }
        }

        public BaliseStats(Balise balise)
        {
            Balise = balise;
            Balise.PositionsChange += new Balise.PositionsChangeDelegate(Balise_PositionsChange);
            NombreMessagesRecus = 0;
            AnglesMesures = new List<double>();
            DistancesMesures = new List<double>();
        }

        void Balise_PositionsChange()
        {
            if (NombreMessagesRecus == 0)
                DatePremierMessage = DateTime.Now;

            NombreMessagesRecus++;
            TimeSpan tempsEcoule = DateTime.Now - DateDernierMessage;
            DateDernierMessage = DateTime.Now;

            AnglesMesures.Add(Balise.Detections[0].AngleCentral);
            DistancesMesures.Add(Balise.Detections[0].Distance);

            if (NouvelleDonnee != null)
                NouvelleDonnee(tempsEcoule, Balise.Detections[0]);
        }

        public void Reset()
        {
            NombreMessagesRecus = 0;
            AnglesMesures.Clear();
            DistancesMesures.Clear();
        }

        //Déclaration du délégué pour l’évènement de nouvelle donnée
        public delegate void NouvelleDonneeDelegate(TimeSpan temps, DetectionBalise detection);
        //Déclaration de l’évènement utilisant le délégué
        public event NouvelleDonneeDelegate NouvelleDonnee;
    }
}
