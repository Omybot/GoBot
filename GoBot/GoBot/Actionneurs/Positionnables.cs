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
        public ServoLunaireChariot ServoLunaireChariot { get; set; }
        public ServoLunaireMonte ServoLunaireMonte { get; set; }
        public ServoBloqueurBas ServoBloqueurBas { get; set; }
        public ServoBloqueurHaut ServoBloqueurHaut { get; set; }
        public ServoChariot ServoChariot { get; set; }
        public ServoEjecteur ServoEjecteur { get; set; }
        public ServoRehausseur ServoRehausseur { get; set; }
        public MoteurOrientation MoteurOrientation { get; set; }
        public MoteurConvoyeur MoteurConvoyeur { get; set; }

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

    public class ServoLunaireChariot : PositionnableServo
    {
        public int PositionSortie { get; set; }
        public int PositionRange { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.Chariot; } }
    }

    public class ServoLunaireMonte : PositionnableServo
    {
        public int PositionBas { get; set; }
        public int PositionMoyenne { get; set; }
        public int PositionHaut { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.BrasLunaireMonte; } }
    }

    public abstract class ServoPinceLunaire : PositionnableServo
    {
        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
        public int PositionRange { get; set; }
    }

    public class ServoChariot : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.Chariot; } }
        public int PositionRentre { get; set; }
        public int PositionSemiSorti { get; set; }
        public int PositionSorti { get; set; }
    }

    public abstract class ServoMors : PositionnableServo
    {
        public int PositionRentre { get; set; }
        public int PositionSorti { get; set; }
    }

    public abstract class ServoBloqueur : PositionnableServo
    {
        public int PositionRentre { get; set; }
        public int PositionSorti { get; set; }
    }

    public class ServoBloqueurHaut : ServoBloqueur
    {
        public override ServomoteurID ID { get { return ServomoteurID.BloqueurHaut; } }
    }

    public class ServoBloqueurBas : ServoBloqueur
    {
        public override ServomoteurID ID { get { return ServomoteurID.BloqueurBas; } }
    }

    public class ServoRehausseur : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.Rehausseur; } }
        public int PositionRange { get; set; }
        public int PositionBasse { get; set; }
        public int PositionHaute { get; set; }
    }

    public class ServoEjecteur : PositionnableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.Ejecteur; } }
        public int PositionRentre { get; set; }
        public int PositionSorti { get; set; }
    }

    public class ServoPinceLunaireSerrageGauche : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireSerrageGauche; } }
    }

    public class ServoPinceLunaireSerrageDroit : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireSerrageDroit; } }
    }

    #endregion

    #region PositionnableMoteur

    public class MoteurOrientation : PositionnableMoteurVitesse
    {
        public int ValeurTourneGauche { get; set; }
        public int ValeurTourneDroite { get; set; }
        public int ValeurStop { get; set; }

        public override MoteurID ID { get { return MoteurID.Orienteur; } }
    }

    public class MoteurConvoyeur : PositionnableMoteurVitesse
    {
        public int ValeurAvale { get; set; }
        public int ValeurRecrache { get; set; }
        public int ValeurStop { get; set; }

        public override MoteurID ID { get { return MoteurID.Transfert; } }
    }

    #endregion
}
