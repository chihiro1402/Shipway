using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;

namespace ShipwayBusiness.Helper
{
    public class Utils
    {
        public static string MD5(string password)
        {
            if (Utils.IsMD5(password))
            {
                return password;
            }
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5.ComputeHash(encoder.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public static bool IsMD5(string str)
        {
            var regex = new Regex(@"[0-9a-fA-F]{32}");
            if (regex.IsMatch(str))
            {
                return true;
            }
            return false;
        }
    }
}