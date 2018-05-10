using dummyAPI.Application;
using dummyAPI.Exceptions;
using dummyAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace dummyAPI.Repository
{
    public class DummyRepository : IRepository<DummyModel>
    {

        private string _file_repo = "dummy_repository.txt";
        private static List<DummyModel> _dummySet = new List<DummyModel>();

        public OperationResult Add(DummyModel item)
        {
            string dummyString = JsonConvert.SerializeObject(item);
            //Check if item already exists, first on the static list, if not in the repository
            if(_dummySet.BinarySearch(item) >= 0)
            {
                return new AlreadyExistsError("Dummy already exists");

            }
            else
            {
                if (GetAll().BinarySearch(item) >= 0)
                {
                    return new AlreadyExistsError("Dummy already exists");
                }
            }

            using (var fileWriter = File.AppendText(_file_repo))
            {
                fileWriter.WriteLine(dummyString);
            }

            return new OperationResultOk();
        }

        public List<DummyModel> GetAll()
        {
            if (!File.Exists(_file_repo)) return null;

            using (var fileReader = File.OpenText(_file_repo))
            {
                _dummySet.Clear();

                string line = fileReader.ReadLine();
                while (line != null)
                {
                    var dummyObj = JsonConvert.DeserializeObject<DummyModel>(line);
                    _dummySet.Add(dummyObj);
                    line = fileReader.ReadLine();
                }
            }

            return _dummySet;
        }

        public DummyModel Get(int id)
        {
            var result = _dummySet.Find(x => x.id.Equals(id));
            if (result == null)
            {
                using (var fileReader = File.OpenText(_file_repo))
                {
                    string line = fileReader.ReadLine();

                    while (line != null)
                    {
                        var dummyObj = JsonConvert.DeserializeObject<DummyModel>(line);
                        _dummySet.Add(dummyObj);
                        line = fileReader.ReadLine();
                    }
                }
            }
            return result;
        }

        public OperationResult Delete(int id)
        {
            List<DummyModel> file = GetAll();
            var item = file.Find(x => x.id == id);
            if(item == null)
            {
                return new NotFoundError("Dummy not found");
            }

            if (item.Blocked)
            {
                return new BlockedError("The dummy requested is blocked.");
            }

            file.Remove(item);

            File.Delete(_file_repo);

            foreach (var d in file)
            {
                Add(d);
            }

            return new OperationResultOk();
        }

        public OperationResult Update(int id, DummyModel item)
        {
            var result = Delete(id);
            Add(item);

            return result;
        }

    }
}
