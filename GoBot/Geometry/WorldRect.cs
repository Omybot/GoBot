using System.Drawing;

using Geometry.Shapes;

namespace Geometry
{
    public class WorldDimensions
    {
        private Size _screenSize;

        public WorldScale WorldScale { get; protected set; }
        public RectangleF WorldRect { get; protected set; }

        public delegate void WorldChangeDelegate();
        public event WorldChangeDelegate WorldChange;

        public WorldDimensions()
        {
            WorldScale = new WorldScale(5, 0, 0);
            WorldRect = new RectangleF();
        }

        public void SetScreenSize(Size size)
        {
            WorldRect = WorldRect.ExpandWidth(WorldScale.ScreenToRealDistance(size.Width));
            WorldRect = WorldRect.ExpandHeight(WorldScale.ScreenToRealDistance(size.Height));
            _screenSize = size;

            WorldChange?.Invoke();
        }

        public void SetZoomFactor(double mmPerPixel)
        {
            RealPoint center = WorldRect.Center();

            WorldRect = WorldRect.ExpandWidth(WorldRect.Width * (mmPerPixel / WorldScale.Factor));
            WorldRect = WorldRect.ExpandHeight(WorldRect.Height * (mmPerPixel / WorldScale.Factor));

            WorldScale = new WorldScale(mmPerPixel, (int)(-WorldRect.X / mmPerPixel), (int)(-WorldRect.Y / mmPerPixel));

            WorldChange?.Invoke();
        }

        public void SetWorldCenter(RealPoint center)
        {
            WorldRect = WorldRect.SetCenter(center);
            WorldScale = new WorldScale(WorldScale.Factor, -WorldScale.RealToScreenDistance(WorldRect.X), -WorldScale.RealToScreenDistance(WorldRect.Y));

            WorldChange?.Invoke();
        }
    }
}
