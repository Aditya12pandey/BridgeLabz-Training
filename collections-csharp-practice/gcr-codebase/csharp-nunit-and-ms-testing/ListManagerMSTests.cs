using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace MS.Tests
{
    internal class ListManagerMSTests
    {
        private ListManager _listManager;
        private List<int> _list;

        [TestInitialize]
        public void Setup()
        {
            _listManager = new ListManager();
            _list = new List<int>();
        }

        [TestMethod]
        public void AddElement_ShouldAddElementToList()
        {
            _listManager.AddElement(_list, 5);

            CollectionAssert.Contains(_list, 5);
        }

        [TestMethod]
        public void RemoveElement_ShouldRemoveElementFromList()
        {
            _list.Add(5);
            _list.Add(10);

            _listManager.RemoveElement(_list, 5);

            CollectionAssert.DoesNotContain(_list, 5);
        }

        [TestMethod]
        public void GetSize_ShouldReturnCorrectSize()
        {
            _list.Add(1);
            _list.Add(2);

            int size = _listManager.GetSize(_list);

            Assert.AreEqual(2, size);
        }
    }
}
