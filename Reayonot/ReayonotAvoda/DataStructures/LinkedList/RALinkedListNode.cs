using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ReayonotAvoda.LinkedList
{
    /*
     * xtremeio
     */
    class RALinkedListNode<T>
    {
        private RALinkedListNode<T> Previous;
        private RALinkedListNode<T> Next;
        private T Hash;

        public RALinkedListNode(T newNodeHash)
        {
            Hash = newNodeHash;
        }
        public void SetNext(RALinkedListNode<T> node)
        {
            Next = node;
        }
        public void SafeAddNext(RALinkedListNode<T> node)
        {
            if (Next != null)
            {
                SetNext(node);
            }
            else
            {
                Next.SetPrevious(node);
                node.SetNext(Next);
                node.SetPrevious(this);
                SetNext(node);
            }
        }
        public void SetPrevious(RALinkedListNode<T> node)
        {
            Previous = node;
        }
        public void SafeAddPrevious(RALinkedListNode<T> node)
        {
            if (Previous != null)
            {
                SetPrevious(node);
            }
            else
            {
                Previous.SetNext(node);
                node.SetNext(this);
                node.SetPrevious(Previous);
                SetPrevious(node);
            }  
        }
        public void SetHash(T hash)
        {
            Hash = hash;
        }
        public T GetHash(T hash)
        {
            return Hash;
        }
        public int CountTotal()
        {
            return HowManyNodesAreLeft() + HowManyNodesHaveBeenPassed() + 1;
        }
        public int HowManyNodesAreLeft()
        {
            RALinkedListNode<T> movingNode = this;
            int counter = 0;

            while (movingNode.Next != null)
            {
                movingNode = movingNode.Next;
                counter++;
            }

            return counter;
        }
        public int HowManyNodesHaveBeenPassed()
        {
            RALinkedListNode<T> movingNode = this;
            int counter = 0;

            while (movingNode.Previous != null)
            {
                movingNode = movingNode.Previous;
                counter++;
            }

            return counter;
        }
        public RALinkedListNode<T> GetFirstNodeInList()
        {
            RALinkedListNode<T> movingNode = this;

            while (movingNode.Previous != null)
            {
                movingNode = movingNode.Previous;
            }

            return movingNode;
        } 
        public RALinkedListNode<T> GetLastNodeInList()
        {
            RALinkedListNode<T> movingNode = this;

            while (movingNode.Next != null)
            {
                movingNode = movingNode.Next;
            }

            return movingNode;
        }
        public RALinkedListNode<T> GetNodeByNumber(int place)
        {
            if (place > CountTotal())
            {
                return null;
            }

            RALinkedListNode<T> movingNode = this;
            int currentPlace = 0;

            while (movingNode.Previous != null)
            {
                movingNode = movingNode.Previous;
            }

            while (currentPlace != place)
            {
                movingNode = movingNode.Next;
                currentPlace++;
            }

            return movingNode;
        }
        public void AddFirst(RALinkedListNode<T> node)
        {
            RALinkedListNode<T> movingNode = this;

            while (movingNode.Previous != null)
            {
                movingNode = movingNode.Previous;
            }

            movingNode.SafeAddNext(node);
        }
        public void AddLast(RALinkedListNode<T> node)
        {
            RALinkedListNode<T> movingNode = this;

            while (movingNode.Next != null)
            {
                movingNode = movingNode.Next;
            }

            movingNode.SafeAddNext(node);
        }
        public bool DoesTheListConain(RALinkedListNode<T> node)
        {
            RALinkedListNode<T> movingNode = this;
            while (movingNode != null)
            {
                if (movingNode == node)
                {
                    return true;
                }

                movingNode = GetNext();
            }

            movingNode = this;

            while (movingNode != null)
            {
                if (movingNode == node)
                {
                    return true;
                }

                movingNode = GetNext();
            }

            return false;
        }
        public bool Equals(RALinkedListNode<T> node)
        {
            return Hash.Equals(node.Hash);
        }
        public void Delete()
        {
            if (Previous != null)
            {
                if (Next != null)
                {
                    Previous.Next = Next;
                    Next.Previous = Previous;
                }
                else
                {
                    Previous.Next = null;
                }
            }
            else
            {
                if (Next != null)
                {
                    Next.Previous = null;
                }
            }
        }
        public void RemoveNodeByNode(RALinkedListNode<T> node)
        {
            RALinkedListNode<T> movingNode = this;
            while (movingNode != null)
            {
                if (movingNode == node)
                {
                    movingNode.Delete();
                }

                movingNode = GetNext();
            }

            movingNode = this;

            while (movingNode != null)
            {
                if (movingNode == node)
                {
                    movingNode.Delete();
                }

                movingNode = GetNext();
            }
        }
        public void RemoveNodeByNumber(int place)
        {
            GetNodeByNumber(place).Delete();
        }
        public void CopyToLocationByNode(int node, int place)
        {
            AddNodeToLocation(GetNodeByNumber(node), place);
        }
        public void AddNodeToLocation(RALinkedListNode<T> node, int place)
        {
            node.Previous = GetNodeByNumber(place).Previous;
            node.Next = GetNodeByNumber(place);
            GetNodeByNumber(place).Previous.Next = node;
            GetNodeByNumber(place).Previous = node;
        }
        public void RemoveFirst()
        {
            GetNodeByNumber(0).Delete();
        }
        public void RemoveLast()
        {
            GetNodeByNumber(CountTotal() - 1).Delete();
        }
        public RALinkedListNode<T> GetNext()
        {
            return this.Next;
        }
        public RALinkedListNode<T> GetPrevious()
        {
            return this.Previous;
        }
    }
}
