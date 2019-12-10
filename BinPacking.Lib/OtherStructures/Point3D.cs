using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking.Lib.OtherStructures
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override bool Equals(object obj)
        {
            var Point = obj as Point3D;
            if(Point == null)
            {
                return false;
            }
            return (X == Point.X) && (Y == Point.Y) && (Z == Point.Z);
        }
        //This is an awful override.
        public override int GetHashCode()
        {
            return (X + Y + Z).GetHashCode();
        }
    }
}
