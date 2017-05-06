using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Alien : GameObject
    {
        private int value;
        public Alien(GameObject.Name _name, Index _index, GameSpriteFlyweight _gameSprite, CollisionObject _colObj)
            : base(_name, _index, _gameSprite, _colObj, _gameSprite.getPos().x, _gameSprite.getPos().y)
        {
            switch (_name)
            {
                case GameObject.Name.squid:
                    value = 30;
                    break;
                case GameObject.Name.crab:
                    value = 20;
                    break;
                case GameObject.Name.octopus:
                    value = 10;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
        public int getValue()
        {
            return value;
        }
        public override void removeMySprite()
        {
            SpriteManager.find(SpriteGroup.Name.aliens).remove(this.getGameSpriteFlyweight());
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
                other.visitAlien(this);
            }
        }
        public override void visitShield(ShieldChunk shield)
        {
            Debug.Assert(shield != null);
            ColPair pColPair = ColPairManager.find(ColPair.Name.alien_shield);
            pColPair.notifyObservers(this, shield);
        }
        public void explode()
        {
            this.setGameSprite(GameSpriteManager.find(GameSprite.Name.alien_explode));
        }
    }
}
