using BattleMapMain.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Services;
using BattleMapMain.Models;
using static Android.Telecom.Call;

namespace BattleMapMain.ViewModels
{
    public class SessionViewModel : ViewModelBase
    {
        private IServiceProvider serviceProvider;
        private BattleMapProxy hubProxy;
        public SessionViewModel(IServiceProvider serviceProvider, BattleMapProxy hubProxy)
        {
            SessionCommand = new Command(LeaveSession);
            this.serviceProvider = serviceProvider;
        }
        private List<User> usersInSession;
        public List<User> UsersInSession
        {
            get => usersInSession;
            set
            {
                usersInSession = value;
                OnPropertyChanged();
            }
        }

        public ICommand SessionCommand { get; }

        public async void UpdateUsers(User user)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                UsersInSession.Add(user);
                OnPropertyChanged("UsersInSession");
            });
        }

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
