using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleII
{
    /// <summary>
    /// This struct stores the two-dimensional locational
    /// coordinates (x,y)
    /// </summary>
    public struct Point
    {
        #region fields

        // Two public double fields, X and Y
        // That represent a coordinate (X,Y)
        public double X, Y;

        #endregion fields

        #region constructors

        /// <summary>
        /// A constructor that accepts two parameters to assign to X and Y.
        /// </summary>
        /// <param name="x">X coordinate (double)</param>
        /// <param name="y">Y coordinate (double)</param>

        #endregion constructors

        #region methods

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// A public method called Distance() that accepts 
        /// a Point object called other and returns the 
        /// distance between this point and other.
        /// </summary>
        /// <param name="other">(Point) other to calculate distance</param>
        /// <returns>(double) distance between two points</returns>
        public double Distance(Point other)
        {
            double x1 = this.X;
            double y1 = this.Y;
            double x2 = other.X;
            double y2 = other.Y;

            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        /// <summary>
        /// A ToString() override that returns the Point in the string form: (X, Y)
        /// </summary>
        /// <returns>string form: (X, Y)</returns>
        public override string ToString()
        {
            return $"({X},{Y})";
        }

        #endregion methods

    } // end of struct
} // end of namespace
