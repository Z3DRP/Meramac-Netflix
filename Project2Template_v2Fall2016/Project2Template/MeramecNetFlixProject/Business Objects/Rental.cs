using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    public class Rental
    {
        public Rental()
        { }

        public int Movie_Number
        {
            get;
            set;
        }
        public int Member_Number
        {
            get;
            set;
        }

        public DateTime Media_Purchase_Date
        {
            get;
            set;
        }
        public DateTime Media_Streaming_Start_Date
        {
            get;
            set;
        }
        public DateTime Media_Return_Date
        {
            get;
            set;
        }
    }
}
