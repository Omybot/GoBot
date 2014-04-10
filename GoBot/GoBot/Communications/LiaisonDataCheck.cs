using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    class LiaisonDataCheck
    {
        private ConnexionUDP Connexion { get; set; }
        private Carte Carte { get; set; }

        public byte IDTestEmissionActuel { get; set; }
        public int NombreMessagesTotal { get; private set; }
        public int NombreMessagesCorrects { get; private set; }
        public int NombreMessagesPerdusEmission { get; private set; }
        public int NombreMessagesCorrompusEmission { get; private set; }
        public int NombreMessagesPerdusReception { get; private set; }
        public int NombreMessagesCorrompusReception { get; private set; }

        public LiaisonDataCheck(ConnexionUDP connexion, Carte carte)
        {
            Connexion = connexion;
            Carte = carte;

            NombreMessagesTotal = 0;
            NombreMessagesCorrects = 0;
            NombreMessagesPerdusEmission = 0;
            NombreMessagesCorrompusEmission = 0;
            NombreMessagesPerdusReception = 0;
            NombreMessagesCorrompusReception = 0;
            IDTestEmissionActuel = 0;
        }

        public void EnvoiTest()
        {
            IDTestEmissionActuel++;
            Trame t = TrameFactory.TestEmission(Carte, IDTestEmissionActuel);
            Connexion.SendMessage(t);
        }

        public void MessageRecu(Trame trame)
        {
            if ((FonctionBalise)trame[1] == FonctionBalise.TestEmissionCorrompu)
            {
                NombreMessagesTotal++;
                NombreMessagesCorrompusEmission++;
            }
            if ((FonctionBalise)trame[1] == FonctionBalise.TestEmissionReussi)
            {
                NombreMessagesTotal++;
                bool verif = true;
                if (trame.Length == 17)
                {
                    for (int i = 0; i < 16; i++)
                        if (trame[i + 3] != i)
                            verif = false;

                    if (verif)
                    {
                        if (trame[2] == IDTestEmissionActuel)
                            NombreMessagesCorrects++;
                        else
                            NombreMessagesPerdusReception++;
                    }
                    else
                        NombreMessagesCorrompusReception++;
                }
            }
            if ((FonctionBalise)trame[1] == FonctionBalise.TestEmissionPerdu)
            {
                NombreMessagesTotal++;
                NombreMessagesPerdusEmission++;
            }
        }
    }
}
