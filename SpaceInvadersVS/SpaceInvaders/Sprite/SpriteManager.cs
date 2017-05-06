using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteManager : Manager
    {
        public SpriteManager() : base(5, 5)
        {
        }
        protected override LinkNode getNodeObject()
        {
            return new SpriteGroup(10, 5);
        }
        protected override List createActive()
        {
            return new LinkedList();
        }
        public static SpriteGroup add(SpriteGroup.Name _groupName)
        {
            SpriteManager inst = SceneManager.getSpriteManager();
            SpriteGroup node = (SpriteGroup)(inst.baseFind(_groupName));
            if (node == null)
            {
                node = (SpriteGroup)(inst.baseGetReserveNode());
                node.initialize(_groupName);
            }
            inst.baseAdd(node);
            return node;
        }
        public static SpriteGroup find(SpriteGroup.Name _name)
        {
            SpriteManager inst = SceneManager.getSpriteManager();
            SpriteGroup node = (SpriteGroup)inst.baseFind(_name);
            Debug.Assert(node != null);
            return node;
        }
        public static void remove(SpriteGroup.Name _name)
        {
            SpriteManager inst = SceneManager.getSpriteManager();
            inst.baseRemove(_name);
        }
        public static void draw()
        {
            SpriteManager inst = SceneManager.getSpriteManager();
            SpriteGroup current = (SpriteGroup)(inst.baseGetHead());
            while (current != null)
            {
                ((SpriteGroup)current).draw();
                current = (SpriteGroup)(current.getNext());
            }
        }

    }
}
