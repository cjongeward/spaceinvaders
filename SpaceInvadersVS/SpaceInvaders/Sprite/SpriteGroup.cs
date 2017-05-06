using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteGroup : LinkNode
    {
        public enum Name
        {
            aliens,
            boundingBoxes,
            shields,
            player,
            bullets,
            bombs,
            alien_explode,
            player_explode,
            not_initialized
        }
        private bool drawme;
        private List active;
        private List reserve;
        private int numReserveDelta;
        private SpriteGroup.Name name;
        private Index index;
        public SpriteGroup(int numReserve, int _numReserveDelta)
            : base()
        {
            Debug.Assert(numReserve > -1);
            Debug.Assert(_numReserveDelta > -1);
            this.active = new LinkedList();
            this.reserve = new LinkedList();
            this.fillPool(numReserve);
            this.numReserveDelta = _numReserveDelta;
            this.name = SpriteGroup.Name.not_initialized;
            this.index = Index.INDEX_none;
            this.drawme = true;
        }
        public override void clear()
        {
            //do nothing
        }
        public void shouldDraw(bool _drawme)
        {
            drawme = _drawme;
        }
        public void shouldDraw()
        {
            drawme = !drawme;
        }
        public void initialize(SpriteGroup.Name _groupName)
        {
            name = _groupName;
        }
        override public Enum getName()
        {
            return this.name;
        }
        override public Enum getIndex()
        {
            return this.index;
        }
        private void fillPool(int num)
        {
            for (int i = 0; i < num; i++)
            {
                this.reserve.add(new SpriteNode());
            }
        }
        public void attach(SpriteBase _spritebase)
        {
            Debug.Assert(_spritebase != null);
            SpriteNode node = this.getReserveNode();
            node.initialize(_spritebase);
            active.add(node);
        }
        private SpriteNode getReserveNode()
        {
            if (this.reserve.getLength() == 0)
            {
                this.fillPool(numReserveDelta);
            }
            return (SpriteNode)(this.reserve.pop());
        }
        public SpriteNode find(GameSprite.Name _name, Index _index)
        {
            //SpriteNode node = (SpriteNode)(active.find(_name, _index));
            //Debug.Assert(node != null);
            //return node;
            // TODO - no one calls this method.  Commented out to implement SpriteBase
            Debug.Assert(false);
            return new SpriteNode();
        }
        public void remove(GameSprite.Name _name, Index _index)
        {
            //SpriteNode node = (SpriteNode)(active.remove(_name, _index));
            //Debug.Assert(node != null);
            //reserve.add(node);
            // TODO - no one calls this method.  Commented out to implement SpriteBase
            Debug.Assert(false);
        }
        public void remove(SpriteBase sb)
        {
            //remove node 
            // TODO - move to base class
            LinkNode l = this.active.getHead();
            while (l != null)
            {
                if (((SpriteNode)l).getSpriteBase() == sb)
                {
                    this.active.remove(l);
                }
                l = l.getNext();
            }
        }
        public void draw()
        {
            if (drawme)
            {
                LinkNode current = this.active.getHead();
                while (current != null)
                {
                    ((SpriteNode)current).draw();
                    current = current.getNext();
                }
            }
        }

    }
}
