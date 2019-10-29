using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Helpers.FactoryMethod
{
    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ShapeType ShapeType { get; set; }

        public virtual Shape CreateShape(int width, int height)
        {
            Width = width;
            Height = height;
            return this;
        }
    }
}
