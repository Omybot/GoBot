using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GoBot.Devices
{
    class PepperlComm
    {
        IPAddress _ip;

        public PepperlComm(IPAddress ip)
        {
            _ip = ip;
        }

        public Dictionary<String, String> SetParameter(String parameter, String value)
        {
            return SendCommand(PepperlConst.CmdSetParameter, parameter, value);
        }

        public Dictionary<String, String> SetParameters(IEnumerable<String> parameters, IEnumerable<String> values)
        {
            return SendCommand(PepperlConst.CmdSetParameter, parameters, values);
        }

        public Dictionary<String, String> SetParameters(params String[] paramVals)
        {
            return SendCommand(PepperlConst.CmdSetParameter, paramVals);
        }

        public Dictionary<String, String> SendCommand(String command)
        {
            return JsonDumbParser.Parse(SendMessage(command));
        }

        public Dictionary<String, String> SendCommand(PepperlCmd command)
        {
            return JsonDumbParser.Parse(SendMessage(command.GetText()));
        }

        public Dictionary<String, String> SendCommand(PepperlCmd command, IEnumerable<String> parameters, IEnumerable<String> values)
        {
            return SendCommand(command.GetText(), parameters, values);
        }

        public Dictionary<String, String> SendCommand(String command, IEnumerable<String> parameters, IEnumerable<String> values)
        {
            if (parameters.Count() != values.Count())
                return new Dictionary<String, String>();

            StringBuilder message = new StringBuilder(command + "?");

            for (int i = 0; i < parameters.Count(); i++)
                message = message.Append(parameters.ElementAt(i) + "=" + values.ElementAt(i) + "&");

            message.Remove(message.Length - 1, 1); // Le dernier & inutile

            String response = SendMessage(message.ToString());

            return JsonDumbParser.Parse(response);
        }

        public Dictionary<String, String> SendCommand(PepperlCmd command, params String[] paramVals)
        {
            return SendCommand(command.GetText(), paramVals);
        }

        public Dictionary<String, String> SendCommand(String command, params String[] paramVals)
        {
            if (paramVals.Length % 2 != 0)
                return new Dictionary<String, String>();

            List<String> parameters = new List<String>();
            List<String> values = new List<String>();

            for (int i = 0; i < paramVals.Length; i += 2)
            {
                parameters.Add(paramVals[i]);
                values.Add(paramVals[i + 1]);
            }

            return SendCommand(command, parameters, values);
        }

        private String SendMessage(String message)
        {
            String rep = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + _ip.ToString() + "/cmd/" + message);
                request.Timeout = 500;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    rep = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                rep = "";
            }

            return rep;
        }
    }
}
