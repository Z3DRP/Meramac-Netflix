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
    public partial class MemberDataEntry : Form
    {
        (bool, string) ValidForm;
        string appTitle = "Meramc Netflix";
        int txtBxIndex = -1;

        public MemberDataEntry()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            
            ValidForm = ValidateForm(ref txtBxIndex);
            if (ValidForm.Item1)
            {
                
                try
                {
                    Member newMember = new Member();
                    SetNewMember(newMember,false);
                    bool goodInsert = MemberDB.AddMember(newMember);

                    if (goodInsert)
                    {
                        DisplaySuccessMsg("Member", "Added to");
                    }
                    else
                        DisplayErrorMsg("Member has not been added from the database.", appTitle);
                }
                catch(Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, ValidForm.Item2);
            ClearText();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();

            try
            {
                List<Member> memberList = new List<Member>();
                memberList = MemberDB.GetMembers();
                memberView.DataSource = memberList;
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {           
            ResetErrorProvider();
            ValidForm = ValidateSearch(ref txtBxIndex);

            if (ValidForm.Item1)
            {
                Member wantedMember = new Member();
                Member returnedMember = new Member();
                List<Member> memberList = new List<Member>();
                BindingList<Member> mlist = new BindingList<Member>();

                try
                {
                    if (string.IsNullOrEmpty(memberNumberTxt.Text))
                    {
                        // search by last name
                        wantedMember.Last_Name = lastNameTxt.Text.Trim();
                        // memberList = MemberDB.GetMember(wantedMember);
                        memberList = MemberDB.SpGetMembersByLastname(wantedMember.Last_Name);
                    }
                    else if (string.IsNullOrEmpty(lastNameTxt.Text))
                    {
                        wantedMember.Member_Number = Convert.ToInt32(memberNumberTxt.Text);
                        //memberList = MemberDB.GetMember(wantedMember, "by id");
                        memberList = MemberDB.SpGetMemberById(wantedMember.Member_Number);
                    }
                    memberView.DataSource = memberList;
                }
                catch(Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, ValidForm.Item2);

            ClearText();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            ValidForm = ValidateForm(ref txtBxIndex);

            if (ValidForm.Item1)
            {
                try
                {
                    Member updatedMember = new Member();
                    SetNewMember(updatedMember,true);
                    bool goodUpdate = MemberDB.UpdateMember(updatedMember);

                    if (goodUpdate)
                        DisplaySuccessMsg("Member ", "Updated");
                    else
                        DisplayErrorMsg("Unable to updated member in database", appTitle);
                }
                catch(Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, ValidForm.Item2);

            ClearText();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ValidForm = ValidateDelete(ref txtBxIndex);

            if (ValidForm.Item1)
            {
                try
                {
                    Member delMember = new Member();
                    delMember.Member_Number = Convert.ToInt32(memberNumberTxt.Text.Trim());
                    bool goodDel = MemberDB.DeleteMember(delMember);

                    if (goodDel)
                        DisplaySuccessMsg("Member", "Deleted");
                    else
                        DisplayErrorMsg("Unable to delete member in database", appTitle);
                }
                catch(Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, ValidForm.Item2);

            ClearText();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            ClearText();
            ClearForm();
        }
        private void ClearForm()
        {
            ClearText();
            memberView.DataSource = null;
        }
        private void ClearText()
        {
            activeRB.Checked = false;
            InActiveRB.Checked = false;
            memberNumberTxt.Text = string.Empty;
            joinDateTxt.Text = string.Empty;
            firstNameTxt.Text = string.Empty;
            lastNameTxt.Text = string.Empty;
            zipTxt.Text = string.Empty;
            cellTxt.Text = string.Empty;
            emailTxt.Text = string.Empty;
            usernameTxt.Text = string.Empty;
            passwordTxt.Text = string.Empty;
        }
        private (bool, string) ValidateForm(ref int textBoxIndex)
        {
            bool valid = true;
            string errMsg = string.Empty;
            
            try 
            {
                DateTime today = DateTime.Today;
                DateTime joinday;

                if (!activeRB.Checked && !InActiveRB.Checked)
                {
                    valid = false;
                    textBoxIndex = 0;
                    errMsg = "You must selected a member status";
                }
                else if (string.IsNullOrEmpty(memberNumberTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 2;
                    errMsg = "You must enter a member number";
                }
                else if (string.IsNullOrEmpty(joinDateTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 3;
                    errMsg = "You must enter a join date";
                }
                else if (DateTime.TryParse(joinDateTxt.Text, out joinday))
                {
                    if (joinday > today)
                    {
                        valid = false;
                        textBoxIndex = 3;
                        errMsg = "Join date cannot be later then current date";
                    }
                }
                else if (!DateTime.TryParse(joinDateTxt.Text, out joinday))
                {
                    valid = false;
                    textBoxIndex = 3;
                    errMsg = "Join date must be in Date time format";
                }
                
                else if (string.IsNullOrEmpty(firstNameTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 4;
                    errMsg = "You must enter a first name";
                }
                else if (firstNameTxt.Text.Length >= 16)
                {
                    valid = false;
                    textBoxIndex = 4;
                    errMsg = "First name must be less then 15 characters";
                }
                else if (string.IsNullOrEmpty(lastNameTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 5;
                    errMsg = "You must enter a last name";
                }
                else if (lastNameTxt.Text.Length >= 26)
                {
                    valid = false;
                    textBoxIndex = 6;
                    errMsg = "Last name must be less then 25 characters";
                }
                else if (string.IsNullOrEmpty(zipTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 6;
                    errMsg = "You must enter a zip code";
                }
                else if (zipTxt.Text.Length >= 6)
                {
                    valid = false;
                    textBoxIndex = 6;
                    errMsg = "Zipcode must be 5 characters";
                }
                else if (string.IsNullOrEmpty(cellTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 7;
                    errMsg = "You must enter a cell phone number";
                }
                else if (cellTxt.Text.Length != 10)
                {
                    valid = false;
                    textBoxIndex = 7;
                    errMsg = "Phone number must be 10 characters";
                }
                else if (string.IsNullOrEmpty(emailTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 8;
                    errMsg = "You must enter a email address";
                }
                else if (emailTxt.Text.Length >= 21)
                {
                    valid = false;
                    textBoxIndex = 8;
                    errMsg = "Email must be less 20 characters or less";
                }
                else if (string.IsNullOrEmpty(usernameTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 9;
                    errMsg = "You must enter a username";
                }
                else if (usernameTxt.Text.Length >= 21)
                {
                    valid = false;
                    textBoxIndex = 9;
                    errMsg = "Username must be 20 characters or less";
                }
                else if (string.IsNullOrEmpty(passwordTxt.Text))
                {
                    valid = false;
                    textBoxIndex = 10;
                    errMsg = "You must enter a password";
                }
                else if (passwordTxt.Text.Length >= 25)
                {
                    valid = false;
                    textBoxIndex = 10;
                    errMsg = "Password must be 24 characters or less";
                }

            }
             catch(Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }

            return (valid, errMsg);
        }
        private (bool,string) ValidateSearch(ref int textBoxIndex)
        {
            bool valid= true;
            string errMsg = string.Empty;
            if (string.IsNullOrEmpty(memberNumberTxt.Text) && string.IsNullOrEmpty(lastNameTxt.Text))
            {
                valid = false;
                textBoxIndex = 2;
                errMsg = "You must enter a member id or last name to search";
            }
            else if (lastNameTxt.Text.Length >= 26)
            {
                valid = false;
                textBoxIndex = 5;
                errMsg = "Last name must be less than 25 characters";
            }

            return (valid,errMsg);
        }
        private (bool,string) ValidateDelete(ref int textBoxIndex)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(memberNumberTxt.Text))
            {
                valid = false;
                textBoxIndex = 2;
                errMsg = "You must enter a member number to delete";
            }
            return (valid, errMsg);
        }
        private void SetNewMember(Member newMember, bool isUpdate)
        {
            DateTime join = DateTime.Parse(joinDateTxt.Text);
            if (activeRB.Checked)
                newMember.Member_Status = "A";
            if (InActiveRB.Checked)
                newMember.Member_Status = "I";
            if (!isUpdate)
                newMember.Member_Number = MemberDB.GetNextMemberNumber();
            else
                newMember.Member_Number = Convert.ToInt32(memberNumberTxt.Text);

            newMember.Join_Date = join;
            newMember.First_Name = firstNameTxt.Text.Trim();
            newMember.Last_Name = lastNameTxt.Text.Trim();
            newMember.Zipcode = zipTxt.Text.Trim();
            newMember.Cell_Phone = cellTxt.Text.Trim();
            newMember.Email = emailTxt.Text.Trim();
            newMember.Username = usernameTxt.Text.Trim();
            newMember.Password = PwdProtector.Encrypt(passwordTxt.Text.Trim());
        }
        // displays msgbox for succes actions on db
        private void DisplaySuccessMsg(string objName, string dbAction)
        {
            MessageBox.Show($"The {objName} has been {dbAction} the database.", "MeramacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // method to display messageboxes for errors
        private void DisplayErrorMsg(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void SetErrorProvider(int txtBxIndex, string errMsg)
        {
            switch (txtBxIndex)
            {
                case 0:
                    errPv.SetError(InActiveRB, errMsg);
                    break;
                case 1:
                    errPv.SetError(InActiveRB, errMsg);
                    break;
                case 2:
                    errPv.SetError(memberNumberTxt, errMsg);
                    break;
                case 3:
                    errPv.SetError(joinDateTxt, errMsg);
                    break;
                case 4:
                    errPv.SetError(firstNameTxt, errMsg);
                    break;
                case 5:
                    errPv.SetError(lastNameTxt, errMsg);
                    break;
                case 6:
                    errPv.SetError(zipTxt, errMsg);
                    break;
                case 7:
                    errPv.SetError(cellTxt, errMsg);
                    break;
                case 8:
                    errPv.SetError(emailTxt, errMsg);
                    break;
                case 9:
                    errPv.SetError(usernameTxt, errMsg);
                    break;
                case 10:
                    errPv.SetError(passwordTxt, errMsg);
                    break;
            }
        }
        private void ResetErrorProvider()
        {
            errPv.Clear();
        }

        private void MemberDataEntry_Load(object sender, EventArgs e)
        {
            activeRB.Checked = false;
            InActiveRB.Checked = false;
            joinDateTxt.MaskInputRejected += new MaskInputRejectedEventHandler(joinDate_Rejected);
            zipTxt.MaskInputRejected += new MaskInputRejectedEventHandler(zip_Rejected);
            cellTxt.MaskInputRejected += new MaskInputRejectedEventHandler(cell_Rejected);
        }
        private void joinDate_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (joinDateTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid date, reached max number of digits allowed", joinDateTxt, 3000);
            }
            else if (e.Position == joinDateTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Date";
                toolTip1.Show("You cannot add digits to the end of the date", joinDateTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid data";
                toolTip1.Show("Invaliid date format, only digits 0-9 allowed", joinDateTxt, 3000);
            }
        }
        private void zip_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (zipTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid zipcpde, reached max number of digits allowed", zipTxt, 3000);
            }
            else if (e.Position == zipTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of zipcode";
                toolTip1.Show("You cannot add digits to the end of the zipcode", zipTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid data";
                toolTip1.Show("Invaliid zipcode format, only digits 0-9 allowed", zipTxt, 3000);
            }
        }
        private void cell_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (cellTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid phone number, reached max number of digits allowed", cellTxt, 3000);
            }
            else if (e.Position == cellTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Phone number";
                toolTip1.Show("You cannot add digits to the end of the phone number", cellTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid data";
                toolTip1.Show("Invaliid phone number format, only digits 0-9 allowed", cellTxt, 3000);
            }
        }
    }
}
