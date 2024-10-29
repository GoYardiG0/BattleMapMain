using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleMapMain.Models;

namespace BattleMapMain.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

        public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();

        public User() { }
    }
}
