using System;
using System.Collections.Generic;
using System.Text;

namespace ta1
{
    internal class Queue<T>
    {
        Node<T> head;
        Node<T> tail;
        public int count = 0;
        public void Add(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
                tail = head;
            }
            else
            {

                tail.Next = new Node<T>(data);
                tail = tail.Next;
            }
            count++;
        }
        public T Poll()
        {
            if (count == 0)
                throw new InvalidOperationException("Черга пуста!");
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        public int Size()
        {
            return count;
        }
    }
}
