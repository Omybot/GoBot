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

        private Accelerator _acceleratorViolet, _acceleratorYellow;
        private Goldenium _goldeniumViolet, _goldeniumYellow;
        private Balance _balanceViolet, _balanceYellow;

        private VoidZone _zoneViolet, _zoneYellow;

        private Slope _slopeViolet, _slopeYellow;

        private ZoneCalibration _calibViolet, _calibYellow;

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
            _standingAtoms.Add(new StandingAtom(new RealPoint(125, 2012.5), Plateau.ColorLeftBlue, _colorBlueium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(225, 2012.5), Plateau.ColorLeftBlue, _colorGreenium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(325, 2012.5), Plateau.ColorLeftBlue, _colorRedium));

            // Atome accélérateur gauche
            _standingAtoms.Add(new StandingAtom(new RealPoint(1500 - 210, 12.5), Plateau.ColorLeftBlue, _colorBlueium));

            // Atomes de grand distributeur droite
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 500, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 600, 1555.5), Color.White, _colorGreenium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 700, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 800, 1555.5), Color.White, _colorBlueium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 900, 1555.5), Color.White, _colorRedium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 1000, 1555.5), Color.White, _colorGreenium));

            // Atomes de petit distributeur droite (réservé)
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 125, 2012.5), Plateau.ColorRightYellow, _colorBlueium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 225, 2012.5), Plateau.ColorRightYellow, _colorGreenium));
            _standingAtoms.Add(new StandingAtom(new RealPoint(3000 - 325, 2012.5), Plateau.ColorRightYellow, _colorRedium));

            // Atome accélérateur droite
            _standingAtoms.Add(new StandingAtom(new RealPoint(1500 + 210, 12.5), Plateau.ColorRightYellow, _colorBlueium));

            // Accélérateur (déchargement)
            _acceleratorViolet = new Accelerator(new RealPoint(1290, 20), Plateau.ColorRightYellow, 80);
            _acceleratorYellow = new Accelerator(new RealPoint(1710, 20), Plateau.ColorLeftBlue, 80);

            // Goldenium
            _goldeniumViolet = new Goldenium(new RealPoint(770, 20), Plateau.ColorRightYellow, 40);
            _goldeniumYellow = new Goldenium(new RealPoint(3000 - 770, 20), Plateau.ColorLeftBlue, 40);

            // Balances
            _balanceViolet = new Balance(new RealPoint(3000 - 1360, 1800), Plateau.ColorRightYellow, 100);
            _balanceYellow = new Balance(new RealPoint(1360, 1800), Plateau.ColorLeftBlue, 100);

            // Zones de vide
            _zoneViolet = new VoidZone(new RealPoint(3000 - 1000, 1050), Color.White, 150);
            _zoneYellow = new VoidZone(new RealPoint(1000, 1050), Color.White, 150);

            // Pentes
            _slopeViolet = new Slope(new RealPoint(3000 - 700, 1750), Plateau.ColorRightYellow, 170);
            _slopeYellow = new Slope(new RealPoint(700, 1750), Plateau.ColorLeftBlue, 170);

            // Zones de recallage
            _calibViolet = new ZoneCalibration(new RealPoint(300, 300), Plateau.ColorRightYellow, 100);
            _calibYellow = new ZoneCalibration(new RealPoint(3000- 300, 300), Plateau.ColorLeftBlue, 100);
        }

        public Accelerator AcceleratorViolet => _acceleratorViolet;
        public Accelerator AcceleratorYellow => _acceleratorYellow;

        public Goldenium GoldeniumViolet => _goldeniumViolet;
        public Goldenium GoldeniumYellow => _goldeniumYellow;

        public Balance BalanceViolet => _balanceViolet;
        public Balance BalanceYellow => _balanceYellow;

        public VoidZone VoidZoneViolet => _zoneViolet;
        public VoidZone VoidZoneYellow => _zoneYellow;

        public Slope SlopeViolet => _slopeViolet;
        public Slope SlopeYellow => _slopeYellow;

        public ZoneCalibration CalibrationZoneViolet => _calibViolet;
        public ZoneCalibration CalibrationZoneYellow => _calibYellow;

        public List<LayingAtom> LayingAtoms => _layingAtoms;

        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();

                // TODOEACHYEAR Concaténer ici les listes d'éléments

                elements = elements.Concat(_layingAtoms);
                elements = elements.Concat(_standingAtoms);

                elements = elements.Concat(new GameElement[] { _acceleratorViolet, _acceleratorYellow });
                elements = elements.Concat(new GameElement[] { _goldeniumViolet, _goldeniumYellow });
                elements = elements.Concat(new GameElement[] { _balanceViolet, _balanceYellow });
                elements = elements.Concat(new GameElement[] { _zoneViolet, _zoneYellow });
                elements = elements.Concat(new GameElement[] { _slopeViolet, _slopeYellow });
                elements = elements.Concat(new GameElement[] { _calibViolet, _calibYellow });

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
                    if (_zoneViolet.IsObstacle)
                        obstacles.Add(new Circle(_zoneViolet.Position, _zoneViolet.HoverRadius * 0.48));

                    if (_zoneYellow.IsObstacle)
                        obstacles.Add(new Circle(_zoneYellow.Position, _zoneYellow.HoverRadius * 0.48));
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
