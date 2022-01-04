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
    public partial class PasswordRequirements : Form
    {
        string ErrorMessage = string.Empty;
        public PasswordRequirements()
        {
            InitializeComponent();
        }
        public PasswordRequirements(string errMsg)
        {
            InitializeComponent();
            ErrorMessage = errMsg;
        }

        private void PasswordRequirements_Load(object sender, EventArgs e)
        {
            errTxt.Text = ErrorMessage;
        }
    }
}
