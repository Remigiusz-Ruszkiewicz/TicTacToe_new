using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Helpers.Builder
{
    public class Director
    {
        IBoardCreator builder;
        public Director(IBoardCreator builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {            
            builder.CreateRows();
            builder.AddCells();                        
        }
        public List<Row> GetBoard => builder.Rows;        
    }
}
