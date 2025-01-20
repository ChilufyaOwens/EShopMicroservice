using Services.Commons.Domain;

namespace Ordering.Domain.ValueObjects
{
    public sealed class OrderId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private OrderId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new OrderDomainException($"{nameof(OrderId)} cannot be empty.");
            }
            Value = value;
        }

        protected override IEnumerable<object>  GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
