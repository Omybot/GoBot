using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelPetitRobotUtilisation : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelPetitRobotUtilisation()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tailleMax = groupBoxUtil.Height;
            tailleMin = 39;
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupBoxUtil.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public virtual void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupBoxUtil.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupBoxUtil.Height = tailleMin;
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxUtil.Controls)
                    c.Visible = true;

                groupBoxUtil.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.UtilisationPROuvert = deployer;
        }
        private void PanelUtilGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.UtilisationPROuvert);
            switchBoutonPuissance.SetActif(true, false);
        }

        private void switchBoutonPuissance_ChangementEtat(bool actif)
        {
            Robots.PetitRobot.AlimentationPuissance(actif);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.Diagnostic();
        }

        #region BrasAvant
        private void btnAvantHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantHaut);
        }

        private void btnAvantBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantBas);
        }

        private void btnAvantAssiette_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantAssiette);
        }

        private void btnAvantRange_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantRange);
        }
        #endregion

        #region BrasArriere
        private void btnArriereHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereHaut);
        }

        private void btnArriereBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereBas);
        }

        private void btnArriereAssiette_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereAssiette);
        }

        private void btnArriereRange_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereRange);
        }
        #endregion

        private void btnAvGaHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheHaut);
        }

        private void btnAvGaBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheBas);
        }

        private void btnAvDrHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitHaut);
        }

        private void btnAvDrBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitBas);
        }

        private void btnArGaHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheHaut);
        }

        private void btnArGaBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheBas);
        }

        private void btnArDrHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitHaut);
        }

        private void btnArDrBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitBas);
        }

        Thread thDanse;
        private void btnDanse_Click(object sender, EventArgs e)
        {
            thDanse = new Thread(Danse);
            thDanse.Start();
        }

        public void Danse()
        {
            int shrek = 0;
            while(true)
            {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheHaut);//leve patte+shrek
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitHaut);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheHaut);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitHaut);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);

            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Droite, 60, 90);//petit caré qui tourne
            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Gauche, 60, 180);
            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Droite, 60, 90);
            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Gauche, 60, 180);
            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Droite, 60, 90);
            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Gauche, 60, 180);

            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//shrek bas
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);
            Thread.Sleep(400);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//shrek haut
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);
            Thread.Sleep(150);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//sherk bas
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);
            Thread.Sleep(150);

            for (shrek = 0; shrek < 3; shrek++) //araignée
            {
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheBas);//baisse patte
                Thread.Sleep(150);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitBas);
                Thread.Sleep(150);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitBas);
                Thread.Sleep(150);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheBas);
                Thread.Sleep(150);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheHaut);//leve patte
                Thread.Sleep(150);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitHaut);
                Thread.Sleep(150);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitHaut);
                Thread.Sleep(150);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheHaut);
            }
            Robots.PetitRobot.Avancer(200); // Distance en mm
            Robots.PetitRobot.Reculer(200);

            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheBas);//baisse patte
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitBas);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheBas);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitBas);
            Thread.Sleep(300);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheHaut);//leve patte
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitHaut);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheHaut);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitHaut);
            Thread.Sleep(300);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//sherk gauche haut
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);//shrek droit haut

            Robots.PetitRobot.Avancer(200); // Distance en mm
            Robots.PetitRobot.Reculer(200);

            for (shrek = 0; shrek < 5; shrek++) //alterne shrek
            {
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//sherk droit bas
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//sherk gauche haut
                Thread.Sleep(200);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);//shrek droit haut
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);//shrek gauche bas
                Thread.Sleep(200);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//sherk droit bas
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//sherk gauche haut
                Thread.Sleep(200);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);//shrek droit haut
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);//shrek gauche bas
            }

            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Droite, 60, 90);
            Robots.PetitRobot.Virage(SensAR.Avant, SensGD.Gauche, 60, 90);

            Robots.PetitRobot.Virage(SensAR.Arriere, SensGD.Droite, 60, 90);
            Robots.PetitRobot.Virage(SensAR.Arriere, SensGD.Gauche, 60, 90);

            for (shrek = 0; shrek < 4; shrek++) //mille pattes
            {
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitHaut);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheHaut);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheBas);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitBas);
                Thread.Sleep(200);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheHaut);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitHaut);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitBas);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheBas);
                Thread.Sleep(200);
            }
            Robots.PetitRobot.Avancer(200); // Distance en mm
            Robots.PetitRobot.Reculer(200);

            for (shrek = 0; shrek < 10; shrek++) //alterne shrek
            {
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//sherk droit bas
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//sherk gauche haut
                Thread.Sleep(200);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);//shrek droit haut
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);//shrek gauche bas
                Thread.Sleep(200);

            }

            for (shrek = 0; shrek < 5; shrek++) //hola
            {
            Robots.PetitRobot.PivotDroite(15);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//shrek bas
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);
            Thread.Sleep(400);
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//shrek haut
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);
            Thread.Sleep(150);
            }

            Robots.PetitRobot.Avancer(100); // Distance en mm
            Robots.PetitRobot.Virage(SensAR.Arriere, SensGD.Droite, 1, 180);

            for (shrek = 0; shrek < 10; shrek++) //alterne shrek
            {
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//sherk droit bas
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//sherk gauche haut
                Thread.Sleep(200);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);//shrek droit haut
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);//shrek gauche bas
                Thread.Sleep(200);
            }

            Robots.PetitRobot.Virage(SensAR.Arriere, SensGD.Droite, 1, 180);
            Robots.PetitRobot.Reculer(100);

            for (shrek = 0; shrek < 5; shrek++) //alterne shrek
            {
                Robots.PetitRobot.PivotDroite(15);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//shrek bas
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);
                Thread.Sleep(400);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//shrek haut
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);
                Thread.Sleep(150);
            }
            }
        }

        Thread thDanse2;
        private void btnDanse2_Click(object sender, EventArgs e)
        {
            thDanse2 = new Thread(Danse2);
            thDanse2.Start();
        }

        private void Danse2()
        {
            while (true)
            {
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//sherk droit bas
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//sherk gauche haut
                Thread.Sleep(400);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);//shrek droit haut
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);//shrek gauche bas
                Thread.Sleep(400);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteBas);//sherk droit bas
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);//sherk gauche haut
                Thread.Sleep(400);
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);//shrek droit haut
                Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheBas);//shrek gauche bas
            }
        }
    }
}
