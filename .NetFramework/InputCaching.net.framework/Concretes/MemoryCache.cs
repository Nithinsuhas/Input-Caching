using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCaching.net.framework
{
    public class MemoryCache : IMemoryCache
    {
        /// <summary>
        /// Initialize the collection with the size
        /// </summary>
        /// <param name="cacheSize"></param>
        public MemoryCache(int cacheSize)
        {
            MemoryCache.MaxSize = cacheSize;
        }

        private static int MaxSize=20;
        private static readonly object _lock = new object();
        private static MemoryCache _instance = null;
        public static MemoryCache Collection
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MemoryCache(MaxSize);

                    }
                    return _instance;
                }
            }
        }


        public List<string> container = new List<string>();
        public void Reset()
        {
            _instance.container.Clear();

        }

        public bool Exist(MemoryObject hash)
        {
            var matched = false;
            for (int i = 0; i < this.container.Count; i++)
            {
                if (_instance.container[i] == null)
                {
                    return false;
                }
                if (_instance.container[i] == hash.Hash())
                {
                    matched = true;
                    return true;
                }
            }
            return matched;
        }

        public bool Push(MemoryObject Object)
        {


            if (!Exist(Object))
            {
                //hash.AddedOn = DateTime.Now;
                // hash.Id = id++;
                Pop();
                _instance.container.Add(Object.Hash());
                return true;
            }
            else
            {
                return false;
            }




        }
        public void Pop()
        {
            if (_instance.container.Count == MaxSize)
            {
                _instance.container = _instance.container.Skip(1).ToList();
            }
        }
    }

}
