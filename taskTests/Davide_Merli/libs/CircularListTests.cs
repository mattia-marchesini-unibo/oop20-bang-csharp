using Microsoft.VisualStudio.TestTools.UnitTesting;
using task.Davide_Merli.libs;
using System;
using System.Collections.Generic;
using System.Text;

namespace task.Davide_Merli.libs.Tests
{
    [TestClass()]
    public class CircularListTests
    {
        [TestMethod()]
        public void Current_Element_Index()
        {
            var list = new CircularList<int>();
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(list.GetCurrentElement(), 1);
            Assert.AreEqual(list.CurrentIndex, 0);
        }

        [TestMethod()]
        public void Get_Next_Prev()
        {
            var list = new CircularList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(list.GetNext(), 2);
            Assert.AreEqual(list.GetNext(), 3);
            Assert.AreEqual(list.GetNext(), 1);
            Assert.AreEqual(list.GetPrev(), 3);
            Assert.AreEqual(list.GetPrev(), 2);
            Assert.AreEqual(list.GetPrev(), 1);
        }

        [TestMethod()]
        public void Get_Next_Prev_Of()
        {
            var list = new CircularList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(list.GetNextOf(1), 2);
            Assert.AreEqual(list.GetNextOf(2), 3);
            Assert.AreEqual(list.GetNextOf(3), 1);
            Assert.AreEqual(list.GetPrevOf(1), 3);
            Assert.AreEqual(list.GetPrevOf(2), 1);
            Assert.AreEqual(list.GetPrevOf(3), 2);
        }
    }
}