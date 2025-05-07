using BattleMapMain.Models;
using BattleMapMain.Services;
using BattleMapMain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleMapMain.ViewModels
{
    public class CharacterSheetsViewModel:ViewModelBase
    {
        private BattleMapWebAPIProxy proxy;
        private readonly IServiceProvider serviceProvider;

        //private List<Baker> pendingConfectioneriesKeeper;
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
                FilterCharacters();
            }
        }


        //private bool isRefreshing;
        //public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }      

        public CharacterSheetsViewModel(BattleMapWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            GoToAddCommand = new Command(GoToAdd);
            characters = new ObservableCollection<Character>();
            SetCharacters();
            FilterCharacters();
            //pendingConfectioneriesKeeper = new();
            //PendingConfectioneries = new();
            //GetBakers();

        }

        public ICommand GoToAddCommand { get; }

        private void GoToAdd()
        {
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<CharacterAddView>());
        }
        public void SetCharacters()
        {
            ObservableCollection<Character>? characters = ((App)Application.Current).Characters;
            if (characters != null)
            {
                foreach (Character character in characters)
                {
                    if (character.UserId == ((App)Application.Current).LoggedInUser.UserId)
                        this.characters.Add(character);
                }
            }
        }

        public void FilterCharacters()
        {
            this.searchedCharacters = new ObservableCollection<Character>();
            if (this.characters != null)
            {
                if (searchBar == null)
                {
                    foreach (Character character in characters)
                    {
                        this.searchedCharacters.Add(character);
                    }
                }
                else
                {
                    foreach (Character character in characters)
                    {
                        if (character.CharacterName.Contains(searchBar))
                            this.searchedCharacters.Add(character);
                    }
                }
            }
            OnPropertyChanged("SearchedCharacters");
        }

        #region Single Selection
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
            var navParam = new Dictionary<string, object>()
                {
                    { "Character",SelectedCharacter }
                };
            await Shell.Current.GoToAsync("CharacterEdit", navParam);
            SelectedCharacter = null;
        }


        #endregion

        //public String SearchedName
        //{
        //    get
        //    {
        //        return this.searchedName;
        //    }
        //    set
        //    {
        //        this.searchedName = value;
        //        OnPropertyChanged();
        //    }
        //}
        //public bool InSearch
        //{
        //    get
        //    {
        //        return this.inSearch;
        //    }
        //    set
        //    {
        //        this.inSearch = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private void Search(List<string> s)
        //{
        //    SearchedBarList.Clear();
        //    foreach (Recipe r in Recipes)
        //    {
        //        for (int i = 0; i < r.RecipesName.Length; i++)
        //        {
        //            foreach (string sub in s)
        //            {
        //                if (sub[i] != null)
        //                {
        //                    if (r.RecipesName[i] != sub[i])
        //                        return;
        //                }
        //            }
        //        }
        //        searchedBarList.Add(r);
        //    }
        //}

        public void Refresh2()
        {
            OnPropertyChanged("IsLogged");
        }

        //on SortCommand change the list and leave only the users that contain the given string
        //public void Sort()
        //{
        //    List<Recipe> temp = Recipes.Where(r => r.RecipesName.Contains(SearchedName)).ToList();
        //    this.SearchedBarList.Clear();
        //    SearchedBarList = new ObservableCollection<Recipe>(temp);
        //}
        //public void ClearSort()
        //{
        //    this.SearchedBarList.Clear();
        //    SearchedBarList = recipes;
        //}


    }
}
