using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsBombRemover : CollisionObserver
    {
        public override void notify()
        {
            Debug.Assert(this.mySubject != null);
            Debug.Assert(this.mySubject.obj1 != null);
            Debug.Assert(this.mySubject.obj2 != null);
            GameObjectCompositeRoot bomb = null;
            if (this.mySubject.obj1 is Bomb)
            {
                bomb = this.mySubject.obj1;
            }
            if (this.mySubject.obj2 is Bomb)
            {
                bomb = this.mySubject.obj2;
            }
            Debug.Assert(bomb != null);
            GameObjectManager.remove(bomb);
            SpriteBase sb = bomb.getGameSpriteFlyweight();
            SpriteManager.find(SpriteGroup.Name.bombs).remove(sb);
            SpriteManager.find(SpriteGroup.Name.boundingBoxes).remove(bomb.getCollisionSprite());
            ColSpriteManager.remove(bomb.getCollisionSprite());
        }
    }
}
