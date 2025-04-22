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
            SessionCommand = new Command(JoinSession);
            this.serviceProvider = serviceProvider;
            this.hubProxy = hubProxy;
            this.proxy = proxy;
        }

        private string joinCode;
        public string JoinCode
        {
            get => joinCode;
            set
            {
                joinCode = value;
                OnPropertyChanged();
            }
        }

        public ICommand SessionCommand { get; }

        public async void JoinSession()
        {
            InServerCall = true;
            BattleMapViewModel vm = serviceProvider.GetService<BattleMapViewModel>();
            string userid = ((App)Application.Current).LoggedInUser.UserId.ToString();

            await hubProxy.Connect(userid, vm.UpdateMapDetails, joinCode);
            ((App)Application.Current).CurrentSessionCode = joinCode;

            InServerCall = false;
            Session();
        }

        private void Session()
        {
            ((App)Application.Current).notInSession = false;
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
        }
    }
}
