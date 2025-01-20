using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commons.Domain.ValueObjects
{
    public sealed class CustomerId(Guid value) : ValueObject
    {
        public Guid Value { get; } = value;

        public static CustomerId Create(Guid value)
        {
            return new CustomerId(value);
        }

        public static CustomerId CreateNew()
        {
            return new CustomerId(Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
