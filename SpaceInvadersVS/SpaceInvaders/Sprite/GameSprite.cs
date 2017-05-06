using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameSprite : SpriteBase
    {
        public enum Name
        {
            space_invaders,
            alien1,
            alien2,
            alien3,
            alien4,
            alien5,
            alien6,
            alien7,
            alien8,
            alien9,
            alien10,
            ufo,
            player,
            bullet,
            bomb,
            alien_explode,
            player_explode,
            shieldtl,
            shield,
            shieldtr,
            shieldbl,
            shieldbr,
            null_object,
            not_initialized
        }
        private GameSprite.Name name;
        private Index index;
        private Azul.Sprite2D sprite;
        private TextureNode texture;
        private ImageNode image;
        private Vector2 pos;
        private Vector2 scale;
        private Vector2 size;
        public GameSprite()
            : base()
        {
            this.name = GameSprite.Name.not_initialized;
            this.index = Index.INDEX_none;
            this.pos = new Vector2(0.0f, 0.0f);
            this.scale = new Vector2(0.0f, 0.0f);
            this.size = new Vector2(0.0f, 0.0f);
        }
        public override void clear()
        {
            // do nothing
        }
        override public Enum getName()
        {
            return this.name;
        }
        override public Enum getIndex()
        {
            return this.index;
        }
        public virtual void initialize(GameSprite.Name _name, ImageNode _image, Azul.Rect _size)
        {
            this.initialize(_name, Index.INDEX_none, _image, _size);
        }
        public virtual void initialize(GameSprite.Name _name, Index _index, ImageNode _image, Azul.Rect _size)
        {
            Debug.Assert(_image != null);
            Debug.Assert(_size != null);
            this.name = _name;
            this.index = _index;
            this.texture = _image.getTexture();
            Debug.Assert(this.texture != null);
            this.image = _image;
            this.sprite = new Azul.Sprite2D(texture.getTexture(), image.getRect(), _size);
            this.setPos(_size.x, _size.y);
            this.setScale(1.0f, 1.0f);
            this.size.x = _size.w;
            this.size.y = _size.h;
        }
        public virtual void setImage(ImageNode _image)
        {
            this.image = _image;
            this.texture = _image.getTexture();
            this.sprite = new Azul.Sprite2D(texture.getTexture(), image.getRect(), new Azul.Rect(this.pos.x, this.pos.y, this.size.x, this.size.y));
        }
        public void setPos(float _posx, float _posy)
        {
            this.pos.x = _posx;
            this.pos.y = _posy;
            this.sprite.x = _posx;
            this.sprite.y = _posy;
        }
        public void setScale(float _sx, float _sy)
        {
            this.scale.x = _sx;
            this.scale.y = _sy;
            this.sprite.sx = _sx;
            this.sprite.sy = _sy;
        }
        public Vector2 getPos()
        {
            return this.pos;
        }
        public Vector2 getScale()
        {
            return this.scale;
        }
        public Vector2 getSize()
        {
            return this.size;
        }
        public override void Draw()
        {
            this.sprite.Draw();
        }
        public GameSpriteFlyweight getFlyWeight()
        {
            return new GameSpriteFlyweight(this);
        }
    }
}
