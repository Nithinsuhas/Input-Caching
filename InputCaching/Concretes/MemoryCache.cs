using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCaching.Concretes
{
    public class MemoryCache : net.framework.MemoryCache
    {
        public MemoryCache(int cacheSize) : base(cacheSize)
        {
        }
    }
}
