using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldChunk : GameObject
    {
        public ShieldChunk(GameObject.Name _name, Index _index, GameSpriteFlyweight _gameSprite, CollisionObject _colObj)
            : base(_name, _index, _gameSprite, _colObj, _gameSprite.getPos().x, _gameSprite.getPos().y)
        {
        }
        public override void removeMySprite()
        {
            SpriteManager.find(SpriteGroup.Name.shields).remove(this.getGameSpriteFlyweight());
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
                other.visitShield(this);
            }
        }
    }
}
