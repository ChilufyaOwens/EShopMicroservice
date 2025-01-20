using Services.Commons.Domain;
using Services.Commons.Domain.ValueObjects;

namespace Ordering.Domain.Entites
{
    public class Customer : Entity<CustomerId>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;

    }
}
