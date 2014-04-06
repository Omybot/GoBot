using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;

namespace GoBot.Balises
{
    /// <summary>
    /// Permet d'effectuer des calculs statistiques sur les données mesurées et émises par une balise
    /// </summary>
    public class BaliseStats
    {
        /// <summary>
        /// Balise concernée
        /// </summary>
        public Balise Balise { get; private set; }

        /// <summary>
        /// Date de réception du premier message de la balise. Permet de calculer le temps moyen par message
        /// </summary>
        private DateTime DatePremierMessage { get; set; }

        /// <summary>
        /// Date du dernier message reçu.
        /// </summary>
        private DateTime DateDernierMessage { get; set; }

        /// <summary>
        /// Temps moyen écoulé entre la réception de deux messages en provenance de la balise
        /// </summary>
        public TimeSpan TempsMoyenInterMessage
        {
            get
            {
                // Retourne le temps passé entre le premier et le dernier message divisé par le nombre de messages recus (-1 pour compter le nombre d'intervalles)
                return new TimeSpan(0, 0, 0, 0, (int)((DateDernierMessage - DatePremierMessage).TotalMilliseconds / (NombreMessagesRecus - 1.0)));
            }
        }

        /// <summary>
        /// Nombre total de messages reçus en provenance de la balise
        /// </summary>
        public int NombreMessagesRecus { get; private set; }

        /// <summary>
        /// Liste des angles médians retournés par la balise depuis la dernière réinitialisation
        /// </summary>
        public List<double> AnglesMesures1 { get; private set; }

        /// <summary>
        /// Liste des angles médians retournés par la balise depuis la dernière réinitialisation
        /// </summary>
        public List<double> AnglesMesures2 { get; private set; }

        /// <summary>
        /// Liste des valeurs PWM envoyées pour asservissement
        /// </summary>
        public List<double> ValeursPWM { get; private set; }

        /// <summary>
        /// Retourne la stabilité en pourcentage de la mesure de l'angle depuis la dernière réinitialisation
        /// </summary>
        public double StabiliteAngle1
        {
            get
            {
                return 100 - 100 * Maths.EcartType(AnglesMesures1) / AnglesMesures1.Average();
            }
        }

        /// <summary>
        /// Retourne la stabilité en pourcentage de la mesure de l'angle depuis la dernière réinitialisation
        /// </summary>
        public double StabiliteAngle2
        {
            get
            {
                return 100 - 100 * Maths.EcartType(AnglesMesures2) / AnglesMesures2.Average();
            }
        }

        /// <summary>
        /// Retourne l'écart type de l'angle en degrés sur l'ensemble des angles mesurés depuis la dernière réinitialisation
        /// </summary>
        public double EcartTypeAngle1
        {
            get
            {
                return Maths.EcartType(AnglesMesures1);
            }
        }

        /// <summary>
        /// Retourne l'écart type de l'angle en degrés sur l'ensemble des angles mesurés depuis la dernière réinitialisation
        /// </summary>
        public double EcartTypeAngle2
        {
            get
            {
                return Maths.EcartType(AnglesMesures2);
            }
        }

        /// <summary>
        /// Liste des distance mesurées par la balise depuis la dernière réinitialisation
        /// </summary>
        public List<double> DistancesMesures1 { get; private set; }

        /// <summary>
        /// Liste des distance mesurées par la balise depuis la dernière réinitialisation
        /// </summary>
        public List<double> DistancesMesures2 { get; private set; }

        /// <summary>
        /// Retourne la stabilité en pourcentage de la mesure de distance depuis la dernière réinitialisation
        /// </summary>
        public double StabiliteDistance1
        {
            get
            {
                return 100 - 100 * Maths.EcartType(DistancesMesures1) / DistancesMesures1.Average();
            }
        }

        /// <summary>
        /// Retourne la stabilité en pourcentage de la mesure de distance depuis la dernière réinitialisation
        /// </summary>
        public double StabiliteDistance2
        {
            get
            {
                return 100 - 100 * Maths.EcartType(DistancesMesures2) / DistancesMesures2.Average();
            }
        }

        /// <summary>
        /// Retourne l'écart type de la distance en millimètres sur l'ensemble des distances mesurées depuis la dernière réinitialisation
        /// </summary>
        public double EcartTypeDistance1
        {
            get
            {
                return Maths.EcartType(DistancesMesures1);
            }
        }

        /// <summary>
        /// Retourne l'écart type de la distance en millimètres sur l'ensemble des distances mesurées depuis la dernière réinitialisation
        /// </summary>
        public double EcartTypeDistance2
        {
            get
            {
                return Maths.EcartType(DistancesMesures2);
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="balise">Balise concernée</param>
        public BaliseStats(Balise balise)
        {
            Balise = balise;
            Balise.PositionsChange += new Balise.PositionsChangeDelegate(Balise_PositionsChange);
            NombreMessagesRecus = 0;
            AnglesMesures1 = new List<double>();
            DistancesMesures1 = new List<double>();
            AnglesMesures2 = new List<double>();
            DistancesMesures2 = new List<double>();
            ValeursPWM = new List<double>();
        }

        /// <summary>
        /// Fonction déclenchée à la réception d'une mesure de la balise
        /// </summary>
        private void Balise_PositionsChange()
        {
            if (NombreMessagesRecus == 0)
                DatePremierMessage = DateTime.Now;

            NombreMessagesRecus++;
            TimeSpan tempsEcoule = DateTime.Now - DateDernierMessage;
            DateDernierMessage = DateTime.Now;

            if (Balise.Detections.Count > 0)
            {
                AnglesMesures1.Add(Balise.Detections[0].AngleCentral);
                DistancesMesures1.Add(Balise.Detections[0].Distance);

                AnglesMesures2.Add(Balise.Detections[1].AngleCentral);
                DistancesMesures2.Add(Balise.Detections[1].Distance);

                ValeursPWM.Add(Balise.ValeurConsigne);

                if (NouvelleDonnee != null)
                    NouvelleDonnee(tempsEcoule, (int)Balise.ValeurConsigne, Balise.Detections[0], Balise.Detections[1]);
            }
        }

        /// <summary>
        /// Réinitialise toutes les valeurs reçues de la balise
        /// </summary>
        public void Reset()
        {
            NombreMessagesRecus = 0;
            AnglesMesures1.Clear();
            DistancesMesures1.Clear();
            AnglesMesures2.Clear();
            DistancesMesures2.Clear();
        }

        //Déclaration du délégué pour l’évènement de nouvelle donnée
        public delegate void NouvelleDonneeDelegate(TimeSpan temps, int pwm, DetectionBalise detection1, DetectionBalise detection2);
        //Déclaration de l’évènement utilisant le délégué
        public event NouvelleDonneeDelegate NouvelleDonnee;
    }
}
