using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Repositories
{
    public abstract class Repo
    {
        public abstract List<Result> GetResults();
        public abstract void SetResult(Result result);        
        public abstract void ResetResult();
    }
}
