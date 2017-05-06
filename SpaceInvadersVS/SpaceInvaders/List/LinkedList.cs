using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class LinkedList : List
    {
        private int length;
        private LinkNode head;

        public LinkedList()
        {
            length = 0;
            head = null;
        }
        public override void add(LinkNode _node)
        {
            Debug.Assert(_node != null);
            if (this.head == null)
            {
                this.head = _node;
            }
            else
            {
                LinkNode current = this.head;
                while (current.getNext() != null)
                {
                    current = current.getNext();
                }
                current.setNext(_node);
            }
            ++this.length;
        }
        public override LinkNode find(Enum _name, Index _index = Index.INDEX_none)
        {
            LinkNode current = this.head;
            while (current != null)
            {
                if (current.getName().Equals(_name) && current.getIndex().Equals(_index))
                {
                    break;
                }
                current = current.getNext();
            }
            return current;
        }
        public void clear()
        {
            LinkNode current = this.head;
            while (current != null)
            {
                LinkNode temp = current;
                current = current.getNext();
                remove(temp);
            }
        }
        public override LinkNode remove(Enum _name, Index _index = Index.INDEX_none)
        {
            LinkNode current = this.head;
            LinkNode outNode = null;
            if (current != null)
            {
                if (current.getName().Equals(_name) && current.getIndex().Equals(_index))
                {
                    outNode = current;
                    this.head = current.getNext();
                    --this.length;
                }
                else
                {
                    while (current.getNext() != null)
                    {
                        if (current.getNext().getName().Equals(_name) && current.getIndex().Equals(_index))
                        {
                            outNode = current.getNext();
                            current.setNext(current.getNext().getNext());
                            --this.length;
                            break;
                        }
                        current = current.getNext();
                    }
                }
            }
            return outNode;
        }
        public override void remove(LinkNode l)
        {
            LinkNode current = this.head;
            LinkNode outNode = null;
            if (current != null)
            {
                if (current.Equals(l))
                {
                    outNode = current;
                    this.head = current.getNext();
                    --this.length;
                }
                else
                {
                    while (current.getNext() != null)
                    {
                        if (current.getNext().Equals(l))
                        {
                            outNode = current.getNext();
                            current.setNext(current.getNext().getNext());
                            --this.length;
                            break;
                        }
                        current = current.getNext();
                    }
                }
            }
        }
        public override LinkNode pop()
        {
            LinkNode outVal = null;
            if (this.length > 0)
            {
                outVal = this.head;
                this.head = this.head.getNext();
                outVal.next = null;
                length--;
            }
            return outVal;
        }
        public override LinkNode getHead()
        {
            return head;
        }
        public override int getLength()
        {
            return length;
        }
    }
}
