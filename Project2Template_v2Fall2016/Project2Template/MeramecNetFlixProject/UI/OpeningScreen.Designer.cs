
namespace MeramecNetFlixProject.UI
{
    partial class OpeningScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpeningScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loginLblBtn = new System.Windows.Forms.Label();
            this.signUpLblBtn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(447, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 397);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(35, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(415, 450);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(59, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(369, 137);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(99, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Meramac Streaming Services";
            // 
            // loginLblBtn
            // 
            this.loginLblBtn.BackColor = System.Drawing.Color.White;
            this.loginLblBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLblBtn.ForeColor = System.Drawing.Color.White;
            this.loginLblBtn.Image = ((System.Drawing.Image)(resources.GetObject("loginLblBtn.Image")));
            this.loginLblBtn.Location = new System.Drawing.Point(101, 247);
            this.loginLblBtn.Name = "loginLblBtn";
            this.loginLblBtn.Size = new System.Drawing.Size(296, 55);
            this.loginLblBtn.TabIndex = 4;
            this.loginLblBtn.Text = "Login";
            this.loginLblBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginLblBtn.Click += new System.EventHandler(this.loginLblBtn_Click);
            this.loginLblBtn.MouseLeave += new System.EventHandler(this.loginLblBtn_MouseLeave);
            this.loginLblBtn.MouseHover += new System.EventHandler(this.loginLblBtn_MouseHover);
            // 
            // signUpLblBtn
            // 
            this.signUpLblBtn.BackColor = System.Drawing.Color.White;
            this.signUpLblBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLblBtn.ForeColor = System.Drawing.Color.White;
            this.signUpLblBtn.Image = ((System.Drawing.Image)(resources.GetObject("signUpLblBtn.Image")));
            this.signUpLblBtn.Location = new System.Drawing.Point(101, 307);
            this.signUpLblBtn.Name = "signUpLblBtn";
            this.signUpLblBtn.Size = new System.Drawing.Size(296, 55);
            this.signUpLblBtn.TabIndex = 5;
            this.signUpLblBtn.Text = "Sign-Up";
            this.signUpLblBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signUpLblBtn.Click += new System.EventHandler(this.signUpLblBtn_Click);
            this.signUpLblBtn.MouseLeave += new System.EventHandler(this.signUpLblBtn_MouseLeave);
            this.signUpLblBtn.MouseHover += new System.EventHandler(this.signUpLblBtn_MouseHover);
            // 
            // OpeningScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(847, 446);
            this.Controls.Add(this.signUpLblBtn);
            this.Controls.Add(this.loginLblBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "OpeningScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpeningScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label loginLblBtn;
        private System.Windows.Forms.Label signUpLblBtn;
    }
}