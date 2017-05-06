using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSubject
    {
        private LinkedList observerList;
        public GameObjectCompositeRoot obj1, obj2;
        public CollisionSubject()
        {
            this.observerList = new LinkedList();
            this.obj1 = null;
            this.obj2 = null;
        }
        public void clear()
        {
            this.obj1 = this.obj2 = null;
            this.observerList.clear();
        }
        public void attachObserver(CollisionObserver _obs)
        {
            Debug.Assert(_obs != null);
            _obs.setSubject(this);
            this.observerList.add(_obs);
        }
        public void notifyObservers(GameObjectCompositeRoot _gobj1, GameObjectCompositeRoot _gobj2)
        {
            this.obj1 = _gobj1;
            this.obj2 = _gobj2;
            LinkNode current = this.observerList.getHead();
            while (current != null)
            {
                ((CollisionObserver)current).notify();
                current = current.getNext();
            }
        }
    }
}
