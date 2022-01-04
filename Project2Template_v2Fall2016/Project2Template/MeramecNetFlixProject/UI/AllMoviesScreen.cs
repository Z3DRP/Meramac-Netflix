using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetFlixProject.Data_Access_Layer;
using MeramecNetFlixProject.Business_Objects;

namespace MeramecNetFlixProject.UI
{
    public partial class AllMoviesScreen : Form
    {
        List<Movie> AllMovies = new List<Movie>();
        List<Movie> MemberWatchList = new List<Movie>();
        Movie SelectedMovie;
        Member ActiveMember;
        string appTitle = "Meramac Netflix";
        bool HasWatchList;
        bool OnWatchList;
        PictureBox[] PbxArray;
        Image pbxDefault = Image.FromFile("C:/c#2/Project2/DataFiles/Images/UXImgs/stlccLogoColor3.jpg");

        public AllMoviesScreen()
        {
            InitializeComponent();
        }
        public AllMoviesScreen(Member currentMember)
        {
            InitializeComponent();
            try
            {
                SelectedMovie = new Movie();
                ActiveMember = currentMember.MemberCopy();
                AllMovies = MovieDB.SpGetAllMovies();
                MemberWatchList = MovieDB.SpGetWatchListMovies(ActiveMember);
                PbxArray = new PictureBox[AllMovies.Count];

                if (MemberWatchList.Count > 0)
                    HasWatchList = true;
                else
                    HasWatchList = false;
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        // Dynamicly add picture boxs to flow control

        private void AllMoviesScreen_Load(object sender, EventArgs e)
        {
            allMoviesFlow.AutoScroll = false;
            allMoviesFlow.HorizontalScroll.Enabled = false;
            allMoviesFlow.AutoScroll = true;
            // step 1 get all movies from db
            SetImageListImages(AllMovies, movieImgList);

            // step 2 have a method
            // that for each movie in the movie list it adds a picturebox to flow and make click events
            CreatePbxList(AllMovies.Count, PbxArray);

            // fill pbx images with imagelist images
            SetPbxImages(PbxArray, movieImgList);
        }
        private void SetImageListImages(List<Movie> movies, System.Windows.Forms.ImageList imgList)
        {
            try
            {
                if (movies.Count >= 1)
                {
                    for (int indx = 0; indx < movies.Count; indx++)
                    {
                        string fileloc = "C:/c#2/Project2/DataFiles/Images/Movies/";
                        fileloc += movies[indx].Image;
                        Image aimg = Image.FromFile(fileloc);
                        imgList.Images.Add(aimg);
                    }
                }
                else
                    imgList.Images.Add(pbxDefault);
            }
            catch(Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void SetPbxImages(PictureBox[] pbxs, ImageList imgs)
        {
            try
            {
                for (int indx = 0; indx < imgs.Images.Count; indx++)
                {
                    pbxs[indx].Image = imgs.Images[indx];
                }
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void CreatePbxList(int count, PictureBox[] pbxs)
        {
            try
            {
                for (int indx = 0; indx < count; indx++)
                {
                    pbxs[indx] = new PictureBox();
                    pbxs[indx].Name = "moviePbx" + indx;
                    pbxs[indx].Size = new Size(210, 226);
                    //pbxs[indx].BackgroundImageLayout = ImageLayout.Stretch;
                    pbxs[indx].SizeMode = PictureBoxSizeMode.StretchImage;
                    pbxs[indx].MouseClick += new MouseEventHandler(Pbx_Click);
                    allMoviesFlow.Controls.Add(pbxs[indx]);
                }
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void Pbx_Click(object sender, EventArgs e)
        {
            // gets the index off the sender object in the pbx array
            var PbxIndx = Array.IndexOf(PbxArray, sender);
            // Allmovies list and moviesImg list are parrell arrays
            // so use index to determine the index of the movie clicked to find the info for movie 
            SelectedMovie = new Movie();
            SelectedMovie = AllMovies[PbxIndx];
            // then send to movie preview screen
            OnWatchList = CheckWatchList(SelectedMovie.Movie_Title);
            MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, OnWatchList);
            preview.ShowDialog();
        }
        private bool CheckWatchList(string movieTitle)
        {
            bool movieFound = false;
            bool inWatchList = default;
            if (HasWatchList)
            {
                for (int indx = 0; indx < MemberWatchList.Count && !movieFound; indx++)
                {
                    if (movieTitle.Equals(MemberWatchList[indx].Movie_Title))
                    {
                        movieFound = true;
                        inWatchList = true;
                    }
                }
            }
            else
                inWatchList = false;

            return inWatchList;
        }
        private void DisplayError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
