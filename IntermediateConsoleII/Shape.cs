using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleII
{
    /// <summary>
    /// This abstract class will contain only one state field, 
    /// a protected List<Point> called _Vertices which 
    /// must be initialized to an empty list in its declaration.
    /// </summary>
    abstract class Shape
    {
        #region fields

        // Protected list of Point objects
        // Inherited members can use this field
        protected List<Point> _Vertices;

        // For the ToString Override
        StringBuilder sb;

        #endregion fields

        #region properties

        /// <summary>
        /// This field encapsulated the field for the list of shape
        /// vertices modeled as Points. The descendent objects can
        /// override and implement their own business logic rules
        /// for this property.
        /// The accessor and mutator do not need to perform any validation, 
        /// this will be done at the discretion of the derivatives.
        /// </summary>
        public virtual List<Point> Vertices
        {
            get
            {
                return _Vertices;
            }

            set
            {
                _Vertices = value;
            }
        } 

        #endregion properties

        #region constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Shape()
        {
            
        }

        /// <summary>
        /// Parameterized constructor to set the Vertices property
        /// </summary>
        /// <param name="vertices">Accepts list of Point type objects</param>
        public Shape(List<Point> vertices)
        {
            Vertices = vertices;
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Abstract method to calculate area of the shape
        /// Since every shape has specific logic to calculate area 
        /// it must be overridden by Shape’s derivatives.
        /// </summary>
        /// <returns>(double) value of the Shape's area</returns>
        public abstract double Area();

        /// <summary>
        /// Virtual method to calculate perimeter of the shape
        /// Calculates the perimeter of the shape object
        /// Loop to calculate the distance between all adjacent points in the shape
        /// </summary>
        /// <returns>(double) perimeter value</returns>
        public virtual double Perimeter()
        {
            // You can use a for loop to calculate the distance between all adjacent points in the shape to do this.
            // Also, don’t forget to include the distance between the first and last points otherwise the shape’s
            // perimeter would be missing a side!

            double perimeter = 0.0;

            if(Vertices != null)
            {

                for (int i = 1; i < Vertices.Count; i++)
                {
                    perimeter += Vertices[i-1].Distance(Vertices[i]);

                }

                // Add the last side
                perimeter += Vertices[0].Distance(Vertices[Vertices.Count-1]);
            }
            else
            {
                throw new ArgumentNullException("List<Points> Vertices","Shape must not have a null list of vertices");
            }

            return perimeter;

        } // end of method

        /// <summary>
        /// String representation of the shape object
        /// override ToString() so that it creates a string containing the 
        /// string representation of all points in the shape separated by 
        /// commas, such as: (3, 4), (3, 9), (7, 9), (7, 4)
        /// </summary>
        /// <returns>string representation of Vertices</returns>
        public override string ToString()
        {

            // Finally, override ToString() so that it creates a string containing the string representation of all
            // points in the shape separated by commas, such as:
            // (3, 4), (3, 9), (7, 9), (7, 4)

           // Initialize the String Builder Object 
           sb = new StringBuilder();

            if (Vertices != null)
            {
                foreach (Point point in Vertices)
                {
                    sb.Append(point.ToString());
                    sb.Append(", ");
                }

                // Remove that last comma and space
                sb.Remove(sb.Length - 2, 2);
                
            }
            else
            {
                throw new ArgumentNullException("List<Points> Vertices", "Shape must not have a null list of vertices");
            }

            return sb.ToString(); 
        } // end of method

        #endregion methods

    } // end of class Shape
} // end of namespace
