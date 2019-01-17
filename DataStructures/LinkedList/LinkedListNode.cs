using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class LinkedListNode<T>
    {
        public T Item { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Prev { get; set; }

        public LinkedListNode(T item, LinkedListNode<T> next, LinkedListNode<T> prev)
        {
            Item = item;
            Next = next;
            Prev = prev;
        }

        public LinkedListNode(T item, LinkedListNode<T> next)
        {
            Item = item;
            Next = next;
            Prev = null;
        }

        public LinkedListNode(T item)
        {
            Item = item;
            Next = null;
        }
    }
}
