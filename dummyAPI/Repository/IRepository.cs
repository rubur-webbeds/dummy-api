using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dummyAPI.Repository
{
    public interface IRepository<T>
    {
        int Add(T item);

    }
}
