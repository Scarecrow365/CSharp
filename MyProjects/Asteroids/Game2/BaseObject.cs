using System.Drawing;

namespace Game2
{
    // Базовый класс с общими параметрами
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public delegate void Message();
        public abstract void Draw();
        public abstract void Update();
        public virtual void Reset()
        {
            Pos.X = -Size.Width;
        }
        public virtual void Move(int delta)
        {
            Pos.Y = Pos.Y - delta;
        }
        public Rectangle Rect => new Rectangle(Pos, Size);
        public bool Collision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
