using BinPacking.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.Packagers
{
    public interface IBinPackager
    {
        List<Truck> Trucks { get; }
        Rectangle TrucksCapacity { get; }
        void Pack(IEnumerable<BaseContainer> Containers);
    }
}
