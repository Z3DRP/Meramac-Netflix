
namespace MeramecNetFlixProject.UI
{
    partial class MoviesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoviesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trailerLinkTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.imgFileTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.descriptionTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.durationCbx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ratingCmbx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.genreCmbx = new System.Windows.Forms.ComboBox();
            this.yearMadeTxt = new System.Windows.Forms.MaskedTextBox();
            this.movieNumTxt = new System.Windows.Forms.TextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.moviesView = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.errPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movie Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Year Made:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Genre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trailerLinkTxt);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.imgFileTxt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.descriptionTxt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.titleTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.durationCbx);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ratingCmbx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.genreCmbx);
            this.groupBox1.Controls.Add(this.yearMadeTxt);
            this.groupBox1.Controls.Add(this.movieNumTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // trailerLinkTxt
            // 
            this.trailerLinkTxt.Location = new System.Drawing.Point(124, 320);
            this.trailerLinkTxt.Name = "trailerLinkTxt";
            this.trailerLinkTxt.Size = new System.Drawing.Size(549, 24);
            this.trailerLinkTxt.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Trailer Link:";
            // 
            // imgFileTxt
            // 
            this.imgFileTxt.Location = new System.Drawing.Point(124, 281);
            this.imgFileTxt.Name = "imgFileTxt";
            this.imgFileTxt.Size = new System.Drawing.Size(549, 24);
            this.imgFileTxt.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Image Filename:";
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.Location = new System.Drawing.Point(124, 133);
            this.descriptionTxt.Multiline = true;
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(549, 119);
            this.descriptionTxt.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Description:";
            // 
            // titleTxt
            // 
            this.titleTxt.Location = new System.Drawing.Point(357, 25);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(340, 24);
            this.titleTxt.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Title:";
            // 
            // durationCbx
            // 
            this.durationCbx.FormattingEnabled = true;
            this.durationCbx.Location = new System.Drawing.Point(611, 71);
            this.durationCbx.Name = "durationCbx";
            this.durationCbx.Size = new System.Drawing.Size(168, 26);
            this.durationCbx.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rental Duration:";
            // 
            // ratingCmbx
            // 
            this.ratingCmbx.FormattingEnabled = true;
            this.ratingCmbx.Location = new System.Drawing.Point(785, 23);
            this.ratingCmbx.Name = "ratingCmbx";
            this.ratingCmbx.Size = new System.Drawing.Size(83, 26);
            this.ratingCmbx.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(725, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rating:";
            // 
            // genreCmbx
            // 
            this.genreCmbx.FormattingEnabled = true;
            this.genreCmbx.Location = new System.Drawing.Point(68, 73);
            this.genreCmbx.Name = "genreCmbx";
            this.genreCmbx.Size = new System.Drawing.Size(150, 26);
            this.genreCmbx.TabIndex = 7;
            // 
            // yearMadeTxt
            // 
            this.yearMadeTxt.Location = new System.Drawing.Point(345, 73);
            this.yearMadeTxt.Mask = "0000";
            this.yearMadeTxt.Name = "yearMadeTxt";
            this.yearMadeTxt.Size = new System.Drawing.Size(100, 24);
            this.yearMadeTxt.TabIndex = 9;
            this.yearMadeTxt.ValidatingType = typeof(int);
            // 
            // movieNumTxt
            // 
            this.movieNumTxt.Location = new System.Drawing.Point(124, 25);
            this.movieNumTxt.Name = "movieNumTxt";
            this.movieNumTxt.Size = new System.Drawing.Size(147, 24);
            this.movieNumTxt.TabIndex = 1;
            this.toolTip1.SetToolTip(this.movieNumTxt, "Added Movie ids will automatically be converted to next number in sequence");
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(669, 553);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(92, 34);
            this.clearBtn.TabIndex = 7;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // moviesView
            // 
            this.moviesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moviesView.Location = new System.Drawing.Point(18, 396);
            this.moviesView.Name = "moviesView";
            this.moviesView.Size = new System.Drawing.Size(914, 134);
            this.moviesView.TabIndex = 1;
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(69, 553);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(92, 34);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Add";
            this.toolTip1.SetToolTip(this.addBtn, "Added Movie ids will automatically be converted to next number in sequence");
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseBtn.Location = new System.Drawing.Point(189, 553);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(92, 34);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(429, 553);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(92, 34);
            this.updateBtn.TabIndex = 5;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(549, 553);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(92, 34);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(789, 553);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(92, 34);
            this.exitBtn.TabIndex = 8;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(309, 553);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(92, 34);
            this.searchBtn.TabIndex = 4;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // errPv
            // 
            this.errPv.ContainerControl = this;
            this.errPv.Icon = ((System.Drawing.Icon)(resources.GetObject("errPv.Icon")));
            // 
            // MoviesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 614);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.moviesView);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoviesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Data Management";
            this.Load += new System.EventHandler(this.MoviesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox trailerLinkTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox imgFileTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox descriptionTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox durationCbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ratingCmbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox genreCmbx;
        private System.Windows.Forms.MaskedTextBox yearMadeTxt;
        private System.Windows.Forms.TextBox movieNumTxt;
        private System.Windows.Forms.DataGridView moviesView;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ErrorProvider errPv;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}