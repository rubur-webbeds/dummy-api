using dummyAPI.Model;
using Microsoft.AspNetCore.Mvc;
using dummyAPI.Repository;

namespace dummyAPI.Controllers
{
    [Route("api/dummy")]
    public class DummyController : Controller
    {

        private DummyRepository _repo = new DummyRepository();

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var obj = new DummyModel();
            obj.id = 254;
            obj.Name = "dummy";
            
            return Ok(obj);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]DummyModel item)
        {
            _repo.Add(item);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
