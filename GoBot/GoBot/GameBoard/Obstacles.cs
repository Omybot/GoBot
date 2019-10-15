﻿using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.GameElements;

namespace GoBot.GameBoard
{
    public class Obstacles
    {
        private IEnumerable<IShape> _boardObstacles;
        private Dictionary<ColorPlus, IEnumerable<IShape>> _colorObstacles;

        private IEnumerable<IShape> _detectionObstacles;

        private AllGameElements _elements;

        public delegate void ObstaclesChangedDelegate();
        public event ObstaclesChangedDelegate ObstaclesChanged;

        public Obstacles(AllGameElements elements)
        {
            _boardObstacles = CreateBoardObstacles();
            _colorObstacles = CreateColorObstacles();
            _elements = elements;
            _elements.ObstaclesChanged += _elements_ObstaclesChanged;
            _detectionObstacles = new List<IShape>();
        }

        public IEnumerable<IShape> FromAll
        {
            get
            {
                IEnumerable<IShape> all = _boardObstacles;

                all = all.Concat(_elements.AsObstacles);
                if (_colorObstacles.ContainsKey(Plateau.NotreCouleur)) all = all.Concat(_colorObstacles[Plateau.NotreCouleur]);
                if (_detectionObstacles != null) all = all.Concat(_detectionObstacles);

                return all.ToList();
            }
        }

        public IEnumerable<IShape> FromAllExceptBoard
        {
            get
            {
                IEnumerable<IShape> all = _elements.AsObstacles;

                if (_colorObstacles.ContainsKey(Plateau.NotreCouleur)) all = all.Concat(_colorObstacles[Plateau.NotreCouleur]);
                if (_detectionObstacles != null) all = all.Concat(_detectionObstacles);

                return all.ToList();
            }
        }

        public IEnumerable<IShape> FromBoard
        {
            get
            {
                return _boardObstacles;
            }
        }

        public IEnumerable<IShape> FromColor
        {
            get
            {
                return _colorObstacles[Plateau.NotreCouleur];
            }
        }

        public IEnumerable<IShape> FromDetection
        {
            get
            {
                return _detectionObstacles;
            }
        }

        public IEnumerable<IShape> FromElements
        {
            get
            {
                return Plateau.Elements.AsObstacles;
            }
        }

        public IShape BalanceViolet => new PolygonRectangle(new RealPoint(1600, 1250), 300, 300);
        public IShape BalanceYellow => new PolygonRectangle(new RealPoint(1100, 1250), 300, 300);

        public void SetDetections(IEnumerable<IShape> detections)
        {
            _detectionObstacles = detections;
            this.OnObstaclesChanged();
        }

        protected void OnObstaclesChanged()
        {
            ObstaclesChanged?.Invoke();
        }

        private IEnumerable<IShape> CreateBoardObstacles()
        {
            List<IShape> obstacles = new List<IShape>();

            // Contours du plateau
            obstacles.Add(new Segment(new RealPoint(0, 0), new RealPoint(Plateau.Largeur - 4, 0)));
            obstacles.Add(new Segment(new RealPoint(Plateau.Largeur - 4, 0), new RealPoint(Plateau.Largeur - 4, Plateau.Hauteur - 4)));
            obstacles.Add(new Segment(new RealPoint(Plateau.Largeur - 4, Plateau.Hauteur - 4), new RealPoint(0, Plateau.Hauteur - 4)));
            obstacles.Add(new Segment(new RealPoint(0, Plateau.Hauteur - 4), new RealPoint(0, 0)));

            // TODOEACHYEAR : créer les obstacles fixes du plateau

            // Récifs
            obstacles.Add(new PolygonRectangle(new RealPoint(889, 1850), 22, 150));
            obstacles.Add(new PolygonRectangle(new RealPoint(1489, 1700), 22, 300));
            obstacles.Add(new PolygonRectangle(new RealPoint(2089, 1850), 22, 150));

            return obstacles;
        }

        private Dictionary<ColorPlus, IEnumerable<IShape>> CreateColorObstacles()
        {
            Dictionary<ColorPlus, IEnumerable<IShape>> obstacles = new Dictionary<ColorPlus, IEnumerable<IShape>>();

            // TODOEACHYEAR : créer les obstacles fixes en fonction de la couleur (genre zones réservées à l'adversaire)

            List<IShape> obsLeft = new List<IShape>();
            List<IShape> obsRight = new List<IShape>();

            //Bande de droite (zone de départ etc)
            obsLeft.Add(new PolygonRectangle(new RealPoint(2550, 0), 450, 2000));
            //Port secondaire
            obsLeft.Add(new Circle(new RealPoint(1200, 1800), 150));
            
            //Bande de gauche (zone de départ etc)
            obsRight.Add(new PolygonRectangle(new RealPoint(0, 0), 450, 2000));
            //Port secondaire
            obsRight.Add(new Circle(new RealPoint(1800, 1800), 150));
            
            obstacles.Add(Plateau.CouleurGaucheJaune, obsLeft);
            obstacles.Add(Plateau.CouleurDroiteViolet, obsRight);

            return obstacles;
        }

        private void _elements_ObstaclesChanged()
        {
            this.OnObstaclesChanged();
        }
    }
}
