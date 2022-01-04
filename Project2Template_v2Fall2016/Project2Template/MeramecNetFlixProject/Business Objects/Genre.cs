using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    public class Genre
    {
        // remember I dont specify the fields then they will be stored in props
        public Genre()
        {

        }

        public int id { get; set; }
        public string name { get; set; }

    }
}
