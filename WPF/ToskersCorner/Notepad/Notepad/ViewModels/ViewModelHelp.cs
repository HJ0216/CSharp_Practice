using Notepad.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    public class ViewModelHelp : ObservableObject
    {
        #region Properties
        #endregion



        #region Commands
        public ICommand HelpCommand => null ?? new RelayCommand(HelpEvent);

        #endregion



        #region Constructors
        public ViewModelHelp()
        {
        }

        #endregion



        #region Methods
        private void HelpEvent()
        {

        }
        #endregion
    }
}
