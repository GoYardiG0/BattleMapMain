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
        public Monster monster;
        public Character character;
        public int currentHP;
        public string img;
        public Cords location;
        public Mini() { }
        public Mini(string img)
        {
            this.img = img;
        }
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
