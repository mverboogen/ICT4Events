namespace ToegangsControleSysteem
{
    partial class IncheckSystemForm
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
            this.btnVisitorSave = new System.Windows.Forms.Button();
            this.cboxVisitorPayed = new System.Windows.Forms.CheckBox();
            this.cboxVisitorPresent = new System.Windows.Forms.CheckBox();
            this.dtpVisitorReservationDate = new System.Windows.Forms.DateTimePicker();
            this.tbVisitorCampSite = new System.Windows.Forms.TextBox();
            this.tbVisitorZipcode = new System.Windows.Forms.TextBox();
            this.tbVisitorAddress = new System.Windows.Forms.TextBox();
            this.tbVisitorLastname = new System.Windows.Forms.TextBox();
            this.tbVisitorSurname = new System.Windows.Forms.TextBox();
            this.btnVisitorDelete = new System.Windows.Forms.Button();
            this.btnVisitorAdd = new System.Windows.Forms.Button();
            this.lboxVisitorsDetailsMaterials = new System.Windows.Forms.ListBox();
            this.lblEventVisitorsDetailsMaterials = new System.Windows.Forms.Label();
            this.lboxVisitorsDetailsMembers = new System.Windows.Forms.ListBox();
            this.lblEventVisitorsDetailsMembers = new System.Windows.Forms.Label();
            this.gboxEventVisitorsDetails = new System.Windows.Forms.GroupBox();
            this.lblEventVisitorsDetailsBookingDate = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsBednr = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsZipcode = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsAddress = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsLastname = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsSurname = new System.Windows.Forms.Label();
            this.lboxAllVisitors = new System.Windows.Forms.ListBox();
            this.tbAllVisitorsSearch = new System.Windows.Forms.TextBox();
            this.lblEventVisitors = new System.Windows.Forms.Label();
            this.tbcVisitors = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.tpInchecked = new System.Windows.Forms.TabPage();
            this.lboxCheckedInVisitors = new System.Windows.Forms.ListBox();
            this.tbCheckedInVisitors = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxEventVisitorsDetails.SuspendLayout();
            this.tbcVisitors.SuspendLayout();
            this.tpAll.SuspendLayout();
            this.tpInchecked.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVisitorSave
            // 
            this.btnVisitorSave.Location = new System.Drawing.Point(312, 213);
            this.btnVisitorSave.Name = "btnVisitorSave";
            this.btnVisitorSave.Size = new System.Drawing.Size(88, 23);
            this.btnVisitorSave.TabIndex = 32;
            this.btnVisitorSave.Text = "Opslaan";
            this.btnVisitorSave.UseVisualStyleBackColor = true;
            this.btnVisitorSave.Click += new System.EventHandler(this.btnVisitorSave_Click);
            // 
            // cboxVisitorPayed
            // 
            this.cboxVisitorPayed.AutoSize = true;
            this.cboxVisitorPayed.Location = new System.Drawing.Point(234, 192);
            this.cboxVisitorPayed.Name = "cboxVisitorPayed";
            this.cboxVisitorPayed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxVisitorPayed.Size = new System.Drawing.Size(86, 17);
            this.cboxVisitorPayed.TabIndex = 31;
            this.cboxVisitorPayed.Text = "       :Betaald";
            this.cboxVisitorPayed.UseVisualStyleBackColor = true;
            // 
            // cboxVisitorPresent
            // 
            this.cboxVisitorPresent.AutoSize = true;
            this.cboxVisitorPresent.Location = new System.Drawing.Point(22, 192);
            this.cboxVisitorPresent.Name = "cboxVisitorPresent";
            this.cboxVisitorPresent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxVisitorPresent.Size = new System.Drawing.Size(90, 17);
            this.cboxVisitorPresent.TabIndex = 30;
            this.cboxVisitorPresent.Text = "     :Aanwezig";
            this.cboxVisitorPresent.UseVisualStyleBackColor = true;
            // 
            // dtpVisitorReservationDate
            // 
            this.dtpVisitorReservationDate.Location = new System.Drawing.Point(160, 148);
            this.dtpVisitorReservationDate.Name = "dtpVisitorReservationDate";
            this.dtpVisitorReservationDate.Size = new System.Drawing.Size(243, 20);
            this.dtpVisitorReservationDate.TabIndex = 29;
            // 
            // tbVisitorCampSite
            // 
            this.tbVisitorCampSite.Location = new System.Drawing.Point(160, 120);
            this.tbVisitorCampSite.Name = "tbVisitorCampSite";
            this.tbVisitorCampSite.Size = new System.Drawing.Size(243, 20);
            this.tbVisitorCampSite.TabIndex = 27;
            // 
            // tbVisitorZipcode
            // 
            this.tbVisitorZipcode.Location = new System.Drawing.Point(160, 95);
            this.tbVisitorZipcode.Name = "tbVisitorZipcode";
            this.tbVisitorZipcode.Size = new System.Drawing.Size(244, 20);
            this.tbVisitorZipcode.TabIndex = 26;
            // 
            // tbVisitorAddress
            // 
            this.tbVisitorAddress.Location = new System.Drawing.Point(160, 70);
            this.tbVisitorAddress.Name = "tbVisitorAddress";
            this.tbVisitorAddress.Size = new System.Drawing.Size(244, 20);
            this.tbVisitorAddress.TabIndex = 25;
            // 
            // tbVisitorLastname
            // 
            this.tbVisitorLastname.Location = new System.Drawing.Point(160, 43);
            this.tbVisitorLastname.Name = "tbVisitorLastname";
            this.tbVisitorLastname.Size = new System.Drawing.Size(243, 20);
            this.tbVisitorLastname.TabIndex = 23;
            // 
            // tbVisitorSurname
            // 
            this.tbVisitorSurname.Location = new System.Drawing.Point(160, 15);
            this.tbVisitorSurname.Name = "tbVisitorSurname";
            this.tbVisitorSurname.Size = new System.Drawing.Size(243, 20);
            this.tbVisitorSurname.TabIndex = 22;
            // 
            // btnVisitorDelete
            // 
            this.btnVisitorDelete.Location = new System.Drawing.Point(312, 348);
            this.btnVisitorDelete.Name = "btnVisitorDelete";
            this.btnVisitorDelete.Size = new System.Drawing.Size(91, 23);
            this.btnVisitorDelete.TabIndex = 18;
            this.btnVisitorDelete.Text = "Verwijderen";
            this.btnVisitorDelete.UseVisualStyleBackColor = true;
            this.btnVisitorDelete.Click += new System.EventHandler(this.btnVisitorDelete_Click);
            // 
            // btnVisitorAdd
            // 
            this.btnVisitorAdd.Location = new System.Drawing.Point(113, 348);
            this.btnVisitorAdd.Name = "btnVisitorAdd";
            this.btnVisitorAdd.Size = new System.Drawing.Size(99, 23);
            this.btnVisitorAdd.TabIndex = 16;
            this.btnVisitorAdd.Text = "Toevoegen";
            this.btnVisitorAdd.UseVisualStyleBackColor = true;
            this.btnVisitorAdd.Click += new System.EventHandler(this.btnVisitorAdd_Click);
            // 
            // lboxVisitorsDetailsMaterials
            // 
            this.lboxVisitorsDetailsMaterials.FormattingEnabled = true;
            this.lboxVisitorsDetailsMaterials.Location = new System.Drawing.Point(113, 377);
            this.lboxVisitorsDetailsMaterials.Name = "lboxVisitorsDetailsMaterials";
            this.lboxVisitorsDetailsMaterials.Size = new System.Drawing.Size(291, 95);
            this.lboxVisitorsDetailsMaterials.TabIndex = 15;
            // 
            // lblEventVisitorsDetailsMaterials
            // 
            this.lblEventVisitorsDetailsMaterials.AutoSize = true;
            this.lblEventVisitorsDetailsMaterials.Location = new System.Drawing.Point(25, 377);
            this.lblEventVisitorsDetailsMaterials.Name = "lblEventVisitorsDetailsMaterials";
            this.lblEventVisitorsDetailsMaterials.Size = new System.Drawing.Size(56, 13);
            this.lblEventVisitorsDetailsMaterials.TabIndex = 14;
            this.lblEventVisitorsDetailsMaterials.Text = "Materialen";
            // 
            // lboxVisitorsDetailsMembers
            // 
            this.lboxVisitorsDetailsMembers.FormattingEnabled = true;
            this.lboxVisitorsDetailsMembers.Location = new System.Drawing.Point(113, 242);
            this.lboxVisitorsDetailsMembers.Name = "lboxVisitorsDetailsMembers";
            this.lboxVisitorsDetailsMembers.Size = new System.Drawing.Size(290, 95);
            this.lboxVisitorsDetailsMembers.TabIndex = 13;
            // 
            // lblEventVisitorsDetailsMembers
            // 
            this.lblEventVisitorsDetailsMembers.AutoSize = true;
            this.lblEventVisitorsDetailsMembers.Location = new System.Drawing.Point(22, 243);
            this.lblEventVisitorsDetailsMembers.Name = "lblEventVisitorsDetailsMembers";
            this.lblEventVisitorsDetailsMembers.Size = new System.Drawing.Size(40, 13);
            this.lblEventVisitorsDetailsMembers.TabIndex = 12;
            this.lblEventVisitorsDetailsMembers.Text = "Leden:";
            // 
            // gboxEventVisitorsDetails
            // 
            this.gboxEventVisitorsDetails.Controls.Add(this.btnVisitorSave);
            this.gboxEventVisitorsDetails.Controls.Add(this.cboxVisitorPayed);
            this.gboxEventVisitorsDetails.Controls.Add(this.cboxVisitorPresent);
            this.gboxEventVisitorsDetails.Controls.Add(this.dtpVisitorReservationDate);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbVisitorCampSite);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbVisitorZipcode);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbVisitorAddress);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbVisitorLastname);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbVisitorSurname);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnVisitorDelete);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnVisitorAdd);
            this.gboxEventVisitorsDetails.Controls.Add(this.lboxVisitorsDetailsMaterials);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsMaterials);
            this.gboxEventVisitorsDetails.Controls.Add(this.lboxVisitorsDetailsMembers);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsMembers);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsBookingDate);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsBednr);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsZipcode);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsAddress);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsLastname);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsSurname);
            this.gboxEventVisitorsDetails.Location = new System.Drawing.Point(345, 12);
            this.gboxEventVisitorsDetails.Name = "gboxEventVisitorsDetails";
            this.gboxEventVisitorsDetails.Size = new System.Drawing.Size(410, 481);
            this.gboxEventVisitorsDetails.TabIndex = 7;
            this.gboxEventVisitorsDetails.TabStop = false;
            this.gboxEventVisitorsDetails.Text = "Details";
            // 
            // lblEventVisitorsDetailsBookingDate
            // 
            this.lblEventVisitorsDetailsBookingDate.AutoSize = true;
            this.lblEventVisitorsDetailsBookingDate.Location = new System.Drawing.Point(22, 153);
            this.lblEventVisitorsDetailsBookingDate.Name = "lblEventVisitorsDetailsBookingDate";
            this.lblEventVisitorsDetailsBookingDate.Size = new System.Drawing.Size(101, 13);
            this.lblEventVisitorsDetailsBookingDate.TabIndex = 10;
            this.lblEventVisitorsDetailsBookingDate.Text = "Reserveringsdatum:";
            // 
            // lblEventVisitorsDetailsBednr
            // 
            this.lblEventVisitorsDetailsBednr.AutoSize = true;
            this.lblEventVisitorsDetailsBednr.Location = new System.Drawing.Point(22, 123);
            this.lblEventVisitorsDetailsBednr.Name = "lblEventVisitorsDetailsBednr";
            this.lblEventVisitorsDetailsBednr.Size = new System.Drawing.Size(80, 13);
            this.lblEventVisitorsDetailsBednr.TabIndex = 9;
            this.lblEventVisitorsDetailsBednr.Text = "Kampeerplaats:";
            // 
            // lblEventVisitorsDetailsZipcode
            // 
            this.lblEventVisitorsDetailsZipcode.AutoSize = true;
            this.lblEventVisitorsDetailsZipcode.Location = new System.Drawing.Point(22, 98);
            this.lblEventVisitorsDetailsZipcode.Name = "lblEventVisitorsDetailsZipcode";
            this.lblEventVisitorsDetailsZipcode.Size = new System.Drawing.Size(55, 13);
            this.lblEventVisitorsDetailsZipcode.TabIndex = 8;
            this.lblEventVisitorsDetailsZipcode.Text = "Postcode:";
            // 
            // lblEventVisitorsDetailsAddress
            // 
            this.lblEventVisitorsDetailsAddress.AutoSize = true;
            this.lblEventVisitorsDetailsAddress.Location = new System.Drawing.Point(22, 73);
            this.lblEventVisitorsDetailsAddress.Name = "lblEventVisitorsDetailsAddress";
            this.lblEventVisitorsDetailsAddress.Size = new System.Drawing.Size(37, 13);
            this.lblEventVisitorsDetailsAddress.TabIndex = 7;
            this.lblEventVisitorsDetailsAddress.Text = "Adres:";
            // 
            // lblEventVisitorsDetailsLastname
            // 
            this.lblEventVisitorsDetailsLastname.AutoSize = true;
            this.lblEventVisitorsDetailsLastname.Location = new System.Drawing.Point(22, 46);
            this.lblEventVisitorsDetailsLastname.Name = "lblEventVisitorsDetailsLastname";
            this.lblEventVisitorsDetailsLastname.Size = new System.Drawing.Size(67, 13);
            this.lblEventVisitorsDetailsLastname.TabIndex = 5;
            this.lblEventVisitorsDetailsLastname.Text = "Achternaam:";
            // 
            // lblEventVisitorsDetailsSurname
            // 
            this.lblEventVisitorsDetailsSurname.AutoSize = true;
            this.lblEventVisitorsDetailsSurname.Location = new System.Drawing.Point(22, 16);
            this.lblEventVisitorsDetailsSurname.Name = "lblEventVisitorsDetailsSurname";
            this.lblEventVisitorsDetailsSurname.Size = new System.Drawing.Size(58, 13);
            this.lblEventVisitorsDetailsSurname.TabIndex = 4;
            this.lblEventVisitorsDetailsSurname.Text = "Voornaam:";
            // 
            // lboxAllVisitors
            // 
            this.lboxAllVisitors.FormattingEnabled = true;
            this.lboxAllVisitors.Location = new System.Drawing.Point(6, 51);
            this.lboxAllVisitors.Name = "lboxAllVisitors";
            this.lboxAllVisitors.Size = new System.Drawing.Size(299, 394);
            this.lboxAllVisitors.TabIndex = 6;
            this.lboxAllVisitors.SelectedIndexChanged += new System.EventHandler(this.lboxAllVisitors_SelectedIndexChanged);
            // 
            // tbAllVisitorsSearch
            // 
            this.tbAllVisitorsSearch.Location = new System.Drawing.Point(6, 25);
            this.tbAllVisitorsSearch.Name = "tbAllVisitorsSearch";
            this.tbAllVisitorsSearch.Size = new System.Drawing.Size(299, 20);
            this.tbAllVisitorsSearch.TabIndex = 5;
            // 
            // lblEventVisitors
            // 
            this.lblEventVisitors.AutoSize = true;
            this.lblEventVisitors.Location = new System.Drawing.Point(6, 5);
            this.lblEventVisitors.Name = "lblEventVisitors";
            this.lblEventVisitors.Size = new System.Drawing.Size(66, 13);
            this.lblEventVisitors.TabIndex = 4;
            this.lblEventVisitors.Text = "Deelnemers:";
            // 
            // tbcVisitors
            // 
            this.tbcVisitors.Controls.Add(this.tpAll);
            this.tbcVisitors.Controls.Add(this.tpInchecked);
            this.tbcVisitors.Location = new System.Drawing.Point(12, 12);
            this.tbcVisitors.Name = "tbcVisitors";
            this.tbcVisitors.SelectedIndex = 0;
            this.tbcVisitors.Size = new System.Drawing.Size(327, 481);
            this.tbcVisitors.TabIndex = 8;
            this.tbcVisitors.SelectedIndexChanged += new System.EventHandler(this.tbcVisitors_SelectedIndexChanged);
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.lboxAllVisitors);
            this.tpAll.Controls.Add(this.tbAllVisitorsSearch);
            this.tpAll.Controls.Add(this.lblEventVisitors);
            this.tpAll.Location = new System.Drawing.Point(4, 22);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpAll.Size = new System.Drawing.Size(319, 455);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "Alle";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // tpInchecked
            // 
            this.tpInchecked.Controls.Add(this.lboxCheckedInVisitors);
            this.tpInchecked.Controls.Add(this.tbCheckedInVisitors);
            this.tpInchecked.Controls.Add(this.label1);
            this.tpInchecked.Location = new System.Drawing.Point(4, 22);
            this.tpInchecked.Name = "tpInchecked";
            this.tpInchecked.Padding = new System.Windows.Forms.Padding(3);
            this.tpInchecked.Size = new System.Drawing.Size(319, 455);
            this.tpInchecked.TabIndex = 1;
            this.tpInchecked.Text = "Inchecked";
            this.tpInchecked.UseVisualStyleBackColor = true;
            // 
            // lboxCheckedInVisitors
            // 
            this.lboxCheckedInVisitors.FormattingEnabled = true;
            this.lboxCheckedInVisitors.Location = new System.Drawing.Point(10, 53);
            this.lboxCheckedInVisitors.Name = "lboxCheckedInVisitors";
            this.lboxCheckedInVisitors.Size = new System.Drawing.Size(299, 394);
            this.lboxCheckedInVisitors.TabIndex = 9;
            this.lboxCheckedInVisitors.SelectedIndexChanged += new System.EventHandler(this.lboxCheckedInVisitors_SelectedIndexChanged);
            // 
            // tbCheckedInVisitors
            // 
            this.tbCheckedInVisitors.Location = new System.Drawing.Point(10, 27);
            this.tbCheckedInVisitors.Name = "tbCheckedInVisitors";
            this.tbCheckedInVisitors.Size = new System.Drawing.Size(299, 20);
            this.tbCheckedInVisitors.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Deelnemers:";
            // 
            // IncheckSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 499);
            this.Controls.Add(this.tbcVisitors);
            this.Controls.Add(this.gboxEventVisitorsDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IncheckSystemForm";
            this.Text = "Toegangs Controle Systeem";
            this.gboxEventVisitorsDetails.ResumeLayout(false);
            this.gboxEventVisitorsDetails.PerformLayout();
            this.tbcVisitors.ResumeLayout(false);
            this.tpAll.ResumeLayout(false);
            this.tpAll.PerformLayout();
            this.tpInchecked.ResumeLayout(false);
            this.tpInchecked.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVisitorSave;
        private System.Windows.Forms.CheckBox cboxVisitorPayed;
        private System.Windows.Forms.CheckBox cboxVisitorPresent;
        private System.Windows.Forms.DateTimePicker dtpVisitorReservationDate;
        private System.Windows.Forms.TextBox tbVisitorCampSite;
        private System.Windows.Forms.TextBox tbVisitorZipcode;
        private System.Windows.Forms.TextBox tbVisitorAddress;
        private System.Windows.Forms.TextBox tbVisitorLastname;
        private System.Windows.Forms.TextBox tbVisitorSurname;
        private System.Windows.Forms.Button btnVisitorDelete;
        private System.Windows.Forms.Button btnVisitorAdd;
        private System.Windows.Forms.ListBox lboxVisitorsDetailsMaterials;
        private System.Windows.Forms.Label lblEventVisitorsDetailsMaterials;
        private System.Windows.Forms.ListBox lboxVisitorsDetailsMembers;
        private System.Windows.Forms.Label lblEventVisitorsDetailsMembers;
        private System.Windows.Forms.GroupBox gboxEventVisitorsDetails;
        private System.Windows.Forms.Label lblEventVisitorsDetailsBookingDate;
        private System.Windows.Forms.Label lblEventVisitorsDetailsBednr;
        private System.Windows.Forms.Label lblEventVisitorsDetailsZipcode;
        private System.Windows.Forms.Label lblEventVisitorsDetailsAddress;
        private System.Windows.Forms.Label lblEventVisitorsDetailsLastname;
        private System.Windows.Forms.Label lblEventVisitorsDetailsSurname;
        private System.Windows.Forms.ListBox lboxAllVisitors;
        private System.Windows.Forms.TextBox tbAllVisitorsSearch;
        private System.Windows.Forms.Label lblEventVisitors;
        private System.Windows.Forms.TabControl tbcVisitors;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.TabPage tpInchecked;
        private System.Windows.Forms.ListBox lboxCheckedInVisitors;
        private System.Windows.Forms.TextBox tbCheckedInVisitors;
        private System.Windows.Forms.Label label1;
    }
}

