using BinPacking.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.OtherStructures
{
    public class StoredContainer
    {
        public BaseContainer Container { get; set; }
        public Point3D Point { get; set; }

        public StoredContainer(BaseContainer Container, Point3D Point)
        {
            this.Container = Container;
            this.Point = Point;
        }

    }
}
