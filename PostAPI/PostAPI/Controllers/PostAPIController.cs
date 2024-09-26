using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAPIController : ControllerBase
    {
        static List<PostData> PostData = new List<PostData>();
        // GET: api/<PostAPIController>
        [HttpGet]
        public IEnumerable<PostData> Get()
        {
            return PostData;
        }

        // GET api/<PostAPIController>/5
        [HttpGet("{id}")]
        public PostData Get(int id)
        {
            return PostData.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<PostAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] PostData value)
        {
            if (PostData == null)
            {
                return BadRequest(new { message = "Failed: Invalid data received." });
            }

            try
            {
                return Ok(new { message = "API posted successfully", PostData });
            }
            catch (Exception ex)
            {
                // Return failure message in case of an exception
                return StatusCode(500, new { message = "Failed: An error occurred.", error = ex.Message });
            }
            //PostData.Add(value);
        }

        // PUT api/<PostAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
