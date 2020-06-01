using Geometry;
using Geometry.Shapes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class WorldPanel : PictureBox
    {
        private RealPoint _pointClicked, _centerAtStart;
        private WorldScale _scaleAtStart;

        public WorldDimensions Dimensions { get; protected set; }

        public delegate void WorldChangeDelegate();
        public event WorldChangeDelegate WorldChange;

        public delegate void StartMoveDelegate();
        public event StartMoveDelegate StartMove;

        public delegate void StopMoveDelegate();
        public event StopMoveDelegate StopMove;

        public WorldPanel()
        {
            InitializeComponent();
            Dimensions = new WorldDimensions();
            Dimensions.WorldChange += Dimensions_WorldChange;
            _pointClicked = null;
        }

        public bool Moving
        {
            get
            {
                return _pointClicked != null;
            }
        }

        public RealPoint ClickedPoint
        {
            get
            {
                return _pointClicked;
            }
        }

        protected void OnWorldChange()
        {
            WorldChange?.Invoke();
        }

        protected void OnStartMove()
        {
            StartMove?.Invoke();
        }

        protected void OnStopMove()
        {
            StopMove?.Invoke();
        }

        public WorldPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Dimensions = new WorldDimensions();
            Dimensions.WorldChange += Dimensions_WorldChange;
            _pointClicked = null;
        }

        private void Dimensions_WorldChange()
        {
            OnWorldChange();
        }

        private void WorldPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _pointClicked = Dimensions.WorldScale.ScreenToRealPosition(e.Location);
            _centerAtStart = Dimensions.WorldRect.Center();
            _scaleAtStart = new WorldScale(Dimensions.WorldScale);

            OnStartMove();
        }

        private void WorldPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_pointClicked != null)
            {
                RealPoint newMousePosition = _scaleAtStart.ScreenToRealPosition(e.Location);

                RealPoint delta = _pointClicked - newMousePosition;

                Dimensions.SetWorldCenter(_centerAtStart + delta);
            }
        }

        private void WorldPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _pointClicked = null;

            OnStopMove();
        }

        private void WorldPanel_SizeChanged(object sender, System.EventArgs e)
        {
            Dimensions.SetScreenSize(this.Size);
        }
    }
}
