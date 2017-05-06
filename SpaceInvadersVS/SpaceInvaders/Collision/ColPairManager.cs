using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColPairManager : Manager
    {
        public ColPairManager() : base(10, 5)
        {
        }
        protected override LinkNode getNodeObject()
        {
            return new ColPair();
        }
        protected override List createActive()
        {
            return new LinkedList();
        }
        public static ColPair add(ColPair.Name _name, Index _index, GameObjectCompositeRoot pList1, GameObjectCompositeRoot pList2)
        {
            Debug.Assert(pList1 != null);
            Debug.Assert(pList2 != null);
            ColPairManager inst = SceneManager.getColPairManager();
            ColPair node = (ColPair)(inst.baseGetReserveNode());
            node.initialize(_name, _index, pList1, pList2);
            inst.baseAdd(node);
            return node;
        }
        public static ColPair find(ColPair.Name name, Index _index = Index.INDEX_none)
        {
            ColPairManager inst = SceneManager.getColPairManager();
            ColPair i = (ColPair)inst.baseFind(name, _index);
            Debug.Assert(i != null);
            return i;
        }
        public static void remove(ColPair.Name name, Index _index = Index.INDEX_none)
        {
            ColPairManager inst = SceneManager.getColPairManager();
            inst.baseRemove(name);
        }
        public static void remove(ColPair.Name name, GameObjectCompositeRoot goc)
        {
            ColPairManager inst = SceneManager.getColPairManager();
            ColPair cp = (ColPair)inst.baseFind(name);
            cp.remove(goc);
            if (cp.getList1() == null || cp.getList2() == null)
            {
                ColPairManager.remove(name);
            }
        }
        public static void process()
        {
            ColPairManager inst = SceneManager.getColPairManager();
            ColPair current = (ColPair)inst.baseGetHead();
            while (current != null)
            {
                current.process();
                current = (ColPair)current.getNext();
            }
        }
    }
}
