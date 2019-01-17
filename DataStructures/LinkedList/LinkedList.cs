using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        public int Length { get; private set; }

        public LinkedList()
        {
            head = null;
            Length = 0;
            tail = head;
        }


        public void Add(T item)
        {
            var newNode = new LinkedListNode<T>(item);
            if (Length == 0)
            {
                head = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
            }
            tail = newNode;
            Length++;
        }

        public void AddAt(T item, int index)
        {
            IndexValidation(index);
            if (index == 0)
            {
                var newNode = new LinkedListNode<T>(item, head);
                head = newNode;
            }
            else
            {
                var prevNode = GetNodeAt(index - 1);
                var nextNode = prevNode.Next;
                var newNode = new LinkedListNode<T>(item, nextNode, prevNode);
                prevNode.Next = newNode;
                nextNode.Prev = newNode;
            }
            Length++;
        }

        public void Remove(T item)
        {
            var current = head;
            int itemIndex = -1;
            for (int i = 0; i < Length; i++)
            {
                if (current.Item.Equals(item))
                {
                    itemIndex = i;
                    break;
                }
                current = current.Next;
            }
            if (itemIndex > -1)
                RemoveAt(itemIndex);
        }

        public void RemoveAt(int index)
        {
            IndexValidation(index);
            if (Length == 0) return;

            if (index == 0)
            {
                head = head.Next;
            }
            else if (index == Length - 1)
            {
                tail.Prev.Next = null;
                tail = tail.Prev;
            }
            else
            {
                var prevNode = GetNodeAt(index - 1);
                var nextNode = GetNodeAt(index + 1);
                var removedNode = prevNode.Next;
                prevNode.Next = nextNode;
                nextNode.Prev = prevNode;
            }

            Length--;
        }

        public T ElementAt(int index)
        {
            IndexValidation(index);
            var current = GetNodeAt(index);
            return current.Item;
        }

        private void IndexValidation(int index)
        {
            if (index < 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private LinkedListNode<T> GetNodeAt(int index)
        {
            IndexValidation(index);

            var result = head;

            for (int i = 0; i < index; i++)
            {
                result = result.Next;
            }

            return result;
        }

        //GetEnumerator implementation using yield
        //public IEnumerator<T> GetEnumerator()
        //{
        //    var current = head;
        //    while (current != null)
        //    {
        //        var curr = current;
        //        current = current.Next;
        //        yield return curr.Item;
        //    }
        //}

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ListEnumerator : IEnumerator<T>
        {
            private LinkedListNode<T> current;
            private LinkedListNode<T> head;
            private int currentIndex = -1;
            private int length;

            public ListEnumerator(LinkedList<T> lst)
            {
                head = lst.head;
                current = lst.head;
                length = lst.Length;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return current.Item;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (currentIndex != -1)
                    current = current.Next;
                currentIndex++;
                return (currentIndex < length);
            }

            public void Reset()
            {
                current = head;
                currentIndex = -1;
            }
        }
    }
}
