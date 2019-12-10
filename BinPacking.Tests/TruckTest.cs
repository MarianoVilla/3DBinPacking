using BinPacking.Lib;
using BinPacking.Lib.Containers;
using BinPacking.Lib.OtherStructures;
using BinPacking.Tests.InnerHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Tests
{
    [TestFixture]
    public class TruckTest
    {
        private List<BaseContainer> Containers = TestRepo.InMemoryContainers;
        [Test]
        public void TestFits_ShouldFit()
        {
            Truck truck = new Truck(new Rectangle(2, 2, 2));

            Assert.True(truck.Fits(new ClassAContainer(1)));
            Assert.True(truck.Fits(new ClassBContainer(1)));
            Assert.True(truck.Fits(new ClassCContainer(1)));
        }
        [Test]
        public void TestFits_ShouldNotFit()
        {
            Truck truck = new Truck(new Rectangle(1, 1, 1));

            Assert.False(truck.Fits(new ClassAContainer(1)));
            Assert.False(truck.Fits(new ClassBContainer(1)));
            Assert.False(truck.Fits(new ClassCContainer(1)));
        }
        [Test]
        public void TestAdd_ShouldAddAll()
        {
            Truck truck = new Truck(new Rectangle(10, 10, 10));
            foreach (var c in Containers)
            {
                truck.Add(c);
            }
            Assert.AreEqual(truck.StoredContainers.Count, 3);
            Assert.AreEqual(truck.Value, Containers.Sum(x => x.Value));

            var ExpectedRectangle = GeneralHelper.GetExpectedRectangle(new Rectangle(10, 10, 10), Containers.ToArray());

            Assert.AreEqual(truck.UnusedVolume, ExpectedRectangle.Volume);
            Assert.AreEqual(truck.Space.Width, ExpectedRectangle.Width);
            Assert.AreEqual(truck.Space.Height, ExpectedRectangle.Height);
            Assert.AreEqual(truck.Space.Length, ExpectedRectangle.Length);
        }
        [Test]
        public void TestAdd_ShouldAddOne()
        {
            Truck truck = new Truck(new Rectangle(3, 3, 3));
            foreach (var c in Containers)
            {
                truck.Add(c);
            }
            Assert.AreEqual(truck.StoredContainers.Count, 1);
            Assert.AreEqual(truck.Value, Containers[0].Value);
        }
        [Test]
        public void TestAdd_ShouldNotAdd()
        {
            Truck truck = new Truck(new Rectangle(1, 1, 1));
            foreach (var c in Containers)
            {
                truck.Add(c);
            }
            Assert.AreEqual(truck.StoredContainers.Count, 0);
            Assert.AreEqual(truck.Value, 0);
        }
        [Test]
        public void TestUsedArea()
        {
            Truck truck = new Truck(new Rectangle(5, 6, 5));
            truck.Add(Containers[0]);
            Assert.AreEqual(truck.UsedArea, new Point3D(1.0, 2.0, 1.0));
            truck.Add(Containers[0]);
            Assert.AreEqual(truck.UsedArea, new Point3D(2.0, 4.0, 2.0));
            truck.Add(Containers[2]);
            Assert.AreEqual(truck.UsedArea, new Point3D(3.5, 5.5, 3.5));
            //This won't fit, so the used area should remain the same.
            truck.Add(Containers[0]);
            Assert.AreEqual(truck.UsedArea, new Point3D(3.5, 5.5, 3.5));
        }
    }
}
