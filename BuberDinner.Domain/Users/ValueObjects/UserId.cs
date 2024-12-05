using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Users.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId Create(Guid value) => new (value);

        public static UserId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}