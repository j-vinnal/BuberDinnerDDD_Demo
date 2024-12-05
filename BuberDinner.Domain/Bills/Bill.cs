using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;

namespace BuberDinner.Domain.Bills
{
    public class Bill : AggregateRoot<BillId, Guid>
    {
        public DinnerId DinnerId { get; private set; } = default!;
        public GuestId GuestId { get; private set; } = default!;
        public HostId HostId { get; private set; } = default!;
        public Price Price { get; private set; } = default!;
        public DateTime CreatedDateTime { get; private set; } = default!;
        public DateTime UpdatedDateTime { get; private set; } = default!;

        private Bill() { }

        private Bill(
            BillId billId,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(billId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price)
        {
            return new Bill(
                BillId.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        // Additional methods to manage bill updates can be added here
    }
}