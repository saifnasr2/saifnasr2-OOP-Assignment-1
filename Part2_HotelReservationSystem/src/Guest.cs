using System;

namespace Part2_HotelReservationSystem;

public class Guest
{
    public int GuestId { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }

    private readonly List<Reservation> _reservations = new();

    public IReadOnlyList<Reservation> Reservations => _reservations;

    public Guest(int guestId, string fullName, string phoneNumber)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(guestId);
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);

        GuestId = guestId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    public void AddReservation(Reservation reservation)
    {
        ArgumentNullException.ThrowIfNull(reservation);

        _reservations.Add(reservation);
    }
}
