using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipController : ControllerBase
    {
        // GET: api/<FriendshipController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FriendshipController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FriendshipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FriendshipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FriendshipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
