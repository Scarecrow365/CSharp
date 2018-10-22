using System;
using System.Drawing;

namespace Game2
{
    // Класс со свойствам объекта "Heal"
    class Heal : BaseObject
    {

        public Heal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.Green, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Dir.X > 0 && Pos.X > Game.Width) Pos.X = -Size.Width;
            if (Dir.X < 0 && Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

        public override void Reset()
        {
            Pos.X = Game.Width + Size.Width;
            Random rnd = new Random();
            Pos.Y = rnd.Next(0, Game.Height);
        }
    }
}
