using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoBot.GameElements;

namespace GoBot.IHM
{
    public partial class PanelColorPattern : UserControl
    {
        private CubesPattern _pattern;

        public PanelColorPattern()
        {
            InitializeComponent();

            _pattern = new CubesPattern(CubesCross.CubeColor.Joker, CubesCross.CubeColor.Joker, CubesCross.CubeColor.Joker);

            Actionneurs.Actionneur.PatternReader.PatternChanged += PatternReader_PatternChanged;
        }

        private void PatternReader_PatternChanged(CubesPattern pattern)
        {
            _pattern = pattern;

            this.Invalidate();
        }

        public void SetPattern(CubesPattern pattern)
        {
            _pattern = pattern;

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            _pattern.Paint(e.Graphics, new Geometry.Shapes.RealPoint(0, 30), WorldScale.Default());
        }
    }
}
