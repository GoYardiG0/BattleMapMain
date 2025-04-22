using BattleMapMain.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Services;

namespace BattleMapMain.ViewModels
{
    public class SessionViewModel
    {
        private IServiceProvider serviceProvider;
        private BattleMapProxy hubProxy;
        public SessionViewModel(IServiceProvider serviceProvider, BattleMapProxy hubProxy)
        {
            SessionCommand = new Command(LeaveSession);
            this.serviceProvider = serviceProvider;
        }

        public ICommand SessionCommand { get; }

        public async void LeaveSession()
        {
            await hubProxy.Disconnect(((App)Application.Current).CurrentSessionCode); 
            NotSession();
        }
        private void NotSession()
        {
            ((App)Application.Current).notInSession = true;
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
        }
    }
}
