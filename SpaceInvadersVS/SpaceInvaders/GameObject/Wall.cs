using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Wall : GameObject
    {
        public Wall(GameObject.Name _name, Index _index, GameSpriteFlyweight _gameSprite, CollisionObject _colObj)
            : base(_name, _index, _gameSprite, _colObj, _colObj.getRect().getPos().x, _colObj.getRect().getPos().y)
        {
        }
        public override void removeMySprite()
        {
            //do nothing
        }
        public override void accept(CollisionVisitor other)
        {
            Debug.Assert(other != null);
            if (other is GameObjectComposite)
            {
                other.accept(this);
            }
            else
            {
                other.visitWall(this);
            }
        }
        public override void visitBullet(Bullet bullet)
        {
            Debug.Assert(bullet != null);
            ColPair pColPair = ColPairManager.find(ColPair.Name.bullet_ceiling);
            pColPair.notifyObservers(this, bullet);
        }
        public override void visitBomb(Bomb bomb)
        {
            Debug.Assert(bomb != null);
            ColPair pColPair = ColPairManager.find(ColPair.Name.bomb_floor);
            pColPair.notifyObservers(this, bomb);
        }
        public override void visitAlien(Alien alien)
        {
            Debug.Assert(alien != null);

            ColPair pColPair = ColPairManager.find(ColPair.Name.alien_rwall);
            pColPair.notifyObservers(this, alien);
        }
    }
}
