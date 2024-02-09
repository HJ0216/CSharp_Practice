using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Tutorial.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;
        public string Name { get; }
        public Hotel(string name)
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }

        /// <summary>
        /// Get All reservations.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>All reservations.</returns>
        public IEnumerable<Reservation> GetAllreservations()
        {
            return _reservationBook.GetAllReservations();
        }

        /// <summary>
        /// Make a reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <exception cref="ReservationConflictException"></exception>
        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservaion(reservation);
        }

    }
}
