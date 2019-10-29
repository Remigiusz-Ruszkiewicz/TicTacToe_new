using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Helpers.Builder
{
    public interface IBoardCreator
    {
        List<Row> Rows { get; }
        Cell CreateCell(int id, Row row);
        Row CreateRow(int id);
        void CreateRows();
        void AddCells();
    }
}
