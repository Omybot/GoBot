using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;
using GoBot.Actionneurs;

namespace GoBot
{
    public partial class Config
    {
        // Exemple
        // public ServoAscenseurDroitBasDroit ServoAscenseurDroitBasDroit { get; set; }

        public ServoPinceLunaireSerrageGauche ServoPinceLunaireSerrageGauche { get; set; }
        public ServoPinceLunaireSerrageDroit ServoPinceLunaireSerrageDroit { get; set; }

        public ServoLunaireAvance ServoLunaireAvance { get; set; }
        public ServoLunaireMonte ServoLunaireMonte { get; set; }
    }
}

namespace GoBot.Actionneurs
{
    public abstract class Positionnable
    {
        public List<String> Positions()
        {
            PropertyInfo[] proprietes = this.GetType().GetProperties();
            List<String> nomProprietes = new List<string>();
            foreach (PropertyInfo p in proprietes)
                nomProprietes.Add(p.Name);

            return nomProprietes;
        }

        public void SetValue(String nom, int valeur)
        {
            this.GetType().GetProperty(nom).SetValue(this, (object)valeur, null);
        }

        public abstract void Positionner(int position);

        public override string ToString()
        {
            String typeName = this.GetType().Name;
            String nom = "";

            foreach (char c in typeName)
            {
                char ch = c;
                if (c <= 'Z' && c >= 'A')
                    nom += " " + (char)(c + 32);
                else
                    nom += c;
            }

            nom = typeName.Substring(0, 1) + nom.Substring(2);

            return nom;
        }

        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }

    public abstract class PositionnableServo : Positionnable
    {
        public abstract ServomoteurID ID { get; }

        public override void Positionner(int position)
        {
            Robots.GrosRobot.BougeServo(ID, position);
        }
    }

    public abstract class PositionnableMoteur : Positionnable
    {
        public abstract MoteurID ID { get; }

        public override void Positionner(int position)
        {
            Robots.GrosRobot.MoteurPosition(ID, position);
        }
    }

    public abstract class PositionnableMoteurVitesse : Positionnable
    {
        public abstract MoteurID ID { get; }

        public override void Positionner(int position)
        {
            Robots.GrosRobot.MoteurVitesse(ID, position);
        }
    }

    #region PositionnableServo

    // Exemple :
    //public abstract class ServoAscenseurPince : PositionnableServo
    //{
    //    public int PositionOuvert { get; set; }
    //    public int PositionFerme { get; set; }
    //    public int PositionPousse { get; set; }
    //}

    //public class ServoAscenseurDroitHautDroit : ServoAscenseurPince
    //{
    //    public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceHautDroite; } }
    //}

    public class ServoLunaireAvance : PositionnableServo
    {
        public int PositionSortie { get; set; }
        public int PositionRange { get; set; }
        public int PositionSemiSortie { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.BrasLunaireAvance; } }
    }

    public class ServoLunaireMonte : PositionnableServo
    {
        public int PositionBas { get; set; }
        public int PositionHaut { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.BrasLunaireMonte; } }
    }

    public abstract class ServoPinceLunaire : PositionnableServo
    {
        public int PositionOuvert { get; set; }
        public int PositionSemiOuvert { get; set; }
        public int PositionFerme { get; set; }
        public int PositionRange { get; set; }
    }

    public class ServoPinceLunaireSerrageGauche : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireSerrageGauche; } }
    }

    public class ServoPinceLunaireSerrageDroit : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireSerrageDroit; } }
    }

    public abstract class ServoMaintien : PositionnableServo
    {
        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
        public int PositionRange { get; set; }
    }

    #endregion

    #region PositionnableMoteur

    public class PompeBarre : PositionnableMoteurVitesse
    {
        public int ValeurAspiration { get; set; }
        public int ValeurMaintien { get; set; }
        public int ValeurStop { get; set; }

        public PompeBarre()
        {
            Minimum = 0;
            Maximum = 4000;
            ValeurMaintien = 1600;
        }

        public override MoteurID ID { get { return MoteurID.PompeBarre; } }
    }

    public class SerrageBrasDroite : PositionnableMoteurVitesse
    {
        public int ValeurFermeture { get; set; }
        public int ValeurStop { get; set; }
        public int ValeurOuverture { get; set; }

        public SerrageBrasDroite()
        {
            Minimum = 0;
            Maximum = 4000;
        }

        public override MoteurID ID { get { return MoteurID.BrasDroite; } }
    }

    public class SerrageBrasGauche : PositionnableMoteurVitesse
    {
        public int ValeurFermeture { get; set; }
        public int ValeurStop { get; set; }
        public int ValeurOuverture { get; set; }

        public SerrageBrasGauche()
        {
            Minimum = 0;
            Maximum = 4000;
        }

        public override MoteurID ID { get { return MoteurID.BrasGauche; } }
    }

    #endregion
}
