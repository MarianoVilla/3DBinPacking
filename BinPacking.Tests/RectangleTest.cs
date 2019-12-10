using BinPacking.Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Tests
{
    [TestFixture]
    public class RectangleTest
    {
        [Test]
        public void TestCompare()
        {
            Rectangle Rect = new Rectangle(1, 1, 1);

            Assert.AreEqual(Rect.CompareTo(new Rectangle(0.5, 0.5, 0.5)), 1);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(0.99, 0.99, 0.99)), 1);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(1, 0.99, 0.99)), 1);

            Assert.AreEqual(Rect.CompareTo(null), 1);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(1, 1, 1)), 0);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(1, 1, 2)), -1);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(1.5, 1.5, 1.5)), -1);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(0.5, 1.5, 1.5)), -1);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(1.5, 0.5, 1.5)), -1);
            Assert.AreEqual(Rect.CompareTo(new Rectangle(1.5, 1.5, 0.5)), -1);
        }
    }
}
