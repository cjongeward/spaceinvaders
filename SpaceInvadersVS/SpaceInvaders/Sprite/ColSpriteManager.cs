using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColSpriteManager : Manager
    {
        public ColSpriteManager() : base(20, 5)
        {
        }
        protected override LinkNode getNodeObject()
        {
            return new CollisionSprite();
        }
        protected override List createActive()
        {
            return new LinkedList();
        }
        public static CollisionSprite add(CollisionSprite.Name _goname, Index _index, Rect _rect)
        {
            Debug.Assert(_rect != null);
            ColSpriteManager inst = SceneManager.getColSpriteManager();
            CollisionSprite node = (CollisionSprite)(inst.baseGetReserveNode());
            node.initialize(_goname, _rect);
            inst.baseAdd(node);
            return node;
        }
        public static CollisionSprite find(CollisionSprite.Name name, Index _index = Index.INDEX_none)
        {
            ColSpriteManager inst = SceneManager.getColSpriteManager();
            CollisionSprite i = (CollisionSprite)inst.baseFind(name, _index);
            Debug.Assert(i != null);
            return i;
        }
        public static void remove(CollisionSprite.Name name, Index _index = Index.INDEX_none)
        {
            ColSpriteManager inst = SceneManager.getColSpriteManager();
            inst.baseRemove(name);
        }
        public static void remove(CollisionSprite cs)
        {
            ColSpriteManager inst = SceneManager.getColSpriteManager();
            //remove node 
            // TODO - move to base class
            LinkNode l = inst.baseGetHead();
            while (l != null)
            {
                if ((CollisionSprite)l == cs)
                {
                    inst.baseRemove(l);
                }
                l = l.getNext();
            }
        }
    }
}
