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

        private bool showCharacters;
        public bool ShowCharacters
        {
            get => showCharacters;
            set
            {
                showCharacters = value;
                OnPropertyChanged();
            }
        }
        private bool showMonsters;
        public bool ShowMonsters
        {
            get => showMonsters;
            set
            {
                showMonsters = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> filters;
        public ObservableCollection<string> Filters
        {
            get => filters;
            set
            {
                filters = value;
                OnPropertyChanged();                 
            }
        }
        private string selectedFilter;
        public string SelectedFilter
        {
            get => selectedFilter;
            set
            {
                selectedFilter = value;
                OnPropertyChanged();
                switch (value)
                {
                    case "My Monsters":
                        FilterMyMonsters();
                        break;

                    case "All Monsters":
                        FilterAllMonsters();
                        break;
                    case "My Characters":
                        FilterCharacters();
                        break;
                }
            }
        }
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
        private ObservableCollection<Character> characters;
        public ObservableCollection<Character> Characters
        {
            get => characters;
            set
            {
                characters = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Character> searchedCharacters;
        public ObservableCollection<Character> SearchedCharacters
        {
            get => searchedCharacters;
            set
            {
                searchedCharacters = value;
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
                switch (SelectedFilter)
                {
                    default:
                        FilterMyMonsters();
                        break;
                    case "My Monsters":
                        FilterMyMonsters();
                        break;

                    case "All Monsters":
                        FilterAllMonsters();
                        break;
                    case "My Characters":
                        FilterCharacters();
                        break;
                }
            }
        }


        //private bool isRefreshing;
        //public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }      

        public async void InitData()
        {
            monsters = new ObservableCollection<Monster>();
            SetMonsters();
            characters = new ObservableCollection<Character>();
            SetCharacters();
            filters = new ObservableCollection<string>();
            SetFilters();
            FilterMyMonsters();
        }

        public void SetMonsters()
        {
            ObservableCollection<Monster>? monsters = ((App)Application.Current).Monsters;
            if (monsters != null)
            {
                foreach (Monster monster in monsters)
                {
                    this.monsters.Add(monster);
                }
            }
        }
        public void SetCharacters()
        {
            ObservableCollection<Character>? characters = ((App)Application.Current).Characters;
            if (characters != null)
            {
                foreach (Character character in characters)
                {
                    this.characters.Add(character);
                }
            }
        }

        public void SetFilters()
        {
            Filters.Add("My Monsters");
            Filters.Add("All Monsters");
            Filters.Add("My Characters");
            SelectedFilter = Filters.FirstOrDefault();
        }

        public void FilterMyMonsters()
        {
            ShowMonsters = true;
            ShowCharacters = false;
            SearchedMonsters = new ObservableCollection<Monster>();
            if (this.monsters != null)
            {
                if (searchBar == null)
                {
                    foreach (Monster monster in monsters)
                    {
                        if (monster.UserId == ((App)Application.Current).LoggedInUser.UserId)
                            this.SearchedMonsters.Add(monster);
                    }
                }
                else
                {
                    foreach (Monster monster in monsters)
                    {
                        if (monster.MonsterName.ToLower().Contains(searchBar.ToLower()) && monster.UserId == ((App)Application.Current).LoggedInUser.UserId)
                            this.SearchedMonsters.Add(monster);
                    }
                }
            }
        }
        public void FilterAllMonsters()
        {
            ShowMonsters = true;
            ShowCharacters = false;
            SearchedMonsters = new ObservableCollection<Monster>();
            if (this.monsters != null)
            {
                if (searchBar == null)
                {
                    foreach (Monster monster in monsters)
                    {
                        this.SearchedMonsters.Add(monster);
                    }
                }
                else
                {
                    foreach (Monster monster in monsters)
                    {
                        if (monster.MonsterName.ToLower().Contains(searchBar.ToLower()))
                            this.SearchedMonsters.Add(monster);
                    }
                }
            }
            
        }
        public void FilterCharacters()
        {
            ShowCharacters = true;
            ShowMonsters = false;
            SearchedCharacters = new ObservableCollection<Character>();
            if (this.Characters != null)
            {
                if (searchBar == null)
                {
                    foreach (Character character in Characters)
                    {
                        if (character.UserId == 1 || character.UserId == ((App)Application.Current).LoggedInUser.UserId)
                            this.SearchedCharacters.Add(character);
                    }
                }
                else
                {
                    foreach (Character Character in Characters)
                    {
                        if (Character.CharacterName.ToLower().Contains(searchBar.ToLower()))
                            this.SearchedCharacters.Add(Character);
                    }
                }
            }
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
            await selectedMini.SetImage();
            OnPropertyChanged("SelectedMini");
            SelectedMonster = null;
            if (ClosePopup != null)
            {
                List<string> l = new List<string>();
                ClosePopup(l);
            }
        }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get => selectedCharacter;
            set
            {
                selectedCharacter = value;
                OnPropertyChanged();
                if (selectedCharacter != null)
                    OnSingleSelectCharacter();
            }
        }


        async void OnSingleSelectCharacter()
        {
            selectedMini = new Mini(selectedCharacter);
            selectedMini.SetImage();
            OnPropertyChanged("SelectedMini");
            selectedCharacter = null;
            if (ClosePopup != null)
            {
                List<string> l = new List<string>();
                ClosePopup(l);
            }
        }

        #endregion
    }
}
