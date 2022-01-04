using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    public class WatchList
    {
        public int Member_Id
        {
            get;
            set;
        }
        public int Movie_Number
        {
            get;
            set;
        }
        public int Num_Of_Rentals
        {
            get;
            set;
        }
        public DateTime Date_Added
        {
            get;
            set;
        }
        public WatchList CopyList()
        {
            return (WatchList)this.MemberwiseClone();
        }
    }
}
