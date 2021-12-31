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
    /* model must implement IMemoryObject Or Inherit from MemoryObject */
    var Collection = MemoryCache.Collection;
    if (Collection.Push(model))
    {
        //Collection does not contains the input, Proceed to operation
        //Return result
    }
    else
    {
        //Return appropriate Response
    }
```
