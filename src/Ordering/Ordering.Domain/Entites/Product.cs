using Services.Commons.Domain;
using Services.Commons.Domain.ValueObjects;

namespace Ordering.Domain.Entites
{
    public class Product : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;
        public Money Price { get; private set; } = default!;
    }
}
