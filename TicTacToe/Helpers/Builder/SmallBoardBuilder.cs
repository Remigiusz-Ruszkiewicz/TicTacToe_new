using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Helpers.Builder
{
    public class SmallBoardBuilder : DefaultBuilder
    {
        public SmallBoardBuilder() : base(3)
        {
        }
    }
}
