using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCaching
{
    public class MemoryCache:IMemoryCache
    {
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
                        _instance = new MemoryCache();

                    }
                    return _instance;
                }
            }
        }

        private const int size = 20;
        public List<string> maps = new List<string>();
        public void Reset()
        {
            _instance.maps.Clear();

        }

        public bool Exist(MemoryObject hash)
        {
            var matched = false;
            for (int i = 0; i < this.maps.Count; i++)
            {
                if (_instance.maps[i] == null)
                {
                    return false;
                }
                if (_instance.maps[i] == hash.Hash())
                {
                    matched = true;
                    return true;
                }
            }
            return matched;
        }

        public bool Push(MemoryObject hash)
        {


            if (!Exist(hash))
            {
                //hash.AddedOn = DateTime.Now;
                // hash.Id = id++;
                Pop();
                _instance.maps.Add(hash.Hash());
                return true;
            }
            else
            {
                return false;
            }




        }
        public void Pop()
        {
            if (_instance.maps.Count == size)
            {
                _instance.maps = _instance.maps.Skip(1).ToList();
            }
        }
    }

}
