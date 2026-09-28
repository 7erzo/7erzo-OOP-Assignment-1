namespace Part2_HotelReservationSystem;

public class ReservationSystem
{
    private int _nextReservationId = 1;
    private readonly List<Reservation> _reservations = new();
    public bool IsRoomAvailable(Room room, DateTime checkIn, DateTime checkOut)
    {
        foreach (Reservation reservation in _reservations)
        {
            if (reservation.Room == room)
            {
                if (reservation.Status == ReservationStatus.CheckedIn ||
                    reservation.Status == ReservationStatus.Pending ||
                    reservation.Status == ReservationStatus.Confirmed)
                {
                    if (reservation.CheckInDate < checkOut && checkIn < reservation.CheckOutDate)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    public Reservation CreateReservation(
    Guest guest,
    Room room,
    DateTime checkIn,
    DateTime checkOut
)
    {
        if (!IsRoomAvailable(room, checkIn, checkOut))
        {
            throw new InvalidOperationException("Room Is Not Available");
        }

        Reservation reservation = new Reservation(
            _nextReservationId,
            checkIn,
            checkOut,
            room
        );

        _nextReservationId++;

        _reservations.Add(reservation);
        guest.AddReservation(reservation);

        return reservation;
    }


}