using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Composants
{
    public partial class ByteBinaryGraph : UserControl
    {
        private List<Label> Labels { get; set; }
        private List<BinaryGraph> Graphs { get; set; }

        public ByteBinaryGraph()
        {
            InitializeComponent();

            Labels = new List<Label>() { label1, label2, label3, label4, label5, label6, label7, label8 };
            Graphs = new List<BinaryGraph>() { binaryGraph1, binaryGraph2, binaryGraph3, binaryGraph4, binaryGraph5, binaryGraph6, binaryGraph7, binaryGraph8 };
        }

        /// <summary>
        /// Permet de définir la liste des nom des graphes
        /// </summary>
        /// <param name="names">Noms des graphes</param>
        public void SetNames(List<String> names)
        {
            for (int i = 0; i < names.Count && i < Labels.Count; i++)
            {
                Labels[i].Text = names[i];
            }
        }

        /// <summary>
        /// Permet d'ajouter une valeur aux 8 graphes sous forme d'un octet fonctionnant comme un masque
        /// </summary>
        /// <param name="value">Masque des valeurs à ajouter aux graphes</param>
        public void SetValue(Byte value)
        {
            for(int i = 0; i < 8; i++)
            {
                if (Labels[i].Text != "-")
                    Graphs[i].AddPoint((value & 0x1) > 0);

                value = (Byte)(value >> 1);
            }
        }
    }
}
