using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bills.ValueObjects
{
    public sealed class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; }

        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId Create(Guid value) => new (value);

        public static BillId Create(string billId) => new (Guid.Parse(billId));

        public static BillId CreateUnique() => new (Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}