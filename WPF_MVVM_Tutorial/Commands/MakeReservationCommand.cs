using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_Tutorial.Exceptions;
using WPF_MVVM_Tutorial.Models;
using WPF_MVVM_Tutorial.Services;
using WPF_MVVM_Tutorial.ViewModels;

namespace WPF_MVVM_Tutorial.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;
        private readonly NavigationService _reservationViewNavigationService;

        public MakeReservationCommand(ViewModels.MakeReservationViewModel makeReservationViewModel, Hotel hotel, NavigationService reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            this._reservationViewNavigationService = reservationViewNavigationService;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) 
                && _makeReservationViewModel.FloorNumber > 0
                && _makeReservationViewModel.RoomNumber > 0
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber)
                , _makeReservationViewModel.Username
                , _makeReservationViewModel.StartDate
                , _makeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show("Successfully reserved room."
                    , "Success"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();

            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken."
                    , "Error"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Error);
            }

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeReservationViewModel.Username)
                || (e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
                || (e.PropertyName == nameof(MakeReservationViewModel.RoomNumber)))
            {
                OnCanExecutedChanged();
            }
        }

    }
}
