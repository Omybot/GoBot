using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Composants
{
    public partial class TrackBarPlus : UserControl
    {
        private bool _isReversed;
        private bool _isVertical;
        private double _value, _maxValue, _minValue;
        private int _decimalPlaces;
        private bool _isMoving;
        private int _cursorSize;

        private double _lastTickedValue = -1;

        public delegate void ValueChangedDelegate(object sender, double value);

        public event ValueChangedDelegate TickValueChanged;
        public event ValueChangedDelegate ValueChanged;

        public TrackBarPlus()
        {
            InitializeComponent();

            DecimalPlaces = 0;
            _isVertical = false;
            _isReversed = false;
            IntervalTimer = 1;
            TimerTickValue = new Timer();
            TimerTickValue.Tick += new EventHandler(TimerTickValue_Tick);

            _minValue = 0;
            _maxValue = 100;
            _isMoving = false;
            _decimalPlaces = 0;

            _cursorSize = Height - 1;
        }

        private Timer TimerTickValue { get; set; }

        public double Value => _value;

        public uint IntervalTimer { get; set; }

        public int DecimalPlaces { get; set; }

        public double Min
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                SetValue(_value);
            }
        }

        public double Max
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                SetValue(_value);
            }
        }

        public bool Vertical
        {
            get
            {
                return _isVertical;
            }
            set
            {
                int oldWidth = Width;
                int oldHeight = Height;

                if (value)
                {
                    MaximumSize = new Size(15, 3000);
                    MinimumSize = new Size(15, 30);

                    Height = Math.Max(oldWidth, oldHeight);
                    Width = Math.Min(oldWidth, oldHeight);
                }
                else
                {
                    MaximumSize = new Size(3000, 15);
                    MinimumSize = new Size(30, 15);

                    Width = Math.Max(oldWidth, oldHeight);
                    Height = Math.Min(oldWidth, oldHeight);
                }

                _isVertical = value;
                _cursorSize = _isVertical ? Width - 1 : Height - 1;
                Invalidate();
            }
        }

        public bool Reverse
        {
            get
            {
                return _isReversed;
            }
            set
            {
                _isReversed = value;
                Invalidate();
            }
        }

        public void SetValue(double val, bool tickEvent = true)
        {
            val = Math.Max(Min, Math.Min(Max, val));

            if (_value != val)
            {
                _value = Math.Round(val, DecimalPlaces);

                if (tickEvent)
                    TickValueChanged?.Invoke(this, _value);

                ValueChanged?.Invoke(this, _value);
            }

            Invalidate();
        }

        #region Events

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            int direction = Reverse ? -1 : 1;

            if (e.KeyCode == Keys.Down)
            {
                SetValue(Reverse ? Max : Min);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                SetValue(Reverse ? Min : Max);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                SetValue(_value - Math.Ceiling((Max - Min) * 0.05) * direction);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                SetValue(_value + Math.Ceiling((Max - Min) * 0.05) * direction);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Add)
            {
                SetValue(_value + direction);
                e.IsInputKey = true;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                SetValue(_value - direction);
                e.IsInputKey = true;
            }
            base.OnPreviewKeyDown(e);
        }

        void img_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        void img_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        void img_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            Invalidate();
            base.OnLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                StartMoving();
                SetCursorPosition(this.PointToClient(Cursor.Position));
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                EndMoving();

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isMoving) SetCursorPosition(this.PointToClient(Cursor.Position));

            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Focus();
            SetValue(_value + Math.Sign(e.Delta) * (_maxValue - _minValue) / 100, true);
        }

        private void TrackBarPlus_Leave(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void TrackBarPlus_Enter(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void TrackBarPlus_SizeChanged(object sender, EventArgs e)
        {
            _cursorSize = _isVertical ? Width - 1 : Height - 1;
        }

        #endregion

        private void StartMoving()
        {
            _isMoving = true;

            // Le premier tick se fait en 1 milliseconde, les autres suivant l'intervalle
            TimerTickValue.Interval = 1;
            TimerTickValue.Start();
        }

        private void EndMoving()
        {
            _isMoving = false;
        }

        void TimerTickValue_Tick(object sender, EventArgs e)
        {
            // les ticks suivants se font avec l'intervalle voulu
            TimerTickValue.Interval = (int)IntervalTimer;

            if (_lastTickedValue != _value)
            {
                _lastTickedValue = _value;
                TickValueChanged?.Invoke(this, _value);
            }

            if (!_isMoving)
                TimerTickValue.Stop();
        }

        private void TrackBarPlus_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PaintBack(e.Graphics);
            PaintCursor(e.Graphics);
        }

        private void PaintBack(Graphics g)
        {
            GraphicsPath path = new GraphicsPath();
            int x, y, w, h;

            Brush b;

            if (_isVertical)
            {
                h = Height - 1;
                w = (int)(Width / 2.5);
                x = Width / 2 - w / 2;
                y = 0;

                path.AddLine(x + w - 1, y + w / 2 + 1, x + w - 1, y + h - w / 2 - 1);
                path.AddArc(new Rectangle(x + 1, y + h - w - 1, w - 2, w - 2), 0, 180);
                path.AddLine(x + 1, y + w - 1, x + 1, y + w / 2 + 1);
                path.AddArc(new Rectangle(x + 1, y + 1, w - 2, w - 2), 180, 180);

                if (_isReversed)
                    b = new LinearGradientBrush(new Rectangle(x, y, w, h), Color.Gainsboro, Color.White, LinearGradientMode.Vertical);
                else
                    b = new LinearGradientBrush(new Rectangle(x, y, w, h), Color.White, Color.Gainsboro, LinearGradientMode.Vertical);
            }
            else
            {
                h = (int)(Height / 2.5);
                w = Width - 1;
                x = 0;
                y = Height / 2 - h / 2;

                path.AddLine(x + h / 2 + 1, y + 1, x + w - h / 2 - 1, y + 1);
                path.AddArc(new Rectangle(x + w - h - 1, y + 1, h - 2, h - 2), -90, 180);
                path.AddLine(x + w - h / 2 - 1, y + h - 1, x + h / 2 + 1, y + h - 1);
                path.AddArc(new Rectangle(x + 1, y + 1, h - 2, h - 2), 90, 180);

                if (_isReversed)
                    b = new LinearGradientBrush(new Rectangle(x, y, w, h), Color.White, Color.Gainsboro, LinearGradientMode.Horizontal);
                else
                    b = new LinearGradientBrush(new Rectangle(x, y, w, h), Color.Gainsboro, Color.White, LinearGradientMode.Horizontal);
            }

            g.FillPath(b, path);
            b.Dispose();

            g.DrawPath(Pens.LightGray, path);

            path.Dispose();
        }

        private void PaintCursor(Graphics g)
        {
            Rectangle rBall;

            if (_isVertical)
            {
                int y;
                if (_isReversed)
                    y = (int)(((_value - _minValue) * (Height - 1 - _cursorSize)) / (_maxValue - _minValue));
                else
                    y = Height - _cursorSize - 1 - (int)(((_value - _minValue) * (Height - 1 - _cursorSize)) / (_maxValue - _minValue));

                rBall = new Rectangle(0, y, _cursorSize, _cursorSize);
            }
            else
            {
                int x;
                if (_isReversed)
                    x = Width - _cursorSize - 1 - (int)(((_value - _minValue) * (Width - 1 - _cursorSize)) / (_maxValue - _minValue));
                else
                    x = (int)(((_value - _minValue) * (Width - 1 - _cursorSize)) / (_maxValue - _minValue));

                rBall = new Rectangle(x, 0, _cursorSize, _cursorSize);
            }

            Brush bBall = new LinearGradientBrush(rBall, Color.WhiteSmoke, Color.LightGray, 100);
            g.FillEllipse(bBall, rBall);
            bBall.Dispose();

            g.DrawEllipse(Focused ? Pens.DodgerBlue : Pens.Gray, rBall);
        }

        private void SetCursorPosition(Point pos)
        {
            double val;

            if (!Vertical)
            {
                if (pos.X <= _cursorSize / 2)
                    val = (_isReversed) ? _maxValue : _minValue;
                else if (pos.X >= this.Width - _cursorSize / 2 - 1)
                    val = (_isReversed) ? _minValue : _maxValue;
                else
                {
                    val = _minValue + (_maxValue - _minValue) * (pos.X - _cursorSize / 2) / (float)(Width - 1 - _cursorSize);

                    if (_isReversed)
                        val = _maxValue - val + _minValue;
                }
            }
            else
            {
                if (pos.Y <= _cursorSize / 2)
                    val = (!_isReversed) ? _maxValue : _minValue;
                else if (pos.Y >= this.Height - _cursorSize / 2 - 1)
                    val = (!_isReversed) ? _minValue : _maxValue;
                else
                {
                    val = _minValue + (_maxValue - _minValue) * (pos.Y - _cursorSize / 2) / (float)(Height - 1 - _cursorSize);
                    if (!_isReversed)
                        val = _maxValue - val + _minValue;
                }
            }

            SetValue(val, false);
        }
    }
}
