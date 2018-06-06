﻿using GoBot.Geometry.Shapes;
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

                all.Concat(_elements.AsObstacles);
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

            // Distributeurs
            obstacles.Add(new Circle(new RealPoint(0, 840), 110));
            obstacles.Add(new Circle(new RealPoint(610, 2000), 110));
            obstacles.Add(new Circle(new RealPoint(2390, 2000), 110));
            obstacles.Add(new Circle(new RealPoint(3000, 840), 110));

            // Stations dépuration
            obstacles.Add(new PolygonRectangle(new RealPoint(894, 1750), 1200, 250));

            return obstacles;
        }

        private Dictionary<ColorPlus, IEnumerable<IShape>> CreateColorObstacles()
        {
            Dictionary<ColorPlus, IEnumerable<IShape>> obstacles = new Dictionary<ColorPlus, IEnumerable<IShape>>();

            // Obstacles pour le joueur de gauche
            List<IShape> obsLeft = new List<IShape>();
            //obsLeft.Add(new Circle(new RealPoint(250, 850), 200));
            //obsLeft.Add(new PolygonRectangle(new RealPoint(2030, 0), 600, 180));
            //obsLeft.Add(new PolygonRectangle(new RealPoint(2600, 0), 400, 645));
            obstacles.Add(Plateau.CouleurGaucheVert, obsLeft);

            // Obstacles pour le joueur de droite
            List<IShape> obsRight = new List<IShape>();
            obsRight.Add(new Circle(new RealPoint(3000 - 250, 850), 200));
            obsRight.Add(new PolygonRectangle(new RealPoint(400, 0), 600, 180));
            obsRight.Add(new PolygonRectangle(new RealPoint(0, 0), 400, 645));
            obstacles.Add(Plateau.CouleurDroiteOrange, obsRight);

            return obstacles;
        }

        private void _elements_ObstaclesChanged()
        {
            this.OnObstaclesChanged();
        }
    }
}