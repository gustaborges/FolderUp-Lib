using System;
using System.Runtime.Serialization;

namespace FolderizerLib.Configuration
{
    [Serializable]
    public class SearchDepthExceedsAcceptableLimitException : Exception
    {
        public SearchDepthExceedsAcceptableLimitException()
        {
        }

        public SearchDepthExceedsAcceptableLimitException(string message) : base(message)
        {
        }

        public SearchDepthExceedsAcceptableLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SearchDepthExceedsAcceptableLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}