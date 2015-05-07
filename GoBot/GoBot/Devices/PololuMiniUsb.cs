using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pololu.Usc;
using Pololu.UsbWrapper;

namespace GoBot.Devices
{
    public static class PololuMiniUsb
    {
        static string serialNumber;
        static bool connected = false;

        static Usc usc;
        static UscSettings settings;

        static PololuMiniUsb()
        {
            List<DeviceListItem> device_list = Usc.getConnectedDevices();
            if (device_list.Count > 0)
            {
                serialNumber = device_list[0].serialNumber;
                usc = new Usc(device_list[0]);
                settings = usc.getUscSettings();

                Console.WriteLine("Pololu connectée");

                List<int> servos = new List<int>();
                servos.Add(1);
                servos.Add(0);
                servos.Add(3);
                servos.Add(2);
                servos.Add(5);
                servos.Add(8);
                servos.Add(6);
                servos.Add(7);


                connected = true;
                for (int i = 0; i < servos.Count; i++)
                {
                    setMin(servos[i], 256);
                    setMax(servos[i], 16320);
                }
            }
            else
            {
                Console.WriteLine("Pololu non connectée");
            }
        }

        public static void setMin(int index, ushort min)
        {
            settings.channelSettings[index].minimum = min;
            if (connected)
                usc.setUscSettings(settings, false);
        }

        public static void setMax(int index, ushort max)
        {
            settings.channelSettings[index].maximum = max;
            if (connected)
                usc.setUscSettings(settings, false);
        }

        public static void setTarget(byte index, ushort position)
        {
            if (connected)
                usc.setTarget(index, position);
        }

        public static void setSpeed(byte index, ushort speed)
        {
            if (connected)
                usc.setSpeed(index, speed);
        }

        public static void setAcceleration(byte index, ushort acceleration)
        {
            if (connected)
                usc.setAcceleration(index, acceleration);
        }
    }
}
