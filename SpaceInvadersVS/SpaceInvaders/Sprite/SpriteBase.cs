using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class SpriteBase : LinkNode
    {
        public SpriteBase() : base() { }
        public abstract void Draw();
    }
}
