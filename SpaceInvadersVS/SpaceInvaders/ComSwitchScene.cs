using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ComSwitchScene : Command
    {
        private Scene pScene;
        public ComSwitchScene(Scene _pScene)
        {
            pScene = _pScene;
        }
        public override void execute(float deltaTime)
        {
            pScene.nextScene();
        }
    }
}
