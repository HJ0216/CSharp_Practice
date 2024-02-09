using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Input.Manipulations;
using WPF_MVVM_Tutorial.Commands;
using WPF_MVVM_Tutorial.Models;
using WPF_MVVM_Tutorial.Services;
using WPF_MVVM_Tutorial.Stores;

namespace WPF_MVVM_Tutorial.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
		private string _username;

		public string Username
		{
			get { return _username; }
			set {
				_username = value;
				OnPropertyChanged(nameof(Username));
			}
		}

		private int _floorNumber;

		public int FloorNumber
		{
			get { return _floorNumber; }
			set {
				_floorNumber = value;
				OnPropertyChanged(nameof(FloorNumber));
			}
		}

        private int _roomNumber;

        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

		private DateTime _startDate = new DateTime(2024, 2, 9);

		public DateTime StartDate
		{
			get { return _startDate; }
			set 
			{ 
				_startDate = value;
				OnPropertyChanged(nameof(StartDate));
			}
		}

        private DateTime _endDate = new DateTime(2024, 2, 10);

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

		//private ICommand _submitCommand;
		public ICommand SubmitCommand { get; }
        //private ICommand _cancelCommand;
        public ICommand CancelCommand { get; }

        public MakeReservationViewModel(
			Hotel hotel
			, NavigationService reservationViewNavigationService)
        {
			SubmitCommand = new MakeReservationCommand(this, hotel, reservationViewNavigationService);
			CancelCommand = new NavigationCommand(reservationViewNavigationService);
        }

    }
}
