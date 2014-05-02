using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    class LiaisonDataCheck
    {
        private Connexion Connexion { get; set; }
        private Carte Carte { get; set; }

        public byte IDTestEmissionActuel { get; set; }
        private byte IDTestReceptionActuel { get; set; }
        public int NombreMessagesTotal { get; private set; }
        public int NombreMessagesCorrects { get; private set; }
        public int NombreMessagesPerdusEmission { get; private set; }
        public int NombreMessagesCorrompusEmission { get; private set; }
        public int NombreMessagesPerdusReception { get; private set; }
        public int NombreMessagesCorrompusReception { get; private set; }

        public Dictionary<int, List<ReponseLiaison>> Reponses { get; set; }

        public enum ReponseLiaison
        {
            OK,
            PerduEmission,
            PerduReception,
            CorrompuEmission,
            CorrompuReception,
        }

        public LiaisonDataCheck(Connexion connexion, Carte carte)
        {
            Reponses = new Dictionary<int, List<ReponseLiaison>>();
            for (int i = 0; i < 255; i++ )
                Reponses.Add(i, new List<ReponseLiaison>());

            Connexion = connexion;
            Carte = carte;

            NombreMessagesTotal = 0;
            NombreMessagesCorrects = 0;
            NombreMessagesPerdusEmission = 0;
            NombreMessagesCorrompusEmission = 0;
            NombreMessagesPerdusReception = 0;
            NombreMessagesCorrompusReception = 0;
            IDTestEmissionActuel = 255;
            IDTestReceptionActuel = 0;
        }

        public void EnvoiTest()
        {
            NombreMessagesTotal++;
            IDTestEmissionActuel++;

            Trame t = TrameFactory.TestEmission(Carte, IDTestEmissionActuel);
            Connexion.SendMessage(t);
        }

        public void MessageRecu(Trame trame)
        {
            if ((FonctionBalise)trame[1] == FonctionBalise.TestEmissionCorrompu)
            {
                Reponses[trame[2]].Add(ReponseLiaison.CorrompuEmission);

                NombreMessagesCorrompusEmission++;
                if (trame[2] != IDTestReceptionActuel)
                {
                    if (trame[2] < IDTestReceptionActuel)
                    {
                        NombreMessagesPerdusReception += 255 - IDTestReceptionActuel;
                        NombreMessagesPerdusReception += trame[2];

                        for (int i = IDTestReceptionActuel + 1; i < 256; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);

                        for (int i = 0; i < trame[2]; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);
                    }
                    else
                    {
                        NombreMessagesPerdusReception += trame[2] - IDTestReceptionActuel;

                        for (int i = IDTestReceptionActuel; i < trame[2]; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);
                    }
                }

                IDTestReceptionActuel = (byte)(trame[2] + 1);
            }
            if ((FonctionBalise)trame[1] == FonctionBalise.TestEmissionReussi)
            {
                if (trame[2] != IDTestReceptionActuel)
                {
                    if (trame[2] < IDTestReceptionActuel)
                    {
                        NombreMessagesPerdusReception += 255 - IDTestReceptionActuel;
                        NombreMessagesPerdusReception += trame[2];

                        for (int i = IDTestReceptionActuel + 1; i < 256; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);

                        for (int i = 0; i < trame[2]; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);
                    }
                    else
                    {
                        NombreMessagesPerdusReception += trame[2] - IDTestReceptionActuel;

                        for (int i = IDTestReceptionActuel; i < trame[2]; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);
                    }
                }

                bool verif = true;
                if (trame.Length == 19)
                {
                    for (int i = 0; i < 16; i++)
                        if (trame[i + 3] != i)
                            verif = false;

                    if (verif)
                    {
                        NombreMessagesCorrects++;
                        Reponses[trame[2]].Add(ReponseLiaison.OK);
                    }
                    else
                    {
                        NombreMessagesCorrompusReception++;
                        Reponses[trame[2]].Add(ReponseLiaison.CorrompuReception);
                    }
                }

                IDTestReceptionActuel = (byte)(trame[2] + 1);
            }
            if ((FonctionBalise)trame[1] == FonctionBalise.TestEmissionPerdu)
            {
                byte idAttendu = trame[2];
                byte idRecu = trame[3];

                if (idRecu > idAttendu)
                    NombreMessagesPerdusEmission += idRecu - idAttendu;
                else
                {
                    NombreMessagesPerdusEmission += 255 - idAttendu;
                    NombreMessagesPerdusEmission += idRecu;
                }

                if (trame[2] != IDTestReceptionActuel)
                {
                    if (trame[2] < IDTestReceptionActuel)
                    {
                        NombreMessagesPerdusReception += 255 - IDTestReceptionActuel;
                        NombreMessagesPerdusReception += trame[2];

                        for (int i = IDTestReceptionActuel + 1; i < 256; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);

                        for (int i = 0; i < trame[2]; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);
                    }
                    else
                    {
                        NombreMessagesPerdusReception += trame[2] - IDTestReceptionActuel;

                        for (int i = IDTestReceptionActuel; i < trame[2]; i++)
                            Reponses[i].Add(ReponseLiaison.PerduReception);
                    }
                }

                IDTestReceptionActuel = (byte)(idRecu + 1);
            }
        }
    }
}
