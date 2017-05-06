using System;

namespace SpaceInvaders
{
    class TimeEvent : LinkNode
    {
        public enum Name
        {
            animation,
            movement,
            none,
            not_initialized
        }
        private Index index;
        private TimeEvent.Name name;
        private Command command;
        private float triggerTime;
        private float deltaTime;

        public TimeEvent()
            : base()
        {
            this.name = TimeEvent.Name.not_initialized;
        }
        public override void clear()
        {
            command = null;
        }
        public void initialize(TimeEvent.Name _name, Index _index, Command _command, float timeToTrigger)
        {
            this.name = _name;
            this.index = _index;
            this.command = _command;
            this.triggerTime = TimeManager.getCurrentTime() + timeToTrigger;
            this.priority = this.triggerTime;
            this.deltaTime = timeToTrigger;
        }
        public Command getCommand()
        {
            return command;
        }
        public void process()
        {
            command.execute(this.deltaTime);
        }
        public void incrementTriggerTime(float _deltaTime)
        {
            this.triggerTime += _deltaTime;
        }
        public float getTriggerTime()
        {
            return this.triggerTime;
        }
        public float getDeltaTime()
        {
            return this.deltaTime;
        }
        override public Enum getName()
        {
            return this.name;
        }
        override public Enum getIndex()
        {
            return this.index;
        }
    }
}
