using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    public class JsonDumbParser
    {
        public static Dictionary<String, String> Parse(String json)
        {
            Dictionary<String, String> values = new Dictionary<string, string>();

            json = json.Replace("{", "").Replace("}", "").Replace(",\r\n", ":").Replace("\r\n", "");

            List<String> splits = json.Split(new String[] { ":" }, StringSplitOptions.None).ToList();

            for (int i = 0; i < splits.Count; i += 2)
            {
                values.Add(splits[i].Replace("\"", ""), splits[i + 1].Replace("\"", ""));
            }

            return values;
        }
    }
}
