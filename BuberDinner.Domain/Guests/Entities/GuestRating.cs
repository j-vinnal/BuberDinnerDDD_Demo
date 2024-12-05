using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;

namespace BuberDinner.Domain.Guestss.Entities;

public class GuestRating : AggregateRoot<GuestRatingId, Guid>
{
    public HostId HostId { get; private set; } = default!;
    public DinnerId DinnerId { get; private set; } = default!;
    public Rating Rating { get; private set; } = default!;
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private GuestRating() { }

    private GuestRating(
        GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        double ratingValue)
    {
        return new GuestRating(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            Rating.Create(ratingValue),
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
