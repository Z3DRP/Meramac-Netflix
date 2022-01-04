using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeramecNetFlixProject.Data_Access_Layer;

namespace MeramecNetFlixProject.Business_Objects
{
    public class Login
    {   
        public Login()
        { }
        
        public string UserName 
        {
            get;
            set;
        }
        public string Password 
        {
            get;
            set;
        }
        public bool CompareUserName(Login user1, Login user2)
        {
            bool valid;
            if (user1.Equals(user2))
                valid = true;
            else
                valid = false;

            return valid;
        }
    }
}
