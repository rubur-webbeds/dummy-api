using dummyAPI.Application;
using dummyAPI.Model;
using System.Collections.Generic;

namespace dummyAPI.Repository
{
    public interface IRepository<T>
    {
        OperationResult Add(T item);
        List<DummyModel> GetAll();
        DummyModel Get(int id);
        OperationResult Delete(int id);
        OperationResult Update(int id, T item);

    }
}
