using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.Services;

namespace BattleMapMain.Models
{
    public class Monster
    {
        public int MonsterId { get; set; }

        public int UserId { get; set; }

        public string MonsterName { get; set; } = null!;

        public string? MonsterPic { get; set; }
        public string MonsterPicURL 
        { 
            get
            {
                return BattleMapWebAPIProxy.ImageBaseAddress + MonsterPic;
            }
        }

        public int Ac { get; set; }

        public int Hp { get; set; }

        public int Str { get; set; }

        public int Dex { get; set; }

        public int Con { get; set; }

        public int Int { get; set; }

        public int Wis { get; set; }

        public int Cha { get; set; }

        public int Cr { get; set; }

        public string? PassiveDesc { get; set; }

        public string? ActionDesc { get; set; }

        public string? SpecialActionDesc { get; set; }


        public Monster() { }

        public void ReSetMonster(Monster monster)
        {
            this.MonsterId = monster.MonsterId;
            this.UserId = monster.UserId;
            this.MonsterName = monster.MonsterName;
            this.MonsterPic = monster.MonsterPic;
            this.Ac = monster.Ac;
            this.Hp = monster.Hp;
            this.Str = monster.Str;
            this.Dex = monster.Dex;
            this.Con = monster.Con;
            this.Int = monster.Int;
            this.Wis = monster.Wis;
            this.Cha = monster.Cha;
            this.Cr = monster.Cr;
            this.PassiveDesc = monster.PassiveDesc;
            this.ActionDesc = monster.ActionDesc;
            this.SpecialActionDesc = monster.SpecialActionDesc;

        }
    }
}
