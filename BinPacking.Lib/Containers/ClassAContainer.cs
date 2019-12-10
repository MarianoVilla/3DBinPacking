using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.Containers
{
    public class ClassAContainer : BaseContainer
    {
        public ClassAContainer(decimal Value) : base(Value, new Rectangle(1.0, 2.0, 1.0))
        {
        }
    }
}
