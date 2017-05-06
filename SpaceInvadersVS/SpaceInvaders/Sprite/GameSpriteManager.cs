using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameSpriteManager : Manager
    {
        private GameSprite nullObject;
        public GameSpriteManager() : base(30, 5)
        {
            nullObject = new NullGameSprite();
        }
        protected override LinkNode getNodeObject()
        {
            return new GameSprite();
        }
        protected override List createActive()
        {
            return new LinkedList();
        }
        public static GameSprite getNullObject()
        {
            GameSpriteManager inst = SceneManager.getGameSpriteManager();
            return inst.nullObject;
        }
        public static GameSprite add(GameSprite.Name _name, ImageNode _image, Azul.Rect _size)
        {
            return add(_name, Index.INDEX_none, _image, _size);
        }
        public static GameSprite add(GameSprite.Name _name, Index _index, ImageNode _image, Azul.Rect _size)
        {
            Debug.Assert(_image != null);
            Debug.Assert(_size != null);
            GameSpriteManager inst = SceneManager.getGameSpriteManager();
            GameSprite node = (GameSprite)(inst.baseGetReserveNode());
            node.initialize(_name, _index, _image, _size);
            inst.baseAdd(node);
            return node;
        }
        public static GameSprite find(GameSprite.Name name, Index _index = Index.INDEX_none)
        {
            GameSpriteManager inst = SceneManager.getGameSpriteManager();
            GameSprite i = (GameSprite)inst.baseFind(name, _index);
//            Debug.Assert(i != null);
            return i;
        }
        public static void remove(GameSprite.Name name, Index _index = Index.INDEX_none)
        {
            GameSpriteManager inst = SceneManager.getGameSpriteManager();
            inst.baseRemove(name, _index);
        }
    }
}
