using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Helpers.FactoryMethod;

namespace TicTacToe.Models
{
    public class Cross : Shape
    {
        public Line LineLeft { get; set; }
        public Line LineRight { get; set; }
        public string Color { get; set; }
        public override Shape CreateShape(int width, int height)
        {
            //0 lewy górny, lewy dolny szerokość.
            LineLeft = new Line(0, width);
            //Lewy dolny do prawy górny.
            LineRight = new Line(width, height);
            Color = "black";
            ShapeType = Helpers.ShapeType.Cross;
            return base.CreateShape(width, height);
        }
    }
}
