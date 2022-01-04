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
    public partial class CreateAccountScreen : Form
    {
        Member freshMember;
        int txtBoxIndex = -1;
        // invalid password gets passed as a reference if true display a messagebox with passwd requirements
        (bool, string) IsValidPassword;
        bool IsAdmin;
        (bool, string) IsValid;
        string appTitle = "Meramc Netflix";

        public CreateAccountScreen()
        {
            InitializeComponent();
        }
        public CreateAccountScreen(Member newMember)
        {
            InitializeComponent();
            freshMember = newMember.MemberCopy();          
        }
        // UX Button functionality
        // on the btn hover changes x and y are used to keep lable in same position
        private void submitBtn_MouseHover(object sender, EventArgs e)
        {
            CreateBtnsHover(submitBtn, 370, 324);
        }

        private void submitBtn_MouseLeave(object sender, EventArgs e)
        {
            CreateBtnsLeave(submitBtn, 370, 324);
        }
        private void CreateBtnsHover(System.Windows.Forms.Label lbl, int x, int y)
        {
            // You have to link all the events still
            // note the original img box is untitled 2 have to make another selectted 2nd imgbox
            Image himage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/untitled3.png");
            lbl.Location = new Point(x,y);
            lbl.Image = himage;
            lbl.Size = new Size(149, 31);
            lbl.ForeColor = System.Drawing.Color.Khaki;
        }
        private void CreateBtnsLeave(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image limage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/untitled2.png");
            lbl.Location = new Point(x, y);
            lbl.Image = limage;
            lbl.Size = new Size(149, 31);
            lbl.ForeColor = System.Drawing.Color.White;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            ResetErrrorProvider();
            IsValid = ValidateForm(ref txtBoxIndex);

            // if all field are filled then check username and password validity
            if (IsValid.Item1)
            {
                try
                {
                    bool goodAdd;
                    string pwd = confirmPasswordTxt.Text.Trim();
                    IsValidPassword = ValidatePassword(pwd);

                    if (IsValidPassword.Item1)
                    {
                        // other member properties where set with this forms constructor
                        // so set the remaining properties 
                        // encrypt password
                        freshMember.Username = userNameTxt.Text.Trim();
                        //Start here tomorrow
                        pwd = PwdProtector.Encrypt(pwd);
                        freshMember.Password = pwd;
                        // then add new member to the database
                        try
                        {
                            goodAdd = MemberDB.AddMember(freshMember);
                            IsAdmin = RegEx.IsAdmin(freshMember.Username);
                            if (goodAdd)
                            {
                                RentalScreen rentScreen = new RentalScreen(freshMember, IsAdmin);
                                rentScreen.ShowDialog();
                            }
                            else
                                DisplayErrorMsg("There was an issue adding new member to database", appTitle);
                        }
                        catch(Exception ex)
                        { DisplayErrorMsg(ex.Message, appTitle); }
                    }
                    else
                    {
                        PasswordRequirements requirementScreen = new PasswordRequirements(IsValidPassword.Item2);
                        requirementScreen.ShowDialog();
                    }                    
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBoxIndex, IsValid.Item2);

        }
        private void SetErrorProvider(int tbox, string eMsg)
        {
            switch (tbox)
            {
                case 0:
                    errPv.SetError(userNameTxt, eMsg);
                    break;
                case 1:
                    errPv.SetError(passwordTxt, eMsg);
                    break;
                case 2:
                    errPv.SetError(confirmPasswordTxt, eMsg);
                    break;
            }
        }
        private void ResetErrrorProvider()
        {
            errPv.Clear();
        }
        private void DisplayErrorMsg(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private (bool, string) ValidateForm(ref int tBxIndx)
        {
            bool isValid = true;
            string eMsg = string.Empty;

            if (string.IsNullOrEmpty(userNameTxt.Text))
            {
                isValid = false;
                tBxIndx = 0;
                eMsg = "You must enter a username";
            }
            else if (userNameTxt.Text.Length >= 21)
            {
                isValid = false;
                tBxIndx = 0;
                eMsg = "Username must be less than 20 characters";
            }
            else if (string.IsNullOrEmpty(passwordTxt.Text))
            {
                isValid = false;
                tBxIndx = 1;
                eMsg = "You must enter a password";
            }
            else if (passwordTxt.Text.Trim().Length <= 7 || passwordTxt.Text.Trim().Length >= 25)
            {
                isValid = false;
                tBxIndx = 1;
                eMsg = "Error password must be between 8 - 24 characters";
            }
            else if (string.IsNullOrEmpty(confirmPasswordTxt.Text))
            {
                isValid = false;
                tBxIndx = 2;
                eMsg = "You must confirm your password";
            }
            
            else if (confirmPasswordTxt.Text != passwordTxt.Text)
            {
                isValid = false;
                tBxIndx = 1;
                eMsg = "Error passwords do not match";
            }

            return (isValid, eMsg);   
        }
        private (bool,string) ValidatePassword(string pwd)
        {
            bool valid = true;
            string eMsg = string.Empty;
            int upperCount = 0, lowerCount = 0;
            bool digitFound = false, specialCharFound = false;
            

            // check to see password starts with letter or digit
            if (!char.IsLetter(pwd[0]) && !char.IsDigit(pwd[0]))
            {
                valid = false;
                eMsg = "Password must start with a letter or digit";
            }
            // get the number of capital and lower letters .. and check for any digits
            for (int letter = 0; letter <= pwd.Length-1; letter++)
            {
                if (char.IsUpper(pwd[letter]))
                    upperCount++;
                else if (char.IsLower(pwd[letter]))
                    lowerCount++;
                else if (char.IsDigit(pwd[letter]))
                    digitFound = true;
            }
            // check to see if password has any symbols in it
            // if it has symbols see if that symbol is in password requirements
            for (int letter = 0; letter <= pwd.Length-1 && !specialCharFound; letter++)
            {
                specialCharFound = CheckLetter(pwd[letter]);
            }
            if (upperCount == pwd.Length)
            {
                valid = false;
                eMsg = "Password cannot be all capital case letters";
            }
            else if (lowerCount == pwd.Length)
            {
                valid = false;
                eMsg = "Password cannot be all lower case letters";
            }
            else if (!digitFound)
            {
                valid = false;
                eMsg = "Password did not contain any digits";
            }
            else if (!specialCharFound)
            {
                valid = false;
                eMsg = "Password did not contain any symbols";
            }

            return (valid, eMsg);
        }
        private bool CheckLetter(char letter)
        {
            bool valid = false;
            char[] acceptedSymbols = new char[8] { '!', '@', '#', '$', '%', '^', '*', '-' };

            for (int symbl = 0; symbl <= acceptedSymbols.Length-1 && !valid; symbl++)
            {
                if (letter.Equals(acceptedSymbols[symbl]))
                    valid = true;
            }

            return valid;
        }
        private void CreateAccountScreen_Load(object sender, EventArgs e)
        {
            dneLbl.Text = $"(Your Almost Done {freshMember.First_Name})";
        }
    }
}
