using Services.Commons.Domain;

namespace Ordering.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string firstName,
            string? emailAddress,
            string addressLine,
            string state,
            string country,
            string zipCode)
        {
            FirstName = firstName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
        public string FirstName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string State { get; } = default!;
        public string Country { get; } = default!;
        public string ZipCode { get; } = default!;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return EmailAddress;
            yield return AddressLine;
            yield return State;
            yield return Country;
            yield return ZipCode;

        }
    }
}
