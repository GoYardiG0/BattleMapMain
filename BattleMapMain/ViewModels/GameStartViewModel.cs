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
        private bool registered;
        public GameStartViewModel(IServiceProvider serviceProvider, BattleMapProxy hubProxy, BattleMapWebAPIProxy proxy) 
        {
            JoinSessionCommand = new Command(JoinSession);
            CreateSessionCommand = new Command(CreateSession);
            this.serviceProvider = serviceProvider;
            this.hubProxy = hubProxy;
            this.proxy = proxy;
            registered = false;
        }

        private string joinCode;
        public string JoinCode
        {
            get => joinCode;
            set
            {
                joinCode = value;
                OnPropertyChanged();
                ValidateCode();
            }
        }
        private bool showCodeError;
        public bool ShowCodeError
        {
            get => showCodeError;
            set
            {
                showCodeError = value;
                OnPropertyChanged();
            }
        }
        public bool ValidateCode()
        {
            ShowCodeError = string.IsNullOrEmpty(JoinCode);
            return showCodeError;                
        }

        public ICommand JoinSessionCommand { get; }
        public ICommand CreateSessionCommand { get; }

        public async void JoinSession()
        {
            if (!ValidateCode())
            {
                InServerCall = true;
                if (!registered)
                {
                    BattleMapViewModel bvm = serviceProvider.GetService<BattleMapViewModel>();
                    hubProxy.RegisterToUpdateDetails(bvm.UpdateMapDetails);
                    SessionViewModel svm = serviceProvider.GetService<SessionViewModel>();
                    hubProxy.RegisterToUpdateUsers(svm.UpdateUsers);
                }
                int userid = ((App)Application.Current).LoggedInUser.UserId;

                string errorMsg = await hubProxy.Connect(joinCode, userid, false);


                InServerCall = false;
                if (errorMsg == "")
                {
                    ((App)Application.Current).CurrentSessionCode = joinCode;
                    Session();
                }
            }            
        }
        public async void CreateSession()
        {
            if (!ValidateCode())
            {
                InServerCall = true;
                if (!registered)
                {
                    BattleMapViewModel bvm = serviceProvider.GetService<BattleMapViewModel>();
                    await hubProxy.RegisterToUpdateDetails(bvm.UpdateMapDetails);
                    SessionViewModel svm = serviceProvider.GetService<SessionViewModel>();
                    await hubProxy.RegisterToUpdateUsers(svm.UpdateUsers);
                }
                int userid = ((App)Application.Current).LoggedInUser.UserId;

                string? errorMsg = await hubProxy.Connect(joinCode, userid, true);

                InServerCall = false;
                if (errorMsg == "")
                {
                    ((App)Application.Current).CurrentSessionCode = joinCode;
                    Session();
                }
            }            
        }

        private void Session()
        {
            ((App)Application.Current).notInSession = false;
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
        }
    }
}
