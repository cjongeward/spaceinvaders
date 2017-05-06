using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Bomb : GameObject
    {
        public Bomb(GameObject.Name _name, Index _index, GameSpriteFlyweight _gameSprite, CollisionObject _colObj)
            : base(_name, _index, _gameSprite, _colObj, _gameSprite.getPos().x, _gameSprite.getPos().y)
        {
        }
        public override void removeMySprite()
        {
            SpriteManager.find(SpriteGroup.Name.bombs).remove(this.getGameSpriteFlyweight());
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
                other.visitBomb(this);
            }
        }
        public override void visitPlayer(Player player)
        {
            Debug.Assert(player != null);

            ColPair pColPair = ColPairManager.find(ColPair.Name.player_bomb);
            pColPair.notifyObservers(this, player);
        }
        public override void visitShield(ShieldChunk shield)
        {
            Debug.Assert(shield != null);

            ColPair pColPair = ColPairManager.find(ColPair.Name.bomb_shield);
            pColPair.notifyObservers(this, shield);
        }
        public override void update()
        {
            this.pos.y -= Constants.BOMB_SPEED;
            base.update();
        }
    }
}
