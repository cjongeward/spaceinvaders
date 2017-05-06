using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionObject
    {
        protected CollisionSprite pColSprite;
        protected Rect pRect;
        public CollisionObject(float _x, float _y, float _width, float _height, Azul.Color _color)
        {
            this.pRect = new Rect(_color);
            this.pRect.setSize(_width, _height);
            this.updatePos(_x, _y);
            this.pColSprite = ColSpriteManager.add(CollisionSprite.Name.alien, Index.INDEX_none, this.pRect);
            SpriteGroup sg = SpriteManager.find(SpriteGroup.Name.boundingBoxes);
            Debug.Assert(sg != null);
            sg.attach(this.pColSprite);
        }
        public CollisionSprite getCollisionSprite()
        {
            return pColSprite;
        }
        public virtual void updatePos(float _x, float _y)
        {
            this.pRect.setPos(_x - this.pRect.getSize().x / 2.0f, _y - this.pRect.getSize().y / 2.0f);
        }
        public virtual void updateSize(float _w, float _h)
        {
            this.pRect.setSize(_w, _h);
        }
        public virtual void copyRect(Rect _rect)
        {
            pRect.setPos(_rect.getPos());
            pRect.setSize(_rect.getSize());
        }
        public Rect getRect()
        {
            return pRect;
        }
    }
}
