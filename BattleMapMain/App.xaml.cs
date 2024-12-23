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
            LoadBasicDataFromServer();
            InitializeComponent();
            LoggedInUser = null;
            //Start with the Login View
            MainPage = new NavigationPage(serviceProvider.GetService<StatBlockEditView>());
        }
        private async void LoadBasicDataFromServer()
        {
            ObservableCollection<Monster>? monsters = await this.proxy.GetMonsters();
            if (monsters != null)
            {
                this.monsters.Clear();
                foreach (Monster monster in monsters)
                {
                    this.monsters.Add(monster);
                }
            }
        }
    }
}