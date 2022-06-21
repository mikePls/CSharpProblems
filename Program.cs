using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>() { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50 };
            Console.WriteLine("Print:");
            list.Print();
            //Console.WriteLine("Add head");
            //list.AddFirst(0);
            //list.AddFirst(-1);
            Console.WriteLine("Print reversed");
            list.PrintReverse();
            //Console.WriteLine("Remove head and tail");
            //list.RemoveFirst();
            //list.RemoveLast();
            //Console.WriteLine("Print");
            //list.Print();
            //Console.WriteLine("Print reversed");
            //list.PrintReverse();
            Console.WriteLine("Print with enumerator");
            foreach (int i in list)
            {
                Console.WriteLine($"--> {i}");
            }
            Console.WriteLine();
            //Console.WriteLine("Remove item from position '1'");
            //list.RemoveByIndex(1);
            //list.Print();
            //list.PrintReverse();
            Console.WriteLine("Remove by reverse index '0'");
            list.RemoveByReverseIndex(0);
            //list.Print();
            Console.WriteLine("Remove by reverse index '9'");
            list.RemoveByReverseIndex(9);
            list.Print();

        }
    }

    class DoublyLinkedList<T> : IEnumerable<T>
    {
        Node<T> head = null;
        Node<T> tail = null;

        public DoublyLinkedList() { }

        public DoublyLinkedList(Node<T> head) { this.head = head; }
        public DoublyLinkedList(T[] args)
        {
            foreach(T item in args)
            {
                this.AddLast(item);
            }
        }

        public void Add(T t)
        {
            AddLast(t);
        }
        public void AddFirst(T t)
                {
                    if(head == null)
                    {
                        head = new Node<T>(t);
                        return;
                    }
                    var temp = new Node<T>(t);
                    head.Prev = temp;
                    temp.Next = head;
                    head = temp;
                }
        public void AddLast(T t)
        {
            if (head == null)
            {
                head = new Node<T>();
                head.Data = t;
                return;
            }

            if (tail == null)
            {
                tail = new Node<T>(t);
                head.Next = tail;
                tail.Prev = head;
            }
            else
            {
                var temp = new Node<T>(t);
                tail.Next = temp;
                temp.Prev = tail;
                tail = temp;
            }
        }
        public void RemoveFirst()
        {
            head = head.Next;
            head.Prev = null;
        }
        public void RemoveLast()
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        public void RemoveByIndex(int i)
        {
            var current = head;
            var n = 0;
            while (current != null)
            {
                if (i == 0)
                {
                    RemoveFirst();
                    return;
                }
                else if(i == n)
                {
                    if (current.Next != null)
                    {
                        Console.WriteLine("bingo");
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                        return;
                    }
                    else
                    {
                        RemoveLast();
                        return;
                    }
                }
                n++;
                current = current.Next;
            }
        }
        public bool RemoveByReverseIndex(int i)
        {
            if (tail == null || head == null)
            {
                return false;
            }
            var index = 0;
            var current = tail;
            while(current != null)
            {
                Console.WriteLine($"current index= {index}");
                if (i == 0)
                {
                    RemoveLast();
                    return true;
                }
                else if (index == i)
                {
                    Console.WriteLine($"Removing node with value {current.Data}");
                    RemoveNode(current);
                    return true;
                }
                index++;
                current = current.Prev;
            }
            return false;
        }
        public void RemoveNode(Node<T> node)
        {
            if(node.Prev != null && node.Next != null)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
                return;
            }
            if (node.Prev == null)
            {
                head = node.Next;
                head.Prev = null;
            }
            else if (node.Next == null)
            {
                tail = node.Prev;
                tail.Next = null;
            }
        }
        public void Print() 
        {
            Node<T> current = head;
            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void PrintReverse()
        {
            var current = tail;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Prev;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(T? other)
        {
            throw new NotImplementedException();
        }

        internal class Node<N> 
        {
            internal Node<N> Next;
            internal Node<N> Prev;
            internal N Data;

            public Node() { }
            public Node(N n)
            {
                this.Data = n;
            }
            public bool HasNext()
            {
                return Next != null;
            }
            public bool HasPrev()
            {
                return Prev != null;
            }

            public bool HasPrevious()
            {
                return Prev != null;
            }
        }

    }
}
