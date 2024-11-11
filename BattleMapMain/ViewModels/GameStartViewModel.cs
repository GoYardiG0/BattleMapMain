using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleMapMain.ViewModels
{
    public class GameStartViewModel
    {
        public GameStartViewModel() {
            SessionCommand = new Command(Session);
        }
        public ICommand SessionCommand { get; }

        private void Session()
        {
            ((App)Application.Current).NotInSession = false;
        }
    }
}
