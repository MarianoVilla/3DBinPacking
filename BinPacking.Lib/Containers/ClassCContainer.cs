using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.Containers
{
    public class ClassCContainer : BaseContainer
    {
        public ClassCContainer(decimal Value) : base(Value, new Rectangle(1.5, 1.5, 1.5))
        {
        }
    }
}
