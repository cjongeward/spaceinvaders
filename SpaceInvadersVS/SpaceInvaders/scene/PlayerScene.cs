using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerScene : Scene
    {
        private int score;
        private int numLives;
        private Azul.SpriteFont lives;
        private GameSprite player1, player2;
        public PlayerScene(Scene.Name _name)
            : base(_name)
        {
            score = 0;
            numLives = 3;
        }
        public int getScore()
        {
            return score;
        }
        public void addScore(int _points)
        {
            score += _points;
            SceneManager.submitScore(score);
        }
        public int getNumLives()
        {
            return numLives;
        }
        public override void toggleBoundingBoxes()
        {
            SpriteGroup boxes = SpriteManager.find(SpriteGroup.Name.boundingBoxes);
            boxes.shouldDraw();
        }
        public override void initialize()
        {
            lives = new Azul.SpriteFont(numLives.ToString(), Azul.AZUL_FONTS.Consolas36pt, 50.0f, 75.0f);

            SpriteManager.add(SpriteGroup.Name.aliens);
            SpriteGroup boxes = SpriteManager.add(SpriteGroup.Name.boundingBoxes);
            boxes.shouldDraw(false);
            SpriteManager.add(SpriteGroup.Name.bullets);
            SpriteManager.add(SpriteGroup.Name.bombs);
            SpriteManager.add(SpriteGroup.Name.player);
            SpriteManager.add(SpriteGroup.Name.alien_explode);
            SpriteManager.add(SpriteGroup.Name.player_explode);
            SpriteManager.add(SpriteGroup.Name.shields);
            GameSpriteManager.add(GameSprite.Name.shieldtl,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.shieldtl),
                                      new Azul.Rect(350.0f, 100.0f, 20.0f, 20.0f));
            GameSpriteManager.add(GameSprite.Name.shield,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.shield),
                                      new Azul.Rect(350.0f, 100.0f, 20.0f, 20.0f));
            GameSpriteManager.add(GameSprite.Name.shieldtr,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.shieldtr),
                                      new Azul.Rect(350.0f, 100.0f, 20.0f, 20.0f));
            GameSpriteManager.add(GameSprite.Name.shieldbl,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.shieldbl),
                                      new Azul.Rect(350.0f, 100.0f, 20.0f, 20.0f));
            GameSpriteManager.add(GameSprite.Name.shieldbr,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.shieldbr),
                                      new Azul.Rect(350.0f, 100.0f, 20.0f, 20.0f));
            GameSpriteManager.add(GameSprite.Name.alien1,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.alien1_0),
                                  new Azul.Rect(0.0f, 0.0f, 42.0f, 31.0f));
            GameSpriteManager.add(GameSprite.Name.alien2,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.alien2_0),
                                  new Azul.Rect(0.0f, 0.0f, 31.0f, 31.0f));
            GameSpriteManager.add(GameSprite.Name.alien3,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.alien3_0),
                                  new Azul.Rect(0.0f, 0.0f, 42.0f, 31.0f));
            GameSpriteManager.add(GameSprite.Name.bullet,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.bullet),
                                  new Azul.Rect(0.0f, 0.0f, 11.0f, 20.0f));
            GameSpriteManager.add(GameSprite.Name.bomb,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.bomb),
                                  new Azul.Rect(0.0f, 0.0f, 11.0f, 20.0f));
            GameSpriteManager.add(GameSprite.Name.alien_explode,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.alien_explode),
                                  new Azul.Rect(0.0f, 0.0f, 36.0f, 22.0f));
            GameSpriteManager.add(GameSprite.Name.player_explode,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.player_explode),
                                  new Azul.Rect(0.0f, 0.0f, 40.0f, 23.0f));


            // walls floor and ceiling
            CollisionObject ceiling_co = new CollisionObject(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, 
                                                          Constants.SCREEN_WIDTH, 100.0f, new Azul.Color(1.0f, 1.0f, 1.0f));
            GameObjectCompositeRoot ceiling_go = GameObjectManager.add(GameObject.Name.ceiling, 
                                                                       Index.INDEX_none, 
                                                                       GameSpriteManager.getNullObject().getFlyWeight(),
                                                                       ceiling_co);
            CollisionObject floor_co = new CollisionObject(Constants.SCREEN_WIDTH, 100.0f, 
                                                          Constants.SCREEN_WIDTH, 100.0f, new Azul.Color(1.0f, 1.0f, 1.0f));
            GameObjectCompositeRoot floor_go = GameObjectManager.add(GameObject.Name.floor, 
                                                                       Index.INDEX_none, 
                                                                       GameSpriteManager.getNullObject().getFlyWeight(),
                                                                       floor_co);
            CollisionObject rwall_co = new CollisionObject(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT,
                                                          10.0f, Constants.SCREEN_HEIGHT, new Azul.Color(1.0f, 1.0f, 1.0f));
            GameObjectCompositeRoot rwall_go = GameObjectManager.add(GameObject.Name.rwall, 
                                                                       Index.INDEX_none, 
                                                                       GameSpriteManager.getNullObject().getFlyWeight(),
                                                                       rwall_co);
            CollisionObject lwall_co = new CollisionObject(10.0f, Constants.SCREEN_HEIGHT,
                                                          10.0f, Constants.SCREEN_HEIGHT, new Azul.Color(1.0f, 1.0f, 1.0f));
            GameObjectCompositeRoot lwall_go = GameObjectManager.add(GameObject.Name.lwall, 
                                                                       Index.INDEX_none, 
                                                                       GameSpriteManager.getNullObject().getFlyWeight(),
                                                                       lwall_co);

            // build alien grid
            GameObjectComposite alien_grid = AlienFactory.buildGrid();
            ColPair alien_grid_rwall = ColPairManager.add(ColPair.Name.alien_rwall, Index.INDEX_none, rwall_go, alien_grid);
            alien_grid_rwall.attachObserver(new ObsAlienReverser());
            ColPair alien_grid_lwall = ColPairManager.add(ColPair.Name.alien_lwall, Index.INDEX_none, lwall_go, alien_grid);
            alien_grid_lwall.attachObserver(new ObsAlienReverser());

            // bullet infrastructure
            CollisionObject co = new CollisionObject(0.0f, 0.0f, 0.0f, 0.0f, new Azul.Color(0.0f, 1.0f, 0.0f));
            GameObjectCompositeRoot bullet_composite = new GameObjectComposite(GameObject.Name.bullet, co);
            GameObjectManager.add(bullet_composite);
            ColPair alienBullet = ColPairManager.add(ColPair.Name.alien_bullet, Index.INDEX_none, bullet_composite, alien_grid);
            alienBullet.attachObserver(new ObsAlienRemover());
            alienBullet.attachObserver(new ObsBulletRemover());
            alienBullet.attachObserver(new ObsBulletReady());
            alienBullet.attachObserver(new ObsScoreUpdater());
            ColPair bulletCeiling = ColPairManager.add(ColPair.Name.bullet_ceiling, Index.INDEX_none, bullet_composite, ceiling_go);
            bulletCeiling.attachObserver(new ObsBulletRemover());
            bulletCeiling.attachObserver(new ObsBulletReady());

            // bomb infrastructure
            co = new CollisionObject(0.0f, 0.0f, 0.0f, 0.0f, new Azul.Color(0.0f, 1.0f, 0.0f));
            GameObjectCompositeRoot bomb_composite = new GameObjectComposite(GameObject.Name.bomb, co);
            GameObjectManager.add(bomb_composite);
            ColPair bombFloor = ColPairManager.add(ColPair.Name.bomb_floor, Index.INDEX_none, bomb_composite, floor_go);
            bombFloor.attachObserver(new ObsBombRemover());

            //shields
            GameObjectCompositeRoot shields = ShieldFactory.BuildShieldGroup();
            GameObjectManager.add(shields);
            ColPair shieldBullet = ColPairManager.add(ColPair.Name.bullet_shield, Index.INDEX_none, bullet_composite, shields);
            shieldBullet.attachObserver(new ObsBulletRemover());
            shieldBullet.attachObserver(new ObsShieldRemover());
            shieldBullet.attachObserver(new ObsBulletReady());
            ColPair shieldBomb = ColPairManager.add(ColPair.Name.bomb_shield, Index.INDEX_none, bomb_composite, shields);
            shieldBomb.attachObserver(new ObsBombRemover());
            shieldBomb.attachObserver(new ObsShieldRemover());
            ColPair shieldAlien = ColPairManager.add(ColPair.Name.alien_shield, Index.INDEX_none, alien_grid, shields);
            shieldAlien.attachObserver(new ObsShieldRemover());

            // extra lives
            player1 = GameSpriteManager.add(GameSprite.Name.player,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.player),
                                      new Azul.Rect(100.0f, 75.0f, 35.0f, 24.0f));
            player2 = GameSpriteManager.add(GameSprite.Name.player,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.player),
                                      new Azul.Rect(150.0f, 75.0f, 35.0f, 24.0f));
        }
        public GameObjectCompositeRoot buildPlayer()
        {
            //player
            GameSprite p1 = 
                GameSpriteManager.add(GameSprite.Name.player,
                                      Index.INDEX_none,
                                      ImageManager.find(ImageNode.Name.player),
                                      new Azul.Rect(350.0f, 100.0f, 35.0f, 24.0f));
            CollisionObject colp = new CollisionObject(350.0f, 100.0f, p1.getSize().x, p1.getSize().y, new Azul.Color(0.0f, 1.0f, 1.0f));
            GameSpriteFlyweight p1fw = p1.getFlyWeight();
            p1fw.getPos().x = 350.0f;
            p1fw.getPos().y = 150.0f;
            SpriteManager.find(SpriteGroup.Name.player).attach(p1fw);
            Player player_go =  new Player(GameObject.Name.player, Index.INDEX_none, p1fw, colp);

            GameObjectCompositeRoot rwall_go = GameObjectManager.find(GameObject.Name.rwall);
            ColPair player_rwall = ColPairManager.add(ColPair.Name.player_rwall, Index.INDEX_none, rwall_go, player_go);
            player_rwall.attachObserver(new ObsRPlayerStopper());
            GameObjectCompositeRoot lwall_go = GameObjectManager.find(GameObject.Name.lwall);
            ColPair player_lwall = ColPairManager.add(ColPair.Name.player_lwall, Index.INDEX_none, lwall_go, player_go);
            player_lwall.attachObserver(new ObsRPlayerStopper());

            GameObjectCompositeRoot bomb_composite = GameObjectManager.find(GameObject.Name.bomb);
            ColPair playerBomb = ColPairManager.add(ColPair.Name.player_bomb, Index.INDEX_none, bomb_composite, player_go);
            playerBomb.attachObserver(new ObsBombRemover());
            playerBomb.attachObserver(new ObsPlayerRemover());

            return player_go;
        }
        public override void draw()
        {
            lives.Draw();
            if(numLives > 1) player1.Draw();
            if(numLives > 2) player2.Draw();
        }
        public override void nextScene()
        {
            AlienGrid ag = ((AlienGrid)GameObjectManager.find(GameObject.Name.alien_grid));
            if (ag.getAlienCount() < 1)
            {
                SceneManager.setScene(Scene.Name.winner);
            }
            else
            {
                processDeath();
                if (SceneManager.getNumPlayers() == 1)
                {
                    if (this.isDead())
                    {
                        SceneManager.setScene(Scene.Name.end);
                    }
                    else
                    {
                        SceneManager.setScene(Scene.Name.player1);
                    }
                }
                else if (name == Scene.Name.player1)
                {
                    if (SceneManager.player2Dead() && this.isDead())
                    {
                        SceneManager.setScene(Scene.Name.end);
                    }
                    else if (SceneManager.player2Dead())
                    {
                        SceneManager.setScene(Scene.Name.player1);
                    }
                    else
                    {
                        SceneManager.setScene(Scene.Name.player2);
                    }
                }
                else if (name == Scene.Name.player2)
                {
                    if (SceneManager.player1Dead() && this.isDead())
                    {
                        SceneManager.setScene(Scene.Name.end);
                    }
                    else if (SceneManager.player1Dead())
                    {
                        SceneManager.setScene(Scene.Name.player2);
                    }
                    else
                    {
                        SceneManager.setScene(Scene.Name.player1);
                    }
                }
            }
        }
        public void processDeath()
        {
            lives.Update((--numLives).ToString());
        }
        public bool isDead()
        {
            bool d = false;
            if (numLives < 1) d = true;
            return d;
        }
    }
}
