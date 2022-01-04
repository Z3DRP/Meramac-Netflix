
namespace MeramecNetFlixProject.UI
{
    partial class MemberDataEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberDataEntry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InActiveRB = new System.Windows.Forms.RadioButton();
            this.activeRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.memberNumberTxt = new System.Windows.Forms.TextBox();
            this.zipTxt = new System.Windows.Forms.MaskedTextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.cellTxt = new System.Windows.Forms.MaskedTextBox();
            this.lastNameTxt = new System.Windows.Forms.TextBox();
            this.firstNameTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.joinDateTxt = new System.Windows.Forms.MaskedTextBox();
            this.memberView = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.errPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InActiveRB);
            this.groupBox1.Controls.Add(this.activeRB);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Member Status";
            // 
            // InActiveRB
            // 
            this.InActiveRB.AutoSize = true;
            this.InActiveRB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InActiveRB.Location = new System.Drawing.Point(79, 20);
            this.InActiveRB.Name = "InActiveRB";
            this.InActiveRB.Size = new System.Drawing.Size(75, 22);
            this.InActiveRB.TabIndex = 1;
            this.InActiveRB.Text = "InActive";
            this.InActiveRB.UseVisualStyleBackColor = true;
            // 
            // activeRB
            // 
            this.activeRB.AutoSize = true;
            this.activeRB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.activeRB.Location = new System.Drawing.Point(6, 20);
            this.activeRB.Name = "activeRB";
            this.activeRB.Size = new System.Drawing.Size(64, 22);
            this.activeRB.TabIndex = 0;
            this.activeRB.Text = "Active";
            this.activeRB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Join Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "First Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.memberNumberTxt);
            this.groupBox2.Controls.Add(this.zipTxt);
            this.groupBox2.Controls.Add(this.passwordTxt);
            this.groupBox2.Controls.Add(this.usernameTxt);
            this.groupBox2.Controls.Add(this.emailTxt);
            this.groupBox2.Controls.Add(this.cellTxt);
            this.groupBox2.Controls.Add(this.lastNameTxt);
            this.groupBox2.Controls.Add(this.firstNameTxt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.joinDateTxt);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(31, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Member Info";
            // 
            // memberNumberTxt
            // 
            this.memberNumberTxt.Location = new System.Drawing.Point(161, 40);
            this.memberNumberTxt.Name = "memberNumberTxt";
            this.memberNumberTxt.Size = new System.Drawing.Size(207, 24);
            this.memberNumberTxt.TabIndex = 1;
            this.toolTip1.SetToolTip(this.memberNumberTxt, "Added Member ids will automatically be converted to next number in sequence");
            // 
            // zipTxt
            // 
            this.zipTxt.Location = new System.Drawing.Point(161, 148);
            this.zipTxt.Mask = "00000";
            this.zipTxt.Name = "zipTxt";
            this.zipTxt.Size = new System.Drawing.Size(113, 24);
            this.zipTxt.TabIndex = 9;
            this.zipTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(161, 289);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(227, 24);
            this.passwordTxt.TabIndex = 17;
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(161, 256);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(210, 24);
            this.usernameTxt.TabIndex = 15;
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(161, 220);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(227, 24);
            this.emailTxt.TabIndex = 13;
            // 
            // cellTxt
            // 
            this.cellTxt.Location = new System.Drawing.Point(161, 184);
            this.cellTxt.Mask = "(999) 000-0000";
            this.cellTxt.Name = "cellTxt";
            this.cellTxt.Size = new System.Drawing.Size(150, 24);
            this.cellTxt.TabIndex = 11;
            this.cellTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.Location = new System.Drawing.Point(161, 112);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.Size = new System.Drawing.Size(328, 24);
            this.lastNameTxt.TabIndex = 7;
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.Location = new System.Drawing.Point(161, 76);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(259, 24);
            this.firstNameTxt.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Username:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cell Phone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Zipcode:";
            // 
            // joinDateTxt
            // 
            this.joinDateTxt.Location = new System.Drawing.Point(484, 40);
            this.joinDateTxt.Mask = "00/00/0000";
            this.joinDateTxt.Name = "joinDateTxt";
            this.joinDateTxt.Size = new System.Drawing.Size(100, 24);
            this.joinDateTxt.TabIndex = 3;
            this.joinDateTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.joinDateTxt.ValidatingType = typeof(System.DateTime);
            // 
            // memberView
            // 
            this.memberView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.memberView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memberView.Location = new System.Drawing.Point(27, 486);
            this.memberView.Name = "memberView";
            this.memberView.Size = new System.Drawing.Size(916, 150);
            this.memberView.TabIndex = 2;
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(50, 669);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(97, 33);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Add";
            this.toolTip1.SetToolTip(this.addBtn, "Added Member ids will automatically be converted to next number in sequence");
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseBtn.Location = new System.Drawing.Point(179, 668);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(97, 33);
            this.browseBtn.TabIndex = 4;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(437, 668);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(97, 33);
            this.updateBtn.TabIndex = 6;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(566, 668);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(97, 33);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(695, 668);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(97, 33);
            this.clearBtn.TabIndex = 8;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(824, 668);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(97, 33);
            this.exitBtn.TabIndex = 9;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(308, 669);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(97, 33);
            this.searchBtn.TabIndex = 5;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // errPv
            // 
            this.errPv.ContainerControl = this;
            this.errPv.Icon = ((System.Drawing.Icon)(resources.GetObject("errPv.Icon")));
            // 
            // MemberDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 728);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.memberView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemberDataEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member Data Management";
            this.Load += new System.EventHandler(this.MemberDataEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton InActiveRB;
        private System.Windows.Forms.RadioButton activeRB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox zipTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.MaskedTextBox cellTxt;
        private System.Windows.Forms.TextBox lastNameTxt;
        private System.Windows.Forms.TextBox firstNameTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox joinDateTxt;
        private System.Windows.Forms.DataGridView memberView;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox memberNumberTxt;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ErrorProvider errPv;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}