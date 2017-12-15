using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    /// <summary>
    /// MD5哈希工具类
    /// </summary>
    public static class Md5Helper
    {
        /// <summary>
        /// MD5哈系的方法
        /// </summary>
        /// <param name="str">要哈希的字符串</param>
        /// <returns></returns>
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

        /// <summary>
        /// 加盐哈希，预置盐
        /// </summary>
        /// <param name="pass">要加盐哈希的文本</param>
        /// <returns>已加盐哈希的文本结果</returns>
        public static string Md5WithSalt(string pass)
        {
            return Md5Lower(Md5Lower(pass) + "chenjixiangliwenchiwuhaowanjiawendengzhengchengHarborzengdesalt");
        }
    }
}