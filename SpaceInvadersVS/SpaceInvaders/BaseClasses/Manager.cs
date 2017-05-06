using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Manager
    {
        private List active;
        private List reserve;
        private int numReserveDelta;
        protected Manager(int numReserve, int _numReserveDelta)
        {
            Debug.Assert(numReserve > -1);
            Debug.Assert(_numReserveDelta > -1);
            active = this.createActive();
            reserve = new LinkedList();
            this.fillPool(numReserve);
            this.numReserveDelta = _numReserveDelta;
        }
        protected abstract LinkNode getNodeObject();
        protected abstract List createActive();
        protected LinkNode baseGetReserveNode()
        {
            LinkNode outVal = null;
            if (this.reserve.getLength() == 0)
            {
                this.fillPool(numReserveDelta);
            }
            outVal = this.reserve.pop();
            return outVal;
        }
        private void fillPool(int num)
        {
            for (int i = 0; i < num; i++)
            {
                reserve.add(getNodeObject());
            }
        }
        protected void baseAdd(LinkNode node)
        {
            active.add(node);
        }
        protected LinkNode baseFind(Enum _name, Index _index = Index.INDEX_none)
        {
            return active.find(_name, _index);
        }
        protected LinkNode baseRemove(Enum _name, Index _index = Index.INDEX_none)
        {
            LinkNode node = active.remove(_name, _index);
            Debug.Assert(node != null);
            node.baseClear();
            reserve.add(node);
            return node;
        }
        protected LinkNode baseRemove(LinkNode l)
        {
            Debug.Assert(l != null);
            active.remove(l);
            l.baseClear();
            reserve.add(l);
            return l;
        }
        protected LinkNode baseGetHead()
        {
            return active.getHead();
        }
        protected int baseGetLength()
        {
            return active.getLength();
        }
    }
}
