using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Row
    {
        public int Id { get; set; }
        public List<Cell> Cells { get; set; }
    }
}
