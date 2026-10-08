
namespace Part2_HotelReservationSystem;    
class Program
{
    static void Main(string[] args)
    {
        Guest guest = new Guest(
        1,
        "Saif Nasr",
        "01000000000");

        Room room = new Room(
            101,
            RoomType.Single,
            1500m);

        ReservationManager manager = new ReservationManager();

        Console.WriteLine("=== Create Reservation ===");

        Reservation reservation = manager.CreateReservation(
            1,
            guest,
            room,
            new DateTime(2026, 10, 10),
            new DateTime(2026, 10, 13));

        Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
        Console.WriteLine($"Status: {reservation.Status}");
        Console.WriteLine($"Room: {reservation.Room.RoomNumber}");
        Console.WriteLine($"Total: {reservation.CalculateTotalCost()}");


        Console.WriteLine("\n=== Confirm ===");

        reservation.Confirm();

        Console.WriteLine($"Status: {reservation.Status}");


        Console.WriteLine("\n=== Check In ===");

        reservation.CheckIn();

        Console.WriteLine($"Status: {reservation.Status}");


        Console.WriteLine("\n=== Check Out ===");

        reservation.CheckOut();

        Console.WriteLine($"Status: {reservation.Status}");


        Console.WriteLine("\n=== Guest Reservations ===");

        foreach (var guestReservation in guest.Reservations)
        {
            Console.WriteLine(
                $"Reservation #{guestReservation.ReservationId} - " +
                $"{guestReservation.Status}");
        }


        Console.WriteLine("\n=== Test Invalid Transition ===");

        try
        {
            reservation.CheckIn();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected error: {ex.Message}");
        }


        Console.WriteLine("\n=== Test Maintenance ===");

        Room maintenanceRoom = new Room(
            102,
            RoomType.Double,
            2000m);

        maintenanceRoom.StartMaintenance();

        try
        {
            manager.CreateReservation(
                2,
                guest,
                maintenanceRoom,
                new DateTime(2026, 10, 10),
                new DateTime(2026, 10, 12));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected error: {ex.Message}");
        }


        Console.WriteLine("\n=== Test Double Booking ===");

        Room room2 = new Room(
            103,
            RoomType.Suite,
            3000m);

        manager.CreateReservation(
            3,
            guest,
            room2,
            new DateTime(2026, 11, 1),
            new DateTime(2026, 11, 5));

        try
        {
            manager.CreateReservation(
                4,
                guest,
                room2,
                new DateTime(2026, 11, 3),
                new DateTime(2026, 11, 7));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected error: {ex.Message}");
        }

        }
}
    
    
    