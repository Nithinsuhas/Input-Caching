using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCaching.net.framework
{
    public interface IMemoryCache
    {
        /// <summary>
        /// Checks wheather the Object already added into the Memory Cache
        /// </summary>
        /// <param name="Object"></param>
        /// <returns>True if Exists False if not</returns>
        bool Exist(IMemoryObject Object);
        /// <summary>
        /// Adds a new Object to the collection after checking the existance status.
        /// </summary>
        /// <param name="Object"></param>
        /// <returns>True if added, false if already exists</returns>
        bool Push(IMemoryObject Object);
        /// <summary>
        /// Removes the First Object from the collection
        /// </summary>
        void Pop();
        /// <summary>
        /// Resets the Collection.
        /// </summary>
        void Reset();
    }
}
