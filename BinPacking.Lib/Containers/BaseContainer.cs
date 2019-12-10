using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.Containers
{
    public abstract class BaseContainer
    {
        #region Props.
        //There's a hard assumption here: all of our containers are of rectangular shape. This may be replace with an interface for a shape, to avoid the dependency as well.
        public Rectangle Size{ get; }
        public decimal Value { get; }
        #endregion

        #region Constructors.
        public BaseContainer(decimal Value, Rectangle Space)
        {
            this.Value = Value;
            this.Size = Space;
        }
        public BaseContainer(decimal Value, float Length, float Width, float Height)
        {
            this.Value = Value;
            this.Size = new Rectangle(Length, Width, Height);
        }
        #endregion



    }
}
