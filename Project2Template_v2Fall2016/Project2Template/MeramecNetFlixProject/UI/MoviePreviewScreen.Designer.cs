
namespace MeramecNetFlixProject.UI
{
    partial class MoviePreviewScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoviePreviewScreen));
            this.movieImgPbx = new System.Windows.Forms.PictureBox();
            this.pbx1 = new System.Windows.Forms.PictureBox();
            this.orderSelectBtn = new System.Windows.Forms.Label();
            this.previewBtn = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Label();
            this.trailerBrowser = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.greyStar = new System.Windows.Forms.Label();
            this.goldStar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.infoLbl = new System.Windows.Forms.Label();
            this.summaryTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.movieImgPbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx1)).BeginInit();
            this.SuspendLayout();
            // 
            // movieImgPbx
            // 
            this.movieImgPbx.BackColor = System.Drawing.Color.DimGray;
            this.movieImgPbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.movieImgPbx.Location = new System.Drawing.Point(384, 10);
            this.movieImgPbx.Name = "movieImgPbx";
            this.movieImgPbx.Size = new System.Drawing.Size(370, 304);
            this.movieImgPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movieImgPbx.TabIndex = 0;
            this.movieImgPbx.TabStop = false;
            // 
            // pbx1
            // 
            this.pbx1.BackColor = System.Drawing.Color.Black;
            this.pbx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbx1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbx1.Location = new System.Drawing.Point(-4, -8);
            this.pbx1.Name = "pbx1";
            this.pbx1.Size = new System.Drawing.Size(370, 531);
            this.pbx1.TabIndex = 1;
            this.pbx1.TabStop = false;
            // 
            // orderSelectBtn
            // 
            this.orderSelectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderSelectBtn.ForeColor = System.Drawing.Color.White;
            this.orderSelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("orderSelectBtn.Image")));
            this.orderSelectBtn.Location = new System.Drawing.Point(-48, 272);
            this.orderSelectBtn.Name = "orderSelectBtn";
            this.orderSelectBtn.Size = new System.Drawing.Size(290, 42);
            this.orderSelectBtn.TabIndex = 4;
            this.orderSelectBtn.Text = "Order Selection";
            this.orderSelectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.orderSelectBtn.Click += new System.EventHandler(this.orderSelectBtn_Click);
            this.orderSelectBtn.Enter += new System.EventHandler(this.orderSelectBtn_Enter);
            this.orderSelectBtn.Leave += new System.EventHandler(this.orderSelectBtn_Leave);
            this.orderSelectBtn.MouseLeave += new System.EventHandler(this.orderSelectBtn_MouseLeave);
            this.orderSelectBtn.MouseHover += new System.EventHandler(this.orderSelectBtn_MouseHover);
            // 
            // previewBtn
            // 
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBtn.ForeColor = System.Drawing.Color.White;
            this.previewBtn.Image = ((System.Drawing.Image)(resources.GetObject("previewBtn.Image")));
            this.previewBtn.Location = new System.Drawing.Point(-48, 314);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(290, 42);
            this.previewBtn.TabIndex = 6;
            this.previewBtn.Text = "Preview Trailer";
            this.previewBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            this.previewBtn.Enter += new System.EventHandler(this.previewBtn_Enter);
            this.previewBtn.Leave += new System.EventHandler(this.previewBtn_Leave);
            this.previewBtn.MouseLeave += new System.EventHandler(this.previewBtn_MouseLeave);
            this.previewBtn.MouseHover += new System.EventHandler(this.previewBtn_MouseHover);
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Image = ((System.Drawing.Image)(resources.GetObject("backBtn.Image")));
            this.backBtn.Location = new System.Drawing.Point(-48, 356);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(290, 42);
            this.backBtn.TabIndex = 7;
            this.backBtn.Text = "Go Back";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            this.backBtn.Enter += new System.EventHandler(this.backBtn_Enter);
            this.backBtn.Leave += new System.EventHandler(this.backBtn_Leave);
            this.backBtn.MouseLeave += new System.EventHandler(this.backBtn_MouseLeave);
            this.backBtn.MouseHover += new System.EventHandler(this.backBtn_MouseHover);
            // 
            // trailerBrowser
            // 
            this.trailerBrowser.Location = new System.Drawing.Point(384, 320);
            this.trailerBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.trailerBrowser.Name = "trailerBrowser";
            this.trailerBrowser.ScrollBarsEnabled = false;
            this.trailerBrowser.Size = new System.Drawing.Size(734, 395);
            this.trailerBrowser.TabIndex = 6;
            this.trailerBrowser.Visible = false;
            this.trailerBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(33, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 71);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(73, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Add to Watch List";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // greyStar
            // 
            this.greyStar.Image = ((System.Drawing.Image)(resources.GetObject("greyStar.Image")));
            this.greyStar.Location = new System.Drawing.Point(214, 425);
            this.greyStar.Name = "greyStar";
            this.greyStar.Size = new System.Drawing.Size(34, 35);
            this.greyStar.TabIndex = 22;
            this.greyStar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.greyStar.Click += new System.EventHandler(this.greyStar_Click);
            // 
            // goldStar
            // 
            this.goldStar.Image = ((System.Drawing.Image)(resources.GetObject("goldStar.Image")));
            this.goldStar.Location = new System.Drawing.Point(214, 425);
            this.goldStar.Name = "goldStar";
            this.goldStar.Size = new System.Drawing.Size(34, 35);
            this.goldStar.TabIndex = 4;
            this.goldStar.Visible = false;
            this.goldStar.Click += new System.EventHandler(this.goldStar_Click);
            // 
            // label3
            // 
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(-21, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 71);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.BackColor = System.Drawing.Color.Transparent;
            this.titleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.Color.White;
            this.titleLbl.Location = new System.Drawing.Point(4, 32);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(66, 31);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Title";
            // 
            // label5
            // 
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(-21, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 71);
            this.label5.TabIndex = 2;
            this.label5.Text = "label5";
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLbl.ForeColor = System.Drawing.Color.White;
            this.infoLbl.Location = new System.Drawing.Point(7, 102);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(57, 16);
            this.infoLbl.TabIndex = 1;
            this.infoLbl.Text = "Rating ";
            // 
            // summaryTxt
            // 
            this.summaryTxt.BackColor = System.Drawing.Color.Black;
            this.summaryTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.summaryTxt.Cursor = System.Windows.Forms.Cursors.No;
            this.summaryTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryTxt.ForeColor = System.Drawing.Color.White;
            this.summaryTxt.Location = new System.Drawing.Point(777, 42);
            this.summaryTxt.Multiline = true;
            this.summaryTxt.Name = "summaryTxt";
            this.summaryTxt.ReadOnly = true;
            this.summaryTxt.Size = new System.Drawing.Size(328, 220);
            this.summaryTxt.TabIndex = 24;
            this.summaryTxt.TabStop = false;
            // 
            // MoviePreviewScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1130, 727);
            this.Controls.Add(this.summaryTxt);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.goldStar);
            this.Controls.Add(this.greyStar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trailerBrowser);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.orderSelectBtn);
            this.Controls.Add(this.pbx1);
            this.Controls.Add(this.movieImgPbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoviePreviewScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Preview";
            this.Load += new System.EventHandler(this.MoviePreviewScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.movieImgPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox movieImgPbx;
        private System.Windows.Forms.PictureBox pbx1;
        private System.Windows.Forms.Label orderSelectBtn;
        private System.Windows.Forms.Label previewBtn;
        private System.Windows.Forms.Label backBtn;
        private System.Windows.Forms.WebBrowser trailerBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label greyStar;
        private System.Windows.Forms.Label goldStar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.TextBox summaryTxt;
    }
}