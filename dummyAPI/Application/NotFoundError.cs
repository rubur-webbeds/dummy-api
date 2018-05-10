using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dummyAPI.Application
{
    public class NotFoundError : OperationResultError
    {
        public NotFoundError(string message) : base(message)
        {
        }
    }
}
