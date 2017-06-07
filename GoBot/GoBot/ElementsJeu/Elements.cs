using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;

namespace GoBot.ElementsJeu
{
    public class Elements : IEnumerable<ElementJeu>
    {
        public Elements()
        {
            Fusees = new List<Fusee>();
            Fusees.Add(new Fusee(1, new PointReel(40, 1350), Color.White, 40));
            Fusees.Add(new Fusee(2, new PointReel(1150, 40), Plateau.CouleurGaucheBleu, 40));
            Fusees.Add(new Fusee(3, new PointReel(1850, 40), Plateau.CouleurDroiteJaune, 40));
            Fusees.Add(new Fusee(4, new PointReel(2960, 1350), Color.White, 40));

            Modules = new List<Module>();
            Modules.Add(new Module(new PointReel(200, 600), Plateau.CouleurGaucheBleu, 31));
            Modules.Add(new Module(new PointReel(500, 1100), Color.White, 31));
            Modules.Add(new Module(new PointReel(800, 1850), Plateau.CouleurGaucheBleu, 31));
            Modules.Add(new Module(new PointReel(900, 1400), Color.White, 31));
            Modules.Add(new Module(new PointReel(950, 200), Plateau.CouleurGaucheBleu, 31));
            Modules.Add(new Module(new PointReel(1000, 600), Color.White, 31));

            Modules.Add(new Module(new PointReel(2000, 600), Color.White, 31));
            Modules.Add(new Module(new PointReel(2050, 200), Plateau.CouleurDroiteJaune, 31));
            Modules.Add(new Module(new PointReel(2100, 1400), Color.White, 31));
            Modules.Add(new Module(new PointReel(2200, 1850), Plateau.CouleurDroiteJaune, 31));
            Modules.Add(new Module(new PointReel(2500, 1100), Color.White, 31));
            Modules.Add(new Module(new PointReel(2800, 600), Plateau.CouleurDroiteJaune, 31));

            ZonesDepose = new List<ZoneDeposeModules>();
            ZonesDepose.Add(new ZoneDeposeModules(new PointReel(1000, 1500), Color.White, 100));
            ZonesDepose.Add(new ZoneDeposeModules(new PointReel(1500, 1300), Color.White, 100));
            ZonesDepose.Add(new ZoneDeposeModules(new PointReel(2000, 1500), Color.White, 100));
        }

        public List<Fusee> Fusees { get; protected set; }

        public List<Module> Modules { get; protected set; }

        public List<ZoneDeposeModules> ZonesDepose { get; protected set; }

        public IEnumerable<ElementJeu> AllElements
        {
            get
            {
                IEnumerable<ElementJeu> elements = Enumerable.Empty<ElementJeu>();
                elements = elements.Concat(Fusees);
                elements = elements.Concat(Modules);
                elements = elements.Concat(ZonesDepose);

                return elements;
            }
        }

        public IEnumerator<ElementJeu> GetEnumerator()
        {
            return AllElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return AllElements.GetEnumerator();
        }
    }
}
