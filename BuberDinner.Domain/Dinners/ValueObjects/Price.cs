using BuberDinner.Domain.Common.Models;
namespace BuberDinner.Domain.Dinners.ValueObjects;

public class Price: ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    // returns properties of the class in defined order
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}