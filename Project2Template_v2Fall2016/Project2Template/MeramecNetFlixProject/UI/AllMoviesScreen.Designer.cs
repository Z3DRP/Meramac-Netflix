
namespace MeramecNetFlixProject.UI
{
    partial class AllMoviesScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllMoviesScreen));
            this.allMoviesFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.movieImgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // allMoviesFlow
            // 
            this.allMoviesFlow.AutoScroll = true;
            this.allMoviesFlow.BackColor = System.Drawing.Color.Transparent;
            this.allMoviesFlow.Location = new System.Drawing.Point(34, 75);
            this.allMoviesFlow.Name = "allMoviesFlow";
            this.allMoviesFlow.Size = new System.Drawing.Size(887, 494);
            this.allMoviesFlow.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(336, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movies A-Z";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movieImgList
            // 
            this.movieImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.movieImgList.ImageSize = new System.Drawing.Size(256, 256);
            this.movieImgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AllMoviesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(955, 629);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allMoviesFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllMoviesScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movies";
            this.Load += new System.EventHandler(this.AllMoviesScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel allMoviesFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList movieImgList;
    }
}