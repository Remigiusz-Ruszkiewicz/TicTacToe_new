namespace TicTacToe.Models
{
    public class Cell
    {
        public int Id { get; set; }
        public virtual Row Row { get; set; }
    }
}