using Services.Commons.Domain;

namespace Ordering.Domain.ValueObjects
{
    public sealed class OrderItemId(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        public static OrderItemId Create(Guid value)
        {
            return new OrderItemId(value);
        }

        public static OrderItemId CreateNew()
        {
            return new OrderItemId(Guid.NewGuid());
        }



        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
