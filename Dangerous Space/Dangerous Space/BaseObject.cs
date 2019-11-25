using System.Drawing;

namespace Dangerous_Space
{
    public abstract class BaseObject : ICollision
    {
        protected Point Dir;
        protected Point Pos;
        protected Size Size;

        public delegate void Message();

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();
        public abstract void Update();

        public bool Collision(ICollision obj) => obj.rect.IntersectsWith(this.rect);
        public Rectangle rect => new Rectangle(Pos,Size);
    }
}