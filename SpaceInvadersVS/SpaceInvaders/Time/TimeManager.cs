using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimeManager : Manager
    {
        private float currentTime;
        private float pauseTime;
        private bool paused;
        private bool unpaused;
        public TimeManager()
            : base(30, 5)
        {
            this.currentTime = 0.0f;
            this.pauseTime = 0.0f;
            this.paused = false;
            this.unpaused = false;
        }
        protected override List createActive()
        {
            return new PriorityQueue();
        }
        protected override LinkNode getNodeObject()
        {
            return new TimeEvent();
        }
        public static float getCurrentTime()
        {
            TimeManager inst = SceneManager.getTimeManager();
            return inst.currentTime;
        }
        public static void add(TimeEvent.Name _name, Index _index, Command _command, float timeToTrigger)
        {
            TimeManager inst = SceneManager.getTimeManager();
            TimeEvent node = (TimeEvent)(inst.baseGetReserveNode());
            node.initialize(_name, _index, _command, timeToTrigger);
            inst.baseAdd(node);
        }
        private void remove(TimeEvent t)
        {
            this.baseRemove(t);
        }
        public static void remove(Command c)
        {
            TimeManager inst = SceneManager.getTimeManager();
            //remove node 
            LinkNode l = inst.baseGetHead();
            while (l != null)
            {
                if (((TimeEvent)l).getCommand() == c)
                {
                    inst.baseRemove(l);
                }
                l = l.getNext();
            }
        }
        public static void update(float _currentTime)
        {
            TimeManager inst = SceneManager.getTimeManager();
            if (inst.paused)
            {
                if (inst.unpaused)
                {
                    inst.paused = false;
                    inst.unpaused = false;
                    float deltaTime = _currentTime - inst.pauseTime;
                    inst.insertDelay(deltaTime);
               }
            }
            if (inst.unpaused) inst.unpaused = false;
            if(!inst.paused) 
            {
                inst.currentTime = _currentTime;
                TimeEvent current = (TimeEvent)(inst.baseGetHead());
                TimeEvent next;
                while (current != null)
                {
                    next = (TimeEvent)(current.getNext());
                    if (current.getTriggerTime() <= inst.currentTime)
                    {
                        current.process();
                        inst.remove(current);
                    }
                    else
                    {
                        break;
                    }
                    current = next;
                }
            }
        }
        public static void pause()
        {
            TimeManager inst = SceneManager.getTimeManager();
            inst.paused = true;
            inst.pauseTime = inst.currentTime;
        }
        public static void pause(float deltime)
        {
            TimeManager inst = SceneManager.getTimeManager();
            inst.insertDelay(deltime);
        }
        public static void unpause()
        {
            TimeManager inst = SceneManager.getTimeManager();
            inst.unpaused = true;
        }
        private void insertDelay(float deltime)
        {
            TimeEvent current = (TimeEvent)(this.baseGetHead());
            while (current != null)
            {
                current.incrementTriggerTime(deltime);
                current = (TimeEvent)current.getNext();
            }
        }
    }
}
