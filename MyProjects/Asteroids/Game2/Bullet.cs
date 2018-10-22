using System.Drawing;

namespace Game2
{
    // Класс со свойствам объекта "Bullet"
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 10;

        }

        public override void Reset()
        {
            Pos.X = 0;
            Pos.Y = Game.Height / 2;
        }
    }
}
