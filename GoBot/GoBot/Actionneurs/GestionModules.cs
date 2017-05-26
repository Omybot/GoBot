using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class GestionModules
    {
        public int PlacesLibres
        {
            get
            {
                return 5 - ModulesCharges;
            }
        }

        public int ModulesCharges
        {
            get
            {
                return Actionneur.Stockeur.ModulesCount + (Actionneur.Convoyeur.ModuleCharge ? 1 : 0) + (Actionneur.BrasLunaire.ModuleCharge ? 1 : 0);
            }
        }

        public void AttraperUnModuleEtRanger()
        {
            if (Actionneur.Convoyeur.ModuleCharge)
                Actionneur.BrasLunaire.AttraperModuleEtStocker();
            else
            {
                if (Actionneur.BrasLunaire.AttraperModuleEtTransferer())
                {
                    Actionneur.Convoyeur.AvalerUnModule();

                    if (Actionneur.Stockeur.Stockable)
                        ThreadPool.QueueUserWorkItem(new WaitCallback(StockerModule));
                }
            }
        }

        public void AttraperUnModuleEtRangerEnBas()
        {
            if (Actionneur.BrasLunaire.AttraperModuleEtTransferer())
            {
                Actionneur.Convoyeur.AvalerUnModule();
                Actionneur.Stockeur.Avaler();
                Actionneur.Convoyeur.RecracherUnModule();
                Actionneur.Stockeur.Caller();
                Actionneur.Stockeur.MilieuVersBas();
            }
        }

        private void StockerModule(Object useless)
        {
            Actionneur.Stockeur.Avaler();
            Actionneur.Convoyeur.RecracherUnModule();
            Actionneur.Stockeur.Caller();
            Actionneur.Stockeur.Ranger(false);
        }

        public void EjecterUnModuleEtRanger()
        {
            if (Actionneur.Stockeur.Ejectable)
            {
                Actionneur.Stockeur.Descendre();
                Actionneur.Stockeur.Ejecter();
                Actionneur.Ejecteur.EjecterBonneCouleur();
                Actionneur.Stockeur.Ranger(false);

                if (Actionneur.Stockeur.Stockable && Actionneur.Convoyeur.ModuleCharge)
                {
                    Actionneur.Stockeur.Avaler();
                    Actionneur.Convoyeur.RecracherUnModule();
                    Actionneur.Stockeur.Caller();
                }

                if (!Actionneur.Convoyeur.ModuleCharge && Actionneur.BrasLunaire.ModuleCharge)
                {
                    Actionneur.BrasLunaire.TransfererStock();
                    Actionneur.Convoyeur.AvalerUnModule();
                }

                if (Plateau.Enchainement != null && Plateau.Enchainement.TempsRestant < new TimeSpan(0, 0, 30))
                {
                    if (Actionneur.Stockeur.ModulesCount == 0 && !Actionneur.BrasLunaire.ModuleCharge && Actionneur.BrasLunaireDroite.Charge)
                    {
                        Robots.GrosRobot.Avancer(250); // Besoin de 20cm derriere pour la manoeuvre
                        Actionneur.BrasLunaireDroite.TransfertAvant();
                        AttraperUnModuleEtRangerEnBas();
                        Robots.GrosRobot.Reculer(100); // Rattrape le décallage de la manoeuvre
                        Robots.GrosRobot.PivotGauche(43);
                        Robots.GrosRobot.Reculer(50);
                    }

                    if (Actionneur.Stockeur.ModulesCount == 0 && !Actionneur.BrasLunaire.ModuleCharge && Actionneur.BrasLunaireGauche.Charge)
                    {
                        Robots.GrosRobot.Avancer(250); // Besoin de 20cm derriere pour la manoeuvre
                        Actionneur.BrasLunaireGauche.TransfertAvant();
                        AttraperUnModuleEtRangerEnBas();
                        Robots.GrosRobot.Reculer(100); // Rattrape le décallage de la manoeuvre
                        Robots.GrosRobot.PivotDroite(43);
                        Robots.GrosRobot.Reculer(50);
                    }
                }
            }
        }

        public void TransfertBrasGauche()
        {
            // TODO dépose
            AttraperUnModuleEtRanger();
        }

        public void TransfertBrasDroite()
        {
            // TODO dépose
            AttraperUnModuleEtRanger();
        }

        public void FideFusee()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(privateVide));
        }

        private void privateVide(object useless)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                    Actionneurs.Actionneur.BrasLunaire.Descendre();
                Actionneurs.Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(120);
                Actionneurs.Actionneur.BrasLunaire.Avancer();
                Thread.Sleep(180);
                Actionneurs.Actionneur.BrasLunaire.Fermer();
                Thread.Sleep(180);
                Actionneurs.Actionneur.BrasLunaire.Reculer();
                Robots.GrosRobot.Reculer(30);
                Actionneurs.Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(50);
                Robots.GrosRobot.Lent();
                Robots.GrosRobot.Avancer(30);
                Robots.GrosRobot.Rapide();
                Actionneurs.Actionneur.BrasLunaire.Fermer();

                Actionneur.GestionModules.AttraperUnModuleEtRanger();
            }
        }
    }
}
