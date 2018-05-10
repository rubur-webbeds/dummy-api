using System;

namespace dummyAPI.Exceptions
{
    public class BlockedDummyException : Exception
    {
        public BlockedDummyException()
        {

        }

        public BlockedDummyException(String msg) : base(msg)
        {

        }

        public BlockedDummyException(String msg, Exception ex) : base(msg, ex)
        {

        }
    }
}
