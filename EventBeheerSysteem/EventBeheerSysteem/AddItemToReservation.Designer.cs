namespace EventBeheerSysteem
{
    partial class AddItemToReservation
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
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.tbCampSites = new System.Windows.Forms.TextBox();
            this.tbZipcode = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lboxMembers = new System.Windows.Forms.ListBox();
            this.lblEventVisitorsDetailsMembers = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsBookingDate = new System.Windows.Forms.Label();
            this.lblCampSites = new System.Windows.Forms.Label();
            this.lblZipcode = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblLastname = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAvailable = new System.Windows.Forms.TextBox();
            this.lboxReservations = new System.Windows.Forms.ListBox();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.Location = new System.Drawing.Point(144, 148);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(243, 20);
            this.dtpReservationDate.TabIndex = 43;
            // 
            // tbCampSites
            // 
            this.tbCampSites.Location = new System.Drawing.Point(144, 120);
            this.tbCampSites.Name = "tbCampSites";
            this.tbCampSites.ReadOnly = true;
            this.tbCampSites.Size = new System.Drawing.Size(243, 20);
            this.tbCampSites.TabIndex = 42;
            // 
            // tbZipcode
            // 
            this.tbZipcode.Location = new System.Drawing.Point(144, 95);
            this.tbZipcode.Name = "tbZipcode";
            this.tbZipcode.ReadOnly = true;
            this.tbZipcode.Size = new System.Drawing.Size(244, 20);
            this.tbZipcode.TabIndex = 41;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(144, 70);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(244, 20);
            this.tbAddress.TabIndex = 40;
            // 
            // tbLastname
            // 
            this.tbLastname.Location = new System.Drawing.Point(144, 43);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.ReadOnly = true;
            this.tbLastname.Size = new System.Drawing.Size(243, 20);
            this.tbLastname.TabIndex = 39;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(144, 15);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.ReadOnly = true;
            this.tbSurname.Size = new System.Drawing.Size(243, 20);
            this.tbSurname.TabIndex = 38;
            // 
            // lboxMembers
            // 
            this.lboxMembers.FormattingEnabled = true;
            this.lboxMembers.Location = new System.Drawing.Point(97, 176);
            this.lboxMembers.Name = "lboxMembers";
            this.lboxMembers.Size = new System.Drawing.Size(290, 95);
            this.lboxMembers.TabIndex = 37;
            // 
            // lblEventVisitorsDetailsMembers
            // 
            this.lblEventVisitorsDetailsMembers.AutoSize = true;
            this.lblEventVisitorsDetailsMembers.Location = new System.Drawing.Point(6, 177);
            this.lblEventVisitorsDetailsMembers.Name = "lblEventVisitorsDetailsMembers";
            this.lblEventVisitorsDetailsMembers.Size = new System.Drawing.Size(40, 13);
            this.lblEventVisitorsDetailsMembers.TabIndex = 36;
            this.lblEventVisitorsDetailsMembers.Text = "Leden:";
            // 
            // lblEventVisitorsDetailsBookingDate
            // 
            this.lblEventVisitorsDetailsBookingDate.AutoSize = true;
            this.lblEventVisitorsDetailsBookingDate.Location = new System.Drawing.Point(6, 153);
            this.lblEventVisitorsDetailsBookingDate.Name = "lblEventVisitorsDetailsBookingDate";
            this.lblEventVisitorsDetailsBookingDate.Size = new System.Drawing.Size(101, 13);
            this.lblEventVisitorsDetailsBookingDate.TabIndex = 35;
            this.lblEventVisitorsDetailsBookingDate.Text = "Reserveringsdatum:";
            // 
            // lblCampSites
            // 
            this.lblCampSites.AutoSize = true;
            this.lblCampSites.Location = new System.Drawing.Point(6, 123);
            this.lblCampSites.Name = "lblCampSites";
            this.lblCampSites.Size = new System.Drawing.Size(80, 13);
            this.lblCampSites.TabIndex = 34;
            this.lblCampSites.Text = "Kampeerplaats:";
            // 
            // lblZipcode
            // 
            this.lblZipcode.AutoSize = true;
            this.lblZipcode.Location = new System.Drawing.Point(6, 98);
            this.lblZipcode.Name = "lblZipcode";
            this.lblZipcode.Size = new System.Drawing.Size(55, 13);
            this.lblZipcode.TabIndex = 33;
            this.lblZipcode.Text = "Postcode:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 73);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(37, 13);
            this.lblAddress.TabIndex = 32;
            this.lblAddress.Text = "Adres:";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(6, 46);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(67, 13);
            this.lblLastname.TabIndex = 31;
            this.lblLastname.Text = "Achternaam:";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(6, 16);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(58, 13);
            this.lblSurname.TabIndex = 30;
            this.lblSurname.Text = "Voornaam:";
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.lblSurname);
            this.gbDetails.Controls.Add(this.dtpReservationDate);
            this.gbDetails.Controls.Add(this.lblLastname);
            this.gbDetails.Controls.Add(this.tbCampSites);
            this.gbDetails.Controls.Add(this.lblAddress);
            this.gbDetails.Controls.Add(this.tbZipcode);
            this.gbDetails.Controls.Add(this.lblZipcode);
            this.gbDetails.Controls.Add(this.tbAddress);
            this.gbDetails.Controls.Add(this.lblCampSites);
            this.gbDetails.Controls.Add(this.tbLastname);
            this.gbDetails.Controls.Add(this.lblEventVisitorsDetailsBookingDate);
            this.gbDetails.Controls.Add(this.tbSurname);
            this.gbDetails.Controls.Add(this.lblEventVisitorsDetailsMembers);
            this.gbDetails.Controls.Add(this.lboxMembers);
            this.gbDetails.Location = new System.Drawing.Point(325, 12);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(402, 278);
            this.gbDetails.TabIndex = 44;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Details";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(494, 347);
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(133, 20);
            this.numAmount.TabIndex = 45;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(419, 349);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(40, 13);
            this.lblAmount.TabIndex = 46;
            this.lblAmount.Text = "Aantal:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(649, 344);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 48;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Beschikbaar:";
            // 
            // tbAvailable
            // 
            this.tbAvailable.Location = new System.Drawing.Point(494, 314);
            this.tbAvailable.Name = "tbAvailable";
            this.tbAvailable.ReadOnly = true;
            this.tbAvailable.Size = new System.Drawing.Size(133, 20);
            this.tbAvailable.TabIndex = 44;
            // 
            // lboxReservations
            // 
            this.lboxReservations.FormattingEnabled = true;
            this.lboxReservations.Location = new System.Drawing.Point(12, 12);
            this.lboxReservations.Name = "lboxReservations";
            this.lboxReservations.Size = new System.Drawing.Size(305, 355);
            this.lboxReservations.TabIndex = 50;
            this.lboxReservations.SelectedIndexChanged += new System.EventHandler(this.lboxReservations_SelectedIndexChanged);
            // 
            // AddItemToReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 381);
            this.Controls.Add(this.lboxReservations);
            this.Controls.Add(this.tbAvailable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.gbDetails);
            this.Name = "AddItemToReservation";
            this.Text = "AddItemToReservation";
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.TextBox tbCampSites;
        private System.Windows.Forms.TextBox tbZipcode;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.ListBox lboxMembers;
        private System.Windows.Forms.Label lblEventVisitorsDetailsMembers;
        private System.Windows.Forms.Label lblEventVisitorsDetailsBookingDate;
        private System.Windows.Forms.Label lblCampSites;
        private System.Windows.Forms.Label lblZipcode;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAvailable;
        private System.Windows.Forms.ListBox lboxReservations;
    }
}