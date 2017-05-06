using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WinnerScene : Scene
    {
        private Azul.SpriteFont title;
        public WinnerScene()
            : base(Scene.Name.winner)
        {
            this.title = new Azul.SpriteFont("Congratulations earthling", Azul.AZUL_FONTS.Consolas60pt, 100.0f, Constants.SCREEN_HEIGHT * 0.5f); 
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
