using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.Services;

namespace BattleMapMain.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        public int? UserId { get; set; }

        public string CharacterName { get; set; } = null!;

        public string? CharacterPic { get; set; }
        public string CharacterPicURL
        {
            get
            {
                return BattleMapWebAPIProxy.ImageBaseAddress + CharacterPic;
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

        public int Level { get; set; }

        public string? PassiveDesc { get; set; }

        public string? ActionDesc { get; set; }

        public string? SpecialActionDesc { get; set; }

        public Character() { }
    }
}
