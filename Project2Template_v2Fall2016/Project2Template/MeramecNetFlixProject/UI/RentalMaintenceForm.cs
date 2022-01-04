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
    public partial class RentalMaintenceForm : Form
    {
        (bool, string) isValid;
        int txtBxIndex = -1;
        string appTitle = "Meramc Netflix";
        List<Rental> rentalList = new List<Rental>();

        public RentalMaintenceForm()
        {
            InitializeComponent();
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            isValid = ValidateForm(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    Rental newRental = new Rental();
                    setNewRental(newRental);
                    bool goodInsert = RentalDB.AddRental(newRental);

                    if (goodInsert)
                        DisplaySuccessMsg("Rental inforamtion", "Added");
                    else
                        DisplayErrorMsg("Rental has not been added to the database", appTitle);
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);

            ClearText();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Rental> rentalList = new List<Rental>();
                rentalList = RentalDB.GetRentals();
                rentalsView.DataSource = rentalList;
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            isValid = IsValidSearch(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    Rental rentalRequest = new Rental();

                    if (string.IsNullOrEmpty(movieIdTxt.Text))
                    {
                        rentalRequest.Member_Number = Convert.ToInt32(memberIdTxt.Text.Trim());
                        rentalList = RentalDB.SpGetRentalByMember(rentalRequest);
                    }
                    else if (string.IsNullOrEmpty(memberIdTxt.Text))
                    {
                        rentalRequest.Movie_Number = Convert.ToInt32(movieIdTxt.Text.Trim());
                        rentalList = RentalDB.SpGetRentalByMovie(rentalRequest);
                    }
                    else if (!string.IsNullOrEmpty(memberIdTxt.Text) && !string.IsNullOrEmpty(movieIdTxt.Text))
                    {

                    }

                    rentalsView.DataSource = rentalList;
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);

            ClearText();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            isValid = ValidateForm(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    Rental updatedRental = new Rental();
                    setUpdateRental(updatedRental);
                    bool goodUpdate = RentalDB.UpdateRental(updatedRental);

                    if (goodUpdate)
                        DisplaySuccessMsg("Rental information", "Updated");
                    else
                        DisplayErrorMsg("Unable to updated rental in database", appTitle);
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);
            ClearText();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            isValid = ValidateDelete(ref txtBxIndex);

            if (isValid.Item1)
            {
                try
                {
                    DateTime purchaseDate = DateTime.Parse(rentDateTxt.Text); ;
                    Rental delRental = new Rental();
                    delRental.Movie_Number = Convert.ToInt32(movieIdTxt.Text.Trim());
                    delRental.Member_Number = Convert.ToInt32(memberIdTxt.Text.Trim());
                    delRental.Media_Purchase_Date = purchaseDate;
                    bool goodDel = RentalDB.DeleteRental(delRental);

                    if (goodDel)
                        DisplaySuccessMsg("Rental information", "Deleted");
                    else
                        DisplayErrorMsg("Unable to delete rental in database", appTitle);
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(txtBxIndex, isValid.Item2);

            ClearText();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearText();
            ClearForm();
        }
        private void ClearForm()
        {
            ClearText();
            rentalsView.DataSource = null;
        }
        private void ClearText()
        {
            movieIdTxt.Text = string.Empty;
            rentDateTxt.Text = string.Empty;
            memberIdTxt.Text = string.Empty;
            startDateTxt.Text = string.Empty;
            returnDateTxt.Text = string.Empty;
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setNewRental(Rental rental)
        {
            DateTime dateRented = DateTime.Parse(rentDateTxt.Text);
            DateTime streamDate = DateTime.Parse(startDateTxt.Text);
            DateTime returnDate = DateTime.Parse(returnDateTxt.Text);
            rental.Movie_Number = Convert.ToInt32(movieIdTxt.Text);
            rental.Member_Number = Convert.ToInt32(memberIdTxt.Text);
            rental.Media_Purchase_Date = dateRented;
            rental.Media_Streaming_Start_Date = streamDate;
            rental.Media_Return_Date = streamDate;
        }
        private void setUpdateRental(Rental rental)
        {
            DateTime purchaseDate = DateTime.Parse(rentDateTxt.Text);
            DateTime streamingDate = DateTime.Parse(startDateTxt.Text);
            DateTime returnDate = DateTime.Parse(returnDateTxt.Text); ;

            rental.Movie_Number = Convert.ToInt32(movieIdTxt.Text);
            rental.Member_Number = Convert.ToInt32(memberIdTxt.Text);
            rental.Media_Purchase_Date = purchaseDate;
            rental.Media_Streaming_Start_Date = streamingDate;
            rental.Media_Return_Date = returnDate;
        }
        private void DisplaySuccessMsg(string objName, string dbAction)
        {
            MessageBox.Show($"The {objName} has been {dbAction} in the database.", appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    errPv.SetError(movieIdTxt, errMsg);
                    break;
                case 1:
                    errPv.SetError(rentDateTxt, errMsg);
                    break;
                case 2:
                    errPv.SetError(memberIdTxt, errMsg);
                    break;
                case 3:
                    errPv.SetError(startDateTxt, errMsg);
                    break;
                case 4:
                    errPv.SetError(returnDateTxt, errMsg);
                    break;
            }
        }
        private void ResetErrorProvider()
        {
            errPv.Clear();
        }
        private (bool, string) ValidateForm(ref int txtBxIndx)
        {
            bool valid = true;
            string eMsg = string.Empty;
            int movieNum, memberNum;
            DateTime purDate, strDate, rDate;

            try
            {
                if (string.IsNullOrEmpty(movieIdTxt.Text))
                {
                    valid = false;
                    txtBxIndx = 0;
                    eMsg = "You must enter movie number";
                }
                else if (string.IsNullOrEmpty(rentDateTxt.Text))
                {
                    valid = false;
                    txtBxIndx = 1;
                    eMsg = "You must enter purchase date";
                }
                else if (string.IsNullOrEmpty(memberIdTxt.Text))
                {
                    valid = false;
                    txtBxIndx = 2;
                    eMsg = "You must enter member number";
                }
                else if (string.IsNullOrEmpty(startDateTxt.Text))
                {
                    valid = false;
                    txtBxIndx = 3;
                    eMsg = "You must enter streaming start date";
                }
                else if (!DateTime.TryParse(startDateTxt.Text, out strDate))
                {
                    valid = false;
                    txtBxIndx = 3;
                    eMsg = "Start date must be in Date time format";
                }
                else if (string.IsNullOrEmpty(returnDateTxt.Text))
                {
                    valid = false;
                    txtBxIndx = 4;
                    eMsg = "You must enter return date";
                }
                else if (!DateTime.TryParse(returnDateTxt.Text, out rDate))
                {
                    valid = false;
                    txtBxIndx = 4;
                    eMsg = "Return date must be in Date time format";
                }

                if (int.TryParse(movieIdTxt.Text, out movieNum))
                {
                    if (movieNum >= int.MaxValue || movieNum < 0)
                    {
                        valid = false;
                        txtBxIndx = 0;
                        eMsg = "Movie number out of bounds";
                    }
                }
                else if (!int.TryParse(movieIdTxt.Text, out movieNum))
                {
                    valid = false;
                    txtBxIndx = 0;
                    eMsg = "Only digits allowed for movie number";
                }
                if (int.TryParse(memberIdTxt.Text, out memberNum))
                {
                    if (memberNum >= int.MaxValue || memberNum < 0)
                    {
                        valid = false;
                        txtBxIndx = 0;
                        eMsg = "Member number out of bounds";
                    }
                }
                else if (!int.TryParse(memberIdTxt.Text, out memberNum))
                {
                    valid = false;
                    txtBxIndx = 2;
                    eMsg = "Only Digits allowed for member number";
                }

                if (DateTime.TryParse(rentDateTxt.Text, out purDate))
                {
                    if (purDate > DateTime.Today)
                    {
                        valid = false;
                        txtBxIndx = 4;
                        eMsg = "Purchase date cannot be past current date";
                    }
                }
                else if (!DateTime.TryParse(rentDateTxt.Text, out purDate))
                {
                    valid = false;
                    txtBxIndx = 4;
                    eMsg = "Rent/Purchase date must be in Date time format";
                }
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }

            return (valid, eMsg);
        }
        private (bool, string) IsValidSearch(ref int txtBxIndx)
        {
            bool valid = true;
            string eMsg = string.Empty;
            int movNum, memNum;

            try
            {
                if (string.IsNullOrEmpty(movieIdTxt.Text) && string.IsNullOrEmpty(memberIdTxt.Text))
                {
                    valid = false;
                    eMsg = "You must enter a movie number or member number to search";
                    txtBxIndx = 0;
                }
                if (string.IsNullOrEmpty(movieIdTxt.Text))
                {
                    //memNum = Convert.ToInt32(memberIdTxt.Text);

                    if (int.TryParse(memberIdTxt.Text,out memNum))
                    {
                        if (memNum >= int.MaxValue || memNum < 0)
                        {
                            valid = false;
                            eMsg = "Movie number is out of bounds";
                            txtBxIndx = 0;
                        }
                    }
                    else
                    {
                        valid = false;
                        eMsg = "Only digits allowed for movie number";
                        txtBxIndx = 0;
                    }
                    
                }
                else if (string.IsNullOrEmpty(memberIdTxt.Text))
                {
                    //movNum = Convert.ToInt32(movieIdTxt.Text);
                    if (int.TryParse(movieIdTxt.Text, out movNum))
                    {
                        if (movNum >= int.MaxValue || movNum < 0)
                        {
                            valid = false;
                            eMsg = "Member number is out of bounds";
                            txtBxIndx = 1;
                        }
                    }
                    else
                    {
                        valid = false;
                        eMsg = "Only digits allowed for member number";
                        txtBxIndx = 1;
                    }
                    
                }
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, appTitle); }

            return (valid, eMsg);
        }
        private (bool, string) ValidateDelete(ref int txtBxIndx)
        {
            bool valid = true;
            string errMsg = string.Empty;
            int memberNum, movieNum;
            DateTime purDate;

            if (string.IsNullOrEmpty(movieIdTxt.Text))
            {
                valid = false;
                txtBxIndex = 0;
                errMsg = "You must enter movie id";
            }
            else if (string.IsNullOrEmpty(memberIdTxt.Text))
            {
                valid = false;
                txtBxIndex = 2;
                errMsg = "You must enter member id";
            }
            else if (string.IsNullOrEmpty(rentDateTxt.Text))
            {
                valid = false;
                txtBxIndex = 1;
                errMsg = "You must enter purchase date";
            }
            memberNum = Convert.ToInt32(memberIdTxt.Text);
            movieNum = Convert.ToInt32(movieIdTxt.Text);
            purDate = DateTime.Parse(rentDateTxt.Text);

            if (memberNum >= int.MaxValue || memberNum < 0)
            {
                valid = false;
                txtBxIndx = 2;
                errMsg = "Member number out of bounds";
            }
            else if (movieNum >= int.MaxValue || movieNum < 0)
            {
                valid = false;
                txtBxIndx = 0;
                errMsg = "Movie number out of bounds";
            }
            else if (purDate > DateTime.Today)
            {
                valid = false;
                txtBxIndx = 1;
                errMsg = "Purchase date cannot be further then current date";
            }

            return (valid, errMsg);
        }
        // code for masktext rejects
        private void RentalMaintenceForm_Load(object sender, EventArgs e)
        {
            rentDateTxt.MaskInputRejected += new MaskInputRejectedEventHandler(rentDate_Rejected);
            startDateTxt.MaskInputRejected += new MaskInputRejectedEventHandler(startDate_Rejected);
            returnDateTxt.MaskInputRejected += new MaskInputRejectedEventHandler(returnDate_Rejected);
        }
        private void rentDate_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (rentDateTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid date, reached max number of digits allowed",rentDateTxt,3000);
            }
            else if (e.Position == rentDateTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Date";
                toolTip1.Show("You cannot add digits to the end of the date",rentDateTxt,3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid data";
                toolTip1.Show("Invaliid date format, only digits 0-9 allowed",rentDateTxt,3000);
            }
        }
        private void startDate_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (startDateTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid date, reached max number of digits allowed", startDateTxt, 3000);
            }
            else if (e.Position == startDateTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Date";
                toolTip1.Show("You cannot add digits to the end of the date", startDateTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid data";
                toolTip1.Show("Invaliid date format, only digits 0-9 allowed",startDateTxt, 3000);
            }
        }
        private void returnDate_Rejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            if (returnDateTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max number of digits";
                toolTip1.Show("Invalid date, reached max number of digits allowed", returnDateTxt, 3000);
            }
            else if (e.Position == returnDateTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Date";
                toolTip1.Show("You cannot add digits to the end of the date", returnDateTxt, 3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invlaid data";
                toolTip1.Show("Invaliid date format, only digits 0-9 allowed", returnDateTxt, 3000);
            }
        }
    }
}
