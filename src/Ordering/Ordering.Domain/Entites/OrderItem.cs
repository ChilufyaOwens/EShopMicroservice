using Services.Commons.Domain;

namespace Ordering.Domain.Entites
{
    public class OrderItem(OrderItemId id, Guid product, int quantity, Money unitPrice) : Entity<OrderItemId>(id)
    {
        public Guid ProductId { get; private set; } = product;
        public int Quantity { get; private set; } = quantity;
        public Money UnitPrice { get; private set; } = unitPrice;
    }
}
