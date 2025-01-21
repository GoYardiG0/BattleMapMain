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
            //Start with the Login View
            MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());

        }
        public async void SetMonsters(ObservableCollection<Monster>? monsters)
        {            
            if (monsters != null)
            {

                foreach (Monster monster in monsters)
                {
                    this.monsters.Add(monster);
                }
            }
        }
    }
}