using BinPacking.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.Packagers
{
    public class DefaultPackager: IBinPackager
    {
        public List<Truck> Trucks { get; } = new List<Truck>();
        public Rectangle TrucksCapacity { get; }

        public DefaultPackager(Rectangle TrucksCapacity)
        {
            this.TrucksCapacity = TrucksCapacity;
            Trucks.Add(new Truck((Rectangle)TrucksCapacity.Clone()));
        }

        public void Pack(IEnumerable<BaseContainer> Containers)
        {
            Containers = OrderContainers(Containers);
            foreach(var c in Containers)
            {
                var FirstTruckWhereItFits = Trucks.FirstOrDefault(x => x.Fits(c));
                if (FirstTruckWhereItFits == null)
                {
                    Trucks.Add(new Truck((Rectangle)TrucksCapacity.Clone()));
                    var LastTruck = Trucks.Last();
                    LastTruck.Add(c);
                }
                else
                {
                    FirstTruckWhereItFits.Add(c);
                    continue;
                }
            }
        }
        /// <summary>
        /// The containers are ordered by value and then by size, both descending. The size comparision is delegated entirely to the <see cref="Rectangle"/>.
        /// </summary>
        /// <returns>An ordered list of containers.</returns>
        private List<BaseContainer> OrderContainers(IEnumerable<BaseContainer> Containers)
        {
            return Containers.OrderByDescending(x => x.Value).ThenByDescending(x => x.Size).ToList();
        }
    }
}
