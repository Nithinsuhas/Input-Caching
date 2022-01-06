# Input-Caching

For handling input caching mechanism
This Class library is developed using dot net core 6.

Main purpose of this project is

- To add caching mechanism for .net web api projects
- To avoid duplicated post requests.

# Usage

```c#
    /* In Starup.cs */
    services.AddSingleton<IMemoryCache>(new MemoryCache(CollectoinSize));

    /* In Controller */
    /* For Objects */

    [Route("api/[controller]")]
    [ApiController]
    public class CacheTestController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] Data model)
        {
            var Collection = MemoryCache.Collection;
            if (Collection.Push(model))
            {
                /* 
                Memory collection does not contains the object proceed to operation.
                    keep in mind that the collecton only holds upto CollectoinSize specified by you.
                */
                return Ok("Added");
            }
            else
            {

                 /* 
                A post request with same input has already recived, 
                it is still containing inside the memory collection 
                */
                return BadRequest("Already Added");
            }
        }

        [HttpPost]
        [Route("List")]
        public IActionResult PostList([FromBody] MemoryList<Data> model)
        {
            /*
            MemoryList is an extenstion of list, You will have all operations of list.
            */
            var Collection = MemoryCache.Collection;
            if (Collection.Push(model))
            {
                /* 
                Memory collection does not contains the object proceed to operation.
                    keep in mind that the collecton only holds upto CollectoinSize specified by you.
                */
                return Ok("Added");
            }
            else
            {
                /* 
                A post request with same input has already recived, 
                it is still containing inside the memory collection 
                */
                return BadRequest("Already Added");
            }
        }

        
    }




    public class Data : MemoryObject
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }

```
