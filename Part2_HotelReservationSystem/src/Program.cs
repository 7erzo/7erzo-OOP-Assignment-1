using Part2_HotelReservationSystem;

var system = new ReservationSystem();

var room = new Room(
    101,
    RoomType.Double,
    1500m
);

var guest = new Guest(
    1,
    "Mahmoud Herzallah",
    "01000000000"
);

Console.WriteLine("=== Hotel Reservation System ===");
Console.WriteLine();

var reservation = system.CreateReservation(
    guest,
    room,
    new DateTime(2026, 10, 1),
    new DateTime(2026, 10, 4)
);

Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
Console.WriteLine($"Guest: {guest.FullName}");
Console.WriteLine($"Room: {room.RoomNumber}");
Console.WriteLine($"Status: {reservation.Status}");
Console.WriteLine($"Total Cost: {reservation.TotalCost}");

Console.WriteLine();
Console.WriteLine("=== Reservation Lifecycle ===");

reservation.Confirm();
Console.WriteLine($"After Confirm: {reservation.Status}");

reservation.CheckIn();
Console.WriteLine($"After Check-In: {reservation.Status}");

reservation.CheckOut();
Console.WriteLine($"After Check-Out: {reservation.Status}");

Console.WriteLine();
Console.WriteLine("=== Guest Reservation History ===");
Console.WriteLine($"Reservations Count: {guest.Reservations.Count}");

Console.WriteLine();
Console.WriteLine("=== Double Booking Test ===");

try
{
    system.CreateReservation(
        guest,
        room,
        new DateTime(2026, 10, 2),
        new DateTime(2026, 10, 5)
    );
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Rejected: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("=== Maintenance Test ===");

room.StartMaintenance();

try
{
    system.CreateReservation(
        guest,
        room,
        new DateTime(2026, 10, 10),
        new DateTime(2026, 10, 12)
    );
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Rejected: {ex.Message}");
}

room.EndMaintenance();

Console.WriteLine();
Console.WriteLine("=== Price Update Test ===");

Console.WriteLine($"Old Rate: {room.NightlyRate}");

room.SetNightlyRate(1800m);

Console.WriteLine($"New Rate: {room.NightlyRate}");
