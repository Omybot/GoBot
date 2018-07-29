using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// Classe de stockage d'un résultat qui n'est calculé que quand nécessaire et stocké pour une future utilisation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VolatileResult<T>
    {
        private T _result;
        private CalculDelegate _calcul;
        private bool _computed;

        public delegate T CalculDelegate();

        /// <summary>
        /// Crée la valeur volatile en spécifiant la fonction de calcul pour obtenir le résultat
        /// </summary>
        /// <param name="calcul"></param>
        public VolatileResult(CalculDelegate calcul)
        {
            _calcul = calcul;
            _computed = false;
        }

        /// <summary>
        /// Obtient la valeur en la calculant automatiquement si c'est le premier appel depuis l'initialisation ou définit la valeur résultat.
        /// </summary>
        public T Value
        {
            get
            {
                if (!_computed)
                {
                    _result = _calcul.Invoke();
                    _computed = true;
                }
                return _result;
            }
            set
            {
                _result = value;
                _computed = true;
            }
        }

        /// <summary>
        /// Obtient si la valeur est actuellement définie ou non.
        /// </summary>
        public bool Computed
        {
            get
            {
                return _computed;
            }
        }

        /// <summary>
        /// Réinitialise la valeur calculée. La prochaine demande de valeur forcera le calcul.
        /// </summary>
        public void Reset()
        {
            _computed = false;
        }
    }
}
