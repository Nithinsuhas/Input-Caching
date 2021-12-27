using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace InputCaching
{

    public abstract class MemoryObject: IMemoryObject
    {
        //public DateTime AddedOn;
        public int Id;

        public virtual string UniquCombo()
        {

            return JsonConvert.SerializeObject(this, Formatting.None);
        }
        public string Hash()
        {
            var result = default(string);

            using (var algo = new MD5CryptoServiceProvider())
            {
                result = GenerateHashString(algo, UniquCombo());
            }

            return result;
        }
        private static string GenerateHashString(HashAlgorithm algo, string text)
        {
            // Compute hash from text parameter
            algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Get has value in array of bytes
            var result = algo.Hash;

            // Return as hexadecimal string
            return string.Join(
                string.Empty,
                result.Select(x => x.ToString("x2")));
        }
    }
}
