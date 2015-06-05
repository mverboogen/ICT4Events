namespace ReserveringSysteem
{
    partial class EnlargedPlattegrond
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
            this.pbPlattegrondLarge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlattegrondLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlattegrondLarge
            // 
            this.pbPlattegrondLarge.Image = global::ReserveringSysteem.Properties.Resources.CampingLarge;
            this.pbPlattegrondLarge.Location = new System.Drawing.Point(-2, 0);
            this.pbPlattegrondLarge.Name = "pbPlattegrondLarge";
            this.pbPlattegrondLarge.Size = new System.Drawing.Size(652, 482);
            this.pbPlattegrondLarge.TabIndex = 0;
            this.pbPlattegrondLarge.TabStop = false;
            this.pbPlattegrondLarge.Click += new System.EventHandler(this.pbPlattegrondLarge_Click);
            // 
            // Plattegrond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 482);
            this.Controls.Add(this.pbPlattegrondLarge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Plattegrond";
            this.Text = "Plattegrond";
            ((System.ComponentModel.ISupportInitialize)(this.pbPlattegrondLarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlattegrondLarge;
    }
}