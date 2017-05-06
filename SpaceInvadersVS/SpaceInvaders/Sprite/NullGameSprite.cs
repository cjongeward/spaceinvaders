using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NullGameSprite : GameSprite
    {
        private GameSprite.Name name;
        private Index index;
        public NullGameSprite()
            : base()
        {
            this.name = GameSprite.Name.null_object;
            this.index = Index.INDEX_none;
        }
        override public Enum getName()
        {
            return this.name;
        }
        override public Enum getIndex()
        {
            return this.index;
        }
        public override void initialize(GameSprite.Name _name, ImageNode _image, Azul.Rect _size)
        {
            Debug.Assert(false);
        }
        public override void initialize(GameSprite.Name _name, Index _index, ImageNode _image, Azul.Rect _size)
        {
            Debug.Assert(false);
        }
        public override void setImage(ImageNode _image)
        {
            //do nothing
        }
        public override void Draw()
        {
            // do nothing
        }
        public GameSpriteFlyweight getFlyWeight()
        {
            return new GameSpriteFlyweight(this);
        }
    }
}
