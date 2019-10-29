using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public abstract class AbstractResult 
    {
        public string Id { get; set; }
        public string Value { get; set; }
        [NotMapped]
        public bool IsDecorated { get; set; } = false;
        public virtual void Decorate()
        {
            IsDecorated = true;
        }
    }
}
