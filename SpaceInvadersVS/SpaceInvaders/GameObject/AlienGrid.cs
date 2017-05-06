using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienGrid : GameObjectComposite
    {
        private bool dropDownInProgress;
        private Random random;
        private int alienCount;
        private float stepTime;
        private float minStepTime;
        public AlienGrid(CollisionObject _co) : base(GameObject.Name.alien_grid, _co)
        {
            this.dropDownInProgress = false;
            random = new Random();
            this.alienCount = 55;
            this.minStepTime = Constants.ALIEN_STEP_TIME;
            this.stepTime = this.minStepTime * (float)this.alienCount;
        }
        public void notifyDeadAlien()
        {
            this.stepTime = this.minStepTime * (float)--this.alienCount;
        }
        public int getAlienCount()
        {
            return this.alienCount;
        }
        public float getStepTime()
        {
            return this.stepTime;
        }
        public void sideStep()
        {
            this.dropDownInProgress = false;
            this.move(Constants.SIDE_STEP * this.direction, 0.0f);
            this.update();
            this.dropBomb();
        }
        public void dropDownReverseDirection()
        {
            if (!this.dropDownInProgress)
            {
                this.dropDownInProgress = true;
                // back out of collision and drop down
                this.move(-Constants.SIDE_STEP * this.direction, -Constants.DOWN_STEP);
                this.direction *= -1.0f;
            }
        }
        public void spawnBomb(Vector2 _pos)
        {
                GameSprite b1 = GameSpriteManager.find(GameSprite.Name.bomb);
                CollisionObject cs = new CollisionObject(300.0f, 900.0f, b1.getSize().x, b1.getSize().y, new Azul.Color(1.0f, 1.0f, 0.0f));
                GameSpriteFlyweight b1fw = b1.getFlyWeight();
                b1fw.setPos(_pos);
                SpriteManager.find(SpriteGroup.Name.bombs).attach(b1fw);
                GameObjectCompositeRoot g = GameObjectManager.find(GameObject.Name.bomb);
                ((GameObjectComposite)g).add(new Bomb(GameObject.Name.bomb, Index.INDEX_none, b1fw, cs));
        }
        public void dropBomb()
        {
            if (random.Next(3) == 1 && alienCount > 0)
            {
                spawnBomb(this.getRandomAlien().getPos());
            }
        }
        public GameObject getRandomAlien()
        {
            GameObjectCompositeRoot current = ((GameObjectComposite)this).head;
            for (int i = 0; i < random.Next(11); i++)
            {
                current = current.next;
                if (current == null)
                {
                    current = ((GameObjectComposite)this).head;
                }
            }
            GameObjectCompositeRoot currentAlien = ((GameObjectComposite)current).head;
            while (currentAlien.next != null)
            {
                currentAlien = currentAlien.next;
            }
            return (GameObject)currentAlien;
        }
    }
}
