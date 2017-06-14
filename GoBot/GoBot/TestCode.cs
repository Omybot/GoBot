using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;
using System.Windows.Forms;
using GoBot.Communications;

namespace GoBot
{
    public static class TestCode
    {
        public static void VerificationEnums()
        {
            StringBuilder erreurs = new StringBuilder();
            erreurs.AppendLine("Les valeurs d'énumerations suivantes n'ont pas de traduction litéralle dans le nommeur :");
            bool erreur = false;

            List<Type> typesEnum = new List<Type>();
            typesEnum.Add(typeof(CapteurID));
            typesEnum.Add(typeof(CapteurOnOffID));
            typesEnum.Add(typeof(ActionneurOnOffID));
            typesEnum.Add(typeof(ServomoteurID));
            typesEnum.Add(typeof(MoteurID));
            typesEnum.Add(typeof(CodeurID));
            typesEnum.Add(typeof(CapteurCouleurID));
            typesEnum.Add(typeof(BaliseID));
            typesEnum.Add(typeof(LedID));
            typesEnum.Add(typeof(LedRgbID));
            typesEnum.Add(typeof(LidarID));
            typesEnum.Add(typeof(FrameFunction));
            
            foreach (Type type in typesEnum)
            {
                foreach (var valeur in Enum.GetValues(type))
                {
                    String resultat = Nommeur.NommerInconnu((Convert.ChangeType(valeur, type)));
                    if (resultat == (Convert.ChangeType(valeur, type).ToString()) || resultat == "" || resultat == "Inconnu")
                    {
                        erreurs.Append("\t");
                        erreurs.Append(type.ToString());
                        erreurs.Append(".");
                        erreurs.AppendLine(Convert.ChangeType(valeur, type).ToString());
                        erreur = true;
                    }
                }
            }

            if (erreur)
                MessageBox.Show(erreurs.ToString(), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
