namespace EventBeheerSysteem
{
    partial class EbsAddEventForm
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
            this.lblAddEventNaam = new System.Windows.Forms.Label();
            this.lblAddEventLocatie = new System.Windows.Forms.Label();
            this.lblAddEventBeginDate = new System.Windows.Forms.Label();
            this.lblAddEventEndDate = new System.Windows.Forms.Label();
            this.tbAddEventName = new System.Windows.Forms.TextBox();
            this.tbAddEventLocation = new System.Windows.Forms.TextBox();
            this.dtpAddEventBeginDate = new System.Windows.Forms.DateTimePicker();
            this.dtpAddEventEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddEventCancel = new System.Windows.Forms.Button();
            this.btnAddEventOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddEventNaam
            // 
            this.lblAddEventNaam.AutoSize = true;
            this.lblAddEventNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEventNaam.Location = new System.Drawing.Point(25, 25);
            this.lblAddEventNaam.Name = "lblAddEventNaam";
            this.lblAddEventNaam.Size = new System.Drawing.Size(89, 17);
            this.lblAddEventNaam.TabIndex = 0;
            this.lblAddEventNaam.Text = "Event Naam:";
            // 
            // lblAddEventLocatie
            // 
            this.lblAddEventLocatie.AutoSize = true;
            this.lblAddEventLocatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEventLocatie.Location = new System.Drawing.Point(25, 75);
            this.lblAddEventLocatie.Name = "lblAddEventLocatie";
            this.lblAddEventLocatie.Size = new System.Drawing.Size(98, 17);
            this.lblAddEventLocatie.TabIndex = 1;
            this.lblAddEventLocatie.Text = "Event Lokatie:";
            // 
            // lblAddEventBeginDate
            // 
            this.lblAddEventBeginDate.AutoSize = true;
            this.lblAddEventBeginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEventBeginDate.Location = new System.Drawing.Point(25, 125);
            this.lblAddEventBeginDate.Name = "lblAddEventBeginDate";
            this.lblAddEventBeginDate.Size = new System.Drawing.Size(127, 17);
            this.lblAddEventBeginDate.TabIndex = 2;
            this.lblAddEventBeginDate.Text = "Event Begindatum:";
            // 
            // lblAddEventEndDate
            // 
            this.lblAddEventEndDate.AutoSize = true;
            this.lblAddEventEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEventEndDate.Location = new System.Drawing.Point(25, 175);
            this.lblAddEventEndDate.Name = "lblAddEventEndDate";
            this.lblAddEventEndDate.Size = new System.Drawing.Size(119, 17);
            this.lblAddEventEndDate.TabIndex = 3;
            this.lblAddEventEndDate.Text = "Event Einddatum:";
            // 
            // tbAddEventName
            // 
            this.tbAddEventName.Location = new System.Drawing.Point(150, 25);
            this.tbAddEventName.Name = "tbAddEventName";
            this.tbAddEventName.Size = new System.Drawing.Size(200, 20);
            this.tbAddEventName.TabIndex = 4;
            // 
            // tbAddEventLocation
            // 
            this.tbAddEventLocation.Location = new System.Drawing.Point(150, 75);
            this.tbAddEventLocation.Name = "tbAddEventLocation";
            this.tbAddEventLocation.Size = new System.Drawing.Size(200, 20);
            this.tbAddEventLocation.TabIndex = 5;
            // 
            // dtpAddEventBeginDate
            // 
            this.dtpAddEventBeginDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAddEventBeginDate.Location = new System.Drawing.Point(150, 125);
            this.dtpAddEventBeginDate.Name = "dtpAddEventBeginDate";
            this.dtpAddEventBeginDate.Size = new System.Drawing.Size(200, 20);
            this.dtpAddEventBeginDate.TabIndex = 6;
            // 
            // dtpAddEventEndDate
            // 
            this.dtpAddEventEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAddEventEndDate.Location = new System.Drawing.Point(150, 175);
            this.dtpAddEventEndDate.Name = "dtpAddEventEndDate";
            this.dtpAddEventEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpAddEventEndDate.TabIndex = 7;
            // 
            // btnAddEventCancel
            // 
            this.btnAddEventCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddEventCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEventCancel.Location = new System.Drawing.Point(150, 225);
            this.btnAddEventCancel.Name = "btnAddEventCancel";
            this.btnAddEventCancel.Size = new System.Drawing.Size(95, 25);
            this.btnAddEventCancel.TabIndex = 8;
            this.btnAddEventCancel.Text = "Annuleren";
            this.btnAddEventCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddEventOk
            // 
            this.btnAddEventOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEventOk.Location = new System.Drawing.Point(255, 225);
            this.btnAddEventOk.Name = "btnAddEventOk";
            this.btnAddEventOk.Size = new System.Drawing.Size(95, 25);
            this.btnAddEventOk.TabIndex = 9;
            this.btnAddEventOk.Text = "Toevoegen";
            this.btnAddEventOk.UseVisualStyleBackColor = true;
            this.btnAddEventOk.Click += new System.EventHandler(this.btnAddEventOk_Click);
            // 
            // EbsAddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddEventOk);
            this.Controls.Add(this.btnAddEventCancel);
            this.Controls.Add(this.dtpAddEventEndDate);
            this.Controls.Add(this.dtpAddEventBeginDate);
            this.Controls.Add(this.tbAddEventLocation);
            this.Controls.Add(this.tbAddEventName);
            this.Controls.Add(this.lblAddEventEndDate);
            this.Controls.Add(this.lblAddEventBeginDate);
            this.Controls.Add(this.lblAddEventLocatie);
            this.Controls.Add(this.lblAddEventNaam);
            this.Name = "EbsAddEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Toevoegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddEventNaam;
        private System.Windows.Forms.Label lblAddEventLocatie;
        private System.Windows.Forms.Label lblAddEventBeginDate;
        private System.Windows.Forms.Label lblAddEventEndDate;
        private System.Windows.Forms.TextBox tbAddEventName;
        private System.Windows.Forms.TextBox tbAddEventLocation;
        private System.Windows.Forms.DateTimePicker dtpAddEventBeginDate;
        private System.Windows.Forms.DateTimePicker dtpAddEventEndDate;
        private System.Windows.Forms.Button btnAddEventCancel;
        private System.Windows.Forms.Button btnAddEventOk;
    }
}