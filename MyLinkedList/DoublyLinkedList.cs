using System.Collections.Generic;
using System.Linq;

namespace MyLinkedList
{
    public sealed class DoublyLinkedNode : Node
    {
        public DoublyLinkedNode Previous;
        public DoublyLinkedNode Next;
    }

    public sealed class DoublyLinkedList : ILinkedList
    {
        DoublyLinkedNode Top = null;

        /// <summary>
        /// Adds a new node to the end with a O(1) complexity.
        /// </summary>
        public void Add(string value)
        {
            var newNode = new DoublyLinkedNode { Value = value, Previous = null, Next = null };
            if (Top == null)
            {
                Top = newNode;
                Top.Next = Top;
                Top.Previous = Top;
            }
            else
            {
                newNode.Previous = Top.Previous;
                newNode.Next = Top;
                Top.Previous.Next = newNode;
                Top.Previous = newNode;
            }
        }

        /// <summary>
        /// Looks for a given value with a O(N) complexity.
        /// </summary>
        public Node Contains(string value)
        {
            if (Top == null)
            {
                return null;
            }
            var currentNode = Top;
            bool firstLoop = true; // breaks the infinite loop
            while (firstLoop || currentNode != Top)
            {
                firstLoop = false;
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            // At this point nothing was found
            return null;
        }

        /// <summary>
        /// Deletes the first appearance of a given value with a O(N) complexity.
        /// </summary>
        public bool Delete(string value)
        {
            if (Top == null)
            {
                return false;
            }
            var currentNode = Top;
            bool firstLoop = true; // breaks the infinite loop
            while (firstLoop || currentNode != Top)
            {
                firstLoop = false;
                if (currentNode.Value == value)
                {
                    if (currentNode == Top) // Top node case
                    {
                        if (Top.Previous == Top && Top.Next == Top) // Top is the last node
                        {
                            Top = null;
                            return true;
                        }
                        {
                            Top = Top.Next;
                            // no return here as we'd like the rest of the code to execute
                        }
                    }
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            // At this point nothing could be deleted
            return false;
        }

        /// <summary>
        /// Converts the linked list to an array with a O(N) complexity.
        /// </summary>
        public string[] ToArray() => ToEnumerable().ToArray();

        private IEnumerable<string> ToEnumerable()
        {
            if (Top != null)
            {
                var currentNode = Top;
                bool firstLoop = true; // breaks the infinite loop
                while (firstLoop || currentNode != Top)
                {
                    firstLoop = false;
                    yield return currentNode.Value;
                    currentNode = currentNode.Next;
                }
            }
        }
    }
}
