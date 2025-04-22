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
        public ObservableCollection<Monster> Monsters {  get; set; }
        public ObservableCollection<Character> Characters {  get; set; }
        public string CurrentSessionCode {  get; set; }

        private BattleMapWebAPIProxy proxy;
        public bool notInSession;
        public App(IServiceProvider serviceProvider, BattleMapWebAPIProxy proxy)
        {
            notInSession = true;
            this.proxy = proxy;
            //LoadBasicDataFromServer();
            InitializeComponent();
            LoggedInUser = null;
            Monsters = new ObservableCollection<Monster>();
            Characters = new ObservableCollection<Character>();
            SetMonsters();
            SetCharacters();
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
                    this.Monsters.Add(monster);
                }
            }
        } public async void SetCharacters()
        {
            ObservableCollection<Character>? characters = await this.proxy.GetCharacters();
            if (characters != null)
            {

                foreach (Character character in characters)
                {
                    this.Characters.Add(character);
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