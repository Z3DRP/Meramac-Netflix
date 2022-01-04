using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    public class Movie
    {

        
        public Movie()
        {

        }
        public int Movie_Number
        {
            get;
            set;
        }
        public int Movie_Year_Made
        {
            get;
            set;
        }
        public int Rental_Duration { get; set; }

        public int Genre_Id { get; set; }
        public string Movie_Rating 
        {
            get;
            set;
        }
        public string Movie_Title 
        {
            get;
            set;
        }
        public string Description 
        {
            get;
            set;
        }
        public string Image 
        {
            get;
            set;
        }
        public string Trailer 
        {
            get;
            set;
        }
        // method to valid date data passed into constructor
        private (bool,string) isValid(int mNumber, int year, int dur, int gId,string rating, string title, string des, string img, string trailr)
        {
            bool isValid = true;
            string errMsg = string.Empty;
            DateTime today = DateTime.Now;
            int todayYear = today.Year;

            if (mNumber > int.MaxValue && mNumber < int.MinValue)
            {
                isValid = false;
                errMsg = "Movie Number is out of Range";
            }
            else if (year < 1888 && year > todayYear)
            {
                isValid = false;
                errMsg = "The year the movie was made is out of range";
            }
            else if (dur < 0 && dur > int.MaxValue)
            {
                isValid = false;
                errMsg = "The movie duration is out of range";
            }
            else if (gId < 0 && gId > int.MaxValue)
            {
                isValid = false;
                errMsg = "Genre id is out of range";
            }
            else if (rating.Length >= 6)
            {
                isValid = false;
                errMsg = "Movie Rating is out of range";
            }
            else if (title.Length > 100)
            {
                isValid = false;
                errMsg = "Movie title length is to long";
            }
            else if (des.Length > 255)
            {
                isValid = false;
                errMsg = "Movie description length is to long";
            }
            else if (img.Length > 255)
            {
                isValid = false;
                errMsg = "Image file name length is to long";
            }
            else if (trailr.Length > 255)
            {
                isValid = false;
                errMsg = "Trialer file name length is to long";
            }

            return (isValid, errMsg);
        }
        public Movie MovieCopy()
        {
            return (Movie)this.MemberwiseClone();
        }
    }
}
