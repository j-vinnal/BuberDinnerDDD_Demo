using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Guestss.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    private GuestRating(
        GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestRatingId)
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
