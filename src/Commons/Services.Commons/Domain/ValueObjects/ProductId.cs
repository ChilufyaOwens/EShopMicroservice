
namespace Services.Commons.Domain.ValueObjects
{
    public sealed class ProductId(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        public static ProductId Create(Guid Value)
        {
            return new ProductId(Value);
        }

        public static ProductId CreateNew()
        {
            return new ProductId(Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
