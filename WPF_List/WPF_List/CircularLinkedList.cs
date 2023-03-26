using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace WPF_List
{
    internal class CircularLinkedList
    {
        public Node Head { get; private set; }
        public int Size { get; private set; }

        public CircularLinkedList()
        {
            Head = null;
            Size = 0;
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
            }
            else
            {
                newNode.Next = Head.Next;
                Head.Next = newNode;
            }
            Size++;
        }

        public void Remove(int data)
        {
            if (Head == null)
                return;

            Node current = Head;

            do
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    Size--;
                    if (Head.Data == data)
                        Head = Head.Next;
                    return;
                }
                current = current.Next;
            } while (current != Head);
        }

        public void AddBefore(int value, int newValue)
        {
            if (Head == null)
                return;

            Node current = Head;
            do
            {
                if (current.Next.Data == value)
                {
                    Node newNode = new Node(newValue);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    if (Head.Data == value)
                        Head = newNode;
                    Size++;
                    return;
                }
                current = current.Next;
            } while (current != Head);
        }

        public void SwapElements(int firstValue, int secondValue)
        {
            if (Head == null)
                return;

            Node firstNode = null;
            Node secondNode = null;
            Node current = Head;

            do
            {
                if (current.Data == firstValue)
                    firstNode = current;

                if (current.Data == secondValue)
                    secondNode = current;

                current = current.Next;
            } while (current != Head);

            if (firstNode == null || secondNode == null)
                return;

            Node firstPrev = GetPreviousNode(firstNode);
            Node secondPrev = GetPreviousNode(secondNode);

            if (firstPrev != null)
                firstPrev.Next = secondNode;
            else
                Head = secondNode;

            if (secondPrev != null)
                secondPrev.Next = firstNode;
            else
                Head = firstNode;

            Node temp = firstNode.Next;
            firstNode.Next = secondNode.Next;
            secondNode.Next = temp;
        }

        private Node GetPreviousNode(Node node)
        {
            Node current = Head;

            while (current != null && current.Next != node)
                current = current.Next;

            return current;
        }

        public void Clear()
        {
            Head = null;
            Size = 0;
        }

        
       }
}

