using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsBulletRemover : CollisionObserver
    {
        public override void notify()
        {
            Debug.Assert(this.mySubject != null);
            Debug.Assert(this.mySubject.obj1 != null);
            Debug.Assert(this.mySubject.obj2 != null);
            GameObjectCompositeRoot bullet = null;
            if (this.mySubject.obj1 is Bullet)
            {
                bullet = this.mySubject.obj1;
            }
            if (this.mySubject.obj2 is Bullet)
            {
                bullet = this.mySubject.obj2;
            }
            Debug.Assert(bullet != null);
            GameObjectManager.remove(bullet);
            SpriteBase sb = bullet.getGameSpriteFlyweight();
            SpriteManager.find(SpriteGroup.Name.bullets).remove(sb);
            SpriteManager.find(SpriteGroup.Name.boundingBoxes).remove(bullet.getCollisionSprite());
            ColSpriteManager.remove(bullet.getCollisionSprite());
        }
    }
}
