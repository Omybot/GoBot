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

        public AscenseurAmpoule AscenseurAmpoule { get; set; }
        public AscenseurDroit AscenseurDroit { get; set; }
        public AscenseurGauche AscenseurGauche { get; set; }
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

    public class ServoAscenseurDroitHautDroit : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceHautDroite; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoAscenseurDroitHautGauche : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceHautGauche; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoAscenseurDroitBasDroit : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceBasDroite; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoAscenseurDroitBasGauche : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceBasGauche; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoAscenseurGaucheHautDroit : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceHautDroite; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoAscenseurGaucheHautGauche : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceHautGauche; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoAscenseurGaucheBasDroit : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceBasDroite; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

    public class ServoAscenseurGaucheBasGauche : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.AscenseurGauchePinceBasGauche; } }

        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
    }

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
