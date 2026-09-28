namespace Part2_HotelReservationSystem;

public class Reservation
{
    public Reservation(int reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
    {
        if (checkInDate >= checkOutDate)
        {
            throw new ArgumentException("Check In Must Be Before Check Out");
        }
        if (room.IsUnderMaintenance)
        {
            throw new ArgumentException("The Room is under Maintenance");
        }
        ReservationId = reservationId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Room = room;
        Status = ReservationStatus.Pending;
    }

    public int ReservationId { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }

    public Room Room { get; }
    public ReservationStatus Status { get; private set; }
    public void Confirm()
    {
        if (Status == ReservationStatus.Pending)
        {

            Status = ReservationStatus.Confirmed;
        }
        else
        {
            throw new InvalidOperationException("You Can't Confirm Reservation");
        }
    }
    public void CheckIn()
    {
        if (Status == ReservationStatus.Confirmed)
        {

            Status = ReservationStatus.CheckedIn;
        }
        else
            throw new InvalidOperationException("You Can't Check In Reservation");

    }
    public void CheckOut()
    {
        if (Status == ReservationStatus.CheckedIn)
        {
            Status = ReservationStatus.CheckedOut;
        }
        else
            throw new InvalidOperationException("You Can't Check Out Reservation");
    }
    public void Cancel()
    {
        if (Status == ReservationStatus.Confirmed || Status == ReservationStatus.Pending)
        {
            Status = ReservationStatus.Cancelled;
        }
        else
            throw new InvalidOperationException("You Can't Cancel The Reservation.");
    }
    public decimal TotalCost =>
        (CheckOutDate - CheckInDate).Days * Room.NightlyRate;
}