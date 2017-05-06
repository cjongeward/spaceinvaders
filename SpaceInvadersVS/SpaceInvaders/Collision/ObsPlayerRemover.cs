using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsPlayerRemover : CollisionObserver
    {
        public override void notify()
        {
            Debug.Assert(this.mySubject != null);
            Debug.Assert(this.mySubject.obj1 != null);
            Debug.Assert(this.mySubject.obj2 != null);
            GameObjectCompositeRoot player = null;
            if (this.mySubject.obj1 is Player)
            {
                player = this.mySubject.obj1;
            }
            if (this.mySubject.obj2 is Player)
            {
                player = this.mySubject.obj2;
            }
            Debug.Assert(player != null);
            player.removeMe();
            ((Player)player).explode();
            //add explosion back to the game object manager but not attached to the grid
            player.setCollisionObject(new NullCollisionObject());
            GameObjectManager.add(player);
            SpriteManager.find(SpriteGroup.Name.player).attach(player.getGameSpriteFlyweight());
            //remove the explosion after while
            TimeManager.add(TimeEvent.Name.none, Index.INDEX_none, new ComRemover(player), 0.49f);
            TimeManager.add(TimeEvent.Name.none, Index.INDEX_none, new ComSwitchScene(SceneManager.getActiveScene()), 0.5f);
            TimeManager.pause(2.5f);
            SoundManager.playPlayerEx();
        }
 
    }
}
