using BinPacking.Lib;
using BinPacking.Lib.Containers;
using BinPacking.Lib.Packagers;
using BinPacking.Tests.InnerHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace BinPacking.Tests.PackagersTests
{
    [TestFixture]
    public class DefaultPackagerTest
    {
        private Truck Truck = new Truck(new Rectangle(3, 3, 3));

        [Test]
        public void TestOrderContainers_ByValue()
        {
            PrivateObject PrivatePackager = new PrivateObject(new DefaultPackager(new Rectangle(3, 3, 3)));

            var UnorderedContainers = new List<BaseContainer>() { new ClassAContainer(1), new ClassAContainer(2), new ClassAContainer(3) };
            var OrderedContainers = PrivatePackager.Invoke("OrderContainers", UnorderedContainers) as List<BaseContainer>;

            Assert.AreEqual(OrderedContainers[0], UnorderedContainers[2]);
            Assert.AreEqual(OrderedContainers[1], UnorderedContainers[1]);
            Assert.AreEqual(OrderedContainers[2], UnorderedContainers[0]);
        }

        [Test]
        public void TestOrderContainers_BySize()
        {
            PrivateObject PrivatePackager = new PrivateObject(new DefaultPackager(new Rectangle(3, 3, 3)));

            var UnorderedContainers = new List<BaseContainer>() { new ClassAContainer(1), new ClassBContainer(1), new ClassCContainer(1) };
            var OrderedContainers = PrivatePackager.Invoke("OrderContainers", UnorderedContainers) as List<BaseContainer>;

            Assert.AreEqual(OrderedContainers[0], UnorderedContainers[2]);
            Assert.AreEqual(OrderedContainers[1], UnorderedContainers[1]);
            Assert.AreEqual(OrderedContainers[2], UnorderedContainers[0]);
        }
        [Test]
        public void TestOrderContainers_ByValueAndSize_ShouldPrioritizeValue()
        {
            PrivateObject PrivatePackager = new PrivateObject(new DefaultPackager(new Rectangle(3, 3, 3)));

            var UnorderedContainers = new List<BaseContainer>() { new ClassAContainer(1), new ClassBContainer(2), new ClassCContainer(1) };
            var OrderedContainers = PrivatePackager.Invoke("OrderContainers", UnorderedContainers) as List<BaseContainer>;

            Assert.AreEqual(OrderedContainers[0], UnorderedContainers[1]);
            Assert.AreEqual(OrderedContainers[1], UnorderedContainers[2]);
            Assert.AreEqual(OrderedContainers[2], UnorderedContainers[0]);

        }
        [Test]
        public void TestPack_ShouldUseOneTruckPerContainer()
        {
            DefaultPackager Packager = new DefaultPackager(new Rectangle(2,2,2));

            var Containers = TestRepo.InMemoryContainers;

            Packager.Pack(Containers);

            Assert.AreEqual(Packager.Trucks.Count, 3);
            Assert.AreEqual(Packager.Trucks.Sum(x => x.StoredContainers.Count), 3);
            Assert.AreEqual(Packager.Trucks.Sum(x => x.Value), Containers.Sum(x => x.Value));

        }
        [Test]
        public void TestPack_ShouldUseTwoTrucks()
        {
            DefaultPackager Packager = new DefaultPackager(new Rectangle(4, 4, 4));

            var Containers = TestRepo.InMemoryContainers;

            Packager.Pack(Containers);

            Assert.AreEqual(Packager.Trucks.Count, 2);
            Assert.AreEqual(Packager.Trucks.Sum(x => x.StoredContainers.Count), 3);
            Assert.AreEqual(Packager.Trucks.Sum(x => x.Value), Containers.Sum(x => x.Value));
        }
        //TODO: add assertions to check volume and value.
        [Test]
        public void TestPack_ShouldOnlyUseOne()
        {
            DefaultPackager Packager = new DefaultPackager(new Rectangle(8, 8, 8));

            var Containers = TestRepo.InMemoryContainers;

            Packager.Pack(Containers);

            Assert.AreEqual(Packager.Trucks.Count, 1);
            Assert.AreEqual(Packager.Trucks.Sum(x => x.StoredContainers.Count), 3);
            Assert.AreEqual(Packager.Trucks.Sum(x => x.Value), Containers.Sum(x => x.Value));
        }


    }
}
