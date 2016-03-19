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

        public Servo2 Servo2 { get; set; }
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

    public class Servo2 : PositionnableServo
    {
            public override ServomoteurID ID { get { return ServomoteurID.Libre3; } }
    }
    #endregion

    #region PositionnableMoteur


    #endregion
}
