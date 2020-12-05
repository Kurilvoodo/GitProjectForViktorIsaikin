using System.Security.Cryptography;
using System.Text;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.Utils
{
    public class HashUtils
    {
        public static byte[] ComputeHash(string password)
        {
            byte[] hash;
            using (var sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return hash;
        }
    }
}