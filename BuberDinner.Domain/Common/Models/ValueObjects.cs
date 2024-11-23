namespace BuberDinner.Domain.Common.Models;


// ValueObject is a base class for all value objects in the domain
public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {

        //check if two objects are of the same type
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        //cast obj to ValueObject then it has GetEqualityComponents method 
        // which returns properties of the class in defined order
        var valueObject = (ValueObject)obj;

        //compare properties of the class in defined order
        //if properties are the same, return true
        return GetEqualityComponents()
            .SequenceEqual(valueObject.GetEqualityComponents());
    }

    //overloading == operator   
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }

    //overloading != operator
    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);
    }

    //override GetHashCode method
    //XOR returns same hashcode when properties are the same
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}

//example of a value object
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