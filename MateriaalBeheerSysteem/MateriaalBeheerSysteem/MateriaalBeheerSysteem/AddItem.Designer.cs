namespace MateriaalBeheerSysteem
{
    partial class AddItem
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblEventMaterialDetailsDailyrent = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsPrice = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsName = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.numRentPrice = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(139, 15);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(256, 20);
            this.tbName.TabIndex = 17;
            // 
            // lblEventMaterialDetailsDailyrent
            // 
            this.lblEventMaterialDetailsDailyrent.AutoSize = true;
            this.lblEventMaterialDetailsDailyrent.Location = new System.Drawing.Point(12, 75);
            this.lblEventMaterialDetailsDailyrent.Name = "lblEventMaterialDetailsDailyrent";
            this.lblEventMaterialDetailsDailyrent.Size = new System.Drawing.Size(72, 13);
            this.lblEventMaterialDetailsDailyrent.TabIndex = 16;
            this.lblEventMaterialDetailsDailyrent.Text = "Huur per dag:";
            // 
            // lblEventMaterialDetailsPrice
            // 
            this.lblEventMaterialDetailsPrice.AutoSize = true;
            this.lblEventMaterialDetailsPrice.Location = new System.Drawing.Point(12, 45);
            this.lblEventMaterialDetailsPrice.Name = "lblEventMaterialDetailsPrice";
            this.lblEventMaterialDetailsPrice.Size = new System.Drawing.Size(29, 13);
            this.lblEventMaterialDetailsPrice.TabIndex = 15;
            this.lblEventMaterialDetailsPrice.Text = "Prijs:";
            // 
            // lblEventMaterialDetailsName
            // 
            this.lblEventMaterialDetailsName.AutoSize = true;
            this.lblEventMaterialDetailsName.Location = new System.Drawing.Point(12, 15);
            this.lblEventMaterialDetailsName.Name = "lblEventMaterialDetailsName";
            this.lblEventMaterialDetailsName.Size = new System.Drawing.Size(38, 13);
            this.lblEventMaterialDetailsName.TabIndex = 14;
            this.lblEventMaterialDetailsName.Text = "Naam:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(139, 101);
            this.numAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(255, 20);
            this.numAmount.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Aantal:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(320, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(15, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // numRentPrice
            // 
            this.numRentPrice.DecimalPlaces = 2;
            this.numRentPrice.Location = new System.Drawing.Point(139, 73);
            this.numRentPrice.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numRentPrice.Name = "numRentPrice";
            this.numRentPrice.Size = new System.Drawing.Size(256, 20);
            this.numRentPrice.TabIndex = 24;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(139, 43);
            this.numPrice.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(255, 20);
            this.numPrice.TabIndex = 25;
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 170);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.numRentPrice);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblEventMaterialDetailsDailyrent);
            this.Controls.Add(this.lblEventMaterialDetailsPrice);
            this.Controls.Add(this.lblEventMaterialDetailsName);
            this.Name = "AddItem";
            this.Text = "AddItem";
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblEventMaterialDetailsDailyrent;
        private System.Windows.Forms.Label lblEventMaterialDetailsPrice;
        private System.Windows.Forms.Label lblEventMaterialDetailsName;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numRentPrice;
        private System.Windows.Forms.NumericUpDown numPrice;

    }
}