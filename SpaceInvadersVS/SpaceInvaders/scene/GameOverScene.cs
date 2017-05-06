using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameOverScene : Scene
    {
        private Azul.SpriteFont title;
        public GameOverScene()
            : base(Scene.Name.end)
        {
            this.title = new Azul.SpriteFont("Game Over", Azul.AZUL_FONTS.Consolas60pt, Constants.SCREEN_WIDTH * 0.5f - 200.0f, Constants.SCREEN_HEIGHT * 0.5f); 
        }
        public override void initialize()
        {
            TimeManager.add(TimeEvent.Name.none, Index.INDEX_none, new ComSwitchScene(this), 3.0f);
            TimeManager.pause();
        }
        public override void draw()
        {
            this.title.Draw(); 
        }
        public override void nextScene()
        {
            TimeManager.add(TimeEvent.Name.none, Index.INDEX_none, new ComSwitchScene(this), 3.0f);
            TimeManager.pause();
            SceneManager.setScene(Scene.Name.attract);
        }
    }
}
