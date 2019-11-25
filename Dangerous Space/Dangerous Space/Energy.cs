using System.Drawing;

namespace Dangerous_Space
{
    class Energy : BaseObject
    {
        public Energy(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.GreenYellow, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
        }
    }
}
