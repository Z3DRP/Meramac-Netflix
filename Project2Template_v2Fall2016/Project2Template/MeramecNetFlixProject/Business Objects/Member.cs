using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeramecNetFlixProject.Data_Access_Layer;

namespace MeramecNetFlixProject.Business_Objects
{
    public class Member
    {
        // add constructor and method to set saltedPasswd and method to set member info in two groups name info then contact info
        public Member()
        {

        }

        public string Member_Status 
        {
            get;
            set;
        }
        public int Member_Number
        {
            get;
            set;
        }
        public DateTime Join_Date
        {
            get;
            set;
        }
        public string First_Name
        {
            get;
            set;
        }
        public string Last_Name
        {
            get;
            set;
        }
        public string Zipcode 
        {
            get;
            set;
        }
        public string Cell_Phone
        {
            get;
            set;
        }
        public string Username 
        {
            get;
            set;
        }
        public string Password 
        {
            get;
            set;
        }
        public string Email 
        {
            get;
            set;
        }
        public Member MemberCopy()
        {
            return (Member)this.MemberwiseClone();
        }

    }
}
