using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteCloneApp.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            // TODO: Login Functionality
        }
    }
}
