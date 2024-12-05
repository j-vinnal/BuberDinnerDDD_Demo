using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuSectionId : AggregateRootId<Guid>
{
    public override Guid Value { get; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId Create(Guid value) => new (value);

    public static MenuSectionId CreateUnique() => new (Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}