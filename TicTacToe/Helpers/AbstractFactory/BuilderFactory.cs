using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Helpers.Builder;

namespace TicTacToe.Helpers.AbstractFactory
{
    public static class BuilderFactory
    {
        public static IBoardCreator GetBuilder(string name)
        {
            IBoardCreator result = null;
            switch (name)
            {
                case "small":
                    result = new SmallBoardBuilder();
                    break;
                case "medium":
                    result = new MediumBoardBuilder();
                    break;
                default:
                    throw new Exception("Not valid name");
            }
            return result;
        }
    }
}
