using System.Runtime.Serialization;

namespace Services.Commons.Exception
{
    [Serializable]
    public class DomainException : System.Exception
    {
        public DomainException() : base() { }
        public DomainException(string message) : base(message) { }
        public DomainException(string message, System.Exception inner) : base(message, inner) { }
        
    }
}
