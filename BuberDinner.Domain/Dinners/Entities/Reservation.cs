using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.Enums;
using BuberDinner.Domain.Dinners.Enums;
using BuberDinner.Domain.Guests.ValueObjects;

namespace BuberDinner.Domain.Dinners.ValueObjects;


public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }



    private Reservation(
         ReservationId reservationId,
         int guestCount,
         ReservationStatus reservationStatus,
         GuestId guestId,
         BillId billId,
         DateTime createdDateTime,
         DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
    int guestCount,
    GuestId guestId,
    BillId billId)
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestCount,
            ReservationStatus.PendingGuestConfirmation,
            guestId,
            billId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}

