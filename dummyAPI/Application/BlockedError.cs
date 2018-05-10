using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dummyAPI.Application
{
    public class BlockedError : OperationResultError
    {
        public BlockedError(string message) : base(message)
        {
        }
    }
}
