using System;

namespace Part2_HotelReservationSystem;

public class Room
{
    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }

    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(roomNumber);

        if (nightlyRate <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(nightlyRate),
                "Nightly rate must be greater than zero.");

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
        IsUnderMaintenance = false;
    }

    public void ChangeNightlyRate(decimal newRate)
    {
        if (newRate <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(newRate),
                "Nightly rate must be greater than zero.");

        NightlyRate = newRate;
    }

    public void StartMaintenance()
    {
        if (IsUnderMaintenance)
            throw new InvalidOperationException(
                "Room is already under maintenance.");

        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        if (!IsUnderMaintenance)
            throw new InvalidOperationException(
                "Room is not currently under maintenance.");

        IsUnderMaintenance = false;
    }
}
