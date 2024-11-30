namespace BuberDinner.Domain.Common.Models;

// AggregateRoot is a base class for all aggregate roots in the domain
public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    protected AggregateRoot(TId id) : base(id)
    {
    }

    protected AggregateRoot() { }
}