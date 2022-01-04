using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeramecNetFlixProject.UI
{
    public partial class OpeningScreen : Form
    {
        public OpeningScreen()
        {
            InitializeComponent();
        }

        // UX Button functionality
        // on the btn hover changes x and y are used to keep lable in same position
        private void loginLblBtn_MouseHover(object sender, EventArgs e)
        {
            OpenScreenBtnHover(loginLblBtn, 101, 247);
        }

        private void loginLblBtn_MouseLeave(object sender, EventArgs e)
        {
            OpenScreenBtnLeave(loginLblBtn, 101, 247);
        }

        private void signUpLblBtn_MouseHover(object sender, EventArgs e)
        {
            OpenScreenBtnHover(signUpLblBtn, 101, 307);
        }

        private void signUpLblBtn_MouseLeave(object sender, EventArgs e)
        {
            OpenScreenBtnLeave(signUpLblBtn, 101, 307);
        }

        private void OpenScreenBtnHover(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image himage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/image1.png");
            lbl.Image = himage;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(296, 55);
            lbl.ForeColor = System.Drawing.Color.Khaki;
        }
        private void OpenScreenBtnLeave(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image limage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/txtBoxBckgnd.png");
            lbl.Location = new Point(x, y);
            lbl.Image = limage;
            lbl.Size = new Size(296, 55);
            lbl.ForeColor = System.Drawing.Color.White;
        }

        private void loginLblBtn_Click(object sender, EventArgs e)
        {
            LoginScreen Login = new LoginScreen();
            Login.ShowDialog();
        }

        private void signUpLblBtn_Click(object sender, EventArgs e)
        {
            SignUpScreen signUp = new SignUpScreen();
            signUp.ShowDialog();
        }
    }
}
