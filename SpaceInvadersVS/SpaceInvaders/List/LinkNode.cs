using System;

namespace SpaceInvaders
{
    abstract class LinkNode
    {
        public LinkNode next;
        public LinkNode prev;
        public float priority;
        public LinkNode()
        {
            this.next = null;
            this.prev = null;
            this.priority = 0.0f;
        }
        public LinkNode getNext()
        {
            return next;
        }
        public void setNext(LinkNode _next)
        {
            next = _next;
        }
        public LinkNode getPrev()
        {
            return prev;
        }
        public void setPrev(LinkNode _prev)
        {
            prev = _prev;
        }
        public void baseClear()
        {
            next = null;
            prev = null;
            this.clear();
        }
        public abstract Enum getName();
        public abstract Enum getIndex();
        public abstract void clear();
    }
}
