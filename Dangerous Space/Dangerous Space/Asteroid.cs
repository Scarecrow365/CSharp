using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dangerous_Space
{
    internal class Asteroid : BaseObject, IComparable
    {
        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawImage(Image.FromFile($@"{Application.StartupPath}\Resources\Asteroid.png"), Pos.X,
            //    Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.widthPlayingField) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.heightPlayingField) Dir.Y = -Dir.Y;
        }
        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }
    }
}