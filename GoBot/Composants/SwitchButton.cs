using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Composants
{
    public partial class SwitchButton : UserControl
    {
        public SwitchButton()
        {
            InitializeComponent();
            _value = false;
            _isMirrored = true;
            Invalidate();
        }

        public delegate void ValueChangedDelegate(object sender, bool value);

        /// <summary>
        /// Se produit lorsque l'état du bouton change
        /// </summary>
        public event ValueChangedDelegate ValueChanged;

        private bool _value;
        private bool _isMirrored;

        private bool _isFocus;

        /// <summary>
        /// Retourne vrai ou faux selon l'état du composant
        /// </summary>
        public bool Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (this._value != value)
                {
                    this._value = value;
                    Invalidate();
                    OnValueChanged();
                }
            }
        }

        /// <summary>
        /// Mettre à vrai pour activer le contrôle de droite à gauche au lieu de gauche à droite
        /// </summary>
        public bool Mirrored
        {
            get
            {
                return _isMirrored;
            }
            set
            {
                _isMirrored = value;
                Invalidate();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Value = (!Value);
        }

        protected override void OnEnter(EventArgs e)
        {
            _isFocus = true;
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            _isFocus = false;
            Invalidate();
            base.OnLeave(e);
        }

        protected void OnValueChanged()
        {
            ValueChanged?.Invoke(this, _value);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int w, h;
            bool ballOnLeft;

            w = Width - 1;
            h = Height - 1;

            path.AddLine(h / 2 + 1, 1, w - h / 2 - 1, 1);
            path.AddArc(new Rectangle(w - h - 1, 1, h - 2, h - 2), -90, 180);
            path.AddLine(w - h / 2 - 1, h - 1, h / 2 + 1, h - 1);
            path.AddArc(new Rectangle(1, 1, h - 2, h - 2), 90, 180);

            Rectangle rBall;

            if (_value)
            {
                Brush b = new LinearGradientBrush(new Rectangle(1, 1, w - 2, h - 2), Color.FromArgb(43, 226, 75), Color.FromArgb(36, 209, 68), 12);
                e.Graphics.FillPath(b, path);
                b.Dispose();

                Pen p = new Pen(Color.FromArgb(22, 126, 40));
                e.Graphics.DrawPath(_isFocus ? Pens.DodgerBlue : p, path);
                p.Dispose();

                ballOnLeft = _isMirrored;
            }
            else
            {
                e.Graphics.FillPath(Brushes.WhiteSmoke, path);
                ballOnLeft = !_isMirrored;
                e.Graphics.DrawPath(_isFocus ? Pens.DodgerBlue : Pens.LightGray, path);
            }

            if (ballOnLeft)
                rBall = new Rectangle(0, 0, h, h);
            else
                rBall = new Rectangle(w - h, 0, h, h);

            Brush bBall = new LinearGradientBrush(rBall, Color.WhiteSmoke, Color.LightGray, 100);
            e.Graphics.FillEllipse(bBall, rBall);
            bBall.Dispose();

            e.Graphics.DrawEllipse(_isFocus ? Pens.DodgerBlue : Pens.Gray, rBall);

            path.Dispose();

            //base.OnPaint(e);

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void SwitchButton_MouseClick(object sender, MouseEventArgs e)
        {
            Focus();
            Value = !Value;
        }
    }
}
