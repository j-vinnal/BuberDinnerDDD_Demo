using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; }

        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId Create(Guid value) => new (value);

        public static ReservationId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}