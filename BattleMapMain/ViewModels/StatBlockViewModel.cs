using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.ViewModels
{
    public class StatBlockViewModel : ViewModelBase
    {
        StatBlockViewModel() { }

        #region name
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
        private bool showNameError;

        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }      

        private string nameError;

        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }

        #endregion

        #region ac

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
        private bool showAcError;

        public bool ShowAcError
        {
            get => showAcError;
            set
            {
                showAcError = value;
                OnPropertyChanged();
            }
        }

        private string acError;

        public string AcError
        {
            get => acError;
            set
            {
                acError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateAc()
        {
            if (ac == null) showAcError = true; else showAcError = false;
        }

        #endregion       

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
    }
}
