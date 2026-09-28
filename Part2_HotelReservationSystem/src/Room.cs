namespace Part2_HotelReservationSystem;

public class Room
{
    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if (nightlyRate <= 0)
        {
            throw new ArgumentException("Nightly rate must be greater than zero.");
        }
        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
        IsUnderMaintenance = false;
    }

    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }
    public void SetNightlyRate(decimal rate)
    {
        if (rate <= 0)
        {
            throw new ArgumentException("Rate Cannot Be Zero Or Below");

        }
        NightlyRate = rate;

    }
    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }
    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }
}