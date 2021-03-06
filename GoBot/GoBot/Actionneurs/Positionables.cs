﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace GoBot.Actionneurs
{
    public abstract class Positionable
    {
        private int? _lastPosition;

        public List<String> GetPositionsName()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            List<String> propertiesName = new List<string>();
            foreach (PropertyInfo p in properties)
            {
                if (p.Name.StartsWith("Position"))
                    propertiesName.Add(p.Name);
            }

            return propertiesName;
        }

        public Dictionary<String, int> GetPositions()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            Dictionary<String, int> positions = new Dictionary<String, int>();

            foreach (PropertyInfo p in properties)
            {
                if (p.Name.StartsWith("Position"))
                    positions.Add(p.Name, (int)p.GetValue(this, null));
            }

            return positions;
        }

        public int GetLastPosition()
        {
            return _lastPosition.HasValue ? _lastPosition.Value : (Minimum + Maximum) / 2;
        }

        public void SendPosition(int position)
        {
            _lastPosition = position;
            SendPositionSpecific(position);
        }

        protected abstract void SendPositionSpecific(int position);

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

        protected override void SendPositionSpecific(int position)
        {
            Devices.AllDevices.CanServos[ID].SetPosition(position);
        }

        public void DisableTorque()
        {
            Devices.AllDevices.CanServos[ID].DisableOutput();
        }
    }

    public abstract class PositionableMotorPosition : Positionable
    {
        public abstract MotorID ID { get; }

        protected override void SendPositionSpecific(int position)
        {
            Robots.MainRobot.SetMotorAtPosition(ID, position, true);
        }

        public void Stop(StopMode mode)
        {
            Robots.MainRobot.SetMotorStop(ID, mode);
        }

        public void OriginInit()
        {
            Stop(StopMode.Abrupt);
            Robots.MainRobot.SetMotorAtOrigin(ID, true);
            Robots.MainRobot.SetMotorReset(ID);
            Stop(StopMode.Abrupt);
            Robots.MainRobot.SetMotorAtPosition(ID, 30);
        }
    }

    public abstract class PositionableMotorSpeed : Positionable
    {
        public abstract MotorID ID { get; }

        protected override void SendPositionSpecific(int position)
        {
            Robots.MainRobot.SetMotorSpeed(ID, position > 0 ? SensGD.Gauche : SensGD.Droite, Math.Abs(position));
        }
    }
}
