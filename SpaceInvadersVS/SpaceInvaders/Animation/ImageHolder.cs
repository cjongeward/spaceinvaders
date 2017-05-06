using System;

namespace SpaceInvaders
{
    class ImageHolder
    {
        private ImageNode image;
        private ImageHolder next;
        public ImageHolder(ImageNode _image)
        {
            this.image = _image;
            this.next = null;
        }
        public ImageNode getImage()
        {
            return this.image;
        }
        public void setImage(ImageNode _image)
        {
            this.image = _image;
        }
        public ImageHolder getNext()
        {
            return this.next;
        }
        public void setNext(ImageHolder _i)
        {
            this.next = _i;
        }
    }
}
