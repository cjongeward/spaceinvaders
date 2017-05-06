using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextureNode : LinkNode
    {
        public enum Name
        {
            space_invaders,
            shield,
            not_initialized
        }
        private TextureNode.Name name;
        private Index index;
        private Azul.Texture texture;
        public TextureNode()
            : base()
        {
            this.name = Name.not_initialized;
            this.index = Index.INDEX_none;
        }
        public override void clear()
        {
            // do nothing
        }
        public void initialize(TextureNode.Name _name, String image)
        {
            this.name = _name;
            texture = new Azul.Texture(image);
        }
        override public Enum getName()
        {
            return this.name;
        }
        override public Enum getIndex()
        {
            return this.index;
        }
        public Azul.Texture getTexture()
        {
            return texture;
        }
    }
}
