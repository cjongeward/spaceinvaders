using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Scene
    {
        public enum Name
        {
            open,
            attract,
            player1,
            player2,
            trans,
            end,
            winner,
            not_initialized
        }
        protected Scene.Name name;
        private SpriteManager pSpriteManager;
        private ColPairManager pColPairManager;
        private GameObjectManager pGameObjectManager;
        private ColSpriteManager pColSpriteManager;
        private GameSpriteManager pGameSpriteManager;
        private TimeManager pTimeManager;
        private InputManager pInputManager;
        public Scene(Scene.Name _name)
        {
            name = _name;
            pSpriteManager = new SpriteManager();
            pColPairManager = new ColPairManager();
            pGameObjectManager = new GameObjectManager();
            pColSpriteManager = new ColSpriteManager();
            pGameSpriteManager = new GameSpriteManager();
            pTimeManager = new TimeManager();
            pInputManager = new InputManager();
        }
        public void setName(Scene.Name _name)
        {
            name = _name;
        }
        public abstract void initialize();
        public ColPairManager getColPairManager()
        {
            return this.pColPairManager;
        }
        public GameObjectManager getGameObjectManager()
        {
            return this.pGameObjectManager;
        }
        public ColSpriteManager getColSpriteManager()
        {
            return this.pColSpriteManager;
        }
        public GameSpriteManager getGameSpriteManager()
        {
            return this.pGameSpriteManager;
        }
        public TimeManager getTimeManager()
        {
            return this.pTimeManager;
        }
        public InputManager getInputManager()
        {
            return this.pInputManager;
        }
        public SpriteManager getSpriteManager()
        {
            return this.pSpriteManager;
        }
        public Enum getName()
        {
            return this.name;
        }
        public abstract void draw();
        public abstract void nextScene();
        public virtual void toggleBoundingBoxes()
        {
            //do nothing
        }
    }
}
