using System;

namespace Part2_HotelReservationSystem;

public class ReservationManager
{
    private readonly List<Reservation> _reservations = new();

    public IReadOnlyList<Reservation> Reservations => _reservations;

    public Reservation CreateReservation(
        int reservationId,
        Guest guest,
        Room room,
        DateTime checkInDate,
        DateTime checkOutDate)
    {
        ArgumentNullException.ThrowIfNull(guest);
        ArgumentNullException.ThrowIfNull(room);

        foreach (var reservation in _reservations)
        {
            if (reservation.ReservationId == reservationId)
            {
                throw new InvalidOperationException(
                    "A reservation with this ID already exists.");
            }
        }

        foreach (var reservation in _reservations)
        {
            if (reservation.Room == room &&
                reservation.Status != ReservationStatus.Cancelled &&
                reservation.Status != ReservationStatus.CheckedOut)
            {
                bool overlaps =
                    checkInDate < reservation.CheckOutDate &&
                    checkOutDate > reservation.CheckInDate;

                if (overlaps)
                {
                    throw new InvalidOperationException(
                        "The room is already booked for the selected dates.");
                }
            }
        }

        Reservation newReservation = new Reservation(
            reservationId,
            checkInDate,
            checkOutDate,
            room);

        _reservations.Add(newReservation);
        guest.AddReservation(newReservation);

        return newReservation;
    }
}
