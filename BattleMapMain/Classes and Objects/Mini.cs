using BattleMapMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.Classes_and_Objects
{
    public class Mini
    {
        Monster monster;
        Character character;
        int currentHP;
        string img;
        public Mini() { }
        public Mini(Monster monster)
        {
            this.monster = monster;
            currentHP = monster.Hp;
            img = monster.MonsterPicURL;
        }
        public Mini(Character character)
        {
            this.character = character;
            this.currentHP = character.Hp;
            img = character.CharacterPic;
        }
    }
}
