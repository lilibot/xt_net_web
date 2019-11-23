using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1Rectangle
{
    class Rectangle
    {
        private int length;
        private int width;
        
        public Rectangle()
        { }
        public Rectangle(int length, int width)
        {
            if ((length < 1) || (width < 1))
                throw new ArgumentOutOfRangeException("Sides value of rectangle should be more than 0");
            this.length = length;
            this.width = width;
        }
        public int Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Sides value of rectangle should be more than 0");
                }

                this.length = value;
            }
        }
        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Value", value.ToString(), "Sides value of rectangle should be more than 0");
                }

                this.width = value;
            }
        }
        public int CalculateArea()
        {
            return this.length * this.width;
        }

    }
}
