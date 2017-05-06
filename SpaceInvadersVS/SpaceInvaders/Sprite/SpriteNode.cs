using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteNode : LinkNode
    {
        private GameSprite.Name name;
        private Index index;
        private SpriteBase pSpriteBase;
        public SpriteNode()
            : base()
        {
            this.name = GameSprite.Name.not_initialized;
            this.index = Index.INDEX_none;
            // TODO - implement spriteBase
            this.pSpriteBase = new GameSprite();
        }
        public override void clear()
        {
            // do nothing
        }
        public void initialize(SpriteBase _spriteBase)
        {
            Debug.Assert(_spriteBase != null);
            pSpriteBase = _spriteBase;
            //this.name = (GameSprite.Name)_spriteBase.getName();
            //this.index = (Index)_spriteBase.getIndex();
        }
        public void draw()
        {
            this.pSpriteBase.Draw();
        }
        override public Enum getName()
        {
            // TODO - should never be here
            Debug.Assert(false);
            return this.name;
        }
        override public Enum getIndex()
        {
            // TODO - should never be here
            Debug.Assert(false);
            return this.index;
        }
        public SpriteBase getSpriteBase()
        {
            return pSpriteBase;
        }
    }
}
