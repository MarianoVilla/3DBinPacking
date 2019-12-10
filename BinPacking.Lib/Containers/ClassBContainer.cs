using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.Containers
{
    public class ClassBContainer : BaseContainer
    {
        public ClassBContainer(decimal Value) : base(Value, new Rectangle(1.5, 2.0, 1.0))
        {
        }
    }
}
