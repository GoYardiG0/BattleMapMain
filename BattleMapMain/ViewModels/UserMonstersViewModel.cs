using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Models;
using BattleMapMain.Services;
using BattleMapMain.Views;

namespace BattleMapMain.ViewModels
{
    public class UserMonstersViewModel: ViewModelBase
    {
        private BattleMapWebAPIProxy proxy;
        private readonly IServiceProvider serviceProvider;

        //private List<Baker> pendingConfectioneriesKeeper;
        private ObservableCollection<Monster> monsters;
        public ObservableCollection<Monster> Monsters
        {
            get => monsters;
            set
            {
                monsters = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Monster> searchedMonsters;
        public ObservableCollection<Monster> SearchedMonsters
        {
            get => searchedMonsters;
            set
            {
                searchedMonsters = value;
                OnPropertyChanged();
            }
        }

        private string searchBar;
        public string SearchBar
        {
            get => searchBar;
            set
            {
                searchBar = value;
                OnPropertyChanged();
                FilterMonsters();
            }
        }


        //private bool isRefreshing;
        //public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }      

        public UserMonstersViewModel(BattleMapWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            GoToAddCommand = new Command(GoToAdd);
            monsters = new ObservableCollection<Monster>();
            SetMonsters();
            FilterMonsters();
            //pendingConfectioneriesKeeper = new();
            //PendingConfectioneries = new();
            //GetBakers();

        }

        public ICommand GoToAddCommand { get; }

        private void GoToAdd()
        {
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<MonsterAddView>());
        }
        public void SetMonsters()
        {
            ObservableCollection<Monster>? monsters = ((App)Application.Current).Monsters;
            if (monsters != null)
            {
                foreach (Monster monster in monsters)
                {
                    if (monster.UserId == ((App)Application.Current).LoggedInUser.UserId)
                        this.monsters.Add(monster);
                }
            }
            OnPropertyChanged("monsters");
        }

        public void FilterMonsters()
        {
            this.searchedMonsters = new ObservableCollection<Monster>();
            if (this.monsters != null)
            {
                if (searchBar == null)
                {
                    foreach (Monster monster in monsters)
                    {
                        this.searchedMonsters.Add(monster);
                    }
                }
                else
                {
                    foreach (Monster monster in monsters)
                    {
                        if (monster.MonsterName.Contains(searchBar))
                            this.searchedMonsters.Add(monster);
                    }
                }
            }
            OnPropertyChanged("SearchedMonsters");
        }

        #region Single Selection
        private Monster selectedMonster;
        public Monster SelectedMonster
        {
            get => selectedMonster;
            set
            {
                selectedMonster = value;
                OnPropertyChanged();
                if (selectedMonster != null)
                    OnSingleSelectMonster();
            }
        }


        async void OnSingleSelectMonster()
        {
            var navParam = new Dictionary<string, object>()
                {
                    { "Monster",SelectedMonster }
                };
            await Shell.Current.GoToAsync("MonsterEdit", navParam);
            SelectedMonster = null;
        }


        #endregion
    }
}
