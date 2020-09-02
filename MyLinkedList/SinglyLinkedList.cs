using System.Collections.Generic;
using System.Linq;

namespace MyLinkedList
{
    public sealed class SinglyLinkedNode : Node
    {
        public SinglyLinkedNode Next;
    }

    public sealed class SinglyLinkedList : ILinkedList
    {
        SinglyLinkedNode Top = null;

        /// <summary>
        /// Adds a new node to the end with a O(N) complexity.
        /// </summary>
        public void Add(string value)
        {
            var newNode = new SinglyLinkedNode { Value = value, Next = null };
            if (Top == null)
            {
                Top = newNode;
            }
            else
            {
                var currentNode = Top;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
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
            while(currentNode != null)
            {
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
            SinglyLinkedNode previousNode = null;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    if(previousNode == null) // Top node case
                    {
                        Top = Top.Next;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;
                    }
                    return true; // Also breaks the loop
                }
                previousNode = currentNode;
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
                while (currentNode != null)
                {
                    yield return currentNode.Value;
                    currentNode = currentNode.Next;
                }
            }
        }
    }
}
