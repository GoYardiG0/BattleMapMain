using BattleMapMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.Services;
using Microsoft.Maui.Graphics.Platform;
using System.Text.Json.Serialization;

namespace BattleMapMain.Classes_and_Objects
{
    public class Mini
    {
        public static BattleMapWebAPIProxy proxy;

        public Monster monster {  get; set; }
        public Character character {  get; set; }        
        public Cords location {  get; set; }
        public static List<Mini> AllMinis = new List<Mini>();

        [JsonIgnore]
        public Microsoft.Maui.Graphics.IImage img {  get; set; }        

        public string Name { get; set; }

        public string ImgURL {  get; set; }                           

        public int Ac { get; set; }

        public int Hp { get; set; }        

        public int Level { get; set; }
        
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
            this.ImgURL = monster.MonsterPicURL;
            this.Ac = monster.Ac;
            this.Hp = monster.Hp;          
            this.Level = monster.Cr;           
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
            this.ImgURL = character.CharacterPicURL;
            this.Ac = character.Ac;
            this.Hp = character.Hp;        
            this.Level = character.Level;           
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
                this.ImgURL = monster.MonsterPicURL;
                this.Ac = monster.Ac;
                this.Hp = monster.Hp;
                this.Level = monster.Cr;
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
                this.ImgURL = character.CharacterPicURL;
                this.Ac = character.Ac;
                this.Hp = character.Hp;
                this.Level = character.Level;
            }
            if (mini.img != null)
                this.img = mini.img;
        }

        public async Task SetImage()
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
