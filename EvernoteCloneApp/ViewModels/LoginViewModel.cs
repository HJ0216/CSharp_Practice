using EvernoteCloneApp.Model;
using EvernoteCloneApp.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteCloneApp.ViewModels
{
    public class LoginViewModel
    {
		private User _user;

		public User User
		{
			get { return _user; }
			set { _user = value; }
		}

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }
    }
}
