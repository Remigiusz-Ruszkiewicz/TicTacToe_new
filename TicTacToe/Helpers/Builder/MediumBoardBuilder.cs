using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Helpers.Builder
{
    public class MediumBoardBuilder : DefaultBuilder
    {
        public MediumBoardBuilder() : base(4)
        {
        }
    }
}
