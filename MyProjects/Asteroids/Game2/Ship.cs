using System.Drawing;

namespace Game2
{
    // Класс со свойствам объекта "Ship"
    class Ship : BaseObject
    {
        private int energy = 100;
        public int Energy => energy;
        public void EnergyUp(int n)

        {
            energy += n;
        }

        public void EnergyLow(int n)
        {
            energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.Purple, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public static event Message MessageDie;
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
