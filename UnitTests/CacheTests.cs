using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void CacheTest_FRAMEWORK()
        {
            TMemoryObject memoryObject = new TMemoryObject();
            memoryObject.Id = 1212;
            var init = memoryObject.Hashed;
            var x = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                 x = memoryObject.Hashed;
            }

            Assert.AreEqual(init, x);
            
        }
    }

    
}
public class TMemoryObject : InputCaching.net.framework.MemoryObject
{
    public int Id { get; set; }
}