using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectComposite : GameObjectCompositeRoot
    {
        public GameObjectCompositeRoot head;
        public GameObjectComposite(GameObject.Name _name, CollisionObject _co)
            : base(_name, Index.INDEX_none, _co)
        {
            head = null;
        } 
        public override void removeMySprite()
        {
            // do nothing
        }
        public void add(GameObjectCompositeRoot _g)
        {
            Debug.Assert(_g != null);
            if (head == null)
            {
                head = _g;
            }
            else
            {
                GameObjectCompositeRoot current = this.head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = _g;
            }
        }
        public override void remove(GameObjectCompositeRoot _g)
        {
            Debug.Assert(_g != null);
            if (this.head != null)
            {
                this.head.remove(_g);
                if (this.head.isEmpty())
                {
                    SpriteManager.find(SpriteGroup.Name.boundingBoxes).remove(this.head.getCollisionSprite());
                }
                if (this.head.Equals(_g) || this.head.isEmpty())
                {
                    GameObjectCompositeRoot temp = this.head.next;
                    this.head = temp;
                }
                else
                {
                    GameObjectCompositeRoot current = this.head;
                    while (current.next != null)
                    {
                        current.next.remove(_g);
                        if (current.next.isEmpty())
                        {
                            SpriteManager.find(SpriteGroup.Name.boundingBoxes).remove(current.next.getCollisionSprite());
                        }

                        if (current.next.Equals(_g) || current.next.isEmpty())
                        {
                            current.next = current.next.next;
                            break;
                        }
                        current = current.next;
                    }
                }
            }
        }
        public override void move(float _x, float _y)
        {
            GameObjectCompositeRoot current = this.head;
            while (current != null)
            {
                current.move(_x, _y);
                current = current.next;
            }
        }
        public override void update()
        {
            GameObjectCompositeRoot current = this.head;
            if (current != null)
            {
                current.update();
                pColObject.copyRect(current.getBoundingVol());
                current = current.next;
                while (current != null)
                {
                    current.update();
                    pColObject.getRect().union(current.getBoundingVol());
                    current = current.next;
                }
            }
        }
        public override void accept(CollisionVisitor other)
        {
            Rect r1;
            Rect r2 = ((GameObjectCompositeRoot)other).getBoundingVol();
            Debug.Assert(r2 != null);
            GameObjectCompositeRoot current = this.head;
            if (current != null)
            {
                while (current != null)
                {
                    r1 = current.getBoundingVol();
                    if (r1.intersects(r2))
                    {
                        current.accept(other);
                    }
                    current = current.next;
                }
            }
        }
        public override bool isEmpty()
        {
            return this.head == null;
        }
        public override GameSpriteFlyweight getGameSpriteFlyweight()
        {
            return null;
        }
    }
}
