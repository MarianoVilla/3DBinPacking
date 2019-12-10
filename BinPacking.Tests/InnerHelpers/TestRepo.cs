using BinPacking.Lib;
using BinPacking.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Tests.InnerHelpers
{
    public class TestRepo
    {
        public static Truck InMemoryTruck { get; } = new Truck(new Rectangle(1, 1, 1));
        public static List<BaseContainer> InMemoryContainers { get; } = new List<BaseContainer>()
            { new ClassAContainer(1), new ClassBContainer(2), new ClassCContainer(3) };
    }
}
