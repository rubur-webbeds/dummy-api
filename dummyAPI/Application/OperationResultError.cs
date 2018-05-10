using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dummyAPI.Application
{
    public class OperationResultError : OperationResult
    {
        public string Message { get; set; }
        public OperationResultError(string message)
        {
            Message = message;
        }
    }
}
