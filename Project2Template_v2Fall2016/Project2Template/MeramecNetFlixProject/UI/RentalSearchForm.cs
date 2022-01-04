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
    public partial class RentalSearchForm : Form
    {
        string appTitle = "Meramc Netflix";
        string fileLoc = "C:/c#2/Project2/DataFiles/Images/Movies/";
        int GenreIndex = -1;
        bool IsGenre = false;
        bool GenreFound = false;
        bool ImageFound = false;
        bool HasWatchList = false;
        bool OnWatchList = false;
        (bool, string) IsValid;
        Movie SelectedMovie;
        Member ActiveMember;
        List<Genre> listOfGenres = new List<Genre>();
        List<Movie> SearchedMovies = new List<Movie>();
        List<Movie> WList = new List<Movie>();
        List<Genre> RequestedGenres = new List<Genre>();
        PictureBox[] PbxArray;
        Image pbxDefault = Image.FromFile("C:/c#2/Project2/DataFiles/Images/UXImgs/stlccLogoColor3.jpg");
        int img0 = 0, img1 = 1, img2 = 2, img3 = 3, img4 = 4, img5 = 5;

        public RentalSearchForm()
        {
            InitializeComponent();
        }
        public RentalSearchForm(Member currentMember, List<Movie> wList)
        {
            InitializeComponent();
            ActiveMember = currentMember.MemberCopy();
            SelectedMovie = new Movie();
            WList = wList;
            if (WList.Count > 0)
            {
                HasWatchList = true;
                WList = wList;
            }

            // double check this is the correct sp to get all genres
            listOfGenres = GenreDB.SpGetGenreInfo();
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
            catch (Exception ex)
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
                    searchFlow.Controls.Add(pbxs[indx]);
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
            SelectedMovie = SearchedMovies[PbxIndx];
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
                for (int indx = 0; indx < WList.Count - 1 && !movieFound; indx++)
                {
                    if (movieTitle.Equals(WList[indx].Movie_Title))
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
        private void SearchBtnsHover(System.Windows.Forms.Label lbl, int x, int y)
        {
            // You have to link all the events still

            // note the original img box is untitled 2 have to make another selectted 2nd imgbox
            Image himage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/untitled3.png");
            lbl.Image = himage;
            lbl.Size = new Size(x,y);
            lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
        }
        private void SearchBtnsLeave(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image limage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/untitled2.png");
            lbl.Image = limage;
            lbl.Size = new Size(x,y);
            lbl.ForeColor = System.Drawing.Color.White;
        }
        private void findBtn_MouseHover(object sender, EventArgs e)
        {
            SearchBtnsHover(findBtn, 157, 37);
        }

        private void findBtn_MouseLeave(object sender, EventArgs e)
        {
            SearchBtnsLeave(findBtn, 157, 37);
        }

        private void clearBtn_MouseHover(object sender, EventArgs e)
        {
            SearchBtnsHover(clearBtn, 157, 37);
        }

        private void clearBtn_MouseLeave(object sender, EventArgs e)
        {
            SearchBtnsLeave(clearBtn, 157, 37);
        }
        private void DisplayError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void DisplaySuccess(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void RentalSerachForm_Load(object sender, EventArgs e)
        {

            searchFlow.AutoScroll = false;
            searchFlow.HorizontalScroll.Enabled = false;
            searchFlow.AutoScroll = true;
            searchFlow.Visible = false;
            searchFlow.BackColor = System.Drawing.Color.Transparent;
            searchTxt.Focus();          
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            searchTxt.Text = string.Empty;
            //clear out movies for another search
            ClearSearches();
            searchTxt.Focus();
            reelPbx.Visible = true;
        }
        private void ClearSearches()
        {
            //clear out movie(s) information from any previous searches
            SearchedMovies.Clear();
            searchImgs.Images.Clear();
            searchFlow.Controls.Clear();
            SelectedMovie = null;
        }
        private void findBtn_Click(object sender, EventArgs e)
        {
            reelPbx.Visible = false;
            searchFlow.Visible = true;
            //clear out movie(s) information from any previous searches
            ClearSearches();

            IsValid = ValidSearch();

            if (IsValid.Item1)
            {
                try
                {
                    string requestedContent = searchTxt.Text.Trim();
                    bool GenreMatch;
                    // check if text entered is in the list of genres
                    GenreMatch = CheckForGenre(requestedContent);

                    if (GenreMatch)
                    {
                        IsGenre = true;
                        GenreFound = true;
                        SearchedMovies = MovieDB.SpGetMoviesInGenere(requestedContent);
                    }
                    else if (!GenreMatch)
                        SearchedMovies = MovieDB.SpSearchMovies(requestedContent);

                    if (SearchedMovies.Count == 0)
                    { DisplaySuccess("No results found", appTitle); }

                    else if (SearchedMovies.Count >= 1)
                    {
                        PbxArray = new PictureBox[SearchedMovies.Count];
                        SetImageListImages(SearchedMovies, searchImgs);
                        CreatePbxList(SearchedMovies.Count, PbxArray);
                        SetPbxImages(PbxArray, searchImgs);
                    }
                    else
                        DisplayError("Unkown error occured while searching", appTitle);
                }
                catch(Exception ex)
                { DisplayError(ex.Message, appTitle); }
                
            }
            else
                SetErrorProvider(IsValid.Item2);

            Array.Clear(PbxArray, 0, PbxArray.Length);

        }
        private bool CheckForGenre(string request)
        {
            bool isMatch = default;

            for (int indx = 0; indx < listOfGenres.Count && !isMatch; indx++)
            {
                if (request.Equals(listOfGenres[indx].name))
                {
                    isMatch = true;
                    GenreFound = true;
                }
            }

            return isMatch;
        }
        private void AddPbxImages(List<System.Windows.Forms.PictureBox> pbxList, System.Windows.Forms.ImageList imgList)
        {
            for (int indx = 0; indx <= imgList.Images.Count-1; indx++)
            {
                pbxList[indx].Image = imgList.Images[indx];
            }
        }
        private (bool, string) ValidSearch()
        {
            bool valid;
            string emsg = string.Empty;

            if (string.IsNullOrEmpty(searchTxt.Text))
            {
                valid = false;
                emsg = "You must enter a movie or genre to search";
            }
            else if (searchTxt.Text.Length >= 256)
            {
                valid = false;
                emsg = "Search word must be 255 characters or less";
            }
            else
                valid = true;
            return (valid, emsg);
        }

        private void SetErrorProvider(string emsg)
        {
            errPv.SetError(searchTxt, emsg);
        }
        private void ResetErrorProvider()
        {
            errPv.Clear();
        }

        private void moreBtn_Click(object sender, EventArgs e)
        {
            // movies the index of the image list to show other movies
            try
            {
                img0++;
                img1++;
                img2++;
                img3++;
                img4++;
                img5++;

                if (img0 >= searchImgs.Images.Count)
                    img0 = 0;
                if (img1 >= searchImgs.Images.Count)
                    img1 = 0;
                if (img2 >= searchImgs.Images.Count)
                    img2 = 0;
                if (img3 >= searchImgs.Images.Count)
                    img3 = 0;
                if (img4 >= searchImgs.Images.Count)
                    img4 = 0;
                if (img5 >= searchImgs.Images.Count)
                    img5 = 0;

            }catch(Exception ex)
            { DisplayError(ex.Message, appTitle); }
           
        }
        private void CheckIndexNumber(ref int indx, System.Windows.Forms.ImageList imgList)
        {
            if (indx >= imgList.Images.Count)
                indx = 0;
        }

    }

    
}
