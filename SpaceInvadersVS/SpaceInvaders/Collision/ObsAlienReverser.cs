using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsAlienReverser : CollisionObserver
    {
        public override void notify()
        {
            Debug.Assert(this.mySubject != null);
            Debug.Assert(this.mySubject.obj1 != null);
            Debug.Assert(this.mySubject.obj2 != null);
            AlienGrid alien_grid = (AlienGrid)GameObjectManager.find(GameObject.Name.alien_grid);
            alien_grid.dropDownReverseDirection();
        }
    }
}
