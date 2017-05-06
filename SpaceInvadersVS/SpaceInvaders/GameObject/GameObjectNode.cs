using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectNode : LinkNode
    {
        private GameObjectCompositeRoot gameObject;
        public GameObjectNode()
            : base()
        {
            this.gameObject = null;
        }
        public override void clear()
        {
            gameObject = null;
        }
        public GameObjectCompositeRoot getGameObject()
        {
            return this.gameObject;
        }
        public override Enum getName()
        {
            return this.gameObject.getName();
        }
        public override Enum getIndex()
        {
            return this.gameObject.getIndex();
        }
        public void initialize(GameObjectCompositeRoot _go)
        {
            Debug.Assert(_go != null);
            this.gameObject = _go;
        }
    }
}
