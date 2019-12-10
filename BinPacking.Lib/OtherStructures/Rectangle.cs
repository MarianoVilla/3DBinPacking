using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib
{
    public class Rectangle : IComparable, ICloneable
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Volume { get { return (Length * Width * Height); } }


        public Rectangle(double Width, double Height, double Length)
        {
            if (!ValidDimensions(Length, Width, Height))
                throw new ArgumentException("The Length, Width and Height have to be positive");

            this.Length = Length;
            this.Width = Width;
            this.Height = Height;
        }
        private bool ValidDimensions(params double[] Dimensions) => Dimensions.All(x => x > 0);

        public int CompareTo(object rectangle)
        {
            //If the incoming rectangle is null, this is bigger: "nothing" fits everywhere.
            if (rectangle == null)
                return 1;

            Rectangle rect = rectangle as Rectangle;

            if(rect == null)
                throw new ArgumentException("No known comparision.");

            if (SmallerInAnyDimension(rect))
                return -1;
            if (EqualInEveryDimension(rect))
                return 0;
            //We could return in an else of the first if, but I think this is clearer.
            if (BiggerInEveryDimension(rect) || !SmallerInAnyDimension(rect))
                return 1;

            //When none of the containers is strictly bigger (in dimensions), we consider the volume instead.
            return CompareVolumes(rect);

            throw new ArgumentException("No known comparision.");

        }
        //If the incoming rectangle is bigger in any dimension, then there's no way to fit it in: this is smaller.
        private bool SmallerInAnyDimension(Rectangle rect)
        {
            return ((this.Height - rect.Height) < 0) || ((this.Width - rect.Width) < 0) || ((this.Length - rect.Length) < 0);
        }
        //If this is bigger in every dimension, we can rest assure that this is bigger.
        private bool BiggerInEveryDimension(Rectangle rect)
        {
            return ((this.Height - rect.Height) > 0) && ((this.Width - rect.Width) > 0) && ((this.Length - rect.Length) > 0);
        }
        //If the incoming rectangle is equal in every dimension, then we have an equally sized rectangle. Ignoring physical constraints for simplicity, we could say that the rectangle "fits".
        private bool EqualInEveryDimension(Rectangle rect)
        {
            return ((this.Height - rect.Height) == 0) && ((this.Width - rect.Width) == 0) && ((this.Length - rect.Length) == 0);
        }
        private int CompareVolumes(Rectangle rect)
        {
            if (this.Volume - rect.Volume > 0)
                return 1;           
            if (this.Volume - rect.Volume == 0)
                return 0;           
            if (this.Volume - rect.Volume < 0)
                return -1;
            throw new ArgumentException("Non-comparable volumes.");
        }

        public object Clone()
        {
            return new Rectangle(this.Length, this.Width, this.Height);
        }
    }
}
