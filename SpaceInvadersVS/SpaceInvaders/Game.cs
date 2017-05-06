using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class Game : Azul.Engine
    {
        static float c1 = 0.0f;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            Azul.Camera.setWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

            setClearBufferColor(new Azul.Color(0.0f, 0.0f, 0.0f));

            TextureManager.add(TextureNode.Name.space_invaders, "space.tga");
            TextureNode tn = TextureManager.find(TextureNode.Name.space_invaders);
            TextureManager.add(TextureNode.Name.shield, "shield.tga");
            TextureNode shield_tx = TextureManager.find(TextureNode.Name.shield);

            ImageManager.add(ImageNode.Name.space_invaders, tn, new Azul.Rect(27, 81, 80, 36));
            ImageManager.add(ImageNode.Name.alien1_0, tn, new Azul.Rect(136, 65, 85, 62));
            ImageManager.add(ImageNode.Name.alien1_1, tn, new Azul.Rect(253, 65, 85, 62));
            ImageManager.add(ImageNode.Name.alien2_0, tn, new Azul.Rect(370, 65, 62, 62));
            ImageManager.add(ImageNode.Name.alien2_1, tn, new Azul.Rect(465, 65, 62, 62));
            ImageManager.add(ImageNode.Name.alien3_0, tn, new Azul.Rect(559, 65, 93, 62));
            ImageManager.add(ImageNode.Name.alien3_1, tn, new Azul.Rect(27, 202, 93, 62));
            ImageManager.add(ImageNode.Name.bullet, tn, new Azul.Rect(438, 491, 22, 39));
            ImageManager.add(ImageNode.Name.bomb, tn, new Azul.Rect(438, 491, 22, 39));
            ImageManager.add(ImageNode.Name.player, tn, new Azul.Rect(243, 494, 57, 40));
            ImageManager.add(ImageNode.Name.alien_explode, tn, new Azul.Rect(490, 489, 73, 44));
            ImageManager.add(ImageNode.Name.player_explode, tn, new Azul.Rect(330, 491, 81, 46));
            ImageManager.add(ImageNode.Name.shieldtl, shield_tx, new Azul.Rect(0, 0, 20, 20));
            ImageManager.add(ImageNode.Name.shield, shield_tx, new Azul.Rect(20, 0, 20, 20));
            ImageManager.add(ImageNode.Name.shieldtr, shield_tx, new Azul.Rect(40, 0, 20, 20));
            ImageManager.add(ImageNode.Name.shieldbr, shield_tx, new Azul.Rect(60, 0, 20, 20));
            ImageManager.add(ImageNode.Name.shieldbl, shield_tx, new Azul.Rect(80, 0, 20, 20));

            SceneManager.initialize();
        }
       
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update(float totalTime)
        {
            InputManager.keyboardInputs();
            TimeManager.update(totalTime);
            // update all game objects
            GameObjectManager.update();
            ColPairManager.process();
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SpriteManager.draw();
            SceneManager.draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }


        private void checkInput()
        {

           
        }

    }
}
