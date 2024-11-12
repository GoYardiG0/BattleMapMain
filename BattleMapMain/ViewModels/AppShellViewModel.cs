using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.ViewModels;
using BattleMapMain.Views;
using BattleMapMain.Models;
using BattleMapMain.Services;

namespace BattleMapMain.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        private User? currentUser;
        private IServiceProvider serviceProvider;
        private bool notInSession;
        public bool NotInSession
        {
            get => notInSession;
            set
            {
                    notInSession = value;
                    OnPropertyChanged();
                    OnPropertyChanged("InSession");

            }
        }
        public bool InSession
        {
            get => !notInSession;

        }
        public AppShellViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.currentUser = ((App)Application.Current).LoggedInUser;
            this.NotInSession = true;
        }

        public void Session()
        {
            NotInSession = false;
        }

        //this command will be used for logout menu item
        public Command LogoutCommand
        {
            get
            {
                return new Command(OnLogout);
            }
        }
        //this method will be trigger upon Logout button click
        public void OnLogout()
        {
            ((App)Application.Current).LoggedInUser = null;

            ((App)Application.Current).MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
        }
    }
}
