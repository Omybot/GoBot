using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pololu.Usc;
using Pololu.UsbWrapper;
using GoBot.Communications;
using System.Threading;
using System.Diagnostics;

namespace GoBot.Devices
{
    public static class PololuMiniUart
    {
        public static void setTarget(byte channel, ushort target)
        {
            byte[] serialBytes = new byte[4];
            serialBytes[0] = 0x84; // Command byte: Set Target.
            serialBytes[1] = channel; // First data byte holds channel number.
            serialBytes[2] = (byte)(target & 0x7F); // Second byte holds the lower 7 bits of target.
            serialBytes[3] = (byte)((target >> 7) & 0x7F);   // Third data byte holds the bits 7-13 of target.

            Connexions.ConnexionIO.SendMessage(TrameFactory.EnvoyerUart(Carte.RecIO, new Trame(serialBytes)));
        }

        public static void setSpeed(byte channel, ushort target)
        {
            byte[] serialBytes = new byte[4];
            serialBytes[0] = 0x87; // Command byte: Set Target.
            serialBytes[1] = channel; // First data byte holds channel number.
            serialBytes[2] = (byte)(target & 0x7F); // Second byte holds the lower 7 bits of target.
            serialBytes[3] = (byte)((target >> 7) & 0x7F);   // Third data byte holds the bits 7-13 of target.

            Connexions.ConnexionMove.SendMessage(TrameFactory.EnvoyerUart(Carte.RecMove, new Trame(serialBytes)));
        }

        public static void setAcceleration(byte channel, ushort target)
        {
            byte[] serialBytes = new byte[4];
            serialBytes[0] = 0x89; // Command byte: Set Target.
            serialBytes[1] = channel; // First data byte holds channel number.
            serialBytes[2] = (byte)(target & 0x7F); // Second byte holds the lower 7 bits of target.
            serialBytes[3] = (byte)((target >> 7) & 0x7F);   // Third data byte holds the bits 7-13 of target.

            Connexions.ConnexionMove.SendMessage(TrameFactory.EnvoyerUart(Carte.RecMove, new Trame(serialBytes)));
        }

        public static void setPWM(byte channel, ushort target)
        {
            byte[] serialBytes = new byte[4];
            serialBytes[0] = 0x8A; // Command byte: Set Target.
            serialBytes[1] = channel; // First data byte holds channel number.
            serialBytes[2] = (byte)(target & 0x7F); // Second byte holds the lower 7 bits of target.
            serialBytes[3] = (byte)((target >> 7) & 0x7F);   // Third data byte holds the bits 7-13 of target.

            Connexions.ConnexionMove.SendMessage(TrameFactory.EnvoyerUart(Carte.RecMove, new Trame(serialBytes)));
        }
    }
}
