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
    
    public partial class AdminScreen : Form
    {
        Member ActiveMember;
        public AdminScreen()
        {
            InitializeComponent();
        }
        public AdminScreen(Member activeAdmin)
        {
            InitializeComponent();
            ActiveMember = activeAdmin.MemberCopy();
        }
        // code for label color chaning effects
        private void DataEntryLblHover(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image Himage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/rentalhver.png");
            lbl.Location = new Point(x, y);
            lbl.Image = Himage;
            lbl.Size = new Size(283, 49);
            lbl.ForeColor = System.Drawing.Color.Khaki;
        }
        private void DataEntryLblLeave(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image limage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/rentalblb.png");
            lbl.Location = new Point(x, y);
            lbl.Image = limage;
            lbl.Size = new Size(283, 49);
            lbl.ForeColor = System.Drawing.Color.White;
        }
        private void reportLbl_MouseHover(object sender, EventArgs e)
        {
            DataEntryLblHover(reportLbl, -54, 315);
        }

        private void reportLbl_MouseLeave(object sender, EventArgs e)
        {
            DataEntryLblLeave(reportLbl, -54, 315);
        }
        private void MemberBtn_MouseHover(object sender, EventArgs e)
        {
            DataEntryLblHover(memberBtn, -54, 52);
        }

        private void MemberBtn_MouseLeave(object sender, EventArgs e)
        {
            DataEntryLblLeave(memberBtn, -54, 52);
        }

        private void MoviesBtn_MouseHover(object sender, EventArgs e)
        {
            DataEntryLblHover(moviesBtn, -54, 119);
        }

        private void MoviesBtn_MouseLeave(object sender, EventArgs e)
        {
            DataEntryLblLeave(moviesBtn, -54, 119);
        }

        private void GenreBtn_MouseHover(object sender, EventArgs e)
        {
            DataEntryLblHover(genreBtn, -54, 185);
        }

        private void GenreBtn_MouseLeave(object sender, EventArgs e)
        {
            DataEntryLblLeave(genreBtn, -54, 185);
        }

        private void RentalsBtn_MouseHover(object sender, EventArgs e)
        {
            DataEntryLblHover(rentalsBtn, -54, 250);
        }

        private void RentalsBtn_MouseLeave(object sender, EventArgs e)
        {
            DataEntryLblLeave(rentalsBtn, -54, 250);
        }

        private void MemberBtn_Click(object sender, EventArgs e)
        {
            MemberDataEntry memberEditForm = new MemberDataEntry();
            memberEditForm.ShowDialog();
        }

        private void MoviesBtn_Click(object sender, EventArgs e)
        {
            MoviesForm movieEditForm = new MoviesForm();
            movieEditForm.ShowDialog();
        }

        private void GenreBtn_Click(object sender, EventArgs e)
        {
            GenreForm genreEditForm = new GenreForm();
            genreEditForm.ShowDialog();
        }

        private void RentalsBtn_Click(object sender, EventArgs e)
        {
            RentalMaintenceForm rentalEditForm = new RentalMaintenceForm();
            rentalEditForm.ShowDialog();
        }
        private void reportLbl_Click(object sender, EventArgs e)
        {
            ReportCenter reportsInterface = new ReportCenter();
            reportsInterface.ShowDialog();
        }
        private void AdminScreen_Load(object sender, EventArgs e)
        {
            nameLbl.Text = ActiveMember.First_Name;
        }
    }
}
