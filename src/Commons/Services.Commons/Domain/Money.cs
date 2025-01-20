
using Services.Commons.Exception;

namespace Services.Commons.Domain
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if(amount < 0)
            {
                throw new DomainException("Amount cannot be negative.");
            }

            if(string.IsNullOrWhiteSpace(currency))
            {
                throw new DomainException("Currency cannot be empty.");
            }
            Amount = amount;
            Currency = currency;
        }

        public static bool IsLessThanZero(decimal other)
        {
            return other < 0;
        }

        public static Money Sum(Money price, Money other)
        {
            if (price.Currency != other.Currency)
            {
                throw new DomainException("Currencies must be the same.");
            }
            return new Money(price.Amount + other.Amount, price.Currency);
        }

        public static Money Subtract(Money price, Money other)
        {
            if (price.Currency != other.Currency)
            {
                throw new DomainException("Currencies must be the same.");
            }
            return new Money(price.Amount - other.Amount, price.Currency);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
