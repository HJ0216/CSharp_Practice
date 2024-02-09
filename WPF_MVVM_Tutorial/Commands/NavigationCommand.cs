using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Tutorial.Services;
using WPF_MVVM_Tutorial.Stores;
using WPF_MVVM_Tutorial.ViewModels;

namespace WPF_MVVM_Tutorial.Commands
{
    internal class NavigationCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigationCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Func<ViewModelBase> CreateViewModel { get; }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
