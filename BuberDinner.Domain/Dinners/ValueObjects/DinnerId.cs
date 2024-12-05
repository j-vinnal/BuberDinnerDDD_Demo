using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid>
{
    public override Guid Value { get; }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId Create(Guid value) => new (value);

    public static DinnerId CreateUnique() => new (Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}