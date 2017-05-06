using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameSpriteFlyweight : SpriteBase
    {
        private GameSprite pGameSprite;
        private Vector2 pos;
        public GameSpriteFlyweight(GameSprite _gameSprite)
        {
            this.pGameSprite = _gameSprite;
            pos = new Vector2(_gameSprite.getPos());
        }
        public override void clear()
        {
            pGameSprite = null;
        }
        public Vector2 getPos()
        {
            return this.pos;
        }
        public void setPos(Vector2 _pos)
        {
            this.pos = _pos;
        }
        public override void Draw()
        {
            pGameSprite.setPos(this.pos.x, this.pos.y);
            pGameSprite.Draw(); 
        }
        public override Enum getName()
        {
            return pGameSprite.getName();
        }
        public override Enum getIndex()
        {
            return pGameSprite.getIndex();
        }
        public GameSprite getGameSprite()
        {
            return pGameSprite;
        }
    }
}
