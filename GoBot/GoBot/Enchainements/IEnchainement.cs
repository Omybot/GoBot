using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;

namespace GoBot.Enchainements
{
    public abstract class Enchainement
    {
        static private System.Timers.Timer timerFinMatch;
        public Color Couleur { get; set; }
        public static int DureeMatch { get; set; }

        public Enchainement()
        {
            DureeMatch = 90000;
            Couleur = Color.Purple;
        }

        public void Executer()
        {
            timerFinMatch = new System.Timers.Timer();
            timerFinMatch.Elapsed += new ElapsedEventHandler(timerFinMatch_Elapsed);
            timerFinMatch.Interval = DureeMatch;
            timerFinMatch.Start();
        }

        private void timerFinMatch_Elapsed(object sender, ElapsedEventArgs e)
        {
            GrosRobot.Stop(StopMode.Freely);
            GrosRobot.CoupureAlim();
            PetitRobot.Stop(StopMode.Freely);
            Plateau.Balise1.ReglageVitesse = false;
            Plateau.Balise2.ReglageVitesse = false;
            Plateau.Balise3.ReglageVitesse = false;
            Plateau.Balise1.VitesseRotation(0);
            Plateau.Balise2.VitesseRotation(0);
            Plateau.Balise3.VitesseRotation(0);
            timerFinMatch.Stop();
        }
    }
}
