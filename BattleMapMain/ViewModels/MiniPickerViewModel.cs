using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.Services;
using BattleMapMain.Views;
using BattleMapMain.Models;
using BattleMapMain.Classes_and_Objects;

namespace BattleMapMain.ViewModels
{
    public partial class BattleMapViewModel : ViewModelBase
    {

        public event Action<List<string>> ClosePopup;

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

        private ObservableCollection<Monster> searchedMonsters;
        public ObservableCollection<Monster> SearchedMonsters
        {
            get => searchedMonsters;
            set
            {
                searchedMonsters = value;
                OnPropertyChanged();
            }
        }

        private string searchBar;
        public string SearchBar
        {
            get => searchBar;
            set
            {
                searchBar = value;
                OnPropertyChanged();
                FilterMonsters();
            }
        }


        //private bool isRefreshing;
        //public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }      

        public async void InitData()
        {
            monsters = new ObservableCollection<Monster>();
            SetMonsters();
            FilterMonsters();
        }

        public void SetMonsters()
        {
            ObservableCollection<Monster>? monsters = ((App)Application.Current).monsters;
            if (monsters != null)
            {
                foreach (Monster monster in monsters)
                {
                    if (monster.UserId == 1 || monster.UserId == ((App)Application.Current).LoggedInUser.UserId)
                        this.monsters.Add(monster);
                }
            }
        }

        public void FilterMonsters()
        {
            this.searchedMonsters = new ObservableCollection<Monster>();
            if (this.monsters != null)
            {
                if (searchBar == null)
                {
                    foreach (Monster monster in monsters)
                    {
                        this.searchedMonsters.Add(monster);
                    }
                }
                else
                {
                    foreach (Monster monster in monsters)
                    {
                        if (monster.MonsterName.Contains(searchBar))
                            this.searchedMonsters.Add(monster);
                    }
                }
            }
            OnPropertyChanged("SearchedMonsters");
        }

        #region Single Selection
        private Monster selectedMonster;
        public Monster SelectedMonster
        {
            get => selectedMonster;
            set
            {
                selectedMonster = value;
                OnPropertyChanged();
                if (selectedMonster != null)
                    OnSingleSelectMonster();
            }
        }


        async void OnSingleSelectMonster()
        {
            selectedMini = new Mini(selectedMonster);
            selectedMini.SetImage();
            OnPropertyChanged("SelectedMini");
            selectedMonster = null;
            if (ClosePopup != null)
            {
                List<string> l = new List<string>();
                ClosePopup(l);
            }
        }


        #endregion
    }
}
