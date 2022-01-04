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
    public partial class RentalScreen : Form
    {
        string appTitle = "Meramc Netflix";
        Member ActiveMember = new Member();
        Movie SelectedMovie;
        List<Movie> movieList = new List<Movie>();
        List<Movie> MoviesFound = new List<Movie>();
        bool IsAdmin;
        bool AllGenresClick;
        bool success;
        bool HasWatchList = false;
        bool HasMightLike = false;
        bool HasRecommended = false;
        bool MovieOnWatch = false;
        string fileLoc = "C:/c#2/Project2/DataFiles/Images/Movies/";
        string pbxDefault = "C:/c#2/Project2/DataFiles/Images/UXImgs/stlccLogoColor3.jpg";
        int wlImg0 = 0;
        int wlImg1 = 1;
        int wlImg2 = 2;
        int recImg0 = 0;
        int recImg1 = 1;
        int recImg2 = 2;
        int actionImg0 = 0;
        int actionImg1 = 1;
        int actionImg2 = 2;
        int actionImg3 = 3;
        int scifiImg0 = 0;
        int scifiImg1 = 1;
        int scifiImg2 = 2;
        int scifiImg3 = 3;
        int classicImg0 = 0;
        int classicImg1 = 1;
        int classicImg2 = 2;
        int classicImg3 = 3;
        int dramaImg0 = 0;
        int dramaImg1 = 1;
        int dramaImg2 = 2;
        int dramaImg3 = 3;
        int comedyImg0 = 0;
        int comedyImg1 = 1;
        int comedyImg2 = 2;
        int comedyImg3 = 3;
        int mlImg0 = 0;
        int mlImg1 = 1;
        int mlImg2 = 2;
        int gImg0 = 0;
        int gImg1 = 1;
        int gImg2 = 2;
        int gImg3 = 3;
        int horrorImg0 = 0;
        int horrorImg1 = 1;
        int horrorImg2 = 2;
        int horrorImg3 = 3;

        // make lists to hold images from database
        List<Genre> AllGenres = new List<Genre>();
        List<Genre> AllGenresIds = new List<Genre>();
        List<Movie> aList = new List<Movie>();
        List<Movie> sList = new List<Movie>();
        List<Movie> csList = new List<Movie>();
        List<Movie> dList = new List<Movie>();
        List<Movie> cmList = new List<Movie>();
        List<Movie> hList = new List<Movie>();
        List<Movie> MemberWatchList = new List<Movie>();
        List<Movie> MightLike = new List<Movie>();
        List<Movie> RecommendedMovies = new List<Movie>();
        List<Movie> genreMovies = new List<Movie>();

        // event for homebutton
        public event EventHandler GoHome;

        private void RaiseGoHome()
        {
            var handler = GoHome;
            if (GoHome != null)
                GoHome(this, EventArgs.Empty);
        }
        public RentalScreen()
        {
            InitializeComponent();
        }
        // constructor to accept the username and isAdmin from loginScreen
        public RentalScreen(Member aMember, bool isAdmin)
        {
            InitializeComponent();
            moviesFlw.AutoScroll = false;
            moviesFlw.HorizontalScroll.Enabled = false;
            moviesFlw.AutoScroll = true;
            ActiveMember = aMember.MemberCopy();
            userNameLbl.Text = ActiveMember.First_Name;
            MightLike = MovieDB.SpGetTop3();
            MemberWatchList = MovieDB.SpGetWatchListMovies(ActiveMember);
            RecommendedMovies = MovieDB.SpGetRecommended();
            AllGenres = GenreDB.SpGetGenreInfo();

            if (MightLike.Count >= 1)
            {
                HasMightLike = true;
                mightLikeLbl.Visible = true;
                mviewFlw.Visible = true;
            }
            if (MemberWatchList.Count >= 1)
            {
                HasWatchList = true;
                watchListLbl.Visible = true;
                wListFlw.Visible = true;
            }               
            if (RecommendedMovies.Count >= 1)
            {
                HasRecommended = true;
                recommendedLbl.Visible = true;
                recommendedFlow.Visible = true;
            }
            
            IsAdmin = isAdmin;
            if (IsAdmin)
            {
                adminBtn.Visible = true;
            }
            else
                adminBtn.Visible = false;
            
        }


        private void RentalScreen_Load(object sender, EventArgs e)
        {
            // if you have enough time use rental table to get recommended and add 
            // assign queries to the correct list
            aList = MovieDB.SpGetMoviesInGenere("Action");
            sList = MovieDB.SpGetMoviesInGenere("Scifi");
            csList = MovieDB.SpGetMoviesInGenere("Classic");
            dList = MovieDB.SpGetMoviesInGenere("Drama");
            cmList = MovieDB.SpGetMoviesInGenere("Comedy");
            hList = MovieDB.SpGetMoviesInGenere("Horror");

            SetImageListImages(aList, actionImgList);
            SetImageListImages(sList, scifiImgList);
            SetImageListImages(csList, classicImgList);
            SetImageListImages(dList, dramaImgList);
            SetImageListImages(cmList, comedyImgList);
            SetImageListImages(hList, horrorImgList);
            SetImageListImages(MightLike, mightLikeImgList);
            SetImageListImages(MemberWatchList, watchListImgList);
            SetImageListImages(RecommendedMovies, recommendedImgList);
            

            SetImagePbx(actPbx1, actionImgList, actionImg0);
            SetImagePbx(actPbx2, actionImgList, actionImg1);
            SetImagePbx(actPbx3, actionImgList, actionImg2);
            SetImagePbx(actPbx4, actionImgList, actionImg3);

            SetImagePbx(sciPbx1, scifiImgList, scifiImg0);
            SetImagePbx(sciPbx2, scifiImgList, scifiImg1);
            SetImagePbx(sciPbx3, scifiImgList, scifiImg2);
            SetImagePbx(sciPbx4, scifiImgList, scifiImg3);

            SetImagePbx(clsPbx1, classicImgList, classicImg0);
            SetImagePbx(clsPbx2, classicImgList, classicImg1);
            SetImagePbx(clsPbx3, classicImgList, classicImg2);
            SetImagePbx(clsPbx4, classicImgList, classicImg3);

            SetImagePbx(dmPbx1,dramaImgList,dramaImg0);
            SetImagePbx(dmPbx2, dramaImgList, dramaImg1);
            SetImagePbx(dmPbx3, dramaImgList, dramaImg2);
            SetImagePbx(dmPbx4, dramaImgList, dramaImg3);

            SetImagePbx(hPbx1, horrorImgList, horrorImg0);
            SetImagePbx(hPbx2, horrorImgList, horrorImg1);
            SetImagePbx(hPbx3, horrorImgList, horrorImg2);
            SetImagePbx(hPbx4, horrorImgList, horrorImg3);

            SetImagePbx(cmPbx1, comedyImgList, comedyImg0);
            SetImagePbx(cmPbx2, comedyImgList, comedyImg1);
            SetImagePbx(cmPbx3, comedyImgList, comedyImg2);
            SetImagePbx(cmPbx4, comedyImgList, comedyImg3);

            if (MightLike.Count > 0)
            {
                SetImagePbx(mLPbx1, mightLikeImgList, mlImg0);
                SetImagePbx(mLPbx2, mightLikeImgList, mlImg1);
                SetImagePbx(mLPbx3, mightLikeImgList, mlImg2);
            }
            
            if (MemberWatchList.Count > 0)
            {
                SetImagePbx(wLPbx1, watchListImgList, wlImg0);
                SetImagePbx(wLPbx2, watchListImgList, wlImg1);
                SetImagePbx(wLPbx3, watchListImgList, wlImg2);
            }

            if (RecommendedMovies.Count > 0)
            {
                SetImagePbx(recmdPbx1, recommendedImgList, recImg0);
                SetImagePbx(recmdPbx2, recommendedImgList, recImg1);
                SetImagePbx(recmdPbx3, recommendedImgList, recImg2);
            }

            genreCmbx.DataSource = AllGenres;
            genreCmbx.DisplayMember = "name";
            genreCmbx.ValueMember = "id";

            timer.Enabled = true;
        }
        
        private void actPbx1_Click(object sender, EventArgs e)
        {
            // search the db with img for movie
            
            try
            {
                // CheckIndexNumber is needed becase the index is incremented with a btn click event if it is equal to count it set to zero
                // but if user clicks the picbox before the btn click event then the index overflow is wouldnt be caught this method prevents that
                // pass in a different variable set to index value and use that to set movie so the index does not get thrown off for next btn event
                int testIndx = actionImg0;
                CheckIndexNumber(ref testIndx, actionImgList);
                SelectedMovie = aList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch(Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }

        }

        private void actPbx2_Click(object sender, EventArgs e)
        {
            // search the db with img for movie
            try
            {
                int testIndx = actionImg1;
                CheckIndexNumber(ref testIndx, actionImgList);
                SelectedMovie = aList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void actPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = actionImg2;
                CheckIndexNumber(ref testIndx, actionImgList);
                SelectedMovie = aList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void sciPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = scifiImg0;
                CheckIndexNumber(ref testIndx, scifiImgList);
                SelectedMovie = sList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void sciPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = scifiImg1;
                CheckIndexNumber(ref testIndx, scifiImgList);
                SelectedMovie = sList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void sciPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = scifiImg2;
                CheckIndexNumber(ref testIndx, scifiImgList);
                SelectedMovie = sList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void clsPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = classicImg0;
                CheckIndexNumber(ref testIndx, classicImgList);
                SelectedMovie = csList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void clsPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = classicImg1;
                CheckIndexNumber(ref testIndx, classicImgList);
                SelectedMovie = csList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void clsPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = classicImg2;
                CheckIndexNumber(ref testIndx, classicImgList);
                SelectedMovie = csList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void dmPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = dramaImg0;
                CheckIndexNumber(ref testIndx, dramaImgList);
                SelectedMovie = dList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void dmPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = dramaImg1;
                CheckIndexNumber(ref testIndx, dramaImgList);
                SelectedMovie = dList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void dmPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = dramaImg2;
                CheckIndexNumber(ref testIndx, dramaImgList);
                SelectedMovie = dList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void cmPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = comedyImg0;
                CheckIndexNumber(ref testIndx, comedyImgList);
                SelectedMovie = cmList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void cmPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = comedyImg1;
                CheckIndexNumber(ref testIndx, comedyImgList);
                SelectedMovie = cmList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void cmPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = comedyImg2;
                CheckIndexNumber(ref testIndx, comedyImgList);
                SelectedMovie = cmList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void mLPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = mlImg0;
                CheckIndexNumber(ref testIndx, mightLikeImgList);
                SelectedMovie = MightLike[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void mLPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = mlImg1;
                CheckIndexNumber(ref testIndx, mightLikeImgList);
                SelectedMovie = MightLike[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void mLPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = mlImg2;
                CheckIndexNumber(ref testIndx, mightLikeImgList);
                SelectedMovie = MightLike[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void wLPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = wlImg0;
                CheckIndexNumber(ref testIndx, watchListImgList);
                SelectedMovie = MemberWatchList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void wLPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = wlImg1;
                CheckIndexNumber(ref testIndx, watchListImgList);
                SelectedMovie = MemberWatchList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void wLPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = wlImg2;
                CheckIndexNumber(ref testIndx, watchListImgList);
                SelectedMovie = MemberWatchList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }
        private void recmdPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = recImg0;
                CheckIndexNumber(ref testIndx, recommendedImgList);
                SelectedMovie = RecommendedMovies[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void recmdPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = recImg1;
                CheckIndexNumber(ref testIndx, recommendedImgList);
                SelectedMovie = RecommendedMovies[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void recmdPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = recImg2;
                CheckIndexNumber(ref testIndx, recommendedImgList);
                SelectedMovie = RecommendedMovies[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }
        private void genrePbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = gImg0;
                CheckIndexNumber(ref testIndx, genreImgList);
                SelectedMovie = genreMovies[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void genrePbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = gImg1;
                CheckIndexNumber(ref testIndx, genreImgList);
                SelectedMovie = genreMovies[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void genrePbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = gImg2;
                CheckIndexNumber(ref testIndx, genreImgList);
                SelectedMovie = genreMovies[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void actPbx4_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = actionImg3;
                CheckIndexNumber(ref testIndx, actionImgList);
                SelectedMovie = aList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch(Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void sciPbx4_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = scifiImg3;
                CheckIndexNumber(ref testIndx, scifiImgList);
                SelectedMovie = sList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void clsPbx4_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = classicImg3;
                CheckIndexNumber(ref testIndx, classicImgList);
                SelectedMovie = csList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void dmPbx4_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = dramaImg3;
                CheckIndexNumber(ref testIndx, dramaImgList);
                SelectedMovie = dList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void cmPbx4_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = comedyImg3;
                CheckIndexNumber(ref testIndx, comedyImgList);
                SelectedMovie = cmList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void genrePbx4_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = gImg3;
                CheckIndexNumber(ref testIndx, genreImgList);
                SelectedMovie = genreMovies[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie,starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }

        private void hPbx1_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = horrorImg0;
                CheckIndexNumber(ref testIndx, horrorImgList);
                SelectedMovie = hList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void hPbx2_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = horrorImg1;
                CheckIndexNumber(ref testIndx, horrorImgList);
                SelectedMovie = hList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void hPbx3_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = horrorImg2;
                CheckIndexNumber(ref testIndx, horrorImgList);
                SelectedMovie = hList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }

        private void hPbx4_Click(object sender, EventArgs e)
        {
            try
            {
                int testIndx = horrorImg3;
                CheckIndexNumber(ref testIndx, horrorImgList);
                SelectedMovie = hList[testIndx];
                bool starred = CheckWatchList(SelectedMovie.Movie_Title);
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, starred);
                preview.ShowDialog();
            }
            catch (Exception ex)
            { DisplayError(ex.Message, "Unkown Error"); }
        }
        private void btnSearchIcn_Click(object sender, EventArgs e)
        {
            RentalSearchForm searchForm = new RentalSearchForm(ActiveMember, MemberWatchList);
            searchForm.ShowDialog();
        }

        private void tvBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There are currently no tv shows available", appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void moviesBtn_Click(object sender, EventArgs e)
        {
            AllMoviesScreen allMovies = new AllMoviesScreen(ActiveMember);
            allMovies.ShowDialog();
        }

        private void myStuffBtn_Click(object sender, EventArgs e)
        {
            MemberWatchList = MovieDB.SpGetWatchListMovies(ActiveMember);

            if (MemberWatchList.Count >= 1)
            {
                MyStuffScreen myScreen = new MyStuffScreen(ActiveMember, true);
                myScreen.ShowDialog();
            }
            else if (MemberWatchList.Count < 1)
            {
                DialogResult res = MessageBox.Show(
                        "You currently do not have any movies on your Watchlist would you like to see recomendations?",
                        appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    MyStuffScreen myScreen = new MyStuffScreen(ActiveMember, false);
                    myScreen.ShowDialog();
                }
            }
            
            
        }
        private bool CheckWatchList(string movieTitle)
        {
            bool found = default;
            bool inWatchList = default;
            if (HasWatchList)
            {
                for (int indx = 0; indx < MemberWatchList.Count && !found; indx++)
                {
                    if (movieTitle.Equals(MemberWatchList[indx].Movie_Title))
                    {
                        inWatchList = true;
                        found = true;
                    }
                }
            }
            else
                inWatchList = false;

            return inWatchList;
        }
        private void CheckIndexNumber(ref int indx, System.Windows.Forms.ImageList imgList)
        {
            if (indx > imgList.Images.Count)
                indx = 0;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (HasWatchList)
                {
                    wlImg0++;
                    wlImg1++;
                    wlImg2++;

                    if (wlImg0 == watchListImgList.Images.Count)
                        wlImg0 = 0;
                    if (wlImg1 == watchListImgList.Images.Count)
                        wlImg1 = 0;
                    if (wlImg2 == watchListImgList.Images.Count)
                        wlImg2 = 0;

                    wLPbx1.Image = watchListImgList.Images[wlImg0];
                    wLPbx2.Image = watchListImgList.Images[wlImg1];
                    wLPbx3.Image = watchListImgList.Images[wlImg2];
                }
                if(HasRecommended)
                {
                    recImg0++;
                    recImg1++;
                    recImg2++;

                    if (recImg0 == recommendedImgList.Images.Count)
                        recImg0 = 0;
                    if (recImg1 == recommendedImgList.Images.Count)
                        recImg1 = 0;
                    if (recImg2 == recommendedImgList.Images.Count)
                        recImg2 = 0;

                    recmdPbx1.Image = recommendedImgList.Images[recImg0];
                    recmdPbx2.Image = recommendedImgList.Images[recImg1];
                    recmdPbx3.Image = recommendedImgList.Images[recImg2];
                }
           
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void actionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // incremnt index
                actionImg0++;
                actionImg1++;
                actionImg2++;
                actionImg3++;

                // if index out of range loop back to zero
                if (actionImg0 == actionImgList.Images.Count)
                    actionImg0 = 0;
                if (actionImg1 == actionImgList.Images.Count)
                    actionImg1 = 0;
                if (actionImg2 == actionImgList.Images.Count)
                    actionImg2 = 0;
                if (actionImg3 == actionImgList.Images.Count)
                    actionImg3 = 0;

                // set pbxs
                actPbx1.Image = actionImgList.Images[actionImg0];
                actPbx2.Image = actionImgList.Images[actionImg1];
                actPbx3.Image = actionImgList.Images[actionImg2];
                actPbx4.Image = actionImgList.Images[actionImg3];
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void scifiBtn_Click(object sender, EventArgs e)
        {
            try
            {
                scifiImg0++;
                scifiImg1++;
                scifiImg2++;
                scifiImg3++;

                if (scifiImg0 == scifiImgList.Images.Count)
                    scifiImg0 = 0;
                if (scifiImg1 == scifiImgList.Images.Count)
                    scifiImg1 = 0;
                if (scifiImg2 == scifiImgList.Images.Count)
                    scifiImg2 = 0;
                if (scifiImg3 == scifiImgList.Images.Count)
                    scifiImg3 = 0;

                sciPbx1.Image = scifiImgList.Images[scifiImg0];
                sciPbx2.Image = scifiImgList.Images[scifiImg1];
                sciPbx3.Image = scifiImgList.Images[scifiImg2];
                sciPbx4.Image = scifiImgList.Images[scifiImg3];
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void classicBtn_Click(object sender, EventArgs e)
        {
            try
            {
                classicImg0++;
                classicImg1++;
                classicImg2++;
                classicImg3++;

                if (classicImg0 == classicImgList.Images.Count)
                    classicImg0 = 0;
                if (classicImg1 == classicImgList.Images.Count)
                    classicImg1 = 0;
                if (classicImg2 == classicImgList.Images.Count)
                    classicImg2 = 0;
                if (classicImg3 == classicImgList.Images.Count)
                    classicImg3 = 0;

                clsPbx1.Image = classicImgList.Images[classicImg0];
                clsPbx2.Image = classicImgList.Images[classicImg1];
                clsPbx3.Image = classicImgList.Images[classicImg2];
                clsPbx4.Image = classicImgList.Images[classicImg3];
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void dramaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dramaImg0++;
                dramaImg1++;
                dramaImg2++;
                dramaImg3++;

                if (dramaImg0 == dramaImgList.Images.Count)
                    dramaImg0 = 0;
                if (dramaImg1 == dramaImgList.Images.Count)
                    dramaImg1 = 0;
                if (dramaImg2 == dramaImgList.Images.Count)
                    dramaImg2 = 0;
                if (dramaImg3 == dramaImgList.Images.Count)
                    dramaImg3 = 0;

                dmPbx1.Image = dramaImgList.Images[dramaImg0];
                dmPbx2.Image = dramaImgList.Images[dramaImg1];
                dmPbx3.Image = dramaImgList.Images[dramaImg2];
                dmPbx4.Image = dramaImgList.Images[dramaImg3];
            }
            catch (Exception ex)
            { throw ex; }
        }
        private void horrBtn_Click(object sender, EventArgs e)
        {
            try
            {
                horrorImg0++;
                horrorImg1++;
                horrorImg2++;
                horrorImg3++;

                if (horrorImg0 == horrorImgList.Images.Count)
                    horrorImg0 = 0;
                if (horrorImg1 == horrorImgList.Images.Count)
                    horrorImg1 = 0;
                if (horrorImg2 == horrorImgList.Images.Count)
                    horrorImg2 = 0;
                if (horrorImg3 == horrorImgList.Images.Count)
                    horrorImg3 = 0;

                hPbx1.Image = horrorImgList.Images[horrorImg0];
                hPbx2.Image = horrorImgList.Images[horrorImg1];
                hPbx3.Image = horrorImgList.Images[horrorImg2];
                hPbx4.Image = horrorImgList.Images[horrorImg3];
            }
            catch(Exception ex)
            { throw ex; }
        }
        private void comedyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                comedyImg0++;
                comedyImg1++;
                comedyImg2++;
                comedyImg3++;

                if (comedyImg0 == comedyImgList.Images.Count )
                    comedyImg0 = 0;
                if (comedyImg1 == comedyImgList.Images.Count)
                    comedyImg1 = 0;
                if (comedyImg2 == comedyImgList.Images.Count)
                    comedyImg2 = 0;
                if (comedyImg3 == comedyImgList.Images.Count)
                    comedyImg3 = 0;

                cmPbx1.Image = comedyImgList.Images[comedyImg0];
                cmPbx2.Image = comedyImgList.Images[comedyImg1];
                cmPbx3.Image = comedyImgList.Images[comedyImg2];
                cmPbx4.Image = comedyImgList.Images[comedyImg3];
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void searchMoviesBtn_Click(object sender, EventArgs e)
        {
            RentalSearchForm searchForm = new RentalSearchForm(ActiveMember,MemberWatchList);
            searchForm.ShowDialog();
        }
        private void selectGenreBtn_Click(object sender, EventArgs e)
        {
            selectGenreBtn.Visible = false;
            genreCmbx.Visible = true;
        }

        private void genreCmbx_Leave(object sender, EventArgs e)
        {
            selectGenreBtn.Visible = true;
        }
        private void genreCmbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // clear out any previous movies
            try
            {
                genreMovies.Clear();
                genreImgList.Images.Clear();
                // selectedGenreBtn.Visible = true;
                // have to check this
                Genre selectedGenre = (Genre)genreCmbx.SelectedItem;
                genreMovies = MovieDB.SpGetMoviesFromGenre(selectedGenre.id);
                // check number of movies in genre
                if (genreMovies.Count >= 1)
                {
                    SetImageListImages(genreMovies, genreImgList);
                    SetImagePbx(genrePbx1, genreImgList, gImg0);
                    SetImagePbx(genrePbx2, genreImgList, gImg1);
                    SetImagePbx(genrePbx3, genreImgList, gImg2);
                    SetImagePbx(genrePbx4, genreImgList, gImg3);
                    EnableGenreFlow();
                }
                // if the genre is a newly added genre with no movies then display a message saying so
                else
                    DisplaySuccess("Selected Genre currently does not have any movies check back soon after update.",appTitle);
                
            }
            catch ( Exception ex)
            { throw ex; }
        }
        private void EnableGenreFlow()
        {
            genreFlow.Visible = true;
            nextBtn.Visible = true;
            genrePbx1.Visible = true;
            genrePbx2.Visible = true;
            genrePbx3.Visible = true;
            genrePbx4.Visible = true;
            genreCmbx.Visible = false;
            selectGenreBtn.Visible = true;
        }
        private void nextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                gImg0++;
                gImg1++;
                gImg2++;
                gImg3++;

                if (gImg0 == genreImgList.Images.Count - 1)
                    gImg0 = 0;
                if (gImg1 == genreImgList.Images.Count - 1)
                    gImg1 = 0;
                if (gImg2 == genreImgList.Images.Count - 1)
                    gImg2 = 0;
                if (gImg3 == genreImgList.Images.Count - 1)
                    gImg3 = 0;

                genrePbx1.Image = genreImgList.Images[gImg0];
                genrePbx2.Image = genreImgList.Images[gImg1];
                genrePbx3.Image = genreImgList.Images[gImg2];
                genrePbx4.Image = genreImgList.Images[gImg3];
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void SetImageListImages(List<Movie> movies, System.Windows.Forms.ImageList imgList)
        {
            try
            {
                if (movies.Count >= 1)
                {
                    for (int indx = 0; indx <= movies.Count - 1; indx++)
                    {
                        string fileloc = "C:/c#2/Project2/DataFiles/Images/Movies/";
                        fileloc += movies[indx].Image;
                        Image aimg = Image.FromFile(fileloc);
                        imgList.Images.Add(aimg);
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        // these commented out methods are to dynamically add a section to the moviesFlow
        //private void MakeFlow()
        //{
        //    FlowLayoutPanel flow = new FlowLayoutPanel();
        //    flow.FlowDirection = FlowDirection.LeftToRight;

        //}
        //private void MakePicBox(Genre genreName, int picBoxNum)
        //{ 
        //    PictureBox  pbx = new PictureBox();
        //    pbx.Size = new Size(113, 137);
        //    pbx.Click += EventHandler(pbx_Click);
        //}
        //private void AddToFlow(System.Windows.Forms.PictureBox picbox, System.Windows.Forms.FlowLayoutPanel flow)
        //{
        //    flow.Controls.Add(picbox);
        //}
        private void SetImagePbx(System.Windows.Forms.PictureBox pbx, System.Windows.Forms.ImageList imgList, int numbIndx)
        {
            try
            {
                if (imgList.Images.Count == 0)
                {
                    pbx.Image = Image.FromFile(pbxDefault);
                }
                else
                    pbx.Image = imgList.Images[numbIndx];
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }

        }
        private void DisplayError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void DisplaySuccess(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string GetFileLoc(string genreType)
        {
            string loc = string.Empty;

            switch (genreType)
            {
                case "Action":
                    loc = "C:/ c#2/Project2/DataFiles/Images/Movies/Action/";
                    break;
                case "Comedy":
                    loc = "C:/c#2/Project2/DataFiles/Images/Movies/Comdey";
                    break;
                case "Drama":
                    loc = "C:/c#2/Project2/DataFiles/Images/Movies/Drama";
                    break;
                case "Classic":
                    loc = "C:/c#2/Project2/DataFiles/Images/Movies/Classic";
                    break;
                case "Scifi":
                    loc = "C:/c#2/Project2/DataFiles/Images/Movies/Scifi";
                    break;
            }
            return loc;
        }
        private List<string> GetFileLocs(List<Movie> watchlist)
        {
            Genre gname = new Genre();
            Genre g = new Genre();
            List<Genre> genrenames = new List<Genre>();
            List<string> flocations = new List<string>();

            for (int elmt = 0; elmt <= watchlist.Count; elmt++)
            {
                g.id = MemberWatchList[elmt].Genre_Id;
                gname = GenreDB.GetGenreName(g);
                genrenames.Add(gname);
            }
            for (int elmt = 0; elmt <= genrenames.Count; elmt++)
            {
                switch (genrenames[elmt].name)
                {
                    case "Action":
                        flocations.Add("C:/ c#2/Project2/DataFiles/Images/Movies/Action/");
                        break;
                    case "Comedy":
                        flocations.Add("C:/c#2/Project2/DataFiles/Images/Movies/Comdey");
                        break;
                    case "Drama":
                        flocations.Add("C:/c#2/Project2/DataFiles/Images/Movies/Drama");
                        break;
                    case "Classic":
                        flocations.Add("C:/c#2/Project2/DataFiles/Images/Movies/Classic");
                        break;
                    case "Scifi":
                        flocations.Add("C:/c#2/Project2/DataFiles/Images/Movies/Scifi");
                        break;
                }
            }
            return flocations;

        }
        private void MovieGenreLblHover(System.Windows.Forms.Label lbl)
        {
            Image Himage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/vertLbl1hover.png");
            lbl.Image = Himage;
            lbl.Size = new Size(49, 232);
            lbl.ForeColor = System.Drawing.Color.Khaki;

        }
        private void MovieGenreLblLeave(System.Windows.Forms.Label lbl, string imgFile)
        {
            //the file determined by the calling btn sent in the sets the image 
            Image limage = Image.FromFile(imgFile);
            lbl.Image = limage;
            lbl.Size = new Size(49, 232);
            lbl.ForeColor = System.Drawing.Color.White;
        }

        private void scifiBtn_MouseHover(object sender, EventArgs e)
        {
            MovieGenreLblHover(scifiBtn);
        }

        private void scifiBtn_MouseLeave(object sender, EventArgs e)
        {
            string img = "C:/C#2/Project2/DataFiles/Images/UXImgs/sciVert.png";
            try
            {
                MovieGenreLblLeave(scifiBtn, img);
            }
            catch (Exception ex)
            {

                DisplayError(ex.Message, appTitle);
            }
        }

        private void actionBtn_MouseHover(object sender, EventArgs e)
        {
            MovieGenreLblHover(actionBtn);
        }

        private void actionBtn_MouseLeave(object sender, EventArgs e)
        {
            string img = "C:/C#2/Project2/DataFiles/Images/UXImgs/actVert.png";
            try
            {
                MovieGenreLblLeave(actionBtn, img);
            }
            catch (Exception ex)
            {

                DisplayError(ex.Message, appTitle);
            }
        }
        private void horrBtn_MouseHover(object sender, EventArgs e)
        {
            MovieGenreLblHover(horrBtn);
        }

        private void horrBtn_MouseLeave(object sender, EventArgs e)
        {
            string img = "C:/C#2/Project2/DataFiles/Images/UXImgs/horrVert.png";

            try
            {
                MovieGenreLblLeave(horrBtn, img);
            }
            catch(Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void nextBtn_MouseHover(object sender, EventArgs e)
        {
            MovieGenreLblHover(nextBtn);
        }

        private void nextBtn_MouseLeave(object sender, EventArgs e)
        {
            string img = "C:/C#2/Project2/DataFiles/Images/UXImgs/next2V.png";
            try
            {
                MovieGenreLblLeave(nextBtn, img);
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, appTitle);
            }
        }

        private void classicBtn_MouseHover(object sender, EventArgs e)
        {
            MovieGenreLblHover(classicBtn);
        }

        private void classicBtn_MouseLeave(object sender, EventArgs e)
        {
            string img = "C:/C#2/Project2/DataFiles/Images/UXImgs/clssVert.png";
            try
            {
                MovieGenreLblLeave(classicBtn, img);
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, appTitle);
            }
        }

        private void dramaBtn_MouseHover(object sender, EventArgs e)
        {
            MovieGenreLblHover(dramaBtn);
        }

        private void dramaBtn_MouseLeave(object sender, EventArgs e)
        {
            string img = "C:/C#2/Project2/DataFiles/Images/UXImgs/dramVert.png";
            try
            {
                MovieGenreLblLeave(dramaBtn, img);
            }
            catch (Exception ex)
            {

                DisplayError(ex.Message, appTitle);
            }
        }

        private void comedyBtn_MouseHover(object sender, EventArgs e)
        {
            MovieGenreLblHover(comedyBtn);
        }

        private void comedyBtn_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                MovieGenreLblLeave(comedyBtn, "C:/C#2/Project2/DataFiles/Images/UXImgs/comVert.png");
            }
            catch (Exception ex)
            {

                DisplayError(ex.Message, appTitle);
            }
        }

        private void homeBtn_MouseHover(object sender, EventArgs e)
        {
            HoverChange(homeBtn);
        }


        private void homeBtn_MouseLeave(object sender, EventArgs e)
        {
            LeaveChange(homeBtn);
        }

        private void tvBtn_MouseHover(object sender, EventArgs e)
        {
            HoverChange(tvBtn);
        }

        private void tvBtn_MouseLeave(object sender, EventArgs e)
        {
            LeaveChange(tvBtn);
        }

        private void moviesBtn_MouseHover(object sender, EventArgs e)
        {
            HoverChange(moviesBtn);
        }

        private void moviesBtn_MouseLeave(object sender, EventArgs e)
        {
            LeaveChange(moviesBtn);
        }

        private void myStuffBtn_MouseHover(object sender, EventArgs e)
        {
            HoverChange(myStuffBtn);
        }

        private void myStuffBtn_MouseLeave(object sender, EventArgs e)
        {
            LeaveChange(myStuffBtn);
        }

        private void logoutBtn_MouseHover(object sender, EventArgs e)
        {
            HoverChange(logoutBtn);
        }

        private void logoutBtn_MouseLeave(object sender, EventArgs e)
        {
            LeaveChange(logoutBtn);
        }

        private void adminBtn_MouseHover(object sender, EventArgs e)
        {
            HoverChange(adminBtn);
        }

        private void adminBtn_MouseLeave(object sender, EventArgs e)
        {
            LeaveChange(adminBtn);
        }
        private void HoverChange(System.Windows.Forms.Label lbl)
        {
            lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
        }
        private void LeaveChange(System.Windows.Forms.Label lbl)
        {
            lbl.ForeColor = System.Drawing.Color.White;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult goodBye = MessageBox.Show("Do you wish to close application after logout?", appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (goodBye == DialogResult.Yes)
                Application.Exit();
            else
                this.Close();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            AdminScreen adminLogin = new AdminScreen(ActiveMember);
            adminLogin.ShowDialog();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            // event to close login for to take back to opening screen
            RaiseGoHome();
            //this.Close();
        }
        private void ButtonHover(System.Windows.Forms.Label lblBtn)
        {
            lblBtn.ForeColor = System.Drawing.Color.DarkSlateGray;
        }
        private void ButtonLeave(System.Windows.Forms.Label lblBtn)
        {
            lblBtn.ForeColor = System.Drawing.Color.White;
        }
        private void searchMoviesBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonHover(searchMoviesBtn);
        }

        private void searchMoviesBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(searchMoviesBtn);
        }

        private void selectGenreBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonHover(selectGenreBtn);
        }

        private void selectGenreBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(selectGenreBtn);
        }


    }
}
