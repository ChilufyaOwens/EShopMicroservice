namespace Services.Commons.Domain
{
    /// <summary>
    /// Represents a base class for value objects.
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        /// <summary>
        /// Gets the components that are used to determine equality.
        /// </summary>
        /// <returns>An enumerable of objects representing the equality components.</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Determines whether the specified value object is equal to the current value object.
        /// </summary>
        /// <param name="other">The value object to compare with the current value object.</param>
        /// <returns>true if the specified value object is equal to the current value object; otherwise, false.</returns>
        public bool Equals(ValueObject? other)
        {
            return Equals((object)other);
        }

        /// <summary>
        /// Determines whether two value objects are equal.
        /// </summary>
        /// <param name="a">The first value object to compare.</param>
        /// <param name="b">The second value object to compare.</param>
        /// <returns>true if the value objects are equal; otherwise, false.</returns>
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }


        /// <summary>
        /// Determines whether two value objects are not equal.
        /// </summary>
        /// <param name="a">The first value object to compare.</param>
        /// <param name="b">The second value object to compare.</param>
        /// <returns>true if the value objects are not equal; otherwise, false.</returns>
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }
    }
}
