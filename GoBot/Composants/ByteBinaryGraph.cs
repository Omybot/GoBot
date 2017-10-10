using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Composants
{
    public partial class ByteBinaryGraph : UserControl
    {
        private List<Label> labels;
        private List<BinaryGraph> graphs;

        public ByteBinaryGraph()
        {
            InitializeComponent();

            labels = new List<Label>() { label1, label2, label3, label4, label5, label6, label7, label8 };
            graphs = new List<BinaryGraph>() { binaryGraph1, binaryGraph2, binaryGraph3, binaryGraph4, binaryGraph5, binaryGraph6, binaryGraph7, binaryGraph8 };
        }

        public void SetNames(List<String> names)
        {
            for (int i = 0; i < names.Count && i < labels.Count; i++)
            {
                labels[i].Text = names[i];
            }
        }

        public void SetValue(Byte value)
        {
            for(int i = 0; i < graphs.Count; i++)
            {
                graphs[i].AddPoint((value & 0x1) > 0);
                value = (Byte)(value >> 1);
            }
        }
    }
}
