using BattleMapMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.Services;
using Microsoft.Maui.Graphics.Platform;

namespace BattleMapMain.Classes_and_Objects
{
    public class Mini
    {
        public static BattleMapWebAPIProxy proxy;

        public Monster monster;
        public Character character;
        public int currentHP;
        public Cords location;
        public static List<Mini> AllMinis = new List<Mini>();
        public Microsoft.Maui.Graphics.IImage img;        

        public string Name { get; set; }

        public string ImgURL {  get; set; }                           

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
        public Mini() { }
        public Mini(Monster monster)
        {
            this.Name = $"{monster.MonsterName}";
            int count = 0;
            foreach (Mini m in AllMinis)
            {
                if (m.monster != null && m.monster.MonsterName == monster.MonsterName)
                    count++;
            }
            if (count > 0)
                this.Name += $"_{count}";
            this.monster = monster;
            currentHP = monster.Hp;
            this.ImgURL = monster.MonsterPicURL;
            this.Ac = monster.Ac;
            this.Hp = monster.Hp;
            this.Str = monster.Str;
            this.Dex = monster.Dex;
            this.Con = monster.Con;
            this.Int = monster.Int;
            this.Wis = monster.Wis;
            this.Cha = monster.Cha;
            this.Level = monster.Cr;
            this.PassiveDesc = monster.PassiveDesc;
            this.ActionDesc = monster.ActionDesc;
            this.SpecialActionDesc = monster.SpecialActionDesc;
        }
        public Mini(Character character)
        {
            this.Name = $"{character.CharacterName}";
            int count = 0;
            foreach (Mini m in AllMinis)
            {
                if (m.character != null && m.character.CharacterName == character.CharacterName)
                    count++;
            }
            if (count > 0)
                this.Name += $"_{count}";
            this.character = character;
            this.currentHP = character.Hp;
            this.ImgURL = character.CharacterPicURL;
            this.Ac = character.Ac;
            this.Hp = character.Hp;
            this.Str = character.Str;
            this.Dex = character.Dex;
            this.Con = character.Con;
            this.Int = character.Int;
            this.Wis = character.Wis;
            this.Cha = character.Cha;
            this.Level = character.Level;
            this.PassiveDesc = character.PassiveDesc;
            this.ActionDesc = character.ActionDesc;
            this.SpecialActionDesc = character.SpecialActionDesc;
        }
        public Mini(Mini mini)
        {
            if (mini.monster != null)
            {
                Monster monster = mini.monster;
                this.Name = $"{monster.MonsterName}";
                int count = 0;
                foreach (Mini m in AllMinis)
                {
                    if (m.monster != null && m.monster.MonsterName == monster.MonsterName)
                        count++;
                }
                if (count > 0)
                    this.Name += $"_{count}";
                this.monster = monster;
                currentHP = monster.Hp;
                this.ImgURL = monster.MonsterPicURL;
                this.Ac = monster.Ac;
                this.Hp = monster.Hp;
                this.Str = monster.Str;
                this.Dex = monster.Dex;
                this.Con = monster.Con;
                this.Int = monster.Int;
                this.Wis = monster.Wis;
                this.Cha = monster.Cha;
                this.Level = monster.Cr;
                this.PassiveDesc = monster.PassiveDesc;
                this.ActionDesc = monster.ActionDesc;
                this.SpecialActionDesc = monster.SpecialActionDesc;
            }
            else if (mini.character != null)
            {
                Character character = mini.character;
                this.Name = $"{character.CharacterName}";
                int count = 0;
                foreach (Mini m in AllMinis)
                {
                    if (m.character != null && m.character.CharacterName == character.CharacterName)
                        count++;
                }
                if (count > 0)
                    this.Name += $"_{count}";
                this.character = character;
                this.currentHP = character.Hp;
                this.ImgURL = character.CharacterPicURL;
                this.Ac = character.Ac;
                this.Hp = character.Hp;
                this.Str = character.Str;
                this.Dex = character.Dex;
                this.Con = character.Con;
                this.Int = character.Int;
                this.Wis = character.Wis;
                this.Cha = character.Cha;
                this.Level = character.Level;
                this.PassiveDesc = character.PassiveDesc;
                this.ActionDesc = character.ActionDesc;
                this.SpecialActionDesc = character.SpecialActionDesc;
            }
            if (mini.img != null)
                this.img = mini.img;
        }

        public async void SetImage()
        {
            if (this.monster != null)
            {
                Stream stream = await proxy.GetImage(this.monster.MonsterPicURL);
                using (stream)
                {
                    img = PlatformImage.FromStream(stream);
                }
            }
            else if (this.character != null)
            {
                Stream stream = await proxy.GetImage(this.character.CharacterPicURL);
                using (stream)
                {
                    img = PlatformImage.FromStream(stream);
                }
            }
            
        }
    }
}
