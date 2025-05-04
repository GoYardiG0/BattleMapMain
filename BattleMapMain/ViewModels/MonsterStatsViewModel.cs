using BattleMapMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.Services;

namespace BattleMapMain.ViewModels
{
    [QueryProperty(nameof(Monster), "Monster")]
    public class MonsterStatsViewModel : ViewModelBase
    {

        private Monster monster;
        public Monster Monster
        {
            get { return monster; }
            set
            {
                this.monster = value;
                OnPropertyChanged();                
            }
        }

        public MonsterStatsViewModel()
        {

        }

        //    private string name;
        //    public string Name
        //    {
        //        get => name;
        //        set
        //        {
        //                name = value;
        //                OnPropertyChanged();
        //        }
        //    }

        //    private int ac;
        //    public int Ac
        //    {
        //        get => ac;
        //        set
        //        {
        //            ac = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int hp;
        //    public int Hp
        //    {
        //        get => hp;
        //        set
        //        {
        //            hp = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int str;
        //    public int Str
        //    {
        //        get => str;
        //        set
        //        {
        //            str = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int dex;
        //    public int Dex
        //    {
        //        get => dex;
        //        set
        //        {
        //            dex = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int con;
        //    public int Con
        //    {
        //        get => con;
        //        set
        //        {
        //            con = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int inte;
        //    public int Inte
        //    {
        //        get => inte;
        //        set
        //        {
        //            inte = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int wis;
        //    public int Wis
        //    {
        //        get => wis;
        //        set
        //        {
        //            wis = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int cha;
        //    public int Cha
        //    {
        //        get => cha;
        //        set
        //        {
        //            cha = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private int level;
        //    public int Level
        //    {
        //        get => level;
        //        set
        //        {
        //            level = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private string passiveDesc;
        //    public string PassiveDesc
        //    {
        //        get => passiveDesc;
        //        set
        //        {
        //            passiveDesc = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private string actionDesc;
        //    public string ActionDesc
        //    {
        //        get => actionDesc;
        //        set
        //        {
        //            actionDesc = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private string specialActionDesc;
        //    public string SpecialActionDesc
        //    {
        //        get => specialActionDesc;
        //        set
        //        {
        //            specialActionDesc = value;
        //            OnPropertyChanged();
        //        }
        //    }     
        //}
    }
}
