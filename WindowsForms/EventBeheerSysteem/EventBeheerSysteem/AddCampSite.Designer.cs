namespace EventBeheerSysteem
{
    partial class AddCampSite
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
            this.gboxEventBedsDetails = new System.Windows.Forms.GroupBox();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numSurfaceArea = new System.Windows.Forms.NumericUpDown();
            this.lblSurfaceArea = new System.Windows.Forms.Label();
            this.numMaxRenters = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblMaxRenters = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gboxEventBedsDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSurfaceArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRenters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxEventBedsDetails
            // 
            this.gboxEventBedsDetails.Controls.Add(this.numAmount);
            this.gboxEventBedsDetails.Controls.Add(this.label1);
            this.gboxEventBedsDetails.Controls.Add(this.numSurfaceArea);
            this.gboxEventBedsDetails.Controls.Add(this.lblSurfaceArea);
            this.gboxEventBedsDetails.Controls.Add(this.numMaxRenters);
            this.gboxEventBedsDetails.Controls.Add(this.numPrice);
            this.gboxEventBedsDetails.Controls.Add(this.lblMaxRenters);
            this.gboxEventBedsDetails.Controls.Add(this.lblPrice);
            this.gboxEventBedsDetails.Location = new System.Drawing.Point(12, 12);
            this.gboxEventBedsDetails.Name = "gboxEventBedsDetails";
            this.gboxEventBedsDetails.Size = new System.Drawing.Size(333, 123);
            this.gboxEventBedsDetails.TabIndex = 0;
            this.gboxEventBedsDetails.TabStop = false;
            this.gboxEventBedsDetails.Text = "Info";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(116, 95);
            this.numAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(211, 20);
            this.numAmount.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aantal:";
            // 
            // numSurfaceArea
            // 
            this.numSurfaceArea.Location = new System.Drawing.Point(116, 69);
            this.numSurfaceArea.Name = "numSurfaceArea";
            this.numSurfaceArea.Size = new System.Drawing.Size(211, 20);
            this.numSurfaceArea.TabIndex = 2;
            // 
            // lblSurfaceArea
            // 
            this.lblSurfaceArea.AutoSize = true;
            this.lblSurfaceArea.Location = new System.Drawing.Point(15, 71);
            this.lblSurfaceArea.Name = "lblSurfaceArea";
            this.lblSurfaceArea.Size = new System.Drawing.Size(68, 13);
            this.lblSurfaceArea.TabIndex = 6;
            this.lblSurfaceArea.Text = "Oppervlakte:";
            // 
            // numMaxRenters
            // 
            this.numMaxRenters.Location = new System.Drawing.Point(116, 43);
            this.numMaxRenters.Name = "numMaxRenters";
            this.numMaxRenters.Size = new System.Drawing.Size(211, 20);
            this.numMaxRenters.TabIndex = 1;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(116, 19);
            this.numPrice.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(211, 20);
            this.numPrice.TabIndex = 0;
            // 
            // lblMaxRenters
            // 
            this.lblMaxRenters.AutoSize = true;
            this.lblMaxRenters.Location = new System.Drawing.Point(15, 45);
            this.lblMaxRenters.Name = "lblMaxRenters";
            this.lblMaxRenters.Size = new System.Drawing.Size(76, 13);
            this.lblMaxRenters.TabIndex = 5;
            this.lblMaxRenters.Text = "Max Huurders:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(15, 21);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(29, 13);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Prijs:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(270, 141);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(14, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddCampSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 168);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gboxEventBedsDetails);
            this.Name = "AddCampSite";
            this.Text = "Kampeerplaats Toevoegen";
            this.gboxEventBedsDetails.ResumeLayout(false);
            this.gboxEventBedsDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSurfaceArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRenters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxEventBedsDetails;
        private System.Windows.Forms.NumericUpDown numMaxRenters;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblMaxRenters;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numSurfaceArea;
        private System.Windows.Forms.Label lblSurfaceArea;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label label1;
    }
}