namespace Services.Commons.Domain
{
    /// <summary>
    /// Represents an abstract base class for entities with a specified identifier type.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents where TId : ValueObject
    {
        /// <summary>
        /// Gets the identifier of the entity.
        /// </summary>
        public TId Id { get; protected set; }

        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        protected Entity(TId id)
        {
            Id = id;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current entity.
        /// </summary>
        /// <param name="obj">The object to compare with the current entity.</param>
        /// <returns>true if the specified object is equal to the current entity; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetRealType() != other.GetRealType())
                return false;
            if (Id is null)
                return false;
            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Determines whether two specified entities have the same value.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns>true if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, false.</returns>
        public static bool operator ==(Entity<TId>? a, Entity<TId>? b) => ReferenceEquals(a, b);

        /// <summary>
        /// Determines whether two specified entities have different values.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns>true if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, false.</returns>
        public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !ReferenceEquals(a, b);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current entity.</returns>
        public override int GetHashCode() => (GetRealType().ToString() + Id).GetHashCode();

        /// <summary>
        /// Gets the real type of the current instance, handling proxy types.
        /// </summary>
        /// <returns>The real type of the current instance.</returns>
        private Type GetRealType()
        {
            var type = GetType();
            return type.ToString().Contains("Castle.Proxies.") ? type.BaseType! : type;
        }

        /// <summary>
        /// Determines whether the specified entity is equal to the current entity.
        /// </summary>
        /// <param name="other">The entity to compare with the current entity.</param>
        /// <returns>true if the specified entity is equal to the current entity; otherwise, false.</returns>
        public bool Equals(Entity<TId>? other)
        {
            return ReferenceEquals((object?)this, other);
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

#pragma warning disable CS8618
        protected Entity() { }
#pragma warning restore CS8618
    }
}
