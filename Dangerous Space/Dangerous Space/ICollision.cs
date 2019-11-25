using System.Drawing;

namespace Dangerous_Space
{
    public interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle rect { get; }
    }
}
