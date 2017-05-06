using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageNode : LinkNode
    {
        public enum Name
        {
            space_invaders,
            alien1_0,
            alien1_1,
            alien2_0,
            alien2_1,
            alien3_0,
            alien3_1,
            alien4_0,
            alien4_1,
            alien5_0,
            alien5_1,
            alien6_0,
            alien6_1,
            alien7_0,
            alien7_1,
            alien8_0,
            alien8_1,
            alien9_0,
            alien9_1,
            alien10_0,
            alien10_1,
            ufo,
            player,
            player_explode,
            alien_explode,
            bullet,
            bomb,
            shieldtl,
            shieldtr,
            shieldbl,
            shieldbr,
            shield,
            not_initialized
        }
        private ImageNode.Name name;
        private Index index;
        private TextureNode texture;
        private Azul.Rect rect;
        public ImageNode()
            : base()
        {
            name = ImageNode.Name.not_initialized;
        }
        public override void clear()
        {
            // do nothing
        }
        public void initialize(ImageNode.Name _name, TextureNode _texture, Azul.Rect _rect)
        {
            this.index = Index.INDEX_none;
            this.name = _name;
            this.rect = _rect;
            this.texture = _texture;
        }
        override public Enum getName()
        {
            return this.name;
        }
        override public Enum getIndex()
        {
            return this.index;
        }
        public Azul.Rect getRect()
        {
            return this.rect;
        }
        public TextureNode getTexture()
        {
            return texture;
        }
    }
}
