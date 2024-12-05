using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guests.ValueObjects;

public sealed class GuestRatingId : AggregateRootId<Guid>
{
    public override Guid Value { get; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId Create(Guid value) => new (value);

    public static GuestRatingId Create(string guestRatingId) => new (Guid.Parse(guestRatingId));
    public static GuestRatingId CreateUnique() => new (Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}