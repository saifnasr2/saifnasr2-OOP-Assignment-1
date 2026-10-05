using System;

namespace Part2_HotelReservationSystem;

public class Reservation
{
    public int ReservationId { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public Room Room { get; }
    public ReservationStatus Status { get; private set; }

    public Reservation(
        int reservationId,
        DateTime checkInDate,
        DateTime checkOutDate,
        Room room)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(reservationId);
        ArgumentNullException.ThrowIfNull(room);

        if (checkOutDate <= checkInDate)
        {
            throw new ArgumentException(
                "Check-out date must be after check-in date.");
        }

        if (room.IsUnderMaintenance)
        {
            throw new InvalidOperationException(
                "Cannot create a reservation for a room under maintenance.");
        }

        ReservationId = reservationId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Room = room;
        Status = ReservationStatus.Pending;
    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
        {
            throw new InvalidOperationException(
                "Only a pending reservation can be confirmed.");
        }

        Status = ReservationStatus.Confirmed;
    }

    public void CheckIn()
    {
        if (Status != ReservationStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Only a confirmed reservation can be checked in.");
        }

        Status = ReservationStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
        {
            throw new InvalidOperationException(
                "Only a checked-in reservation can be checked out.");
        }

        Status = ReservationStatus.CheckedOut;
    }

    public void Cancel()
    {
        if (Status != ReservationStatus.Pending &&
            Status != ReservationStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Only pending or confirmed reservations can be cancelled.");
        }

        Status = ReservationStatus.Cancelled;
    }

    public decimal CalculateTotalCost()
    {
        int nights = (CheckOutDate - CheckInDate).Days;

        return nights * Room.NightlyRate;
    }
}
