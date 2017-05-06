using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextureManager : Manager
    {
        private static TextureManager instance;
        private TextureManager() : base(1,1)
        {
        }
        private static TextureManager getInstance()
        {
            if(instance == null)
            {
                instance = new TextureManager();
            }
            return instance;
        }
        protected override LinkNode getNodeObject()
        {
            return new TextureNode();
        }
        protected override List createActive()
        {
            return new LinkedList();
        }
        public static void add(TextureNode.Name name, String image)
        {
            Debug.Assert(image != null);
            Debug.Assert(image.Length > 0);
            TextureManager inst = getInstance();
            TextureNode node = (TextureNode)(inst.baseGetReserveNode());
            node.initialize(name, image);
            inst.baseAdd(node);
        }
        public static TextureNode find(TextureNode.Name name)
        {
            TextureManager inst = getInstance();
            TextureNode t = (TextureNode)inst.baseFind(name);
            Debug.Assert(t != null);
            return t;
        }
        public static void remove(TextureNode.Name name)
        {
            TextureManager inst = getInstance();
            inst.baseRemove(name);
        }

    }
}
