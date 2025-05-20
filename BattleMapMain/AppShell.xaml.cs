using BattleMapMain.ViewModels;
using BattleMapMain.Views;

namespace BattleMapMain
{
    public partial class AppShell : Shell
    {
        public bool NotInSession;
        AppShellViewModel vm;
        public AppShell(AppShellViewModel vm)
        {
            this.BindingContext = vm;
            this.vm = vm;
            InitializeComponent();
            RegisterRoutes();
            NotInSession = true;
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("SessionTabs", typeof(TabBar));
            Routing.RegisterRoute("GameStart", typeof(GameStartView));
            Routing.RegisterRoute("BattleMap", typeof(BattleMapView));
            Routing.RegisterRoute("MonsterDetails", typeof(MonsterStatsView));
            Routing.RegisterRoute("MonsterEdit", typeof(MonsterEditView));
            Routing.RegisterRoute("CharacterEdit", typeof(CharacterEditView));
            Routing.RegisterRoute("CharacterDetails", typeof(CharacterStatsView)); 
        }
        
        public void UpdateSessionStatus(bool b)
        {
            vm.NotInSession = b;           
        }
    }
}
