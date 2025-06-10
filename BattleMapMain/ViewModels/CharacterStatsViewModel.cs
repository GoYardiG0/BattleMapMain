using BattleMapMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.ViewModels
{
    [QueryProperty(nameof(Character), "Character")]
    public class CharacterStatsViewModel : ViewModelBase
    {
        private Character character;
        public Character Character
        {
            get { return character; }
            set
            {
                this.character = value;
                OnPropertyChanged();
            }
        }
        public CharacterStatsViewModel()
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
