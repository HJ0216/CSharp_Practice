using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Tutorial.Models
{
    public class RoomID
    {
        public int FloorNumber { get; }
        public int RoomNumber { get; }

        public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }

        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }

        public override bool Equals(object? obj)
        {
            return obj is RoomID roomID // obj가 RoomID 타입이라면, 그 객체를 roomID라는 새로운 변수에 할당
                && FloorNumber == roomID.FloorNumber
                && RoomNumber == roomID.RoomNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber);
        }

        public static bool operator ==(RoomID roomID1, RoomID roomID2)
        {
            if(roomID1 is null && roomID2 is null) // == 사용 시, 정의한 operator를 사용하게 되므로 stackoverflow error 발생
            {
                return true;
            }

            return !(roomID1 is null) && roomID1.Equals(roomID2);
        }

        public static bool operator !=(RoomID roomID1, RoomID roomID2)
        {
            return !(roomID1 == roomID2);
        }

    }
}
