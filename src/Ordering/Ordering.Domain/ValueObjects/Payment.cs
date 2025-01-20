using Services.Commons.Domain;

namespace Ordering.Domain.ValueObjects
{
    public class Payment : ValueObject
    {
        public string? CardName { get; } = default!;
        public string CardNubmer { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CardName;
            yield return CardNubmer;
            yield return Expiration;
            yield return CVV;
            yield return PaymentMethod;
        }
    }
}
