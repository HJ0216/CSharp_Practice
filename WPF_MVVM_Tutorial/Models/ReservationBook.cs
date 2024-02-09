using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Tutorial.Exceptions;

namespace WPF_MVVM_Tutorial.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;
        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }
        /*
                public IEnumerable<Reservation> GetReservationForUser(string username)
                {
                    return _reservations.Where(r => r.Username == username);
                    //  _reservations 컬렉션의 각 요소 r에 대해, r.Username이 username과 같은지를 검사하는 함수를 정의
                    // 이 함수가 true를 반환하는 요소들만을 골라 새로운 IEnumerable<Reservation> 컬렉션을 만들어 반환
                }
        */

        /// <summary>
        /// Get All Reservations.
        /// </summary>
        /// <returns>All Reservations in the hotel reservation book.</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        /// <summary>
        /// Add a reservation to the reservation book.
        /// </summary>
        /// <param name="reservation"></param>
        /// <exception cref="ReservationConflictException">Thrown if incoming reservation conflicts with existing reservation.</exception>
        public void AddReservaion(Reservation reservation)
        {
            foreach(Reservation existingReservation in _reservations)
            {
                if (existingReservation.Conflict(reservation))
                {
                    throw new ReservationConflictException(existingReservation, reservation);
                }
            }

            _reservations.Add(reservation);
        }
    }
}
