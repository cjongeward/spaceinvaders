using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsShieldRemover : CollisionObserver
    {
        public override void notify()
        {
            Debug.Assert(this.mySubject != null);
            Debug.Assert(this.mySubject.obj1 != null);
            Debug.Assert(this.mySubject.obj2 != null);
            GameObjectCompositeRoot shield = null;
            if (this.mySubject.obj1 is ShieldChunk)
            {
                shield = this.mySubject.obj1;
            }
            if (this.mySubject.obj2 is ShieldChunk)
            {
                shield = this.mySubject.obj2;
            }
            Debug.Assert(shield != null);
            // remove shield from grid
            shield.removeMe();
        }
 
    }
}
