using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSprite : SpriteBase
    {
        public enum Name
        {
            alien,
            null_object,
            not_initialized
        }

        private Rect boundingVol;
        private CollisionSprite.Name name;
        private Index index;

        public CollisionSprite() : base()
        {
            this.name = CollisionSprite.Name.not_initialized;
            this.index = Index.INDEX_none;
        }
        public override void clear()
        {
            boundingVol = null;
            name = CollisionSprite.Name.not_initialized;
            index = Index.INDEX_none;
        }
        public void initialize(CollisionSprite.Name _name, Rect _rect)
        {
            this.initialize(_name, Index.INDEX_none, _rect);
        }
        public void initialize(CollisionSprite.Name _name, Index _index, Rect _rect)
        {
            this.name = _name;
            this.index = _index;
            boundingVol = _rect;
        }
        public override void Draw()
        {
            this.boundingVol.Draw();
        }
        public override Enum getIndex()
        {
            return this.index;
        }
        public override Enum getName()
        {
            return this.name;
        }
    }
}
