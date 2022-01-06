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

        public IActionResult Post1([FromBody] mlist<Data> model)
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


        public class mlist<T> : List<T>, IMemoryObject
        {
            private bool _hashed = false;
            private string _hash;
            public string Hash()
            {
                if (!_hashed)
                {
                    using (var algo = new MD5CryptoServiceProvider())
                    {
                        var text = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.None);
                        algo.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
                        var result = algo.Hash;

                        // Return as hexadecimal string
                        this._hash = string.Join(
                            string.Empty,
                            result.Select(x => x.ToString("x2")));
                        this._hashed = true;
                    }

                }
                return _hash;
            }
        }
        public class Data : MemoryObject
        {
            public int Id { get; set; }
            public string Code { get; set; }
        }
    }
}
