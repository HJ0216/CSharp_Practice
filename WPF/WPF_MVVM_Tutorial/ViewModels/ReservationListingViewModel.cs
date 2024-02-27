using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM_Tutorial.Commands;
using WPF_MVVM_Tutorial.Models;
using WPF_MVVM_Tutorial.Stores;

namespace WPF_MVVM_Tutorial.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        // private ICommand _makeReservationCommand;
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(Hotel hotel, Services.NavigationService makeReservationService)
        {
            _hotel = hotel;
            _reservations = new ObservableCollection<ReservationViewModel>();
            MakeReservationCommand = new NavigationCommand(makeReservationService);

            UpdateReservations();
        }

        private void UpdateReservations()
        {
            _reservations.Clear();

            foreach(Reservation reservation in _hotel.GetAllreservations())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
