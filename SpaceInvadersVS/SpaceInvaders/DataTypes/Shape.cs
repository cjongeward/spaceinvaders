using System;

namespace SpaceInvaders
{
    abstract class Shape
    {
        abstract public void Draw();
        abstract public bool intersects(Shape _other);
    }
}
