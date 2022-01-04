using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeramecNetFlixProject.Business_Objects;
using MeramecNetFlixProject.Data_Access_Layer;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MeramecNetFlixProject.UI
{
    public static class RegEx 
    {

        public static bool IsAdmin(Member user) 
        {
            // uses reg expression to validate that the member passed in is a admin
            bool isAdmin;
            string pattern = @"[admin]";
            
            try
            {
                if (Regex.IsMatch(user.Username, pattern, RegexOptions.IgnoreCase))
                    isAdmin = true;
                else
                    isAdmin = false;
            }
            catch(Exception ex)
            { throw new ArgumentException(ex.Message); }
            
            return isAdmin;
        }
        public static bool IsAdmin(Login user)
        {
            // uses reg expression to validate that the member passed in is a admin
            bool isAdmin;
            string pattern = @"[admin]";

            try
            {
                if (Regex.IsMatch(user.UserName, pattern, RegexOptions.IgnoreCase))
                    isAdmin = true;
                else
                    isAdmin = false;
            }
            catch (Exception ex)
            { throw new ArgumentException(ex.Message); }

            return isAdmin;
        }
        public static bool IsAdmin(string user)
        {
            bool isAdmin;
            string pattern = @"(admin)";

            try
            {
                if (Regex.IsMatch(user, pattern, RegexOptions.IgnoreCase))
                    isAdmin = true;
                else
                    isAdmin = false;
            }
            catch (Exception ex)
            { throw new ArgumentException(ex.Message); }

            return isAdmin;
        }
        public static bool ValidPassWord(string pwd)
        {
            // must begin with a letter or number contain 8 - 64 characters 
            // contain upper, lower case and numbers
            // contain symbols ! @ # $ % ^ & *
            bool goodPassword;
            string pattern = @"(\w*?)";
            try
            {
                if (Regex.IsMatch(pwd, pattern, RegexOptions.IgnoreCase))
                    goodPassword = true;
                else
                    goodPassword = false;
            }
            catch(Exception ex)
            { throw new ArgumentException(ex.Message); }

            return goodPassword;

        }
        public static (bool, string) CheckPassword(string pwd)
        {
            bool goodPwd;
            string eMsg;
            string Letters_Numbers = @"[A-Z*a-z*0-9*];";
            string Number = @"[0-9*]";
            string Letters = @"[A-Z*a-z*]";
            string goodPat = @"(\w*\d*!*@*#*$*%*\^*&*\**)";
            if (Regex.IsMatch(pwd, goodPat, RegexOptions.IgnoreCase))
            {
                goodPwd = true;
                eMsg = string.Empty;
            }
            else
            {
                goodPwd = false;
                eMsg = "Invalid password";
            }
            return (goodPwd, eMsg);
        }
        public static bool ValidEmail(string email)
        {
            bool isEmail;
            string pattern = @"\w*?@\w*?.com$";

            try
            {
                if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                    isEmail = true;
                else
                    isEmail = false;
            }
            catch(Exception ex)
            { throw new ArgumentException(ex.Message); }

            return isEmail;
        }
        public static bool ValidPhoneNumber(string number)
        {
            bool isPhoneNumber;
            string pattern = @"\d{3}-\d{3}-\d{4}";

            try
            {
                if (Regex.IsMatch(number, pattern))
                    isPhoneNumber = true;
                else
                    isPhoneNumber = false;
            }
            catch(Exception ex)
            { throw new ArgumentException(ex.Message); }

            return isPhoneNumber;
        }
    }
}
