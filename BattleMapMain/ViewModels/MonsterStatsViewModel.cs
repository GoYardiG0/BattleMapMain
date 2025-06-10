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
            CancelCommand = new Command(OnCancel);
        }
        public Command CancelCommand { get; }
        private void OnCancel()
        {
            ((App)Application.Current).MainPage.Navigation.PopAsync();
        }

    }
}
