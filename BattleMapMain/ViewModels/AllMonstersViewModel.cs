using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Models;
using BattleMapMain.Services;
using BattleMapMain.Views;

namespace BattleMapMain.ViewModels
{
    public class AllMonstersViewModel : ViewModelBase
    {
        private BattleMapWebAPIProxy proxy;
        private readonly IServiceProvider serviceProvider;

        //private List<Baker> pendingConfectioneriesKeeper;
        private ObservableCollection<Monster> monsters;
        public ObservableCollection<Monster> Monsters 
        { 
            get => monsters; 
            set 
            {
                monsters = value;
                OnPropertyChanged(); 
            } 
        }
        private Monster selectedMonster;
        public Monster SelectedMonster 
        { 
            get => selectedMonster;
            set 
            { 
                selectedMonster = value; 
                OnPropertyChanged(); 
            } 
        }
        //private bool isRefreshing;
        //public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }      

        public AllMonstersViewModel(BattleMapWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            //pendingConfectioneriesKeeper = new();
            //PendingConfectioneries = new();
            //GetBakers();
            GoToEditCommand = new Command(GoToEdit);

        }

        public ICommand GoToEditCommand { get; }

        public void SetMonsters()
        {
            ObservableCollection<Monster>? monsters = ((App)Application.Current).monsters;
            if (monsters != null)
            {
                this.monsters.Clear();
                foreach (Monster monster in monsters)
                {
                    if (monster.UserId == 0)
                    this.monsters.Add(monster);
                }
            }
        }

        private void GoToEdit()
        {
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<MonsterEditView>());
        }
    }
}

