using System;

namespace SpaceInvaders
{
    abstract class Command
    {
        abstract public void execute( float deltaTime );
    }
}
