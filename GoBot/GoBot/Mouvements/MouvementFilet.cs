using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Windows.Forms;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementFilet : Mouvement
    {
        public MouvementFilet()
        {
            Robot = Robots.PetitRobot;
            Positions.AddRange(PositionsMouvements.PositionsFilet);
        }

        static System.Windows.Forms.Timer timer = null;

        public override bool Executer(int timeOut = 0)
        {
            Robot.Historique.Log("Début filet");

            if (timer == null)
            {
                Robot.Historique.Log("Création timer filet");
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 5000;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }

            Position position = PositionProche;

            if (Robot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                timer.Stop();
                Robot.Historique.Log("Attente fin match");

                do
                {
                    Thread.Sleep(500);
                } while ((DateTime.Now - Plateau.Enchainement.DebutMatch).TotalSeconds < 91);

                LanceFilet.Tirer();
                LanceFilet.FiletLance = position.Coordonnees.X < 1500 ? 1 : 2;
                Plateau.Score += 6;

                return true;
            }
            
            return false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Robot.Historique.Log("Expiration timer filet");

            Positions.Clear();
            Positions.AddRange(PositionsMouvements.PositionsMammouths);

            Position mammouthProche = PositionProche;

            Robot.FailTrajectoire = true;
            Robot.Stop();

            Direction traj = Maths.GetDirection(Robot.Position, mammouthProche.Coordonnees);
            if (Math.Abs(traj.angle.AngleDegres) > 90)
            {
                traj.angle = new Angle(traj.angle.AngleDegres - 180);
            }

            if (traj.angle.AngleDegres < 0)
                Robot.PivotDroite(-traj.angle.AngleDegres);
            else
                Robot.PivotGauche(traj.angle.AngleDegres);

            Robot.Historique.Log("Attente fin match");

            do
            {
                Thread.Sleep(500);
            } while ((DateTime.Now - Plateau.Enchainement.DebutMatch).TotalSeconds < 91);

            LanceFilet.Tirer();
            LanceFilet.FiletLance = mammouthProche.Coordonnees.X < 1500 ? 1 : 2;

            Plateau.Score += 6;
        }

        public override int Score
        {
            get 
            {
                TimeSpan tempsEcoule = DateTime.Now - Plateau.Enchainement.DebutMatch;
                if (tempsEcoule.TotalSeconds > 80 && LanceFilet.FiletLance == 0)
                    return 50;
                else
                    return 0;
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
