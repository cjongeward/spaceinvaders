using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ComPauseTimer : Command
    {
        public override void execute(float deltaTime)
        {
            TimeManager.pause();
        }
    }
}
