using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ComRemover : Command
    {
        private GameObjectCompositeRoot goc;
        public ComRemover(GameObjectCompositeRoot _goc)
        {
            goc = _goc;
        }
        public override void execute(float deltaTime)
        {
            goc.removeMe();
        }
    }
}
