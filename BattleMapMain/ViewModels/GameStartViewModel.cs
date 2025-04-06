using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using BattleMapMain.Views;
using Microsoft.Maui.Controls;
using BattleMapMain.Services;

namespace BattleMapMain.ViewModels
{
    public class GameStartViewModel : ViewModelBase
    {
        private IServiceProvider serviceProvider;
        private BattleMapProxy mapProxy;
        private BattleMapWebAPIProxy Proxy;
        public GameStartViewModel(IServiceProvider serviceProvider, BattleMapProxy proxy, BattleMapWebAPIProxy proxy1) 
        {
            SessionCommand = new Command(Session);
            this.serviceProvider = serviceProvider;
            this.mapProxy = proxy;
            this.Proxy = proxy1;
        }
        public ICommand SessionCommand { get; }

        public async void JoinSession()
        {

        }

        private void Session()
        {
            ((App)Application.Current).notInSession = false;
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
        }
    }
}
