using System;
using System.Drawing;

namespace Game2
{
    // Класс со свойствам объекта "Asteroid"
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
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
