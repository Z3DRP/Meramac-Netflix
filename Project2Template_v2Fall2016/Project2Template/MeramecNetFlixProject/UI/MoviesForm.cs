using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetFlixProject.Business_Objects;
using MeramecNetFlixProject.Data_Access_Layer;


namespace MeramecNetFlixProject.UI
{
    public partial class MoviesForm : Form
    {
        (bool,string) isValid;
        int txtBxIndex = -1;
        string appTitle = "Meramc Netflix";
        List<Genre> genreList;
        List<MovieRating> ratingList;

        public MoviesForm()
        {
            InitializeComponent();
        }

        private void MoviesForm_Load(object sender, EventArgs e)
        {
            genreList = new List<Genre>();
            ratingList = new List<MovieRating>();
            try
            {
                genreList = GenreDB.GetGenres();
                genreCmbx.DataSource = genreList;
                genreCmbx.DisplayMember = "name";
                genreCmbx.ValueMember = "id";

                ratingList = RatingDB.SpGetAllRatings();
                ratingCmbx.DataSource = ratingList;
                ratingCmbx.DisplayMember = "Rating";
                ratingCmbx.ValueMember = "Id";

                for (int indx = 1; indx <= 5; indx++)
                {
                    durationCbx.Items.Add(indx.ToString());
                }
                durationCbx.SelectedIndex = 0;

                yearMadeTxt.MaskInputRejected += new MaskInputRejectedEventHandler(yearMade_Rejected);
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }
        }
        private void yearMade_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (yearMadeTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid date, reached max number of digits allowed", yearMadeTxt, 3000);
            }
            else if (e.Position == yearMadeTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Date";
                toolTip1.Show("You cannot add digits to the end of the date", yearMadeTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid data";
                toolTip1.Show("Invaliid date format, only digits 0-9 allowed", yearMadeTxt, 3000);
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            isValid = ValidateForm(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    Movie newMovie = new Movie();
                    setNewMovie(newMovie,false);
                    bool goodInsert = MovieDB.AddMovie(newMovie);

                    if (goodInsert)
                        DisplaySuccessMsg("Movie", "Added");
                    else
                        DisplayErrorMsg("Movie has not been added to the database", appTitle);
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);

            ClearText();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Movie> movieList = new List<Movie>();
                movieList = MovieDB.SpGetAllMovies();
                moviesView.DataSource = movieList;
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            isValid = IsValidSearch(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    Movie movieReq = new Movie();
                    List<Movie> movieRequest = new List<Movie>();
                    if (string.IsNullOrEmpty(movieNumTxt.Text))
                    {
                        movieReq.Movie_Title = titleTxt.Text.Trim();
                        movieRequest = MovieDB.SpSearchMovies(movieReq.Movie_Title);
                    }
                    else if (string.IsNullOrEmpty(titleTxt.Text))
                    {
                        movieReq.Movie_Number = Convert.ToInt32(movieNumTxt.Text);
                        movieRequest = MovieDB.SpGetMoviesByNumber(movieReq.Movie_Number);
                    }
                    moviesView.DataSource = movieRequest;
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);

            ClearText();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            isValid = ValidateForm(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    Movie updatedMovie = new Movie();
                    setNewMovie(updatedMovie,true);
                    bool goodUpdate = MovieDB.UpdateMovie(updatedMovie);

                    if (goodUpdate)
                        DisplaySuccessMsg("Movie ", "Updated");
                    else
                        DisplayErrorMsg("Unable to updated movie in database", appTitle);
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);

            ClearText();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            isValid = ValidateDelete(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    Movie delMovie = new Movie();
                    delMovie.Movie_Number = Convert.ToInt32(movieNumTxt.Text.Trim());
                    bool goodDel = MovieDB.DeleteMovie(delMovie);

                    if (goodDel)
                        DisplaySuccessMsg("Movie", "Deleted");
                    else
                        DisplayErrorMsg("Unable to delete movie in database", appTitle);
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);

            ClearText();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            ClearText();
            moviesView.DataSource = null;
        }
        private void ClearText()
        {
            movieNumTxt.Text = string.Empty;
            yearMadeTxt.Text = string.Empty;
            genreCmbx.SelectedIndex = 0;
            ratingCmbx.SelectedIndex = 0;
            durationCbx.Text = string.Empty;
            titleTxt.Text = string.Empty;
            descriptionTxt.Text = string.Empty;
            imgFileTxt.Text = string.Empty;
            trailerLinkTxt.Text = string.Empty;
            movieNumTxt.Focus();
        }
        private (bool,string) ValidateForm(ref int txtBxIndx)
        {
            bool valid = true;
            string errMsg = string.Empty;
            int movieNum, yrMade;
            try
            {
                movieNum = Convert.ToInt32(movieNumTxt.Text);
                yrMade = Convert.ToInt32(yearMadeTxt.Text);

                if (string.IsNullOrEmpty(movieNumTxt.Text))
                {
                    valid = false;
                    txtBxIndex = 0;
                    errMsg = "You must enter a movie number";
                }
                if (int.TryParse(movieNumTxt.Text, out movieNum))
                {
                    if (movieNum >= int.MaxValue || movieNum < 0)
                    {
                        valid = false;
                        txtBxIndex = 0;
                        errMsg = "Movie number is out of bounds";
                    }
                }
               
                if (string.IsNullOrEmpty(yearMadeTxt.Text))
                {
                    valid = false;
                    txtBxIndex = 1;
                    errMsg = "You must enter year made";
                }
                if (int.TryParse(yearMadeTxt.Text,out yrMade))
                {
                    if (yrMade < 1900)
                    {
                        valid = false;
                        txtBxIndex = 1;
                        errMsg = "Invalid date movie creation date";
                    }
                }
                
                if (string.IsNullOrEmpty(titleTxt.Text))
                {
                    valid = false;
                    txtBxIndex = 5;
                    errMsg = "You must enter movie title";
                }
                else if (titleTxt.Text.Length >= 101)
                {
                    valid = false;
                    txtBxIndex = 5;
                    errMsg = "Movie title must be 100 characters or less";
                }
                else if (string.IsNullOrEmpty(descriptionTxt.Text))
                {
                    valid = false;
                    txtBxIndex = 6;
                    errMsg = "You must enter movie description";
                }
                else if (descriptionTxt.Text.Length >= 256)
                {
                    valid = false;
                    txtBxIndex = 6;
                    errMsg = "Description must be 256 characters or less";
                }
                else if (string.IsNullOrEmpty(imgFileTxt.Text))
                {
                    valid = false;
                    txtBxIndex = 7;
                    errMsg = "You must enter filename for movie image";
                }
                else if (imgFileTxt.Text.Length >= 256)
                {
                    valid = false;
                    txtBxIndex = 7;
                    errMsg = "Image file location must be 255 characters or less";
                }
                else if (string.IsNullOrEmpty(trailerLinkTxt.Text))
                {
                    valid = false;
                    txtBxIndex = 8;
                    errMsg = "You must enter link to trailer";
                }
                else if (trailerLinkTxt.Text.Length >= 256)
                {
                    valid = false;
                    txtBxIndex = 8;
                    errMsg = "Trailer link must be 256 characters or less";
                }
            }
            catch(Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }

            return (valid, errMsg);
        }
        private (bool,string) IsValidSearch(ref int txtBxIndx)
        {
            bool valid = true;
            string errMsg = string.Empty;
            if (string.IsNullOrEmpty(titleTxt.Text) && string.IsNullOrEmpty(movieNumTxt.Text))
            {
                valid = false;
                txtBxIndex = 0;
                errMsg = "You must enter a movie number or title to search";
            }
            return (valid, errMsg);
        }
        private (bool,string) ValidateDelete(ref int txtBxIndx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(movieNumTxt.Text))
            {
                valid = false;
                txtBxIndx = 0;
                errMsg = "You must enter a movie number to delete";
            }
            return (valid, errMsg);
        }
        private void setNewMovie(Movie newMovie, bool isUpdate)
        {
            try
            {
                MovieRating rating = new MovieRating();
                rating.Id = Convert.ToInt32(ratingCmbx.SelectedValue);
                rating = RatingDB.SpGetRating(rating.Id);

                if (!isUpdate)
                    newMovie.Movie_Number = MovieDB.GetNextMovieNumber();
                else
                    newMovie.Movie_Number = Convert.ToInt32(movieNumTxt.Text);
                newMovie.Movie_Year_Made = Convert.ToInt32(yearMadeTxt.Text.Trim());
                newMovie.Genre_Id = Convert.ToInt32(genreCmbx.SelectedValue);
                newMovie.Movie_Rating = rating.Rating;
                newMovie.Rental_Duration = Convert.ToInt32(durationCbx.SelectedItem);
                newMovie.Movie_Title = titleTxt.Text.Trim();
                newMovie.Description = descriptionTxt.Text.Trim();
                newMovie.Image = imgFileTxt.Text.Trim();
                newMovie.Trailer = trailerLinkTxt.Text.Trim();
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }
        }
        private void DisplaySuccessMsg(string objName, string dbAction)
        {
            MessageBox.Show($"The {objName} has been {dbAction} the database.", "MeramacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // method to display messageboxes for errors
        private void DisplayErrorMsg(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void SetErrorProvider(int txtBxIndex, string errMsg)
        {
            switch (txtBxIndex)
            {
                case 0:
                    errPv.SetError(movieNumTxt, errMsg);
                    break;
                case 1:
                    errPv.SetError(yearMadeTxt, errMsg);
                    break;
                case 2:
                    errPv.SetError(genreCmbx, errMsg);
                    break;
                case 3:
                    errPv.SetError(ratingCmbx, errMsg);
                    break;
                case 4:
                    errPv.SetError(durationCbx, errMsg);
                    break;
                case 5:
                    errPv.SetError(titleTxt, errMsg);
                    break;
                case 6:
                    errPv.SetError(descriptionTxt, errMsg);
                    break;
                case 7:
                    errPv.SetError(imgFileTxt, errMsg);
                    break;
                case 8:
                    errPv.SetError(trailerLinkTxt, errMsg);
                    break;
            }
        }
        private void ResetErrorProvider()
        {
            errPv.Clear();
        }
    }
}
