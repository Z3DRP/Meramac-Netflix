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
    public partial class MyStuffScreen : Form
    {
        Member ActiveMember;
        Movie SelectedMovie;
        List<Movie> MembersList;
        string appTitle = "Meramac Netflix";
        bool HasWatchList;
        bool OnWatchList = true;
        PictureBox[] PbxArray;
        Image pbxDefault = Image.FromFile("C:/c#2/Project2/DataFiles/Images/UXImgs/stlccLogoColor3.jpg");

        public MyStuffScreen()
        {
            InitializeComponent();
        }
        public MyStuffScreen(Member currentMember, bool hasWlist)
        {
            InitializeComponent();
            try
            {
                ActiveMember = currentMember.MemberCopy();               
                HasWatchList = hasWlist;

                if (HasWatchList)
                { 
                    MembersList = MovieDB.SpGetWatchListMovies(ActiveMember);
                }
                if (!HasWatchList)
                { MembersList = MovieDB.SpGetTop15(); }
                
                PbxArray = new PictureBox[MembersList.Count];

            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        // constructor to call if member does not have a watch list
        // this constructor allows them to see recomendations
        public MyStuffScreen(Member currentMember)
        {
            InitializeComponent();
            try
            {
                ActiveMember = currentMember.MemberCopy();
                MembersList = MovieDB.SpGetWatchListMovies(ActiveMember);
                PbxArray = new PictureBox[MembersList.Count];

                if (MembersList.Count > 0)
                    HasWatchList = true;
                else
                    HasWatchList = false;
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
        private void MyStuffScreen_Load(object sender, EventArgs e)
        {
            MyFlow.AutoScroll = false;
            MyFlow.HorizontalScroll.Enabled = false;
            MyFlow.AutoScroll = true;
            
            SetImageListImages(MembersList, myImgList);
            CreatePbxList(MembersList.Count, PbxArray);
            SetPbxImages(PbxArray, myImgList);
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
                    MyFlow.Controls.Add(pbxs[indx]);
                }
            }
            catch (Exception ex)
            { DisplayError(ex.Message, appTitle); }
        }
        private void Pbx_Click(object sender, MouseEventArgs e)
        {
            // gets the index off the sender object in the pbx array
            var PbxIndx = Array.IndexOf(PbxArray, sender);
            // Allmovies list and moviesImg list are parrell arrays
            // so use index to determine the index of the movie clicked to find the info for movie 
            SelectedMovie = new Movie();
            SelectedMovie = MembersList[PbxIndx];
            bool del = default;
            if (HasWatchList)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, OnWatchList);
                        preview.ShowDialog();
                        break;
                    case MouseButtons.Right:
                        DialogResult mDel =
                            MessageBox.Show("Movie will be removed from Watchlist, do you wish to contiune?", appTitle,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mDel == DialogResult.Yes)
                        { del = WatchListDB.SpDeleteMovie(ActiveMember.Member_Number, SelectedMovie.Movie_Number); }
                        MyFlow.Controls.RemoveAt(PbxIndx);
                        break;
                }

                if (del)
                {
                    DisplaySuccess("Movie was removed from Watchlist", appTitle);
                }
            }
            if (!HasWatchList)
            {
                MoviePreviewScreen preview = new MoviePreviewScreen(ActiveMember, SelectedMovie, OnWatchList);
                preview.ShowDialog();
            }
            
        }
       
    }
   
}
