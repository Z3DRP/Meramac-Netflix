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
    public partial class GenreForm : Form
    {
        (bool, string) ValidData;
        int textBxIndex = -1;
        string appTitle = "Meramac Netflix";
        public GenreForm()
        {
            InitializeComponent();
            
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            try
            {
                List<Genre> ListOfGenres = new List<Genre>();

                ListOfGenres = GenreDB.GetGenres();

                dataGridView1.DataSource = ListOfGenres;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            // validate ui 
            ValidData = ValidateForm(ref textBxIndex);

            // if form has valid data then follow through with update otherwise show error message
            if (ValidData.Item1)
            {
                try
                {
                    Genre objGenre = new Genre();
                    objGenre.id = Convert.ToInt32(textBox1.Text.Trim());
                    objGenre.name = textBox2.Text.Trim();

                    bool status = GenreDB.UpdateGenre(objGenre);
                    if (status)
                    {
                        MessageBox.Show("Genre Id has been updated to the database.", "MeramacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Genre Id has not been added to the database.", "MeramacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, appTitle);
                }
            }
            else
                SetErrorProvider(textBxIndex, ValidData.Item2);

            ClearText();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            // validate ui 
            ValidData = ValidateDelete(ref textBxIndex);

            // if form has good data delete from DB
            if (ValidData.Item1)
            {
                //get genre obj 
                Genre objGenre = new Genre();
                objGenre.id = Convert.ToInt32(textBox1.Text.Trim());
                objGenre.name = textBox2.Text.Trim();

                try
                {
                    bool status = GenreDB.DeleteGenre(objGenre);
                    if (status)
                    {
                        MessageBox.Show("Genre Id has been deleted from the database.", "MeramacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Genre Id has not been deleted from the database.", "MeramacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, appTitle);
                }
            }
            else
                SetErrorProvider(textBxIndex, ValidData.Item2);
            ClearText();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            ValidData = ValidateForm(ref textBxIndex);

            if (ValidData.Item1)
            {              
                try
                {
                    Genre genreObj = new Genre();
                    genreObj.id = GenreDB.GetNextGenreNumber();
                    genreObj.name = textBox2.Text.Trim();
                    bool goodInsert = GenreDB.AddGenre(genreObj);

                    if(goodInsert)
                    {
                        DisplaySuccessMsg("Genre", "Added to");
                    }
                    else
                        MessageBox.Show("Genre has not been deleted from the database.", "MeramacNetflix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, appTitle);
                }
            }
            else
                SetErrorProvider(textBxIndex, ValidData.Item2);

            ClearText();
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearText();
            ClearForm();
        }
        // method to check form for null and empty
        private (bool, string) ValidateForm(ref int txtBxIndx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                valid = false;
                txtBxIndx = 0;
                errMsg = "You must enter a genre id.";
            }
            else if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                valid = false;
                txtBxIndx = 1;
                errMsg = "You must enter a genre name.";
            }
            else if (textBox2.Text.Length >= 31)
            {
                valid = false;
                txtBxIndx = 1;
                errMsg = "Genre name must be less than 30 characters";
            }

            return (valid, errMsg);        
        }
        private (bool,string) ValidateDelete(ref int txtBxIndex)
        {
            bool valid = true;
            string errMsg = string.Empty;
            
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                valid = false;
                txtBxIndex = 0;
                errMsg = "You must enter a genre id number to delete";
            }
            return (valid, errMsg);
        }
        private (bool,string) ValidateSearch(ref int tbxindx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                valid = false;
                tbxindx = 0;
                errMsg = "You must enter a genre id or name to search";
            }
            return (valid, errMsg);
        }
        // method to display good database trancsactions
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
                    errPv.SetError(textBox1, errMsg);
                    break;
                case 1:
                    errPv.SetError(textBox2, errMsg);
                    break;
            }
        }
        private void ResetErrorProvider()
        {
            errPv.Clear();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            ResetErrorProvider();
            ValidData = ValidateSearch(ref textBxIndex);

            if (ValidData.Item1)
            {
                List<Genre> requestedGenres = new List<Genre>();
                Genre requestedGenre = new Genre();
                try
                { 
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        requestedGenre.name = textBox2.Text.Trim();
                        requestedGenres = GenreDB.SpGetGenreByName(requestedGenre.name);
                    }
                    else if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        requestedGenre.id = Convert.ToInt32(textBox1.Text.Trim());
                        requestedGenres = GenreDB.SpGetGenreById(requestedGenre.id);
                    }
                              
                    dataGridView1.DataSource = requestedGenres;

                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, appTitle); }
            }
            else
                SetErrorProvider(textBxIndex, ValidData.Item2);
            
            ClearText();
        }
        private void ClearText()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
        private void ClearForm()
        {
            ClearText();
            dataGridView1.DataSource = null;
        }
    }
}
