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
    public partial class SignUpScreen : Form
    {
        int txtBxIndex = -1;
        (bool, string) ValidEmail;
        (bool, string) IsValid;
        (bool, string) ValidPhone;
        string appTitle = "Meramc Netflix";
        Member FreshMember;
        public SignUpScreen()
        {
            InitializeComponent();
        }
        // UX Button functionality
        // on the btn hover changes x and y are used to keep lable in same position
        private void submitBtn_Click(object sender, EventArgs e)
        {
            ResetErrrorProvider();
            VisualEffect(submitBtn, 240, 458);
            IsValid = ValidateForm(ref txtBxIndex);
            
            try
            {
                if (IsValid.Item1)
                {
                    ValidEmail = ValidateEmail(ref txtBxIndex);
                    ValidPhone = ValidatePhone(ref txtBxIndex);
                    if (ValidEmail.Item1)
                    {
                        SetMember();
                        CreateAccountScreen createScreen = new CreateAccountScreen(FreshMember);
                        createScreen.ShowDialog();
                    }
                    else
                        SetErrorProvider(txtBxIndex, ValidEmail.Item2);                    
                }
                else
                    SetErrorProvider(txtBxIndex, IsValid.Item2);
            }
            catch(Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ResetErrrorProvider();
            VisualEffect(cancelBtn, 422, 458);
            firstNameTxt.Text = string.Empty;
            lastNameTxt.Text = string.Empty;
            emailTxt.Text = string.Empty;
            phoneTxt.Text = string.Empty;
            zipTxt.Text = string.Empty;
            CheckClose();
        }

        private void SignUpBtnsHover(System.Windows.Forms.Label lbl, int x, int y)
        {
            // You have to link all the events still

            // note the original img box is untitled 2 have to make another selectted 2nd imgbox
            Image himage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/btnhover.png");
            lbl.Image = himage;
            lbl.Size = new Size(154, 36);
            lbl.ForeColor = System.Drawing.Color.Khaki;
        }
        private void SignUpBtnsLeave(System.Windows.Forms.Label lbl, int x, int y)
        {
            Image limage = Image.FromFile("C:/C#2/Project2/DataFiles/Images/UXImgs/btn.png");
            lbl.Image = limage;
            lbl.Size = new Size(x,y);
            lbl.ForeColor = System.Drawing.Color.White;
        }
        private void VisualEffect(System.Windows.Forms.Label lblBtn, int x, int y)
        {
            // had to change events from hover and leave to just a submit
            // because when passing clicking the submit button then starting the new screen
            // there was an issue happening because the new form would be called threw show dialog but then the
            // mouse hover event would happen and loop the program back this form and not show the new screen
            // did not have time to go back and change the method names so just put them inside the click event
            SignUpBtnsHover(lblBtn, x, y);
            SignUpBtnsLeave(lblBtn, x, y);
        }

        private (bool,string) ValidateForm(ref int tboxIndex)
        {
            bool valid = true;
            string eMsg = string.Empty;

            if (string.IsNullOrEmpty(firstNameTxt.Text))
            {
                valid = false;
                tboxIndex = 0;
                eMsg = "You must enter a first name";
            }
            else if (firstNameTxt.Text.Length >= 16)
            {
                valid = false;
                tboxIndex = 0;
                eMsg = "You must enter a first name";
            }
            else if (string.IsNullOrEmpty(lastNameTxt.Text))
            {
                valid = false;
                tboxIndex = 1;
                eMsg = "You must enter a last name";
            }
            else if (lastNameTxt.Text.Length >= 26)
            {
                valid = false;
                tboxIndex = 1;
                eMsg = "Last name must be 26 characters or less";
            }
            else if (string.IsNullOrEmpty(emailTxt.Text))
            {
                valid = false;
                tboxIndex = 2;
                eMsg = "You must enter a email address";
            }
            else if (emailTxt.Text.Length >= 21)
            {
                valid = false;
                tboxIndex = 2;
                eMsg = "Email address must be 20 characters or less";
            }
            else if (string.IsNullOrEmpty(phoneTxt.Text))
            {
                valid = false;
                tboxIndex = 3;
                eMsg = "You must enter a phone number";
            }
            else if (phoneTxt.Text.Length != 10)
            {
                valid = false;
                tboxIndex = 3;
                eMsg = "Phone number must be 10 digits";
            }
            else if (string.IsNullOrEmpty(zipTxt.Text))
            {
                valid = false;
                tboxIndex = 4;
                eMsg = "You must enter a zipcode";
            }
            else if (zipTxt.Text.Length != 5)
            {
                valid = false;
                tboxIndex = 4;
                eMsg = "Zipcode must be 5 digits";
            }
            return (valid, eMsg);
        }
        private (bool,string) ValidateEmail(ref int txtBxIndx)
        {           
            string eMsg = string.Empty;
            string em = emailTxt.Text.Trim();
            bool valid = RegEx.ValidEmail(em);

            if (!valid)
            {
                eMsg = "Please enter a valid email address";
                txtBxIndx = 2;
            }

            return (valid, eMsg);
        }
        private (bool,string) ValidatePhone(ref int txtBx)
        {
            bool valid = true;
            string eMsg = string.Empty;

            if (!RegEx.ValidPhoneNumber(phoneTxt.Text.Trim()))
            {
                valid = false;
                txtBx = 3;
                eMsg = "Invalid phone number format, only ###-###-#### allowed";
            }
            return (valid, eMsg);
        }
        private void SetErrorProvider(int tbox,string eMsg)
        {
            switch (tbox)
            {
                case 0:
                    errPv.SetError(firstNameTxt, eMsg);
                    break;
                case 1:
                    errPv.SetError(lastNameTxt, eMsg);
                    break;
                case 2:
                    errPv.SetError(emailTxt, eMsg);
                    break;
                case 3:
                    errPv.SetError(phoneTxt, eMsg);
                    break;
                case 4:
                    errPv.SetError(zipTxt, eMsg);
                    break;
            }
        }
        private void SetMember()
        {
            try
            {
                FreshMember = new Member();
                DateTime today = DateTime.Today;
                FreshMember.Member_Status = "A";
                FreshMember.Member_Number = MemberDB.GetNextMemberNumber();
                FreshMember.Join_Date = today;
                FreshMember.First_Name = firstNameTxt.Text.Trim();
                FreshMember.Last_Name = lastNameTxt.Text.Trim();
                FreshMember.Email = emailTxt.Text.Trim();
                FreshMember.Cell_Phone = phoneTxt.Text.Trim();
                FreshMember.Zipcode = zipTxt.Text.Trim();
            }
            catch (Exception ex)
            { throw ex; }
        }
        private void CheckClose()
        {
            DialogResult result = MessageBox.Show("Do you want to close application ?", appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }
        private void ResetErrrorProvider()
        {
            errPv.Clear();
        }
        private void DisplayErrorMsg(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SignUpScreen_Load(object sender, EventArgs e)
        {
            phoneTxt.MaskInputRejected += new MaskInputRejectedEventHandler(PhoneReject);
            zipTxt.MaskInputRejected += new MaskInputRejectedEventHandler(ZipReject);
        }
        private void PhoneReject(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (phoneTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max Digits";
                toolTip1.Show("Invalid phone number, reached max number of digits allowed", phoneTxt, 3000);
            }
            else if (e.Position == phoneTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Number";
                toolTip1.Show("You cannot add digits to the end of the phone number", phoneTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invalid Data";
                toolTip1.Show("Invaliid format, only digits 0-9 allowed", phoneTxt, 3000);
            }
        }
        private void ZipReject(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (zipTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid zipcode, reached max number of digits allowed",zipTxt, 3000);
            }
            else if (e.Position == zipTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of zipcode";
                toolTip1.Show("You cannot add digits to the end of the zipcode", zipTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid Data";
                toolTip1.Show("Invaliid zipcode format, only digits 0-9 allowed", zipTxt, 3000);
            }
        }

        private void submitBtn_MouseHover(object sender, EventArgs e)
        {
            SignUpBtnsHover(submitBtn, 154, 36);
        }

        private void submitBtn_MouseLeave(object sender, EventArgs e)
        {
            SignUpBtnsLeave(submitBtn, 154, 36);
        }

        private void cancelBtn_MouseHover(object sender, EventArgs e)
        {
            SignUpBtnsHover(cancelBtn, 154, 36);
        }

        private void cancelBtn_MouseLeave(object sender, EventArgs e)
        {
            SignUpBtnsLeave(cancelBtn, 154, 36);
        }
    }
}
