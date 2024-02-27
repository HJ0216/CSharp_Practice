using System.Configuration;
using System.Data;
using System.Windows;
using WPF_MVVM_Tutorial.Exceptions;
using WPF_MVVM_Tutorial.Models;
using WPF_MVVM_Tutorial.Stores;
using WPF_MVVM_Tutorial.ViewModels;

namespace WPF_MVVM_Tutorial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _hotel = new Hotel("SingletonSean Suites");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new Services.NavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return new ReservationListingViewModel(_hotel, new Services.NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }

    }

}
