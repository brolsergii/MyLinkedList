using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLinkedList.Test
{
    [TestClass]
    public class LinkedListTest
    {
        private ILinkedList GetLinkedList(string listType)
        {
            if (listType == "SinglyLinkedList")
            {
                return new SinglyLinkedList();
            }
            else if (listType == "DoublyLinkedList")
            {
                return new DoublyLinkedList();
            }
            return null;
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void Add1(string listType)
        {
            var ll = GetLinkedList(listType);
            ll.Add("foo");
            var array1 = ll.ToArray();
            Assert.AreEqual(array1.Length, 1);
            Assert.AreEqual(array1[0], "foo");
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void Add2(string listType)
        {
            var ll = GetLinkedList(listType);
            ll.Add("foo");
            ll.Add("bar");
            var array1 = ll.ToArray();
            Assert.AreEqual(array1.Length, 2);
            Assert.AreEqual(array1[0], "foo");
            Assert.AreEqual(array1[1], "bar");
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void AddDuplicates(string listType)
        {
            var ll = GetLinkedList(listType);
            ll.Add("foo");
            ll.Add("foo");
            var array1 = ll.ToArray();
            Assert.AreEqual(array1.Length, 2);
            Assert.AreEqual(array1[0], "foo");
            Assert.AreEqual(array1[1], "foo");
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void ContainsSimple(string listType)
        {
            var ll = GetLinkedList(listType);
            ll.Add("foo");
            ll.Add("bar");
            Assert.AreEqual("foo", ll.Contains("foo").Value);
            Assert.AreEqual("bar", ll.Contains("bar").Value);
            Assert.AreEqual(null, ll.Contains("string1")?.Value);
            Assert.AreEqual(null, ll.Contains(null)?.Value);
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void ContainsEmpty(string listType)
        {
            var ll = GetLinkedList(listType);
            Assert.AreEqual(null, ll.Contains("foo")?.Value);
            Assert.AreEqual(null, ll.Contains("bar")?.Value);
            Assert.AreEqual(null, ll.Contains("string1")?.Value);
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void DeleteEmpty(string listType)
        {
            var ll = GetLinkedList(listType);
            Assert.IsFalse(ll.Delete("foo"));
            Assert.IsFalse(ll.Delete("bar"));
            Assert.IsFalse(ll.Delete("string1"));
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void DeleteSimple(string listType)
        {
            var ll = GetLinkedList(listType);
            ll.Add("foo");
            ll.Add("bar");
            ll.Add("foo2");
            var array1 = ll.ToArray();
            Assert.AreEqual(array1.Length, 3);
            Assert.AreEqual(array1[0], "foo");
            Assert.AreEqual(array1[1], "bar");
            Assert.AreEqual(array1[2], "foo2");
            Assert.IsTrue(ll.Delete("foo"));
            var array2 = ll.ToArray();
            Assert.AreEqual(array2.Length, 2);
            Assert.AreEqual(array2[0], "bar");
            Assert.AreEqual(array2[1], "foo2");
            Assert.IsTrue(ll.Delete("foo2"));
            var array3 = ll.ToArray();
            Assert.AreEqual(array3.Length, 1);
            Assert.AreEqual(array3[0], "bar");
            Assert.IsFalse(ll.Delete("string1"));
            Assert.IsTrue(ll.Delete("bar"));
            var array4 = ll.ToArray();
            Assert.AreEqual(array4.Length, 0);
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void ToArrayEmpty(string listType)
        {
            var ll = GetLinkedList(listType);
            var array1 = ll.ToArray();
            Assert.AreEqual(array1.Length, 0);
        }

        [DataTestMethod]
        [DataRow("SinglyLinkedList")]
        [DataRow("DoublyLinkedList")]
        public void ToArraySimple(string listType)
        {
            var ll = GetLinkedList(listType);
            ll.Add("foo");
            ll.Add("bar");
            ll.Add("foo2");
            var array1 = ll.ToArray();
            Assert.AreEqual(array1.Length, 3);
            Assert.AreEqual(array1[0], "foo");
            Assert.AreEqual(array1[1], "bar");
            Assert.AreEqual(array1[2], "foo2");
        }
    }
}
