using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guests.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId Create(Guid value) => new (value);

    public static GuestId Create(string guestId) => new (Guid.Parse(guestId));

    public static GuestId CreateUnique() => new (Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}