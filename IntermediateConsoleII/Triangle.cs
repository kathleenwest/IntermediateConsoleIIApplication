using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleII
{
    /// <summary>
    /// Triangle: A Derivative of Shape class
    /// </summary>
    class Triangle : Shape
    {
        #region properties

        /// <summary>
        /// Override of the Vertices property so there is a 
        /// logic check to the set “mutator” ensuring value 
        /// contains exactly three Point objects. If valid, 
        /// assigns the incoming value object to base.Vertices. 
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
                // Check to make sure three points for a triangle
                if (value.Count == 3)
                {
                    base.Vertices = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Verticles", "There must be only three points for the Vertices property");
                }                
            } // end of set
        } // end of property

        #endregion properties

        #region constructors

        /// <summary>
        /// Parameterized constructor for list of
        /// Point objects.
        /// Calls base class constructor
        /// The first constructor accepts a list of Point objects 
        /// and immediately calls the base class constructor 
        /// that accepts a List<Point> object:
        /// Through the magic of polymorphism, Triangle’s Vertices property 
        /// will be called from the base class constructor when it assigns 
        /// the incoming value to the Vertices property. This ensures exactly 
        /// 3 points can be added to the list. No other body code is 
        /// necessary in this constructor.
        /// </summary>
        /// <param name="vertices">List of Point type objects</param>
        public Triangle(List<Point> vertices) : base(vertices)
        {

        }

        /// <summary>
        /// Parameterized constructor for three Point objects.
        /// Three points determine a triangle.
        /// Calls base class constructor
        /// The second constructor of Triangle accepts three 
        /// individual Point objects instead of a list.
        /// Like the first constructor, this one will also utilize 
        /// the base class’s constructor that accepts a list of points. 
        /// No other body code is necessary in this constructor.
        /// </summary>
        /// <param name="v1">type Point 1</param>
        /// <param name="v2">type Point 2</param>
        /// <param name="v3">type Point 3</param>
        public Triangle(Point v1, Point v2, Point v3) : base(new List<Point>() { v1, v2, v3 })
        {

        }

        #endregion constructors

        #region methods

        /// <summary>
        ///The Area() method must be overridden in this class. It utilizes a function 
        ///called Heron’s formula to determine the area of a triangle with arbitrary vertices.
        ///The first step in Heron’s formula is to calculate the semi-perimeter by taking 
        ///the Triangle’s perimeter value and dividing it by 2 (remember the base 
        ///class has a Perimeter() method). Store this result in a double called s.
        ///Next, using the semi-perimeter value s, calculate the area using this formula:
        ///area = √𝑠 ×(𝑠−𝑎)×(𝑠−𝑏)×(𝑠−𝑐)
        /// </summary>
        /// <returns>(double) Area calculation for the triangle shape</returns>
        public override double Area()
        {
            if (Vertices != null)
            {
                // Calculate the semi-perimeter
                double s = (Perimeter()) / 2;

                // Calculate Length Size A
                double a = Vertices[0].Distance(Vertices[1]);

                // Calculate Length Side B
                double b = Vertices[1].Distance(Vertices[2]);

                // Calculate Length Side C
                double c = Vertices[0].Distance(Vertices[2]);

                // Calculate the Area of the Triangle
                double area = Math.Sqrt(s*(s-a)*(s-b)*(s-c));

                return area;
            }
            else
            {
                throw new ArgumentNullException("List<Points> Vertices", "Shape must not have a null list of vertices");
            }
        }// end of method Area

        /// <summary>
        /// This method accepts no parameters and returns a value indicating if 
        /// this Triangle is equilateral, or all three sides have the same length. 
        /// Using a combination of the Utils.IsRelativelyEqual() method and the 
        /// Point’s Distance method, determine if the edges created by the 
        /// three vertices are all relatively equal.
        /// </summary>
        /// <returns>boolean true is Equilateral, false otherwise</returns>
        public virtual bool IsEquilateral()
        {
            bool isEquilateral = false;

            // Assume 3 Vertices otherwise object intializer would had failed
            if (Vertices != null)
            {
                // Calculate Length Size A
                double a = Vertices[0].Distance(Vertices[1]);

                // Calculate Length Side B
                double b = Vertices[1].Distance(Vertices[2]);

                // Calculate Length Side C
                double c = Vertices[0].Distance(Vertices[2]);

                isEquilateral = Utils.IsRelativelyEqual(a, b) && Utils.IsRelativelyEqual(b, c) && Utils.IsRelativelyEqual(a, c);

                return isEquilateral;
            }
            else
            {
                throw new ArgumentNullException("List<Points> Vertices", "Shape must not have a null list of vertices");
            }
        } // end of method return isEquilateral;

        /// <summary>
        /// An isosceles triangle has at least two sides that are equal in length. 
        /// Use a similar technique to IsEquilateral() to determine if this Triangle 
        /// is isosceles. By definition, all equilateral triangles are also isosceles.
        /// </summary>
        /// <returns>boolean true is Isosceles, false otherwise</returns>
        public virtual bool IsIsosceles()
        {           
            // Assume 3 Vertices otherwise object intializer would had failed
            if (Vertices != null)
            {
                // Calculate Length Size A
                double a = Vertices[0].Distance(Vertices[1]);

                // Calculate Length Side B
                double b = Vertices[1].Distance(Vertices[2]);

                // Calculate Length Side C
                double c = Vertices[0].Distance(Vertices[2]);

                return (Utils.IsRelativelyEqual(a, b) || Utils.IsRelativelyEqual(a, c) || Utils.IsRelativelyEqual(b, c));

            }
            else
            {
                throw new ArgumentNullException("List<Points> Vertices", "Shape must not have a null list of vertices");
            }
        } // end of method isIsosoleces

        /// <summary>
        /// A scalene triangle has no two sides that are the same length. By definition, 
        /// if a triangle is not isosceles it must be scalene. Remember, all equilateral 
        /// triangles are also isosceles.
        /// </summary>
        /// <returns>boolean true is Scalene, false otherwise</returns>
        public virtual bool IsScalene()
        {

            if (!IsIsosceles())
            {
                return true;
            }
            else
            {
                return false;
            }
        } // end of method

        /// <summary>
        /// Override of the object ToString method
        /// Returns the text “Triangle: ” plus the base class’s ToString() value
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return "Triangle " + base.ToString();
        }

        #endregion methods

    } // end of class Triangle
} // end of namespace
