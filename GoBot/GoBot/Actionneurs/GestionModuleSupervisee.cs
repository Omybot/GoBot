using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class GestionModuleSupervisee
    {
        int nbStock;
        Semaphore lockAvalage;
        Semaphore lockCouleur;

        public GestionModuleSupervisee()
        {
            nbStock = 0;
            lockAvalage = new Semaphore(1, 100000);
            lockCouleur = new Semaphore(0, 100000);
        }

        public bool AvalerModule()
        {
            if (nbStock == 0)
                return AvalerModule1();
            else if (nbStock == 1)
                return AvalerModule2();
            else if (nbStock == 2)
                return AvalerModule3();
            else if (nbStock == 3)
                return AvalerModule4();
            else if (nbStock == 4)
                return AvalerModule5();
            else
                return false;
        }

        public bool DeposerModule()
        {
            if (nbStock == 1)
                return DeposerModule1();
            else if (nbStock == 2)
                return DeposerModule2();
            else if (nbStock == 3)
                return DeposerModule3();
            else if (nbStock == 4)
                return DeposerModule4();
            else if (nbStock == 5)
                return DeposerModule5();
            else
                return false;
        }

        private bool AvalerModule1()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Avalage module 1");
            if (Actionneur.BrasLunaire.CapteurPresence)
            {
                lockAvalage.WaitOne();

                // Config initiale
                Actionneur.Convoyeur.Libere();
                Actionneur.Stockeur.RangerCalleur();
                Actionneur.Stockeur.PreparerRehausseur();
                Actionneur.Stockeur.BloqueBas();
                Actionneur.Stockeur.RelacheHaut();

                // Mouvements
                Actionneur.BrasLunaire.Monter();
                Actionneur.BrasLunaire.Reculer();
                Thread.Sleep(350);
                Actionneur.Convoyeur.Bloque();
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(100);

                Actionneur.Convoyeur.Avaler();
                Thread.Sleep(500);

                ThreadPool.QueueUserWorkItem(new WaitCallback(RangerEnHaut));
                
                nbStock++;
                succes = true;
            }
            else
            {
                RangerAvecErreur();
            }

            return succes;
        }

        private void RangerAvecErreur()
        {
            Robots.GrosRobot.Historique.Log("Avalage fail");
            Actionneur.BrasLunaire.Ouvrir();
            Thread.Sleep(200);
            Actionneur.BrasLunaire.Reculer();
            Actionneur.BrasLunaire.Monter();
            Thread.Sleep(250);
            Actionneur.BrasLunaire.Fermer();
        }

        private void RangerEnHaut(object o)
        {
            Thread.Sleep(500);
            Actionneur.Convoyeur.Arreter();
            Actionneur.Convoyeur.Libere();
            Caller();
            Thread.Sleep(50);
            Actionneur.Stockeur.MonterRehausseur();
            Thread.Sleep(300);
            Actionneur.Stockeur.BloquerHaut();
            Thread.Sleep(100);
            Actionneur.Stockeur.RangerRehausseur();

            lockAvalage.Release();
        }

        private bool AvalerModule2()
        {
            bool succes = false;

                Robots.GrosRobot.Historique.Log("Avalage module 2");
            if (Actionneur.BrasLunaire.CapteurPresence)
            {
                lockAvalage.WaitOne();

                // Config initiale
                Actionneur.Convoyeur.Libere();
                Actionneur.Stockeur.RangerCalleur();
                Actionneur.Stockeur.PreparerRehausseur();
                Actionneur.Stockeur.BloqueBas();

                // Mouvements
                Actionneur.BrasLunaire.Monter();
                Actionneur.BrasLunaire.Reculer();
                Thread.Sleep(350);
                Actionneur.Convoyeur.Bloque();
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(100);

                Actionneur.Convoyeur.Avaler();
                Thread.Sleep(500);

                ThreadPool.QueueUserWorkItem(new WaitCallback(RangerEnBas));
                
                nbStock++;
                succes = true;
            }
            else
            {
                RangerAvecErreur();
            }

            return succes;
        }

        private void RangerEnBas(Object o)
        {
            Thread.Sleep(500);
            Actionneur.Convoyeur.Arreter();
            Actionneur.Ejecteur.RentrerEjecteur(false);
            Actionneur.Convoyeur.Libere();
            Caller();
            Thread.Sleep(50); // à tester idem 1
            Actionneur.Stockeur.RelacheBas();
            Actionneur.Stockeur.RangerRehausseur();
            Thread.Sleep(200); // à tester ancienne mesure
            lockAvalage.Release();
            PositionnerCouleur(null);
            Actionneur.Ejecteur.CouperEjecteur();
        }

        private bool AvalerModule3()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Avalage module 3");
            if (Actionneur.BrasLunaire.CapteurPresence)
            {
                lockAvalage.WaitOne();

                // Config initiale
                Actionneur.Convoyeur.Libere();
                Actionneur.Stockeur.RangerCalleur();
                Actionneur.Stockeur.BloqueBas();

                // Mouvements
                Actionneur.BrasLunaire.Monter();
                Actionneur.BrasLunaire.Reculer();
                Thread.Sleep(350);
                Actionneur.Convoyeur.Bloque();
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(100);

                Actionneur.Convoyeur.Avaler();
                Thread.Sleep(500);

                ThreadPool.QueueUserWorkItem(new WaitCallback(RangerAuMilieu));

                nbStock++;
                succes = true;
            }
            else
            {
                RangerAvecErreur();
            }

            return succes;
        }

        private void RangerAuMilieu(Object o)
        {
            Thread.Sleep(500);
            Actionneur.Convoyeur.Arreter();
            Actionneur.Convoyeur.Libere();
            Caller();

            lockAvalage.Release();
        }

        private bool AvalerModule4()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Avalage module 4");
            if (Actionneur.BrasLunaire.CapteurPresence)
            {
                // Config initiale
                Actionneur.Convoyeur.Libere();

                // Mouvements
                Actionneur.BrasLunaire.Monter();
                Actionneur.BrasLunaire.Reculer();
                Thread.Sleep(350);
                Actionneur.Convoyeur.Bloque();
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(100);

                lockAvalage.WaitOne();
                Actionneur.Convoyeur.Avaler();
                Thread.Sleep(500); // à tester ancienne mesure
                Actionneur.Convoyeur.Recracher();
                Thread.Sleep(75); // à tester ancienne mesure
                Actionneur.Convoyeur.Arreter();
                lockAvalage.Release();

                nbStock++;
                succes = true;
            }
            else
            {
                RangerAvecErreur();
            }

            return succes;
        }

        private bool AvalerModule5()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Avalage module 5");
            if (Actionneur.BrasLunaire.CapteurPresence)
            {
                // Config initiale

                // Mouvements
                Actionneur.BrasLunaire.Avancer();
                Thread.Sleep(200);
                Actionneur.BrasLunaire.Monter();
                
                nbStock++;
                succes = true;
            }
            else
            {
                RangerAvecErreur();
            }

            return succes;
        }

        public bool AvaleModuleEnBas()
        {
            return AvalerModule2();
        }

        private bool DeposerModule5()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Dépose module 5");
            Ejecter(false);
            Thread.Sleep(500);
            MilieuVersBas();
            ConvoyeurVersMilieu();
            BrasVersConvoyeur();

            succes = true;
            nbStock--;

            return succes;
        }

        private bool DeposerModule4()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Dépose module 4");
            Ejecter(false);
            MilieuVersBas();
            ConvoyeurVersMilieu();

            succes = true;
            nbStock--;

            return succes;
        }

        private bool DeposerModule3()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Dépose module 3");
            Ejecter(false);
            MilieuVersBas();

            succes = true;
            nbStock--;

            return succes;
        }

        private bool DeposerModule2()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Dépose module 2");
            Ejecter();

            succes = true;
            nbStock--;

            return succes;
        }

        private bool DeposerModule1()
        {
            bool succes = false;

            Robots.GrosRobot.Historique.Log("Dépose module 1");
            Actionneur.Ejecteur.RentrerEjecteur(false);
            HautVersBas();
            PositionnerCouleur(null);
            Ejecter();

            succes = true;
            nbStock--;

            return succes;
        }

        private void ConvoyeurVersMilieu()
        {
            Actionneur.Stockeur.BloqueBas();
            Actionneur.Convoyeur.Avaler();
            Thread.Sleep(1000);  // à tester ancienne mesure
            Actionneur.Convoyeur.Arreter();
            Actionneur.Convoyeur.Libere();
            Thread.Sleep(50); // A tester
            Caller();
        }

        private void BrasVersConvoyeur()
        {
            Actionneur.BrasLunaire.Reculer();
            Thread.Sleep(300); // à tester
            Actionneur.Convoyeur.Bloque();
            Actionneur.BrasLunaire.Ouvrir();
            Thread.Sleep(100); // à tester

            Actionneur.Convoyeur.Avaler();
            Thread.Sleep(500); // à tester ancienne mesure
            Actionneur.Convoyeur.Recracher();
            Thread.Sleep(75);
            Actionneur.Convoyeur.Arreter();
        }

        private void HautVersBas()
        {
            Actionneur.Stockeur.RelacheBas();
            Actionneur.Stockeur.MonterRehausseur();
            Thread.Sleep(400); // a tester ancienne valeur
            Actionneur.Stockeur.RelacheHaut();
            Thread.Sleep(75); // a tester ancienne valeur
            Actionneur.Stockeur.RangerRehausseur();
            Thread.Sleep(750); // a tester ancienne valeur
        }

        private void MilieuVersBas()
        {
            Actionneur.Ejecteur.RentrerEjecteur(false);

            Actionneur.Stockeur.PreparerRehausseur();
            Thread.Sleep(250); // a tester
            Actionneur.Stockeur.RelacheBas();
            Thread.Sleep(50); // a tester
            Actionneur.Stockeur.RangerRehausseur();
            Thread.Sleep(250); // a tester

            ThreadPool.QueueUserWorkItem(new WaitCallback(PositionnerCouleur));
        }

        private void PositionnerCouleur(Object o)
        {
            Robots.GrosRobot.Historique.Log("Début positionne couleur");
            Actionneur.Ejecteur.PositionnerCouleur();
            Actionneur.Ejecteur.CouperEjecteur();
            Robots.GrosRobot.Historique.Log("Fin positionne couleur");
            lockCouleur.Release();
        }

        private void Ejecter(bool autoReset = true)
        {
            Robots.GrosRobot.Historique.Log("Ejecte module");
            lockCouleur.WaitOne();
            Actionneur.Ejecteur.SortirEjecteur();
            Thread.Sleep(500); // À tester ancienne mesure
            Actionneur.Ejecteur.RentrerEjecteur(autoReset);
        }

        private void Caller()
        {
            Actionneur.Stockeur.CallerCalleur();
            Thread.Sleep(400); // à tester ancienne mesure idem 1
            Actionneur.Stockeur.RangerCalleur();
        }

        public void Reset()
        {
            Actionneur.Ejecteur.Ejecter();
            Actionneur.Stockeur.RelacheBas();
            Thread.Sleep(600);
            Actionneur.Ejecteur.Ejecter();
            Actionneur.Stockeur.RelacheHaut();
            Thread.Sleep(600);
            Actionneur.Ejecteur.Ejecter();
            nbStock = 0;
        }

        public int NombreModules
        {
            get
            {
                return nbStock;
            }
        }

        public int PlacesLibres
        {
            get
            {
                return 5 - nbStock;
            }
        }

        public void AttraperModule(PointReel pos)
        {
            Robots.GrosRobot.SpeedConfig.LineAcceleration = 500;
            Robots.GrosRobot.SpeedConfig.LineDeceleration = 500;
            Robots.GrosRobot.SpeedConfig.LineSpeed = 500;
            Robots.GrosRobot.SpeedConfig.PivotAcceleration = 500;
            Robots.GrosRobot.SpeedConfig.PivotDeceleration = 500;
            Robots.GrosRobot.SpeedConfig.PivotSpeed = 500;

            Robots.GrosRobot.Stop();
            Robots.GrosRobot.GotoXYTeta(new Calculs.Position(0, pos.Translation(-80, 0)));

            Actionneurs.Actionneur.BrasLunaire.Descendre();
            Actionneurs.Actionneur.BrasLunaire.Ouvrir();
            Thread.Sleep(200);
            Actionneurs.Actionneur.BrasLunaire.Avancer();
            Robots.GrosRobot.SpeedConfig.LineDeceleration = 300;
            Robots.GrosRobot.Avancer(100);
            Actionneurs.Actionneur.BrasLunaire.Fermer();
            Thread.Sleep(200);
            Actionneurs.Actionneur.BrasLunaire.Reculer();
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(30);
            Actionneurs.Actionneur.BrasLunaire.Ouvrir();
            Thread.Sleep(50);
            Robots.GrosRobot.SpeedConfig.LineDeceleration = 300;
            Robots.GrosRobot.Avancer(30);
            Robots.GrosRobot.Rapide();
            Actionneurs.Actionneur.BrasLunaire.Fermer();

            Actionneur.GestionModuleSupervisee.AvalerModule();

            AvalerModule();
        }
    }
}
