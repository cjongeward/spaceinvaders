using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsAlienRemover : CollisionObserver
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
            // remove alien from grid
            alien.removeMe();
            // notify grid of dead alien
            AlienGrid ag = ((AlienGrid)GameObjectManager.find(GameObject.Name.alien_grid));
            ag.notifyDeadAlien();
            //explode alien
            ((Alien)alien).explode();
            //add explosion back to the game object manager but not attached to the grid
            GameObjectManager.add(alien);
            SpriteManager.find(SpriteGroup.Name.aliens).attach(alien.getGameSpriteFlyweight());
            //remove the explosion after half a second
            TimeManager.add(TimeEvent.Name.none, Index.INDEX_none, new ComRemover(alien), 0.5f);

            SoundManager.playAlienEx();

            if (ag.getAlienCount() < 1)
            {
                TimeManager.add(TimeEvent.Name.none, Index.INDEX_none, new ComSwitchScene(SceneManager.getActiveScene()), 0.0f);
            }
        }
    }
}
