using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.Actionneur;

namespace GoBot.Mouvements
{
    class MouvementFeuBordure : Mouvement
    {
        private int numeroFeu;

        public MouvementFeuBordure(int i)
        {
            numeroFeu = i;
            Positions.Add(PositionsMouvements.PositionGrosFeuxBordure[i]);
            Robot = Robots.GrosRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début feu bordure " + numeroFeu);

            Position position = PositionProche;

            if (Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robots.GrosRobot.Historique.Log("Position feu bordure " + numeroFeu + " atteinte");
                BrasFeux.MoveAttrapeContreMur();
                BrasFeux.FeuxStockes.Add(Plateau.Feux[numeroFeu]);

                switch (numeroFeu)
                {
                    case 15:
                        Plateau.Feux[numeroFeu].Couleur = Plateau.CouleurGaucheRouge;
                        break;
                    case 8:
                        Plateau.Feux[numeroFeu].Couleur = Plateau.CouleurDroiteJaune;
                        break;
                    case 7:
                        Plateau.Feux[numeroFeu].Couleur = Plateau.CouleurGaucheRouge;
                        break;
                    case 0:
                        Plateau.Feux[numeroFeu].Couleur = Plateau.CouleurDroiteJaune;
                        break;
                }

                Plateau.Feux[numeroFeu].Debout = false;
                Plateau.Feux[numeroFeu].Angle = 0;
                Plateau.Feux[numeroFeu].Charge = true;

                Robots.GrosRobot.Historique.Log("Fin feu bordure " + numeroFeu);
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation feu bordure " + numeroFeu);
                return false;
            }

            return true;
        }

        public override int Score
        {
            get { return 1; }
        }

        public override double ScorePondere
        {
            get 
            { 
                if(BrasFeux.FeuxStockes.Count == 3 || Plateau.Feux[numeroFeu].Charge || Plateau.Feux[numeroFeu].Positionne)
                    return 0;
                else
                    return Score; 
            }
        }
    }
}
