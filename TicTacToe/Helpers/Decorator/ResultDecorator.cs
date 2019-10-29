using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Helpers.Decorator
{
    public class ResultDecorator: AbstractResult
    {
        protected AbstractResult decorated;
        public ResultDecorator(AbstractResult toDecorate)
        {
            decorated = toDecorate;
        }
        public override void Decorate()
        {
            decorated.Decorate();
        }
    }
}
