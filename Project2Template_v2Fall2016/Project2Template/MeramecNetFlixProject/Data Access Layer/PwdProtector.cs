using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using static System.Convert;
using MeramecNetFlixProject.Business_Objects;

namespace MeramecNetFlixProject.Data_Access_Layer
{
    class PwdProtector
    {

        // salt size must be atleast 8 bytes this is 16 bytes
        private static readonly byte[] salt =
            Encoding.Unicode.GetBytes("7BANANAS");
        // interations must be atleast 1000 this is 2000
        private static readonly int iterations = 2000;

        public static string Encrypt(string pwd)
        {
            // using MD5 to encrypt string
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                // hash data
                byte[] data = md5.ComputeHash(utf8.GetBytes(pwd));
                return Convert.ToBase64String(data);
            }

        }
        public static bool CompareEncryption(Login encryptedPwd, Login enteredPwd)
        {
            bool valid;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                // hash data
                byte[] enteredEncrypted = md5.ComputeHash(utf8.GetBytes(enteredPwd.Password));
                enteredPwd.Password = Convert.ToBase64String(enteredEncrypted);
            }

            if (encryptedPwd.Password.Equals(enteredPwd.Password))
                valid = true;
            else
                valid = false;

            return valid;
        }
        public static bool CompareEncryption(string encryptedPwd, string enteredPwd)
        {
            bool valid;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                // hash data
                byte[] enteredEncrypted = md5.ComputeHash(utf8.GetBytes(enteredPwd));
                enteredPwd = Convert.ToBase64String(enteredEncrypted);
            }

            if (encryptedPwd.Equals(enteredPwd))
                valid = true;
            else
                valid = false;

            return valid;
        }
    }
}
