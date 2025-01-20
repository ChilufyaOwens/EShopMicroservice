namespace Services.Commons.Domain
{
    /// <summary>
    /// Represents an abstract base class for aggregate roots with a specified identifier type.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId> where TId : AggregateRootId<TIdType>
    {
        public new AggregateRootId<TIdType> Id { get; protected set; }

        protected AggregateRoot(TId id) : base(id)
        {
            Id = id;
        }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        protected AggregateRoot() { }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
