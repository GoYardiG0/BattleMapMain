using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Models;
using BattleMapMain.Services;
using BattleMapMain.Views;

namespace BattleMapMain.ViewModels
{

        public class LoginViewModel : ViewModelBase
        {
            private BattleMapWebAPIProxy proxy;
            private IServiceProvider serviceProvider;
            public LoginViewModel(BattleMapWebAPIProxy proxy, IServiceProvider serviceProvider)
            {
                this.serviceProvider = serviceProvider;
                this.proxy = proxy;
                LoginCommand = new Command(() => OnLogin());
                RegisterCommand = new Command(OnRegister);
                name = "";
                password = "";
                InServerCall = false;
                errorMsg = "";
            }

            private string name;
            private string password;

            public string Name
            {
                get => name;
                set
                {
                    if (name != value)
                    {
                        name = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Password
            {
                get => password;
                set
                {
                    if (password != value)
                    {
                        password = value;
                        OnPropertyChanged(nameof(Password));
                    }
                }
            }

            private string errorMsg;
            public string ErrorMsg
            {
                get => errorMsg;
                set
                {
                    if (errorMsg != value)
                    {
                        errorMsg = value;
                        OnPropertyChanged(nameof(ErrorMsg));
                    }
                }
            }


            public ICommand LoginCommand { get; }
            public ICommand RegisterCommand { get; }



            private async void OnLogin()
            {
                //Choose the way you want to blobk the page while indicating a server call
                InServerCall = true;
                ErrorMsg = "";
                //Call the server to login
                LoginInfo loginInfo = new LoginInfo { UserName = Name, Password = Password };
                User? u = await this.proxy.LoginAsync(loginInfo);

                InServerCall = false;

                //Set the application logged in user to be whatever user returned (null or real user)
                ((App)Application.Current).LoggedInUser = u;
                if (u == null)
                {
                    ErrorMsg = "Invalid Username or password";
                }
                else
                {
                    ErrorMsg = "great succes";
                //Navigate to the main page

                //gameStartViewModel.Refresh(); //Refresh data and user in the tasksview model as it is a singleton

                await ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
                //Shell.Current.FlyoutIsPresented = false; //close the flyout

                }
            }

            private void OnRegister()
            {
                ErrorMsg = "";
                Name = "";
                Password = "";
                // Navigate to the Register View page
                ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<RegisterView>());
            }


        }
    
}
