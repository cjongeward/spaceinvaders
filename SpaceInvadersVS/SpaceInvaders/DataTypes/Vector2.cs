using System;

namespace SpaceInvaders
{
    class Vector2
    {
        public float x, y;
        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public Vector2(Vector2 _vec)
        {
            x = _vec.x;
            y = _vec.y;
        }
    }
}
