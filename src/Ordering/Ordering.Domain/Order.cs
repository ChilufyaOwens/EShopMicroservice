using Services.Commons.Domain;

namespace Ordering.Domain
{
    public class Order(OrderId id,
        Customer customer,
        string orderName,
        Address shippingAddress,
        Address billingAddress,
        Payment payment) : AggregateRoot<OrderId, Guid>(id)
    {
        private readonly List<OrderItem> _orderItems = [];
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Customer Customer { get; private set; } = customer;
        public string OrderName { get; private set; } = orderName;

        public Address ShippingAddress { get; private set; } = shippingAddress;
        public Address BillingAddress { get; private set; } = billingAddress;

        public OrderStatus Status { get; private set; } = OrderStatus.Pending;

        public Payment Payment { get; private set; } = payment;

        public Money TotalPrice
        {
            get => new(OrderItems.Sum(x => x.UnitPrice.Amount * x.Quantity), 
                OrderItems.FirstOrDefault()?.UnitPrice.Currency ?? "USD");
            private set { }
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            _orderItems.Remove(orderItem);
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            Status = orderStatus;
        }
    }
}
