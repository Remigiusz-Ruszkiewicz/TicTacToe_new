using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Data
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base(options)
        {
        }
        public DbSet<Result> Results { get; set; }
    } 
}
