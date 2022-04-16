namespace WebApi
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class Hash
    {
        public static string Key { get; set; } = "IncrediblyHardToBypassKey";

        public static string HMACHASH(string str, string key)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                var bhash = hmac.ComputeHash(bstr);
                return BitConverter.ToString(bhash).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
