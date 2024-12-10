using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.ViewModels
{
    public class StatBlockViewModel : ViewModelBase
    {
        StatBlockViewModel()
        {
            
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                    name = value;
                    OnPropertyChanged();
            }
        }
       
        private int ac;
        public int Ac
        {
            get => ac;
            set
            {
                ac = value;
                OnPropertyChanged();
            }
        }
       
        private int hp;
        public int Hp
        {
            get => hp;
            set
            {
                hp = value;
                OnPropertyChanged();
            }
        }
      
        private int str;
        public int Str
        {
            get => str;
            set
            {
                str = value;
                OnPropertyChanged();
            }
        }
      
        private int dex;
        public int Dex
        {
            get => dex;
            set
            {
                dex = value;
                OnPropertyChanged();
            }
        }

        private int con;
        public int Con
        {
            get => con;
            set
            {
                con = value;
                OnPropertyChanged();
            }
        }
     
        private int inte;
        public int Inte
        {
            get => inte;
            set
            {
                inte = value;
                OnPropertyChanged();
            }
        }
     
        private int wis;
        public int Wis
        {
            get => wis;
            set
            {
                wis = value;
                OnPropertyChanged();
            }
        }
      
        private int cha;
        public int Cha
        {
            get => cha;
            set
            {
                cha = value;
                OnPropertyChanged();
            }
        }
      
        private int level;
        public int Level
        {
            get => level;
            set
            {
                level = value;
                OnPropertyChanged();
            }
        }
       
        private string passiveDesc;
        public string PassiveDesc
        {
            get => passiveDesc;
            set
            {
                passiveDesc = value;
                OnPropertyChanged();
            }
        }
       
        private string actionDesc;
        public string ActionDesc
        {
            get => actionDesc;
            set
            {
                actionDesc = value;
                OnPropertyChanged();
            }
        }
                
        private string specialActionDesc;
        public string SpecialActionDesc
        {
            get => specialActionDesc;
            set
            {
                specialActionDesc = value;
                OnPropertyChanged();
            }
        }     
    }
}
