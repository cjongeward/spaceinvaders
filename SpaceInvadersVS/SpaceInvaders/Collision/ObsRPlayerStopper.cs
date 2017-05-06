using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsRPlayerStopper : CollisionObserver
    {
        public override void notify()
        {
            Debug.Assert(this.mySubject != null);
            Debug.Assert(this.mySubject.obj1 != null);
            Debug.Assert(this.mySubject.obj2 != null);
            GameObjectCompositeRoot player = null;
            float edge = 0.0f;
            if (this.mySubject.obj1 is Player)
            {
                player = this.mySubject.obj1;
                edge = this.mySubject.obj2.getBoundingVol().getSize().x;
            }
            if (this.mySubject.obj2 is Player)
            {
                player = this.mySubject.obj2;
                edge = this.mySubject.obj1.getBoundingVol().getSize().x;
            }
            Debug.Assert(player != null);
            GameObject go = (GameObject)player;
            float playerx = go.getPos().x;
            float playerw2 = go.getBoundingVol().getSize().x * 0.5f;
            if (playerx < Constants.SCREEN_WIDTH * 0.5f)
            {
                go.getPos().x = edge + playerw2;
            }
            else
            {
                go.getPos().x = Constants.SCREEN_WIDTH - edge - playerw2;
            }
        }
    }
}
