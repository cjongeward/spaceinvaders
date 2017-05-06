using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class List
    {
        public abstract void add(LinkNode _node);
        public abstract LinkNode find(Enum _name, Index _index);
        public abstract LinkNode remove(Enum _name, Index _index);
        public abstract void remove(LinkNode l);
        public abstract LinkNode pop();
        public abstract LinkNode getHead();
        public abstract int getLength();
    }
}
