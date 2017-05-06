using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class CollisionObserver : LinkNode
    {
        protected CollisionSubject mySubject;
        public override void clear()
        {
            mySubject = null;
        }
        public CollisionSubject getSubject()
        {
            return this.mySubject;
        }
        public void setSubject(CollisionSubject _subject)
        {
            this.mySubject = _subject;
        }

        public abstract void notify();

        public override Enum getName()
        {
            return null;
        }
        public override Enum getIndex()
        {
            return Index.INDEX_none;
        }
    }
}
