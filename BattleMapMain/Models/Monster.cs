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

        public void ReSetMonster(Monster Monster)
        {
            this.MonsterId = Monster.MonsterId;
            this.UserId = Monster.UserId;
            this.MonsterName = Monster.MonsterName;
            this.MonsterPic = Monster.MonsterPic;
            this.Ac = Monster.Ac;
            this.Hp = Monster.Hp;
            this.Str = Monster.Str;
            this.Dex = Monster.Dex;
            this.Con = Monster.Con;
            this.Int = Monster.Int;
            this.Wis = Monster.Wis;
            this.Cha = Monster.Cha;
            this.Cr = Monster.Cr;
            this.PassiveDesc = Monster.PassiveDesc;
            this.ActionDesc = Monster.ActionDesc;
            this.SpecialActionDesc = Monster.SpecialActionDesc;

        }
    }
}
