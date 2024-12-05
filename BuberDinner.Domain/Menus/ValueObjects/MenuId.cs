using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
    public override Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    // TODO: Reforce invariants
    public static MenuId CreateUnique() => new (Guid.NewGuid());

    // TODO: Reforce invariants
    public static MenuId Create(Guid value) => new (value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}