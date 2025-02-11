using BattleMapMain.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleMapMain.ViewModels
{
    public class SessionViewModel
    {
        private IServiceProvider serviceProvider;
        public SessionViewModel(IServiceProvider serviceProvider)
        {
            SessionCommand = new Command(NotSession);
            this.serviceProvider = serviceProvider;
        }

        public ICommand SessionCommand { get; }

        private void NotSession()
        {
            ((App)Application.Current).notInSession = true;
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<LoadingScreenView>());
        }
    }
}
