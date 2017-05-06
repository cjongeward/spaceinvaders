using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class CollisionVisitor
    {
        public virtual void visitAlien(Alien alien)
        {
            Debug.Assert(false);
        }
        public virtual void visitBullet(Bullet bullet)
        {
            Debug.Assert(false);
        }
        public virtual void visitBomb(Bomb bomb)
        {
            Debug.Assert(false);
        }
        public virtual void visitPlayer(Player player)
        {
            Debug.Assert(false);
        }
        public virtual void visitWall(Wall wall)
        {
            Debug.Assert(false);
        }
        public virtual void visitShield(ShieldChunk shield)
        {
            Debug.Assert(false);
        }
        public abstract void accept(CollisionVisitor other);
    }
}
