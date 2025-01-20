using Services.Commons.Exception;

namespace Ordering.Domain.Exception
{
    public class OrderDomainException(string message) : DomainException(message)
    {
    }
}
