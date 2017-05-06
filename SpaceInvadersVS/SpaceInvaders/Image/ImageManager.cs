using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageManager : Manager
    {
        private static ImageManager instance;
        private ImageManager() : base(20, 5)
        {
        }
        private static ImageManager getInstance()
        {
            if(instance == null)
            {
                instance = new ImageManager();
            }
            return instance;
        }
        protected override LinkNode getNodeObject()
        {
            return new ImageNode();
        }
        protected override List createActive()
        {
            return new LinkedList();
        }
        public static void add(ImageNode.Name name, TextureNode texture, Azul.Rect rect)
        {
            Debug.Assert(texture != null);
            Debug.Assert(rect != null);
            ImageManager inst = getInstance();
            ImageNode node = (ImageNode)(inst.baseGetReserveNode());
            node.initialize(name, texture, rect);
            inst.baseAdd(node);
        }
        public static ImageNode find(ImageNode.Name name)
        {
            ImageManager inst = getInstance();
            ImageNode i = (ImageNode)inst.baseFind(name);
            Debug.Assert(i != null);
            return i;
        }
        public static void remove(ImageNode.Name name)
        {
            ImageManager inst = getInstance();
            inst.baseRemove(name);
        }


    }
}
