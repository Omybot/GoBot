using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GoBot.Devices
{
    class HokuyoUsb : Hokuyo
    {
        private SerialPort port;
        private String trameMesure, trameDetails;
        
        public HokuyoUsb(String portCom, LidarID id) : base(id)
        {
            port = new SerialPort(portCom, 115200);
            port.Open();
            trameMesure = "MS0000" + nbPoints.ToString("0000") + "00001";

            //trameDetails = "VV\n00P\n";
            //port.WriteLine(trameDetails);
            //String reponse = GetResultat();

            //Console.WriteLine(reponse);

            //if (reponse.Contains("UBG-04LX-F01")) //Hokuyo bleu
            //{
            //    nbPoints = 725;
            //    angleMesurable = new Angle(240, AnglyeType.Degre);
            //    offsetPoints = 44;
            //}
            //else if (reponse.Contains("URG-04LX-UG01")) //Petit Hokuyo
            //{
            //    nbPoints = 725;
            //    angleMesurable = new Angle(240, AnglyeType.Degre);
            //    offsetPoints = 44;
            //}
            //else if (reponse.Contains("BTM-75LX")) // Grand hokuyo
            //{
            //    nbPoints = 1080;
            //    angleMesurable = new Angle(270, AnglyeType.Degre);
            //    offsetPoints = 0;
            //}
        }

        protected override String GetResultat(int timeout = 500)
        {
            port.WriteLine(trameMesure);

            Stopwatch chrono = Stopwatch.StartNew();
            String reponse = "";

            do
            {
                reponse += port.ReadExisting();
            } while (Regex.Matches(reponse, "\n\n").Count < 2 && chrono.ElapsedMilliseconds < timeout);

            if (chrono.ElapsedMilliseconds > timeout)
                return "";
            else
                return reponse;
        }
    }
}
