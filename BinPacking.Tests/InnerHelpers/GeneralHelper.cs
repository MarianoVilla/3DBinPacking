using BinPacking.Lib;
using BinPacking.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Tests.InnerHelpers
{
    public class GeneralHelper
    {
        public static Rectangle GetExpectedRectangle(Rectangle InitialRectangle, params BaseContainer[] ContainersToSubtract)
        {
            InitialRectangle.Width -= ContainersToSubtract.Sum(x => x.Size.Width);
            InitialRectangle.Length -= ContainersToSubtract.Sum(x => x.Size.Length);
            InitialRectangle.Height -= ContainersToSubtract.Sum(x => x.Size.Height);
            return InitialRectangle;
        }
    }
}
