using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AnimationSprite : Command
    {
        private GameSprite sprite;
        private ImageHolder currentImage;
        private ImageHolder headImage;
        private ImageHolder tail;
        public AnimationSprite(GameSprite _sprite)
        {
            this.sprite = _sprite;
            this.currentImage = null;
            this.headImage = null;
        }
        public void attachImage(ImageNode _image)
        {
            Debug.Assert(_image != null);
            ImageHolder i = new ImageHolder(_image);
            if (this.headImage == null)
            {
                this.headImage = i;
                this.tail = this.headImage;
                this.headImage.setNext(this.headImage);
                this.currentImage = this.headImage;
            }
            else
            {
                this.tail.setNext(i);
                this.tail = i;
                this.tail.setNext(this.headImage);
            }
        }
        public override void execute(float deltaTime)
        {
            sprite.setImage(this.currentImage.getImage());
            this.currentImage = this.currentImage.getNext();

            AlienGrid grid = ((AlienGrid)GameObjectManager.find(GameObject.Name.alien_grid));
            if (grid != null)
            {
                float stepTime = grid.getStepTime();
                TimeManager.add(TimeEvent.Name.animation, (Index)(this.sprite.getIndex()), this, stepTime);
            }
        }
    }
}
