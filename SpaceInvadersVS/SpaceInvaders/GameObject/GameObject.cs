using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class GameObject : GameObjectCompositeRoot
    {
        public enum Name
        {
            octopus,
            squid,
            crab,
            alien_col,
            alien_grid,
            bullet,
            bomb,
            player,
            ceiling,
            floor,
            lwall,
            rwall,
            shield_chunk,
            shield,
            shield_group,
            not_initialized
        }
        private GameSpriteFlyweight gameSpriteFlyweight;
        protected Vector2 pos;

        public GameObject(GameObject.Name _name, Index _index, GameSpriteFlyweight _gameSprite, CollisionObject _colObj, float initX, float initY)
            : base(_name, _index, _colObj)
        {
            this.gameSpriteFlyweight = _gameSprite;
            this.pos = new Vector2(_gameSprite.getPos().x, _gameSprite.getPos().y);
            this.pos.x = initX;
            this.pos.y = initY;
        } 
        public override GameSpriteFlyweight getGameSpriteFlyweight()
        {
            return this.gameSpriteFlyweight;
        }
        public void setGameSprite( GameSprite _gamesprite)
        {
            this.gameSpriteFlyweight = _gamesprite.getFlyWeight();
        }
        public Vector2 getPos()
        {
            return pos;
        }
        public override void update()
        {
            Debug.Assert(this.gameSpriteFlyweight != null);
            this.gameSpriteFlyweight.setPos(this.pos);
            this.pColObject.updatePos(this.pos.x, this.pos.y);
        }
        public override void move(float _x, float _y)
        {
            this.pos.x += _x;
            this.pos.y += _y;
        }
        public override void remove(GameObjectCompositeRoot _go)
        {
            // do nothing
        }
        public override bool isEmpty()
        {
            return false;
        }
    }
}
