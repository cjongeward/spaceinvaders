using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class OpenScene : Scene
    {
        private Azul.SpriteFont title;
        public OpenScene()
            : base(Scene.Name.open)
        {
            this.title = new Azul.SpriteFont("Space Invaders", Azul.AZUL_FONTS.Consolas60pt, Constants.SCREEN_WIDTH * 0.5f - 200.0f, Constants.SCREEN_HEIGHT * 0.5f); 
        }
        public override void initialize()
        {
            TimeManager.add(TimeEvent.Name.none, Index.INDEX_none, new ComSwitchScene(this), 3.0f);
        }
        public override void draw()
        {
            this.title.Draw(); 
        }
        public override void nextScene()
        {
            SceneManager.setScene(Scene.Name.attract);
        }
    }
}
