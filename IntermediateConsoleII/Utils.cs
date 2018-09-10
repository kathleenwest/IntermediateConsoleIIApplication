using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleII
{
    /// <summary>
    /// a static class that contains static methods
    /// basic utilities
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Determines equality for double type values based on a small
        /// margin of error 0.0001. 
        /// This method of Utils will accept two double values and 
        /// attempt to determine if they are relatively equal 
        /// (within some margin of error).
        /// If the absolute value of the difference between d1 
        /// and d2 is less than the margin of error then the method 
        /// should return true, otherwise false.
        /// </summary>
        /// <param name="d1">(double) value 1</param>
        /// <param name="d2">(double) value 2</param>
        /// <returns>boolean true (if Equal) or false otherwise</returns>
        public static bool IsRelativelyEqual(double d1, double d2)
        {
            double margin = Math.Abs(0.0001*(d1 + d2)/2.0);
            double difference = Math.Abs(d2 - d1);

            if(difference <= margin)
            {
                return true;
            }
            else
            {
                return false;
            }
        } // end of method IsRelativelyEqual

        /// <summary>
        /// Determines the boundary box for a list of points.
        /// Determines the minimum, and maximum points and creates
        /// a boundary box for the list of points.
        /// This method accepts a list of Point objects and determines 
        /// the smallest and largest values for the given list’s X and Y 
        /// members. The Tuple that is returned contains the 4 corresponding 
        /// values in this order: minx, minY, maxX, maxY:
        /// With these four values a “bounding box”, or rectangle, can be 
        /// created that represents the smallest rectangular area that 
        /// contains all of the given Point objects.
        /// </summary>
        /// <param name="points">List of Point types</param>
        /// <returns>(double) Tuple of boundary box</returns>
        public static Tuple<double, double, double, double> GetBoundingBox(List<Point> points)
        {
            double minX, minY, maxX, maxY;

            if (points != null)
            {
                // Set the first boundary point
                minX = points[0].X;
                minY = points[0].Y;
                maxX = minX;
                maxY = minY;

                foreach (Point point in points)
                {
                    if (point.X < minX)
                    {
                        minX = point.X;
                    }
                    if (point.Y < minY)
                    {
                        minY = point.Y;
                    }
                    if (point.X > maxX)
                    {
                        maxX = point.X;
                    }
                    if (point.Y > maxY)
                    {
                        maxY = point.Y;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("List<Point> points", "Input needs to be not null");
            }

            return new Tuple<double, double, double, double>(minX, minY, maxX, maxY);
        } // end of method

    } //end of class
} // end of namespace
