using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Repositories
{
    public class JsonRepo : Repo
    {
        const string file = "Data/Data.json";
        public override List<Result> GetResults()
        {
            string data = System.IO.File.ReadAllText(file);
            return JsonConvert.DeserializeObject<List<Result>>(data);
        }

        public override void ResetResult()
        {
            System.IO.File.WriteAllText(file, "");
        }

        public override void SetResult(Result result)
        {
            var list = GetResults();
            list.Add(result);
            System.IO.File.WriteAllText(file,JsonConvert.SerializeObject(list));
        }
    }
}
