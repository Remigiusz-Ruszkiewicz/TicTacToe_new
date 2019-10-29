using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Models;

namespace TicTacToe.Repositories
{
    public class SqlRepo : Repo
    {
        private readonly Context context;

        public SqlRepo(Context context)
        {
            this.context = context;
        }
        public override List<Result> GetResults()
        {
            return context.Results.ToList();
        }

        public override void ResetResult()
        {
            context.Results.RemoveRange(GetResults());
            context.SaveChanges();
        }

        public override void SetResult(Result result)
        {
            if (context.Results.Find(result.Id)!=null)
            {
                return;
            }
            context.Results.Add(result);
            context.SaveChanges();
        }
    }
}
