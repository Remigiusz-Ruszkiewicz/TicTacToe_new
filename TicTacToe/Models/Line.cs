namespace TicTacToe.Models
{
    public class Line
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Line(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}