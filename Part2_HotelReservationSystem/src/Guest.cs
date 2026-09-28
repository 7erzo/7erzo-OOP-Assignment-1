namespace Part2_HotelReservationSystem;

public class Guest
{
    private readonly List<Reservation> _reservations = new();
    public IReadOnlyList<Reservation> Reservations => _reservations;
    public int GuestId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }
    public Guest(int guestId, string fullName, string phoneNumber)
    {
        if (string.IsNullOrEmpty(fullName) ||
            string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException(
                "Full name and phone number cannot be empty."
            );
        }

        GuestId = guestId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }
    public void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
    }


}