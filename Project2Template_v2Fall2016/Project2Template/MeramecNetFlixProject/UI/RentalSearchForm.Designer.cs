
namespace MeramecNetFlixProject.UI
{
    partial class RentalSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentalSearchForm));
            this.searchFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.findBtn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Label();
            this.searchImgs = new System.Windows.Forms.ImageList(this.components);
            this.errPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.reelPbx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errPv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reelPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // searchFlow
            // 
            this.searchFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.searchFlow.Location = new System.Drawing.Point(34, 123);
            this.searchFlow.Name = "searchFlow";
            this.searchFlow.Size = new System.Drawing.Size(887, 388);
            this.searchFlow.TabIndex = 3;
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.ForeColor = System.Drawing.Color.White;
            this.findBtn.Image = ((System.Drawing.Image)(resources.GetObject("findBtn.Image")));
            this.findBtn.Location = new System.Drawing.Point(262, 548);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(157, 37);
            this.findBtn.TabIndex = 4;
            this.findBtn.Text = "Find";
            this.findBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            this.findBtn.MouseLeave += new System.EventHandler(this.findBtn_MouseLeave);
            this.findBtn.MouseHover += new System.EventHandler(this.findBtn_MouseHover);
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(306, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // searchTxt
            // 
            this.searchTxt.BackColor = System.Drawing.Color.Black;
            this.searchTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTxt.ForeColor = System.Drawing.Color.White;
            this.searchTxt.Location = new System.Drawing.Point(351, 63);
            this.searchTxt.Multiline = true;
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(258, 32);
            this.searchTxt.TabIndex = 2;
            this.searchTxt.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(397, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search Movies";
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.Color.White;
            this.clearBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearBtn.Image")));
            this.clearBtn.Location = new System.Drawing.Point(535, 548);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(157, 37);
            this.clearBtn.TabIndex = 6;
            this.clearBtn.Text = "Clear";
            this.clearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            this.clearBtn.MouseLeave += new System.EventHandler(this.clearBtn_MouseLeave);
            this.clearBtn.MouseHover += new System.EventHandler(this.clearBtn_MouseHover);
            // 
            // searchImgs
            // 
            this.searchImgs.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.searchImgs.ImageSize = new System.Drawing.Size(256, 256);
            this.searchImgs.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // errPv
            // 
            this.errPv.ContainerControl = this;
            this.errPv.Icon = ((System.Drawing.Icon)(resources.GetObject("errPv.Icon")));
            // 
            // reelPbx
            // 
            this.reelPbx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reelPbx.BackgroundImage")));
            this.reelPbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reelPbx.Location = new System.Drawing.Point(34, 112);
            this.reelPbx.Name = "reelPbx";
            this.reelPbx.Size = new System.Drawing.Size(887, 425);
            this.reelPbx.TabIndex = 7;
            this.reelPbx.TabStop = false;
            // 
            // RentalSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(955, 629);
            this.Controls.Add(this.reelPbx);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.searchFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RentalSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Movies";
            this.Load += new System.EventHandler(this.RentalSerachForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errPv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reelPbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel searchFlow;
        private System.Windows.Forms.Label findBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label clearBtn;
        private System.Windows.Forms.ImageList searchImgs;
        private System.Windows.Forms.ErrorProvider errPv;
        private System.Windows.Forms.PictureBox reelPbx;
    }
}