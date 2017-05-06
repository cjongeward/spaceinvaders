using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ComAlienMover : Command
    {
        private AlienGrid alien_grid;
        public ComAlienMover(AlienGrid _goc)
        {
            alien_grid = _goc;
        }
        public override void execute(float deltaTime)
        {
            alien_grid.sideStep();
            SoundManager.playMarch();
            TimeManager.add(TimeEvent.Name.movement, Index.INDEX_none, this, alien_grid.getStepTime());
        }
    }
}
