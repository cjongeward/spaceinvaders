using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class GameObjectCompositeRoot : CollisionVisitor
    {
        public GameObjectCompositeRoot next;
        public Boolean wallCol;
        protected float direction;
        protected CollisionObject pColObject;
        protected GameObject.Name name;
        private Index index;
        public GameObjectCompositeRoot(GameObject.Name _name, Index _index, CollisionObject _colObj)
        {
            next = null;
            this.name = _name;
            this.index = _index;
            this.direction = 1.0f;
            this.wallCol = false;
            this.pColObject = _colObj;
        }
        public CollisionSprite getCollisionSprite()
        {
            return pColObject.getCollisionSprite();
        }
        public Enum getName()
        {
            return this.name;
        }
        public Index getIndex()
        {
            return this.index;
        }
        public Rect getBoundingVol()
        {
            return this.pColObject.getRect();
        }
        public void setCollisionObject(CollisionObject _col)
        {
            this.pColObject = _col;
        }
        public void removeMe()
        {
            this.removeMySprite();
            SpriteManager.find(SpriteGroup.Name.boundingBoxes).remove(this.getCollisionSprite());
            ColSpriteManager.remove(this.getCollisionSprite());
            GameObjectManager.remove(this);
        }
        public abstract void remove(GameObjectCompositeRoot _go);
        public abstract void removeMySprite();
        public abstract void move(float _x, float _y);
        public abstract void update();
        public abstract bool isEmpty();
        public abstract GameSpriteFlyweight getGameSpriteFlyweight();
    }
}
