using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Tutorial.Models;

namespace WPF_MVVM_Tutorial.Exceptions
{
    public class ReservationConflictException : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation InComingReservation { get; }

        public ReservationConflictException(Reservation existingReservation, Reservation inComingReservation)
        {
            ExistingReservation = existingReservation;
            InComingReservation = inComingReservation;
        }

        public ReservationConflictException(string? message, Reservation existingReservation, Reservation inComingReservation) : base(message)
        {
            ExistingReservation = existingReservation;
            InComingReservation = inComingReservation;
        }

        public ReservationConflictException(string? message, Exception? innerException, Reservation existingReservation, Reservation inComingReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            InComingReservation = inComingReservation;
        }

        protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
