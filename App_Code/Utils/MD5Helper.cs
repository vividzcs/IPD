using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class Md5Helper
    {
        public static string Md5Lower(string str)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                foreach (var t in hashBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string Md5WithSalt(string pass)
        {
            return Md5Lower(Md5Lower(pass) + "chenjixiangliwenchiwuhaowanjiawendengzhengchengHarborzengdesalt");
        }
    }
}