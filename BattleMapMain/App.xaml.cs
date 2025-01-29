using BattleMapMain.Models;
using BattleMapMain.Services;
using BattleMapMain.Views;
using System.Collections.ObjectModel;


namespace BattleMapMain
{
    public partial class App : Application
    {
        //Application level variables
        public User? LoggedInUser { get; set; }
        public ObservableCollection<Monster> monsters;
        public ObservableCollection<Character> characters;

        private BattleMapWebAPIProxy proxy;
        public bool notInSession;
        public App(IServiceProvider serviceProvider, BattleMapWebAPIProxy proxy)
        {
            notInSession = true;
            this.proxy = proxy;
            //LoadBasicDataFromServer();
            InitializeComponent();
            LoggedInUser = null;
            monsters = new ObservableCollection<Monster>();
            SetMonsters();
            //Start with the Login View
            MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());

        }
        public async void SetMonsters()
        {
            ObservableCollection<Monster>? monsters = await this.proxy.GetMonsters();
            if (monsters != null)
            {

                foreach (Monster monster in monsters)
                {
                    this.monsters.Add(monster);
                }
            }
        } public async void SetCharacter()
        {
            ObservableCollection<Character>? characters = await this.proxy.GetCharacters(LoggedInUser.UserId);
            if (characters != null)
            {

                foreach (Character character in characters)
                {
                    this.characters.Add(character);
                }
            }
        }
        //public async void UpdateMonsters(Monster monster)
        //{
        //    if (monsters != null)
        //    {

        //        foreach (Monster m in monsters)
        //        {
        //            if (m.MonsterId == monster.MonsterId)
        //                m = monster;
        //        }
        //    }
        //}
    }
}