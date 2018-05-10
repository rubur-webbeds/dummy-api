using dummyAPI.Model;
using Microsoft.AspNetCore.Mvc;
using dummyAPI.Repository;
using dummyAPI.Application;

namespace dummyAPI.Controllers
{
    [Route("api/dummy")]
    public class DummyController : Controller
    {

        private DummyRepository _repo = new DummyRepository();

        // GET api/dummy
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll()); 
        }

        // GET api/dummy/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repo.Get(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/dummy
        [HttpPost]
        public IActionResult Post([FromBody]DummyModel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _repo.Add(item);           
            if(result is AlreadyExistsError err)
            {                                
                return Forbid(err.Message);
            }
            return StatusCode(201);
        }

        // PUT api/dummy/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DummyModel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _repo.Update(id, item);

            if (result is OperationResultOk)
            {
                return Ok();
            }
            else if (result is BlockedError err)
            {
                return Forbid(err.Message);
            }
            else if (result is NotFoundError error)
            {
                return NotFound(error.Message);
            }

            return StatusCode(500);
        }

        // DELETE api/dummy/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.Delete(id);
            
            if(result is OperationResultOk)
            {
                return NoContent();
            }
            else if(result is BlockedError err)
            {
                return Forbid(err.Message);
            }
            else if(result is NotFoundError error)
            {
                return NotFound(error.Message);
            }

            return StatusCode(500);
        }
    }
}
