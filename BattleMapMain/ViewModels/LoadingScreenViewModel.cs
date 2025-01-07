using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMapMain.ViewModels
{
    public class LoadingScreenViewModel
    {
        private IServiceProvider serviceProvider;
        public LoadingScreenViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            ShellSwitch();
        }
        private void ShellSwitch()
        {            
            AppShell shell = serviceProvider.GetService<AppShell>();
            ((App)Application.Current).MainPage = shell;
            ((AppShell)AppShell.Current).UpdateSessionStatus(((App)Application.Current).notInSession);
        }
    }
    
}
