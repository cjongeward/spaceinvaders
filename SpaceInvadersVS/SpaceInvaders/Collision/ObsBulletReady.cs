using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObsBulletReady : CollisionObserver
    {
        public override void notify()
        {
            GameObjectCompositeRoot player = null;
            player = GameObjectManager.find(GameObject.Name.player);
            Debug.Assert(player != null);
            ((Player)player).notifyBulletReady();
        }
    }
}
