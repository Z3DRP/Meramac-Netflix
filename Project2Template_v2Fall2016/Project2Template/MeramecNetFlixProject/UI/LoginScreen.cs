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
    public partial class LoginScreen : Form
    {
        string userName = string.Empty;
        string appTitle = "Meramac Netflix";
        bool IsAdmin;
        int imgIndx = 0;
        Login FreshLogin;
        Login Credintials;
        Member CurrentMember;
        RentalScreen RentScreen;
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void submitBtn_MouseClick(object sender, MouseEventArgs e)
        {
            // validate the user entered the correct username and password if so Rental screen
            // if not then user errPv to show error
            bool valid = ValidateForm();
            if (valid)
            {
                try
                {
                    Login FreshLogin = new Login();
                    Login Credintials = new Login();
                    bool validPwd;

                    FreshLogin.UserName = usernameTxt.Text.Trim();
                    FreshLogin.Password = passwordTxt.Text.Trim();
                    Credintials = LoginDB.GetLogin(FreshLogin);

                    if (FreshLogin.UserName.Equals(Credintials.UserName))
                    {
                        // if valid user name then check the encrypted password against the entered password
                        validPwd = PwdProtector.CompareEncryption(Credintials, FreshLogin);

                        if (validPwd)
                        {
                            // check to see if username is an admin
                            CurrentMember = LoginDB.SpGetMember(FreshLogin);
                            IsAdmin = RegEx.IsAdmin(FreshLogin);
                            ClearForm();
                            usernameTxt.Focus();
                            RentScreen = new RentalScreen(CurrentMember, IsAdmin);
                            // adds event handler so when home is clicked on rental screen it will send event
                            // to this form then both forms will close so opening screen is active form
                            RentScreen.GoHome += HandleGoHome;
                            RentScreen.ShowDialog();
                        }
                        else
                            errPv.SetError(passwordTxt, "Invalid Password");
                    }
                    else
                        errPv.SetError(usernameTxt, "Invalid Username");
                
                }
                catch (Exception ex)
                { DisplayError(ex.Message, appTitle); }
            }
            
        }
        // event handler for rental screen home button
        private void HandleGoHome(object sender, EventArgs args)
        {
            this.Close();
            RentScreen.Close();
        }
        // UX Button functionality
        // on the btn hover changes x and y are used to keep lable in same position
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            usernameTxt.Focus();
        }

        private void submitBtn_MouseHover(object sender, EventArgs e)
        {
            LoginBtnsHover(submitBtn, 369, 283);
        }

        private void submitBtn_MouseLeave(object sender, EventArgs e)
        {
            LoginBtnsLeave(submitBtn, 369, 283);
        }
        // on the btn hover changes x and y are used to keep lable in same position
        private void LoginBtnsHover(System.Windows.Forms.Label lbl, int x, int y)
        {
            // You have to link all the events still

            // note the original img box is untitled 2 have to make another selectted 2nd imgbox
            Image himage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/untitled3.png");
            lbl.Location = new Point(x, y);
            lbl.Image = himage;
            lbl.Size = new Size(151, 28);
            lbl.ForeColor = System.Drawing.Color.Khaki;
        }
        private void LoginBtnsLeave(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image limage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/untitled2.png");
            lbl.Location = new Point(x, y);
            lbl.Image = limage;
            lbl.Size = new Size(151, 28);
            lbl.ForeColor = System.Drawing.Color.White;
        }
        private void ClearForm()
        {
            usernameTxt.Text = string.Empty;
            passwordTxt.Text = string.Empty;
        }
        private bool ValidateForm()
        {
            bool valid = true;
            ResetErrPvd();
            if (string.IsNullOrEmpty(usernameTxt.Text))
            {
                usernameTxt.Focus();
                errPv.SetError(usernameTxt, "Please enter your username.");
                valid = false;
            }
            else if (usernameTxt.Text.Length >= 21)
            {
                usernameTxt.Focus();
                errPv.SetError(usernameTxt, "Password must be less than 20 characters");
                valid = false;
            }
            else if (string.IsNullOrEmpty(passwordTxt.Text))
            {
                passwordTxt.Focus();
                errPv.SetError(passwordTxt, "Please enter your password.");
                valid = false;
            }
            else if (passwordTxt.Text.Length >= 25 || passwordTxt.Text.Length <= 7)
            {
                passwordTxt.Focus();
                errPv.SetError(passwordTxt, "Password must be between 8 and 24 characters");
                valid = false;
            }
                
            return valid;
        }
        private void ResetErrPvd()
        {
            errPv.SetError(usernameTxt, string.Empty);
            errPv.SetError(passwordTxt, string.Empty);
            errPv.Clear();
        }
        private void DisplayError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
