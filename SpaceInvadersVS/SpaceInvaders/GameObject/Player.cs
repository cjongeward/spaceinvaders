using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Player : GameObject
    {
        private bool bulletReady;
        public Player(GameObject.Name _name, Index _index, GameSpriteFlyweight _gameSprite, CollisionObject _colObj)
            : base(_name, _index, _gameSprite, _colObj, _gameSprite.getPos().x, _gameSprite.getPos().y)
        {
            this.bulletReady = true;
        }
        public override void removeMySprite()
        {
            SpriteManager.find(SpriteGroup.Name.player).remove(this.getGameSpriteFlyweight());
        }
        public void notifyBulletReady()
        {
            this.bulletReady = true;
        }
        public override void accept(CollisionVisitor other)
        {
            Debug.Assert(other != null);
            other.visitPlayer(this);
        }
        public override void visitBomb(Bomb bomb)
        {
            Debug.Assert(bomb != null);

            ColPair pColPair = ColPairManager.find(ColPair.Name.player_bomb);
            pColPair.notifyObservers(this, bomb);
        }
        public override void visitWall(Wall wall)
        {
            Debug.Assert(wall != null);

            ColPair pColPair = ColPairManager.find(ColPair.Name.player_rwall);
            pColPair.notifyObservers(this, wall);
        }
        public void spawnBullet()
        {
            if (this.bulletReady)
            {
                SoundManager.playShoot();
                GameSprite b1 = GameSpriteManager.find(GameSprite.Name.bullet);
                CollisionObject cs = new CollisionObject(100.0f, 100.0f, b1.getSize().x, b1.getSize().y, new Azul.Color(1.0f, 1.0f, 0.0f));
                GameSpriteFlyweight b1fw = b1.getFlyWeight();
                b1fw.setPos(this.pos);
                SpriteManager.find(SpriteGroup.Name.bullets).attach(b1fw);
                GameObjectCompositeRoot g = GameObjectManager.find(GameObject.Name.bullet);
                ((GameObjectComposite)g).add(new Bullet(GameObject.Name.bullet, Index.INDEX_none, b1fw, cs));
                this.bulletReady = false;
            }
        }
        public void explode()
        {
            this.setGameSprite(GameSpriteManager.find(GameSprite.Name.player_explode));
        }
    }
}
