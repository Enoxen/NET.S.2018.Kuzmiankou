using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BSTree.BSTException
{
    class ComparisonException : Exception
    {
        public ComparisonException()
        {
        }

        public ComparisonException(string message) : base(message)
        {
        }

        public ComparisonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ComparisonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
