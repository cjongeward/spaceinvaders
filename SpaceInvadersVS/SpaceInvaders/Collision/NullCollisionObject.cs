using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NullCollisionObject : CollisionObject
    {
        public NullCollisionObject() : base(0.0f,0.0f,0.0f,0.0f,new Azul.Color(0.0f,0.0f,0.0f))
        {
        }
        public override void updatePos(float _x, float _y)
        {
            // do nothing
        }
        public override void updateSize(float _w, float _h)
        {
            // do nothing
        }
        public override void copyRect(Rect _rect)
        {
            // do nothing
        }
    }
}
