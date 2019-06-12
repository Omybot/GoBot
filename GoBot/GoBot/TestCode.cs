using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;
using System.Windows.Forms;
using GoBot.Communications;
using GoBot.Communications.UDP;

namespace GoBot
{
    public static class TestCode
    {
        public static void TestEnums()
        {
            StringBuilder errors = new StringBuilder();
            errors.AppendLine("Les valeurs d'énumerations suivantes n'ont pas de traduction litéralle dans le nommeur :");
            bool error = false;

            List<Type> typesEnum = new List<Type>();
            typesEnum.Add(typeof(CapteurID));
            typesEnum.Add(typeof(SensorOnOffID));
            typesEnum.Add(typeof(ActuatorOnOffID));
            typesEnum.Add(typeof(ServomoteurID));
            typesEnum.Add(typeof(MotorID));
            typesEnum.Add(typeof(CodeurID));
            typesEnum.Add(typeof(SensorColorID));
            typesEnum.Add(typeof(BaliseID));
            typesEnum.Add(typeof(LedID));
            typesEnum.Add(typeof(LedRgbID));
            typesEnum.Add(typeof(LidarID));
            typesEnum.Add(typeof(UdpFrameFunction));
            
            foreach (Type type in typesEnum)
            {
                foreach (var value in Enum.GetValues(type))
                {
                    String result = NameFinder.GetNameUnknow((Convert.ChangeType(value, type)));
                    if (result == (Convert.ChangeType(value, type).ToString()) || result == "" || result == "Inconnu")
                    {
                        errors.Append("\t");
                        errors.Append(type.ToString());
                        errors.Append(".");
                        errors.AppendLine(Convert.ChangeType(value, type).ToString());
                        error = true;
                    }
                }
            }

            //if (error)
            //    MessageBox.Show(errors.ToString(), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
