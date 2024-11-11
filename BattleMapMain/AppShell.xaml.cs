using BattleMapMain.ViewModels;
using BattleMapMain.Views;

namespace BattleMapMain
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
            this.BindingContext = vm;
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("SessionTabs", typeof(TabBar));
            Routing.RegisterRoute("GameStart", typeof(GameStartView));
            Routing.RegisterRoute("Profile", typeof(ProfileView));
            Routing.RegisterRoute("BattleMap", typeof(BattleMapView));
        }
    }
}
