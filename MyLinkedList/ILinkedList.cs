namespace MyLinkedList
{
    public interface ILinkedList
    {
        /// <summary>
        /// Adds a new item to the linked list.
        /// </summary>
        /// <param name="value">Value of the new item.</param>
        public void Add(string value);

        /// <summary>
        /// Checks if the linked list contains a given value.
        /// </summary>
        /// <param name="value">Value to check for.</param>
        /// <returns>The node if it was found.</returns>
        public Node Contains(string value);

        /// <summary>
        /// Deletes one node of a given value from the linked list.
        /// </summary>
        /// <param name="value">Value to delete.</param>
        /// <returns>True if the value was successfully deleted, false if it wasn't.</returns>
        public bool Delete(string value);

        /// <summary>
        /// Converts the linked list into an array of strings.
        /// </summary>
        /// <returns>An array containing all strings from the linked list.</returns>
        public string[] ToArray();
    }
}
