using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Views;

namespace BattleMapMain.ViewModels
{
    public class BattleMapViewModel
    {
        private IServiceProvider serviceProvider;
        public BattleMapViewModel(IServiceProvider serviceProvider)
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
