using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsScoreUpdater : CollisionObserver
    {
        public override void notify()
        {
            Debug.Assert(this.mySubject != null);
            Debug.Assert(this.mySubject.obj1 != null);
            Debug.Assert(this.mySubject.obj2 != null);
            GameObjectCompositeRoot alien = null;
            if (this.mySubject.obj1 is Alien)
            {
                alien = this.mySubject.obj1;
            }
            if (this.mySubject.obj2 is Alien)
            {
                alien = this.mySubject.obj2;
            }
            Debug.Assert(alien != null);
            Scene scene = SceneManager.getActiveScene();
            ((PlayerScene)scene).addScore(((Alien)alien).getValue());
        }
    }
}
