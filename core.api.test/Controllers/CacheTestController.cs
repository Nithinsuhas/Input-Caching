using InputCaching.net.framework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core.api.test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheTestController : ControllerBase
    {

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Data model)
        {
            var Collection = MemoryCache.Collection;
            if (Collection.Push(model))
            {
                return Ok("Added");
            }
            else
            {
                return BadRequest("Already Added");
            }
        }

        [HttpPost]
        [Route("List")]

        public IActionResult Post1([FromBody] MemoryList<Data> model)
        {
            var Collection = MemoryCache.Collection;
            if (Collection.Push(model))
            {
                return Ok("Added");
            }
            else
            {
                return BadRequest("Already Added");
            }
        }

        public class Data : MemoryObject
        {
            public int Id { get; set; }
            public string Code { get; set; }
        }
    }
}
