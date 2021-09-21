using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Registration.EncryptDecryptProcessor
{
    public class Password
    {
        public static string key = "CoolPassword";
        public static string PasswordEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var result1 = (Convert.ToBase64String(passwordBytes));
            var re= (result1.Remove( result1.Length-1 ));
            return result1;
            
         }
        public static string PasswordDecrypt(string Base64EncodedData)
        { 
            if (string.IsNullOrEmpty(Base64EncodedData)) return "";
            var Base64EncodedByte = Convert.FromBase64String(Base64EncodedData);
            var result = Encoding.UTF8.GetString(Base64EncodedByte);
           // result = result.Substring(1, result.Length - key.Length);
            return result;
        }
    }
}
