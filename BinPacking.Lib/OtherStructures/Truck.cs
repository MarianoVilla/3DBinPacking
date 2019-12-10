
using BinPacking.Lib.Containers;
using BinPacking.Lib.OtherStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib
{
    public class Truck
    {
        #region Props.
        public Rectangle Space { get; private set; }
        public decimal Value { get { return StoredContainers.Sum(x => x.Container.Value);  } }
        public double UnusedVolume { get { return Space.Volume; } }
        public List<StoredContainer> StoredContainers { get; private set; } = new List<StoredContainer>();
        public Point3D UsedArea { get; set; } = new Point3D(0, 0, 0);
        #endregion

        #region Constructors.
        public Truck(Rectangle Space)
        {
            this.Space = Space;
        }
        public Truck(double Length, double Width, double Height)
        {
            this.Space = new Rectangle(Length, Width, Height);
        }
        #endregion

        public bool Fits(BaseContainer Container)
        {
            return this.Space.CompareTo(Container.Size) >= 0;
        }
        public bool Add(BaseContainer Container)
        {
            if (Fits(Container))
            {
                ComputeUsedArea(Container);
                SubtractDimensions(Container);
                this.StoredContainers.Add(new StoredContainer(Container, GetCoordinates(Container)));
                return true;
            }
            return false;
        }
        private void ComputeUsedArea(BaseContainer Container)
        {
            UsedArea.X += Container.Size.Width;
            UsedArea.Y += Container.Size.Height;
            UsedArea.Z += Container.Size.Length;
        }
        private Point3D GetCoordinates(BaseContainer Container)
        {
            double xStartingPoint = UsedArea.X - Container.Size.Width;
            double yStartingPoint = UsedArea.Y - Container.Size.Height;
            double zStartingPoint = UsedArea.Z - Container.Size.Length;
            return new Point3D(xStartingPoint, yStartingPoint, zStartingPoint);
        }
        private void SubtractDimensions(BaseContainer Container)
        {
            var xCoordinate = Space.Width = Space.Width - Container.Size.Width;
            var yCoordinate = Space.Height = Space.Height - Container.Size.Height;
            var zCoordinate = Space.Length = Space.Length - Container.Size.Length;
        }

    }
}
