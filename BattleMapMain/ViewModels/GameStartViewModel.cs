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
        private BattleMapProxy hubProxy;
        private BattleMapWebAPIProxy proxy;
        public GameStartViewModel(IServiceProvider serviceProvider, BattleMapProxy hubProxy, BattleMapWebAPIProxy proxy) 
        {
            SessionCommand = new Command(Session);
            this.serviceProvider = serviceProvider;
            this.hubProxy = hubProxy;
            this.proxy = proxy;
        }
        public ICommand SessionCommand { get; }

        public async void JoinSession()
        {
            BattleMapViewModel vm = new BattleMapViewModel(serviceProvider,proxy);

            hubProxy.RegisterToUpdateDetails(vm.UpdateMapDetails);
            string userid = ((App)Application.Current).LoggedInUser.UserId.ToString();
            hubProxy.Connect(userid);

            
        }

        private void Session()
        {
            ((App)Application.Current).notInSession = false;
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
        }
    }
}
