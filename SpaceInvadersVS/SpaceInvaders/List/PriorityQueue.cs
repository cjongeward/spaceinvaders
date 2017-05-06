using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PriorityQueue : List
    {
        private int length;
        private LinkNode head;

        public PriorityQueue()
        {
            this.length = 0;
            this.head = null;
        }
        public override LinkNode getHead()
        {
            return head;
        }
        public override int getLength()
        {
            return this.length;
        }
        public override void add(LinkNode _node)
        {
            Debug.Assert(_node != null);
            if (this.head == null)
            {
                this.head = _node;
                _node.setNext(null);
                _node.setPrev(null);
            }
            else
            {
                if(_node.priority < this.head.priority)
                {
                    _node.setNext(this.head);
                    this.head.setPrev(_node);
                    this.head = _node;
                }
                else
                {
                    LinkNode current = this.head;
                    while (current.getNext() != null)
                    {
                        if (_node.priority < current.getNext().priority)
                        {
                            _node.setNext(current.getNext());
                            current.getNext().setPrev(_node);
                            _node.setPrev(current);
                            current.setNext(_node);
                            break;
                        }
                        current = current.getNext();
                    }
                    if (current.getNext() == null)
                    {
                        current.setNext(_node);
                        _node.setPrev(current);
                    }
                }
            }
            this.length++;
        }

        public override LinkNode find(Enum _name, Index _index)
        {
            return this.head;
        }
        public override LinkNode remove(Enum _name, Index _index)
        {
            return this.head;
        }
        public override LinkNode pop()
        {
            return this.head;
        }

        public override void remove(LinkNode _node)
        {
            if (_node.getNext() != null)
            {
                _node.getNext().setPrev(_node.getPrev());
            }
            if (_node.getPrev() != null)
            {
                _node.getPrev().setNext(_node.getNext());
            }
            else
            {
                this.head = _node.getNext();
            }
            _node.baseClear();
            this.length--;
        }
    }
}
