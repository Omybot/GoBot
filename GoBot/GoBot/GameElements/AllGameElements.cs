using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;

using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class AllGameElements : IEnumerable<GameElement>
    {
        public delegate void ObstaclesChangedDelegate();
        public event ObstaclesChangedDelegate ObstaclesChanged;

        private List<LayingAtom> _layingAtoms;
        private List<StandingAtom> _standingAtoms;

        private Color _colorRedium, _colorGreenium, _colorBlueium;

        public AllGameElements()
        {
            _colorRedium = Color.FromArgb(250, 36, 39);
            _colorGreenium = Color.FromArgb(164, 217, 51);
            _colorBlueium = Color.FromArgb(39, 186, 243);

            // TODOEACHYEAR Ajouter ici tous les éléments dans les listes

            _layingAtoms = new List<LayingAtom>();

            // Atomes de départ gauche
            _layingAtoms.Add(new LayingAtom(new RealPoint(500, 450), Color.White, _colorRedium));
            _layingAtoms.Add(new LayingAtom(new RealPoint(500, 750), Color.White, _colorRedium));
            _layingAtoms.Add(new LayingAtom(new RealPoint(500, 1050), Color.White, _colorGreenium));

            // Atome pente gauche
            _layingAtoms.Add(new LayingAtom(new RealPoint(834, 1800), Color.White, _colorGreenium));

            // Atomes de départ droite
            _layingAtoms.Add(new LayingAtom(new RealPoint(3000 - 500, 450), Color.White, _colorRedium));
            _layingAtoms.Add(new LayingAtom(new RealPoint(3000 - 500, 750), Color.White, _colorRedium));
            _layingAtoms.Add(new LayingAtom(new RealPoint(3000 - 500, 1050), Color.White, _colorGreenium));

            // Atome pente droite
            _layingAtoms.Add(new LayingAtom(new RealPoint(3000 - 834, 1800), Color.White, _colorGreenium));

            _standingAtoms = new List<StandingAtom>();

            // Atomes de grand distributeur gauche
            _standingAtoms.Add(new StandingAtom(new RealPoint(500, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(600, 1555.5), Color.White, _colorGreenium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(700, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(800, 1555.5), Color.White, _colorBlueium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(900, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(1000, 1555.5), Color.White, _colorGreenium));

            // Atomes de petit distributeur gauche (réservé)
            _standingAtoms.Add(new StandingAtom(new RealPoint(125, 2012.5), Plateau.CouleurGaucheJaune, _colorBlueium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(225, 2012.5), Plateau.CouleurGaucheJaune, _colorGreenium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(325, 2012.5), Plateau.CouleurGaucheJaune, _colorRedium));

            // Atome accélérateur gauche
            _standingAtoms.Add(new StandingAtom(new RealPoint(1500 - 210, 12.5), Plateau.CouleurGaucheJaune, _colorBlueium));

            // Atomes de grand distributeur droite
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 500, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 600, 1555.5), Color.White, _colorGreenium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 700, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 800, 1555.5), Color.White, _colorBlueium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 900, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 1000, 1555.5), Color.White, _colorGreenium));

            // Atomes de petit distributeur droite (réservé)
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 125, 2012.5), Plateau.CouleurDroiteViolet, _colorBlueium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 225, 2012.5), Plateau.CouleurDroiteViolet, _colorGreenium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 325, 2012.5), Plateau.CouleurDroiteViolet, _colorRedium));

            // Atome accélérateur droite
            _standingAtoms.Add(new StandingAtom(new RealPoint(1500 + 210, 12.5), Plateau.CouleurDroiteViolet, _colorBlueium));
        }

        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();

                // TODOEACHYEAR Concaténer ici les listes d'éléments

                elements = elements.Concat(_layingAtoms);
                elements = elements.Concat(_standingAtoms);

                return elements;
            }
        }

        public IEnumerator<GameElement> GetEnumerator()
        {
            return AllElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return AllElements.GetEnumerator();
        }

        public IEnumerable<IShape> AsObstacles
        {
            get
            {
                List<IShape> obstacles = new List<IShape>();

                if (Plateau.Strategy != null && Plateau.Strategy.AvoidElements)
                {
                    // TODOEACHYEAR Ici ajouter à obstacles les elements à contourner
                }

                return obstacles;
            }
        }

        public void SetOpponents(List<RealPoint> positions)
        {
            // TODOEACHYEAR Mettre à jour ICI les éléments en fonction de la position des adversaires

            int opponentRadius = 150;
        }
    }
}
