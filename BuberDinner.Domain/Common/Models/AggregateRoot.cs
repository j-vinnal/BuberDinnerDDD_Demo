namespace BuberDinner.Domain.Common.Models;

// AggregateRoot is a base class for all aggregate roots in the domain
public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
where TId : AggregateRootId<TIdType>
where TIdType : notnull
{
    public virtual new AggregateRootId<TIdType> Id { get; protected set; }
    protected AggregateRoot(TId id) { Id = id; }

    protected AggregateRoot() { Id = default!; }
}

public abstract class AggregateRoot<TId> : Entity<TId>
where TId : notnull
{
    protected AggregateRoot(TId id)
    : base(id) { }
}