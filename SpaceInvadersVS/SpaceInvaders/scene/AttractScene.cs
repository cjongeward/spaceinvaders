using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AttractScene : Scene
    {
        private Azul.SpriteFont title1, title2, title3, title4, title5;
        private Azul.SpriteFont pointsTitle, alien1, alien2, alien3, alien4;
        private GameSprite squid, crab, octopus;
        public AttractScene()
            : base(Scene.Name.attract)
        {
            this.title1 = new Azul.SpriteFont("THE SPACE INVADERS", Azul.AZUL_FONTS.Consolas60pt, 200.0f, Constants.SCREEN_HEIGHT - 200.0f); 
            this.title2 = new Azul.SpriteFont("PRESENTS", Azul.AZUL_FONTS.Consolas48pt, 350.0f, Constants.SCREEN_HEIGHT - 250.0f); 
            this.title3 = new Azul.SpriteFont("PART FOUR", Azul.AZUL_FONTS.Consolas48pt, 325.0f, Constants.SCREEN_HEIGHT - 300.0f); 
            this.title4 = new Azul.SpriteFont("1 or 2 players", Azul.AZUL_FONTS.Consolas48pt, 300.0f, Constants.SCREEN_HEIGHT - 400.0f); 
            this.title5 = new Azul.SpriteFont("(Press 1 or 2)", Azul.AZUL_FONTS.Consolas48pt, 300.0f, Constants.SCREEN_HEIGHT - 450.0f); 
            this.pointsTitle = new Azul.SpriteFont("*SCORE ADVANCE TABLE*", Azul.AZUL_FONTS.Consolas48pt, 150.0f, Constants.SCREEN_HEIGHT - 550.0f); 
            this.alien1 = new Azul.SpriteFont("? MYSTERY", Azul.AZUL_FONTS.Consolas48pt, 400.0f, Constants.SCREEN_HEIGHT - 600.0f); 
            this.alien2 = new Azul.SpriteFont("30 POINTS", Azul.AZUL_FONTS.Consolas48pt, 400.0f, Constants.SCREEN_HEIGHT - 650.0f); 
            this.alien3 = new Azul.SpriteFont("20 POINTS", Azul.AZUL_FONTS.Consolas48pt, 400.0f, Constants.SCREEN_HEIGHT - 700.0f); 
            this.alien4 = new Azul.SpriteFont("10 POINTS", Azul.AZUL_FONTS.Consolas48pt, 400.0f, Constants.SCREEN_HEIGHT - 750.0f); 

        }
        public override void initialize()
        {
            SpriteManager.add(SpriteGroup.Name.aliens);
            squid = GameSpriteManager.add(GameSprite.Name.alien1,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.alien2_0),
                                  new Azul.Rect(350.0f, Constants.SCREEN_HEIGHT - 650.0f, 31.0f, 31.0f));
            crab = GameSpriteManager.add(GameSprite.Name.alien2,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.alien1_0),
                                  new Azul.Rect(350.0f, Constants.SCREEN_HEIGHT - 700.0f, 42.0f, 31.0f));
            octopus = GameSpriteManager.add(GameSprite.Name.alien3,
                                  Index.INDEX_none,
                                  ImageManager.find(ImageNode.Name.alien3_0),
                                  new Azul.Rect(350.0f, Constants.SCREEN_HEIGHT - 750.0f, 42.0f, 31.0f));
        }
        public override void draw()
        {
            this.title1.Draw(); 
            this.title2.Draw(); 
            this.title3.Draw(); 
            this.title4.Draw(); 
            this.title5.Draw(); 
            this.pointsTitle.Draw(); 
            this.alien1.Draw(); 
            this.alien2.Draw(); 
            this.alien3.Draw(); 
            this.alien4.Draw();
            this.squid.Draw();
            this.crab.Draw();
            this.octopus.Draw();
        }
        public void selectNumPlayers(int _num)
        {
            SceneManager.setNumPlayers(_num);
            nextScene();
        }
        public override void nextScene()
        {
            SceneManager.initPlayers();
            SceneManager.setScene(Scene.Name.player1);
        }
    }
}
