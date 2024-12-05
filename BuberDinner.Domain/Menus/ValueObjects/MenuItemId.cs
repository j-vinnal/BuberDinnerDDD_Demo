using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuItemId : AggregateRootId<Guid>
{
    public override Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId Create(Guid value) => new(value);

    public static MenuItemId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}