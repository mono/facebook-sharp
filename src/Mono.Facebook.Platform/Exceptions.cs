using System;

namespace Mono.Facebook.Platform
{
    public class UnsupportedResponseTypeException : Exception
    {
        public UnsupportedResponseTypeException() : base()
        {
        }

        public UnsupportedResponseTypeException(string mesg) : base(mesg)
        {
        }
    }

    public class InvalidAPIResponseException : Exception
    {
        public InvalidAPIResponseException() : base()
        {
        }

        public InvalidAPIResponseException(string mesg) : base(mesg)
        {
        }
    }

    public class EmptyDataSetException : Exception
    {
        public EmptyDataSetException() : base()
        {
        }

        public EmptyDataSetException(string mesg) : base(mesg)
        {
        }
    }
}

