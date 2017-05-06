using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Bullet : GameObject
    {
        public Bullet(GameObject.Name _name, Index _index, GameSpriteFlyweight _gameSprite, CollisionObject _colObj)
            : base(_name, _index, _gameSprite, _colObj, _gameSprite.getPos().x, _gameSprite.getPos().y)
        {
        }
        public override void removeMySprite()
        {
            SpriteManager.find(SpriteGroup.Name.bullets).remove(this.getGameSpriteFlyweight());
        }
        public override void accept(CollisionVisitor other)
        {
            Debug.Assert(other != null);
            //really crappy way of traversing the other game object composite
            if (other is GameObjectComposite)
            {
                other.accept(this);
            }
            else
            {
                other.visitBullet(this);
            }
        }
        public override void visitAlien(Alien alien)
        {
            Debug.Assert(alien != null);

            ColPair pColPair = ColPairManager.find(ColPair.Name.alien_bullet);
            pColPair.notifyObservers(this, alien);
        }
        public override void visitShield(ShieldChunk shield)
        {
            Debug.Assert(shield != null);

            ColPair pColPair = ColPairManager.find(ColPair.Name.bullet_shield);
            pColPair.notifyObservers(this, shield);
        }
        public override void update()
        {
            this.pos.y += Constants.BULLET_SPEED;
            base.update();
        }
    }
}
