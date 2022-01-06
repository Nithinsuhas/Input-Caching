using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Linq;

namespace InputCaching.net.framework
{

    public abstract class MemoryObject : IMemoryObject
    {
        //public DateTime AddedOn;
        // public int Id;


        //private string _hash;

        //public string Hashed { get; private set; }
        [JsonIgnore]
        private bool _hashed = false;
        [JsonIgnore]
        private string __hash;
        //public string Hashed
        //{
        //    get { return Hash(); }
        //    private set { __hash = value; }
        //}
        [JsonIgnore]
        private string _hash;
        [JsonIgnore]
        public string Hashed
        {
            get
            {
                if (_hashed)
                    return _hash;
                else
                    return Hash();
            }
            private set { _hash = value; }
        }




        public virtual string UniquCombo()
        {

            return JsonConvert.SerializeObject(this, Formatting.None);
        }
        public string Hash()
        {
            if (!_hashed)
            {
                using (var algo = new MD5CryptoServiceProvider())
                {
                    _hash = GenerateHashString(algo, UniquCombo());
                    _hashed = true;
                }

            }
            return _hash;
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


    public class MemoryList<T> : System.Collections.Generic.List<T>, IMemoryObject
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

}
