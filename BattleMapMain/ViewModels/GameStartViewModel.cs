using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using BattleMapMain.Views;
using Microsoft.Maui.Controls;

namespace BattleMapMain.ViewModels
{
    public class GameStartViewModel
    {
        private IServiceProvider serviceProvider;
        public GameStartViewModel(IServiceProvider serviceProvider) {
            SessionCommand = new Command(Session);
            this.serviceProvider = serviceProvider;
        }
        public ICommand SessionCommand { get; }

        private void Session()
        {
            ((App)Application.Current).notInSession = false;
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
        }
    }
}
