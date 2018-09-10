using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleII
{
    /// <summary>
    /// Rectangle: A derivative of the Shape class
    /// </summary>
    class Rectangle : Shape
    {
        #region fields

        // Private Fields for Properties
        private double _width = 0.0;
        private double _height = 0.0;

        #endregion fields

        #region properties

        /// <summary>
        /// Override of the base Vertices property
        /// Has a logic check to the set “mutator” ensuring value contains
        /// exactly two or four Point objects. If valid, calls  
        /// Normalize() with value and assign the result to 
        /// base.Vertices. By the way, when the list contains 
        /// two points it is assumed they represent opposing/diagonal 
        /// vertices, such as top-left and bottom-right.
        /// The get accessor only needs to return base.Vertices.
        /// </summary>
        public override List<Point> Vertices
        {
            get
            {
                return base.Vertices;
            }

            set
            {
                // Check to make sure two or four points for a rectangle
                if ((value.Count == 2) || (value.Count == 4))
                {
                    base.Vertices = Normalize(value);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Verticles", "There must be only 2 or 4 points for the Vertices property");
                }
            } // end of set
        } // end of property

        /// <summary>
        /// Width of the rectangle
        /// The Width property contains only the get accessor which returns 
        /// the width of the rectangle. Since we do not know the order of 
        /// the points in the Vertices list we can use Utils.GetBoundingBox() 
        /// to determine the extents of the Rectangle. Pass Vertices to 
        /// Utils.GetBoundingBox() and the result is a Tuple containing 
        /// four doubles. Assuming the result variable is called bounds, 
        /// the minimum X value of the Rectangle is bounds.Item1 and the 
        /// maximum X value is bounds.Item3. Use these two values to 
        /// calculate the width.
        /// </summary>
        public double Width
        {
            get
            {
                if (Vertices != null)
                {
                    Tuple<double, double, double, double> bounds = Utils.GetBoundingBox(Vertices);
                    _width = Math.Abs(bounds.Item3 - bounds.Item1);
                }

                return _width;
            }
        }

        /// <summary>
        /// Height of the rectangle
        /// The Height property is similar to Width except we are interested 
        /// in different values from Utils.GetBoundingBox(). In this case, 
        /// the minimum Y value is bounds.Item2 and the maximum Y value is 
        /// bounds.Item4.
        /// </summary>
        public double Height
        {
            get
            {
                if (Vertices != null)
                {
                    Tuple<double, double, double, double> bounds = Utils.GetBoundingBox(Vertices);
                    _height = Math.Abs(bounds.Item4 - bounds.Item2);
                }

                return _height;
            }

        }

        #endregion properties

        #region constructors

        /// <summary>
        /// Parameterized constructor - List of vertices
        /// In its body, assigned vertices to the Vertices property. 
        /// It will validate the collection and normalize the points.
        /// </summary>
        /// <param name="points">constructor accepts a list of Point objects</param>
        public Rectangle(List<Point> points) : base(points)
        {

        }

        /// <summary>
        /// Parameterized constructor - 2 vertices
        /// accepts two Point objects instead of a list
        /// Like the previous constructor, this method will utilize the 
        /// Vertices property. However, since the input contains two 
        /// individual Point objects they must first be combined into 
        /// a List<Point> variable to pass to Vertices
        /// </summary>
        /// <param name="v1">first Point object</param>
        /// <param name="v2">second Point object</param>
        public Rectangle(Point v1, Point v2) : base(new List<Point> { v1, v2})
        {

        }

        /// <summary>
        /// Parameterized constructor - 4 vertices
        /// accepts four Point objects instead of a list.
        /// These points should represent the four corners of a rectangle. 
        /// Like the previous constructor, this method will create a list 
        /// of points comprised of the parameter objects and pass 
        /// the list to Vertices.
        /// </summary>
        /// <param name="v1">first Point object</param>
        /// <param name="v2">second Point object</param>
        /// <param name="v3">third Point object</param>
        /// <param name="v4">fourth Point object</param>
        public Rectangle(Point v1, Point v2, Point v3, Point v4) : base(new List<Point> { v1, v2, v3, v4})
        {

        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Overridden method to calculate area of the rectangle
        /// standard rectangle area calculation utilizing Width and Height
        /// </summary>
        /// <returns>(double) value area of the rectangle</returns>
        public override double Area()
        {
            return Width * Height;
        }// end of method Area

        /// <summary>
        /// Virtual method to determine if this is a square
        /// </summary>
        /// <returns>boolean true if a square, false otherwise</returns>
        public virtual bool IsSquare()
        {
            if (Utils.IsRelativelyEqual(Width, Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Normalizes the given input of points
        /// When supplied with two point values, the missing two points 
        /// can be inferred using the given two points. However, when 
        /// four points are provided there is no guarantee that the 
        /// provided points comprise a legal rectangle. It could represent 
        /// another quadrilateral with four randomly selected points. Rather 
        /// than introducing complex logic to determine if four points comprise 
        /// a legal rectangle, we’ll use Utils.GetBoundingBox() to determine 
        /// the smallest rectangle that contains all of the points provided 
        /// in input. Remember, the result of Utils.GetBoundingBox(), var 
        /// bounds, is a Tuple containing four doubles representing the 
        /// extent of the bounding rectangle, where:
        ///     • bounds.Item1 = minimum X
        ///     • bounds.Item2 = minimum Y
        ///     • bounds.Item3 = maximum X
        ///     • bounds.Item4 = maximum Y
        /// Using these values, the four vertices of a rectangle can be 
        /// constructed.For example, the first vertex could be(bounds.Item1, bounds.Item2) 
        /// and the second point could be(bounds.Item1,bounds.Item4)
        /// </summary>
        /// <param name="input">List of Point objects</param>
        /// <returns>List of Point objects (normalized)</returns>
        private List<Point> Normalize(List<Point> input)
        {
            if (input != null)
            {
                Tuple<double, double, double, double> bounds = Utils.GetBoundingBox(input);
                double minimumX = bounds.Item1;
                double minimumY = bounds.Item2;
                double maximumX = bounds.Item3;
                double maximumY = bounds.Item4;

                Point v1 = new Point(minimumX, minimumY);
                Point v2 = new Point(minimumX, maximumY);
                Point v3 = new Point(maximumX, maximumY);
                Point v4 = new Point(maximumX, minimumY);

                return new List<Point> { v1, v2, v3, v4 };
            }
            else
            {
                throw new ArgumentNullException("List<Point> input", "Input is Null");
            }

        }

        /// <summary>
        /// Converts this rectangle to a list of triangles
        /// In computer graphics it is common to convert all 
        /// complex polygons into a series of triangles before 
        /// rendering. A Rectangle can easily be broken into 
        /// two triangles. Assume you have a rectangle with 
        /// vertices (a, b, c, d) in clockwise order. This 
        /// can be split into two triangles with vertices 
        /// (a, b, c) and (c, d, a). Use this information to 
        /// construct a list of two Triangle objects to return 
        /// to the caller.
        /// </summary>
        /// <returns>List of Triangle objects</returns>
        public List<Triangle> ToTriangles()
        {
            if (Vertices != null)
            {
                //Assume you have a rectangle with vertices(a, b, c, d) in clockwise order. 
                // This can be split into two triangles with vertices(a, b, c) and(c, d, a).
                // Use this information to construct a list of two Triangle objects to return to the caller.
                //a=0, b=1, c=2, d=3
                Triangle t1 = new Triangle(Vertices[0], Vertices[1], Vertices[2]);
                Triangle t2 = new Triangle(Vertices[2], Vertices[3], Vertices[0]);

                return new List<Triangle> { t1, t2 };
            }

            else
            {
                throw new ArgumentNullException("List<Point> input", "Input is Null");
            }
        } // end of method

        /// <summary>
        /// String representation of the shape object
        /// returns the text “Rectangle: ” plus the base class’s ToString() value.
        /// </summary>
        /// <returns>formated string</returns>
        public override string ToString()
        {
            return "Rectangle: " + base.ToString();
        }

        #endregion methods

    } // end of class
} // end of namespace
