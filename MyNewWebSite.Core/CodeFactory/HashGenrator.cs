using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.Core.CodeFactory
{
    public class HashGenrator
    {
        public static string Md5HashGenrate(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputbytes = Encoding.ASCII.GetBytes(text);
                byte[] hashByte = md5.ComputeHash(inputbytes);

                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < hashByte.Length; i++)
                {
                    sb.Append(hashByte[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public static string SHA1HashGenrate(string text)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputbytes = Encoding.ASCII.GetBytes(text);
                byte[] hashByte = sha1.ComputeHash(inputbytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashByte.Length; i++)
                {
                    sb.Append(hashByte[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string SHA256HashGenrate(string text)
        {
            using (SHA256 sha1 = SHA256.Create())
            {
                byte[] inputbytes = Encoding.ASCII.GetBytes(text);
                byte[] hashByte = sha1.ComputeHash(inputbytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashByte.Length; i++)
                {
                    sb.Append(hashByte[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
