using System;
using System.Collections.Generic;
using System.Reflection;

namespace GoBot.Actionneurs
{
    public abstract class Positionable
    {
        public List<String> PositionsName()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            List<String> propertiesName = new List<string>();
            foreach (PropertyInfo p in properties)
                propertiesName.Add(p.Name);

            return propertiesName;
        }

        public abstract void SendPosition(int position);

        public override string ToString()
        {
            String typeName = this.GetType().Name;
            String name = "";

            foreach (char c in typeName)
            {
                char ch = c;
                if (c <= 'Z' && c >= 'A')
                    name += " " + (char)(c + 32);
                else
                    name += c;
            }

            name = typeName.Substring(0, 1) + name.Substring(2);

            return name;
        }

        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }

    public abstract class PositionableServo : Positionable
    {
        public abstract ServomoteurID ID { get; }

        public override void SendPosition(int position)
        {
            Robots.GrosRobot.BougeServo(ID, position);
        }
    }

    public abstract class PositionableMotorPosition : Positionable
    {
        public abstract MoteurID ID { get; }

        public override void SendPosition(int position)
        {
            Robots.GrosRobot.MoteurPosition(ID, position);
        }
    }

    public abstract class PositionableMotorSpeed : Positionable
    {
        public abstract MoteurID ID { get; }

        public override void SendPosition(int position)
        {
            Robots.GrosRobot.MoteurVitesse(ID, position > 0 ? SensGD.Gauche : SensGD.Droite, Math.Abs(position));
        }
    }
}
