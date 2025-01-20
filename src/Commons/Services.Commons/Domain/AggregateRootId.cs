namespace Services.Commons.Domain
{
    /// <summary>
    /// Represents the base class for aggregate root identifiers.
    /// </summary>
    public abstract class AggregateRootId<TId> : ValueObject
    {
        public abstract TId Value { get; protected set; }
    }
}

