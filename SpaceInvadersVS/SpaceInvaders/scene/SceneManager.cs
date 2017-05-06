using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SceneManager
    {
        private static SceneManager instance;
        private Scene active;
        private Scene open, attract, p1trans, player1, p2trans, player2, end, winner;
        private int numPlayers;
        private Azul.SpriteFont score1, score2, highscore, scoreheader, credits;
        private int hiscore;
        private SceneManager()
        {
            numPlayers = 2;
            hiscore = 0;
            open = new OpenScene();
            attract = new AttractScene();
            player1 = new PlayerScene(Scene.Name.player1);
            player2 = new PlayerScene(Scene.Name.player2);
            end = new GameOverScene();
            winner = new WinnerScene();
            scoreheader = new Azul.SpriteFont("SCORE<1>      HI-SCORE      SCORE<2>", Azul.AZUL_FONTS.Consolas48pt, 50.0f, Constants.SCREEN_HEIGHT - 25.0f);
            score1 = new Azul.SpriteFont("0000", Azul.AZUL_FONTS.Consolas48pt, 75.0f, Constants.SCREEN_HEIGHT - 75.0f);
            highscore = new Azul.SpriteFont(hiscore.ToString("D4"), Azul.AZUL_FONTS.Consolas48pt, 410.0f, Constants.SCREEN_HEIGHT - 75.0f);
            score2 = new Azul.SpriteFont("0000", Azul.AZUL_FONTS.Consolas48pt, 740.0f, Constants.SCREEN_HEIGHT - 75.0f);
            credits = new Azul.SpriteFont("CREDITS 04", Azul.AZUL_FONTS.Consolas48pt, 650.0f,  75.0f);
        }
        private static SceneManager getInstance()
        {
            if(instance == null)
            {
                instance = new SceneManager();
            }
            return instance;
        }
        public static void initialize()
        {
            SceneManager inst = getInstance();
            inst.active = inst.player1;
            inst.active.initialize();
            inst.active = inst.player2;
            inst.active.initialize();
            inst.active = inst.attract;
            inst.active.initialize();
            inst.active = inst.end;
            inst.active.initialize();
            inst.active = inst.winner;
            inst.active.initialize();
            inst.active = inst.open;
            inst.active.initialize();
        }
        public static void submitScore(int _score)
        {
            SceneManager inst = getInstance();
            if (_score > inst.hiscore)
            {
                inst.hiscore = _score;
            }
        }
        public static void initPlayers()
        {
            SceneManager inst = getInstance();
            Scene temp = inst.active;
            inst.player1 = new PlayerScene(Scene.Name.player1);
            inst.player2 = new PlayerScene(Scene.Name.player2);
            inst.active = inst.player1;
            inst.active.initialize();
            inst.active = inst.player2;
            inst.active.initialize();
            inst.active = temp;
        }
        public static void toggleBoundingBoxes()
        {
            instance.active.toggleBoundingBoxes();
        }
        public static void setNumPlayers(int _numPlayers)
        {
            SceneManager inst = getInstance();
            inst.numPlayers = _numPlayers;
        }
        public static int getNumPlayers()
        {
            SceneManager inst = getInstance();
            return inst.numPlayers;
        }
        public static Scene getActiveScene()
        {
            SceneManager inst = getInstance();
            return inst.active;
        }
        public static void setScene(Scene.Name _name)
        {
            SceneManager inst = getInstance();
            TimeManager.pause();
            switch (_name)
            {
                case Scene.Name.attract:
                    inst.active = inst.attract;
                    break;
                case Scene.Name.player1:
                    inst.active = inst.player1;
                    GameObjectManager.add(((PlayerScene)(inst.active)).buildPlayer());
                    break;
                case Scene.Name.player2:
                    inst.active = inst.player2;
                    GameObjectManager.add(((PlayerScene)(inst.active)).buildPlayer());
                    break;
                case Scene.Name.end:
                    inst.active = inst.end;
                    break;
                case Scene.Name.winner:
                    inst.active = inst.winner;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            TimeManager.unpause();
        }
        public static void draw()
        {
            SceneManager inst = getInstance();
            inst.score1.Update(((PlayerScene)(inst.player1)).getScore().ToString("D4"));
            inst.score1.Draw();
            inst.score2.Update(((PlayerScene)(inst.player2)).getScore().ToString("D4"));
            inst.score2.Draw();
            inst.highscore.Update(inst.hiscore.ToString("D4"));
            inst.highscore.Draw();
            inst.scoreheader.Draw();
            inst.credits.Draw();
            inst.active.draw();
        }
        public static bool player1Dead()
        {
            SceneManager inst = getInstance();
            return ((PlayerScene)(inst.player1)).isDead();
        }
        public static bool player2Dead()
        {
            SceneManager inst = getInstance();
            return ((PlayerScene)(inst.player2)).isDead();
        }
        public static ColPairManager getColPairManager()
        {
            SceneManager inst = getInstance();
            return inst.active.getColPairManager();
        }
        public static GameObjectManager getGameObjectManager()
        {
            SceneManager inst = getInstance();
            return inst.active.getGameObjectManager();
        }
        public static ColSpriteManager getColSpriteManager()
        {
            SceneManager inst = getInstance();
            return inst.active.getColSpriteManager();
        }
        public static GameSpriteManager getGameSpriteManager()
        {
            SceneManager inst = getInstance();
            return inst.active.getGameSpriteManager();
        }
        public static TimeManager getTimeManager()
        {
            SceneManager inst = getInstance();
            return inst.active.getTimeManager();
        }
        public static InputManager getInputManager()
        {
            SceneManager inst = getInstance();
            return inst.active.getInputManager();
        }
        public static SpriteManager getSpriteManager()
        {
            SceneManager inst = getInstance();
            return inst.active.getSpriteManager();
        }
    }
}
