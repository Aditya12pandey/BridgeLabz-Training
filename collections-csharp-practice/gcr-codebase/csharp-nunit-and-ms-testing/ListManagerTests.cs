using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class ListManagerTests
    {
        private ListManager _listManager;
        private List<int> _list;

        [SetUp]
        public void Setup()
        {
            _listManager = new ListManager();
            _list = new List<int>();
        }

        [Test]
        public void AddElement_ShouldAddElementToList()
        {
            _listManager.AddElement(_list, 10);

            Assert.Contains(10, _list);
        }

        [Test]
        public void RemoveElement_ShouldRemoveElementFromList()
        {
            _list.Add(10);
            _list.Add(20);

            _listManager.RemoveElement(_list, 10);

            Assert.IsFalse(_list.Contains(10));
        }

        [Test]
        public void GetSize_ShouldReturnCorrectSize()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);

            int size = _listManager.GetSize(_list);

            Assert.AreEqual(3, size);
        }
    }
}
