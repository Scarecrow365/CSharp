using System;
using System.Drawing;

namespace Dangerous_Space
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;

        public static event Message MessageDie;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Brown, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawImage(Image.FromFile($@"{Application.StartupPath}\Resources\Spaceship.png"), Pos.X,
            //    Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }

        public void Up()
        {
            if (Pos.Y > 0)
                Pos.Y -= Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < (Game.heightPlayingField - Size.Height))
                Pos.Y += Dir.Y;
        }

        public void GetDamage(int i)
        {
            _energy -= i;
            if (_energy < 1)
                Die();
            if (_energy > 100)
                _energy = 100;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
