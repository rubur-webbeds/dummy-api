using dummyAPI.Model;
using Newtonsoft.Json;
using System.IO;

namespace dummyAPI.Repository
{
    public class DummyRepository : IRepository<DummyModel>
    {
        public int Add(DummyModel item)
        {
            string dummyString = JsonConvert.SerializeObject(item);

            var filePath = Path.GetTempFileName();

            using (var fileWriter = File.CreateText(filePath))
            {
                fileWriter.WriteLine(dummyString);
            }

            
        }
    }
}
