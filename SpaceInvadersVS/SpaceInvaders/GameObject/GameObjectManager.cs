using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectManager : Manager
    {
        public GameObjectManager() : base(20, 5)
        {
        }
        protected override LinkNode getNodeObject()
        {
            return new GameObjectNode();
        }
        protected override List createActive()
        {
            return new LinkedList();
        }
        public static void add(GameObjectCompositeRoot _goc)
        {
            GameObjectManager inst = SceneManager.getGameObjectManager();
            GameObjectNode node = (GameObjectNode)(inst.baseGetReserveNode());
            node.initialize(_goc);
            inst.baseAdd(node);
        }
        public static GameObjectCompositeRoot add(GameObject.Name _goname, Index _index, GameSpriteFlyweight g1, CollisionObject c1)
        {
            Debug.Assert(g1 != null);
            GameObjectManager inst = SceneManager.getGameObjectManager();
            GameObjectNode node = (GameObjectNode)(inst.baseGetReserveNode());
            //TODO - make a factory
            GameObjectCompositeRoot _go = null;
            switch(_goname)
            {
                case GameObject.Name.crab:
                case GameObject.Name.octopus:
                case GameObject.Name.squid:
                    _go = new Alien(_goname, _index, g1, c1);
                    break;
                case GameObject.Name.alien_grid:
                    _go = new GameObjectComposite(_goname, c1);
                    break;
                case GameObject.Name.bullet:
                    _go = new Bullet(_goname, _index, g1, c1);
                    break;
                case GameObject.Name.bomb:
                    _go = new Bomb(_goname, _index, g1, c1);
                    break;
                case GameObject.Name.player:
                    _go = new Player(_goname, _index, g1, c1);
                    break;
                case GameObject.Name.ceiling:
                case GameObject.Name.floor:
                case GameObject.Name.lwall:
                case GameObject.Name.rwall:
                    _go = new Wall(_goname, _index, g1, c1);
                    break;
                case GameObject.Name.shield:
                    _go = new ShieldChunk(_goname, _index, g1, c1);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            Debug.Assert(_go != null);
            node.initialize(_go);
            inst.baseAdd(node);
            return _go;
        }
        public static GameObjectCompositeRoot find(GameObject.Name name, Index _index = Index.INDEX_none)
        {
            GameObjectManager inst = SceneManager.getGameObjectManager();
            GameObjectNode i = (GameObjectNode)inst.baseFind(name, _index);
            GameObjectCompositeRoot ret = null;
            if (i != null)
            {
                ret = i.getGameObject();
            }
            return ret;
        }
        public static void remove(GameObject.Name name, Index _index = Index.INDEX_none)
        {
            GameObjectManager inst = SceneManager.getGameObjectManager();
            inst.baseRemove(name);
        }
        public static void remove(GameObjectCompositeRoot _go)
        {
            GameObjectManager inst = SceneManager.getGameObjectManager();
            //remove node 
            // TODO - move to base class
            LinkNode l = inst.baseGetHead();
            while (l != null)
            {
                GameObjectCompositeRoot goc = ((GameObjectNode)l).getGameObject();
                if (goc == _go)
                {
                    inst.baseRemove(l);
                }
                else
                {
                    goc.remove(_go);
                }
                l = l.getNext();
            }
        }
        public static void update()
        {
            GameObjectManager inst = SceneManager.getGameObjectManager();
            GameObjectNode current = (GameObjectNode)inst.baseGetHead();
            while (current != null)
            {
                current.getGameObject().update();
                current = (GameObjectNode)current.getNext();
            }
        }
    }
}
