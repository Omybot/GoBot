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
        public ServoAscenseurDroitBasDroit ServoAscenseurDroitBasDroit { get; set; }
        public ServoAscenseurDroitBasGauche ServoAscenseurDroitBasGauche { get; set; }
        public ServoAscenseurDroitHautDroit ServoAscenseurDroitHautDroit { get; set; }
        public ServoAscenseurDroitHautGauche ServoAscenseurDroitHautGauche { get; set; }
        public ServoAscenseurGaucheBasDroit ServoAscenseurGaucheBasDroit { get; set; }
        public ServoAscenseurGaucheBasGauche ServoAscenseurGaucheBasGauche { get; set; }
        public ServoAscenseurGaucheHautDroit ServoAscenseurGaucheHautDroit { get; set; }
        public ServoAscenseurGaucheHautGauche ServoAscenseurGaucheHautGauche { get; set; }

        public ServoBalleVerrouillageDroit ServoBalleVerrouillageDroit { get; set; }
        public ServoBalleVerrouillageGauche ServoBalleVerrouillageGauche { get; set; }

        public ServoAspirateurCoude ServoAspirateurCoude { get; set; }
        public ServoAspirateurEpaule ServoAspirateurEpaule { get; set; }

        public AscenseurAmpoule AscenseurAmpoule { get; set; }
        public AscenseurDroit AscenseurDroit { get; set; }
        public AscenseurGauche AscenseurGauche { get; set; }

        public ServoTapisBras ServoTapisBras { get; set; }
        public ServoTapisPinceDroite ServoTapisPinceDroite { get; set; }
        public ServoTapisPinceGauche ServoTapisPinceGauche { get; set; }
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
                if (c <= 'Z')
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

    #region PositionnableServo

    #region PincesPieds

    public abstract class ServoAscenseurPince : PositionnableServo
    {
        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
        public int PositionPousse { get; set; }
    }

    public class ServoAscenseurDroitHautDroit : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceHautDroite; } }
    }

    public class ServoAscenseurDroitHautGauche : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceHautGauche; } }
    }

    public class ServoAscenseurDroitBasDroit : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceBasDroite; } }
    }

    public class ServoAscenseurDroitBasGauche : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceBasGauche; } }
    }

    public class ServoAscenseurGaucheHautDroit : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceHautDroite; } }
    }

    public class ServoAscenseurGaucheHautGauche : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceHautGauche; } }
    }

    public class ServoAscenseurGaucheBasDroit : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceBasDroite; } }
    }

    public class ServoAscenseurGaucheBasGauche : ServoAscenseurPince
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceBasGauche; } }
    }

    #endregion

    #region Verrouillage balles

    public class ServoBalleVerrouillageDroit : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.BalleVerouillageDroit; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoBalleVerrouillageGauche : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.BalleVerouillageGauche; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    #endregion

    #region Aspirateur

    public class ServoAspirateurCoude : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AspirateurCoude; } }

        public int PositionRange { get; set; }
        public int PositionAspiration { get; set; }
        public int PositionDepose { get; set; }
    }

    public class ServoAspirateurEpaule : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AspirateurEpaule; } }

        public int PositionRange { get; set; }
        public int PositionAspiration { get; set; }
        public int PositionDepose { get; set; }
    }

    #endregion

    #region Tapis

    public class ServoTapisBras : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.TapisBras; } }

        public int PositionRange { get; set; }
        public int PositionDepose { get; set; }
    }

    public class ServoTapisPinceDroite : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.TapisPinceDroite; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoTapisPinceGauche : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.TapisPinceGauche; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    #endregion

    #endregion

    #region PositionnableMoteur

    public class AscenseurGauche : PositionnableMoteur
    {
        public override MoteurID ID { get { return MoteurID.AscenseurGauche; } }

        public int PositionHaute { get; set; }
        public int PositionAttrapage { get; set; }
        public int PositionSouleve { get; set; }
    }

    public class AscenseurDroit : PositionnableMoteur
    {
        public override MoteurID ID { get { return MoteurID.AscenseurDroit; } }

        public int PositionHaute { get; set; }
        public int PositionAttrapage { get; set; }
        public int PositionSouleve { get; set; }
    }

    public class AscenseurAmpoule : PositionnableMoteur
    {
        public override MoteurID ID { get { return MoteurID.AscenseurAmpoule; } }

        public int PositionHaute { get; set; }
        public int PositionAttrapage { get; set; }
    }

    #endregion
}
