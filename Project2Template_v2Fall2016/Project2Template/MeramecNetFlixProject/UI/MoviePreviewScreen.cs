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
    public partial class MoviePreviewScreen : Form
    {
        string appTitle = "Meramac Netfilx";
        string _url;
        string fileLoc = "C:/C#2/Project2/DataFiles/Images/Movies/";
        Member aMember;
        Movie SelectedMovie;
        bool InWatchDB;
        bool OnWatchList;
        // need to add a extra table to database for the watchlist
        public MoviePreviewScreen()
        {
            InitializeComponent();
        }
        public MoviePreviewScreen(Member activeMember, Movie selectedMovie, bool onWatchList)
        {
            InitializeComponent();
            aMember = activeMember.MemberCopy();
            SelectedMovie = selectedMovie.MovieCopy();
            OnWatchList = onWatchList;

            // member previously added movie to watchlist and therefore is already in database
            if (OnWatchList)
                InWatchDB = true;
        }
        // code for button color change
        private void ButtonHover(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image img = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/rentalhver.png");
            lbl.Location = new Point(x, y);
            lbl.Image = img;
            lbl.Size = new Size(290, 42);
            lbl.ForeColor = System.Drawing.Color.Khaki;
        }
        private void ButtonLeave(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image img = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/rentalblb.png");
            lbl.Location = new Point(x, y);
            lbl.Image = img;
            lbl.Size = new Size(290, 42);
            lbl.ForeColor = System.Drawing.Color.White;
        }
        private void orderSelectBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonHover(orderSelectBtn, -48, 272);
        }

        private void orderSelectBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(orderSelectBtn, -48, 272);
        }

        private void previewBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonHover(previewBtn, -48, 314);
        }

        private void previewBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(previewBtn, -48, 314);
        }

        private void backBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonHover(backBtn, -48, 356);
        }

        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(backBtn, -48, 356);
        }

        private void MoviePreviewScreen_Load(object sender, EventArgs e)
        {
            // when form load must take the movie that was passed to form constructor
            // then must query movies table to get the data for the movie to display on the form
            string genreName = GenreDB.SpGetGenreName(SelectedMovie.Genre_Id);
            titleLbl.Text = SelectedMovie.Movie_Title;
            summaryTxt.Text = $"{SelectedMovie.Description}";
            infoLbl.Text = $"{SelectedMovie.Movie_Rating}/{genreName}/{SelectedMovie.Rental_Duration} days";         
            movieImgPbx.Image = Image.FromFile(fileLoc + SelectedMovie.Image);
            
            if (OnWatchList)
            {
                goldStar.Visible = true;
                goldStar.Focus();
            }
                
            else
            {
                greyStar.Visible = true;
                greyStar.Focus();
            }
        }
        private void orderSelectBtn_Click(object sender, EventArgs e)
        {
            bool goodRental;
            DateTime todaysDate = System.DateTime.Now;
            Rental ordered = new Rental();
            ordered.Movie_Number = SelectedMovie.Movie_Number;
            ordered.Member_Number = aMember.Member_Number;
            ordered.Media_Purchase_Date = todaysDate;
            ordered.Media_Streaming_Start_Date = todaysDate;
            ordered.Media_Return_Date = todaysDate.AddDays(SelectedMovie.Rental_Duration);
            goodRental = RentalDB.AddRental(ordered);

            if (goodRental)
                DisplaySuccess("Your Order has been proccessed", appTitle);
            else
                DisplayError("A problem occured while processing your order, please try again later", appTitle);
       
        }
        private void previewBtn_Click(object sender, EventArgs e)
        {
            trailerBrowser.Visible = true;
            try
            {
                _url = SelectedMovie.Trailer;
                trailerBrowser.Navigate(_url);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            trailerBrowser.Stop();
            trailerBrowser.Dispose();
            this.Close();
        }
        private void DisplayError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void DisplaySuccess(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void greyStar_Click(object sender, EventArgs e)
        {
            greyStar.Visible = false;
            goldStar.Visible = true;
            // check to make sure getting added to watch list
            try
            {
                if (!InWatchDB)
                {
                    greyStar.Visible = false;
                    goldStar.Visible = true;
                    InWatchDB = true;
                    DateTime today = DateTime.Today;
                    bool goodInsert;
                    WatchList wList = new WatchList();
                    wList.Member_Id = aMember.Member_Number;
                    wList.Movie_Number = SelectedMovie.Movie_Number;
                    wList.Date_Added = today;
                    goodInsert = WatchListDB.addList(wList.Member_Id, wList.Movie_Number, wList.Date_Added);

                    if (goodInsert)
                        DisplaySuccess("Movie has been added to watchlist", appTitle);
                    if (!goodInsert)
                        DisplayError("A error occured while adding movie to watchlist", appTitle);
                }
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void goldStar_Click(object sender, EventArgs e)
        {
            bool goodDel = default;
            goldStar.Visible = false;
            greyStar.Visible = true;

            if (InWatchDB)
            {
                goodDel = WatchListDB.SpDeleteMovie(aMember.Member_Number, SelectedMovie.Movie_Number);

                if (!goodDel)
                    DisplayError("There was an issue adding movie to your WatchList please try again later.",appTitle);
            }
        }
        private void ChangeTextColor(System.Windows.Forms.Label lblBtn, string action)
        {
            switch (action)
            {
                case "leave":
                    lblBtn.ForeColor = System.Drawing.Color.White;
                    break;
                case "enter":
                    lblBtn.ForeColor = System.Drawing.Color.DarkSlateGray;
                    break;
            }
        }
        private void orderSelectBtn_Enter(object sender, EventArgs e)
        {
            ChangeTextColor(orderSelectBtn, "enter");
        }

        private void orderSelectBtn_Leave(object sender, EventArgs e)
        {
            ChangeTextColor(orderSelectBtn, "leave");
        }

        private void previewBtn_Enter(object sender, EventArgs e)
        {
            ChangeTextColor(previewBtn, "enter");
        }

        private void previewBtn_Leave(object sender, EventArgs e)
        {
            ChangeTextColor(previewBtn, "leave");
        }

        private void backBtn_Enter(object sender, EventArgs e)
        {
            ChangeTextColor(backBtn, "enter");
        }

        private void backBtn_Leave(object sender, EventArgs e)
        {
            ChangeTextColor(backBtn, "leave");
        }
    }
}
