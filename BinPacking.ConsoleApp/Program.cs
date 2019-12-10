using BinPacking.Lib;
using BinPacking.Lib.Containers;
using BinPacking.Lib.Packagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseContainer> Containers = new List<BaseContainer>()
            { new ClassAContainer(1), new ClassBContainer(2), new ClassCContainer(3) };
            DefaultPackager packager = new DefaultPackager(new Rectangle(100, 100, 100));
            packager.Pack(Containers);

        }
    }
}
