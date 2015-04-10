namespace EventBeheerSysteem
{
    partial class EbsHomeForm
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
            this.btnEbsAdd = new System.Windows.Forms.Button();
            this.btnEbsRemove = new System.Windows.Forms.Button();
            this.dgvEbsEvents = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEbsEvent = new System.Windows.Forms.Panel();
            this.btnEventTerug = new System.Windows.Forms.Button();
            this.lblEbsTabEvent = new System.Windows.Forms.Label();
            this.tabEvent = new System.Windows.Forms.TabControl();
            this.tabEventDetails = new System.Windows.Forms.TabPage();
            this.tbEventDetailsCounter = new System.Windows.Forms.TextBox();
            this.dtpEventDetailsEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEventDetailsBeginDate = new System.Windows.Forms.DateTimePicker();
            this.tbEventDetailsLocation = new System.Windows.Forms.TextBox();
            this.tbEventDetailsNaam = new System.Windows.Forms.TextBox();
            this.lblEventDetailsOpen = new System.Windows.Forms.Label();
            this.lblEventDetailsTitel = new System.Windows.Forms.Label();
            this.lblEventDetailsVisitorcount = new System.Windows.Forms.Label();
            this.cboxEventDetailsOpen = new System.Windows.Forms.CheckBox();
            this.lblEventDetailsEndDate = new System.Windows.Forms.Label();
            this.lblEventDetailsBeginDate = new System.Windows.Forms.Label();
            this.lblEventDetailsLocation = new System.Windows.Forms.Label();
            this.lblEventDetailsName = new System.Windows.Forms.Label();
            this.tabEventDeelnemers = new System.Windows.Forms.TabPage();
            this.gboxEventVisitorsDetails = new System.Windows.Forms.GroupBox();
            this.cboxEventVisitorsDetailsPaid = new System.Windows.Forms.CheckBox();
            this.cboxEventVisitorsDetailsPresent = new System.Windows.Forms.CheckBox();
            this.dtpEventVisitorsDetailsBookingDate = new System.Windows.Forms.DateTimePicker();
            this.tbEventVisitorsDetailsStreetNr = new System.Windows.Forms.TextBox();
            this.tbEventVisitorsDetailsBednr = new System.Windows.Forms.TextBox();
            this.tbEventVisitorsDetailsZipcode = new System.Windows.Forms.TextBox();
            this.tbEventVisitorsDetailsStreet = new System.Windows.Forms.TextBox();
            this.tbEventVisitorsDetailsLastname = new System.Windows.Forms.TextBox();
            this.tbEventVisitorsDetailsSurname = new System.Windows.Forms.TextBox();
            this.btnEventVisitorsDetailsDeleteMaterial = new System.Windows.Forms.Button();
            this.btnEventVisitorsDetailsChangeMaterial = new System.Windows.Forms.Button();
            this.btnEventVisitorsDetailsAddMaterial = new System.Windows.Forms.Button();
            this.btnEventVisitorsDetailsDeleteMember = new System.Windows.Forms.Button();
            this.btnEventVisitorsDetailsChangeMember = new System.Windows.Forms.Button();
            this.btnEventVisitorsDetailsAddMember = new System.Windows.Forms.Button();
            this.lboxEventVisitorsDetailsMaterials = new System.Windows.Forms.ListBox();
            this.lblEventVisitorsDetailsMaterials = new System.Windows.Forms.Label();
            this.lboxEventVisitorsDetailsMembers = new System.Windows.Forms.ListBox();
            this.lblEventVisitorsDetailsMembers = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsBookingDate = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsBednr = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsZipcode = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsAddress = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsLastname = new System.Windows.Forms.Label();
            this.lblEventVisitorsDetailsSurname = new System.Windows.Forms.Label();
            this.lboxEventVisitorsList = new System.Windows.Forms.ListBox();
            this.tbEventVisitorsSearch = new System.Windows.Forms.TextBox();
            this.lblEventVisitors = new System.Windows.Forms.Label();
            this.tabEventMaterialen = new System.Windows.Forms.TabPage();
            this.gboxEventMaterialDetails = new System.Windows.Forms.GroupBox();
            this.tbEventMaterialDetailsAvailable = new System.Windows.Forms.TextBox();
            this.tbEventMaterialDetailsDailyrent = new System.Windows.Forms.TextBox();
            this.tbEventMaterialDetailsPrice = new System.Windows.Forms.TextBox();
            this.tbEventMaterialDetailsName = new System.Windows.Forms.TextBox();
            this.tbEventMaterialDetailsId = new System.Windows.Forms.TextBox();
            this.btnEventMaterialDetailsDeleteRenter = new System.Windows.Forms.Button();
            this.btnEventMaterialDetailsChangeRenter = new System.Windows.Forms.Button();
            this.btnEventMaterialDetailsAddRenter = new System.Windows.Forms.Button();
            this.lboxEventMaterialDetailsRentersList = new System.Windows.Forms.ListBox();
            this.lblEventMaterialDetailsRenters = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsAvailable = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsDailyrent = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsPrice = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsName = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsId = new System.Windows.Forms.Label();
            this.btnEventMaterialDeleteMaterial = new System.Windows.Forms.Button();
            this.btnEventMaterialAddMaterial = new System.Windows.Forms.Button();
            this.lboxEventMaterialList = new System.Windows.Forms.ListBox();
            this.lblEventMaterial = new System.Windows.Forms.Label();
            this.tabEventBeds = new System.Windows.Forms.TabPage();
            this.lblEventBedsMap = new System.Windows.Forms.Label();
            this.pboxEventBedsMap = new System.Windows.Forms.PictureBox();
            this.gboxEventBedsDetails = new System.Windows.Forms.GroupBox();
            this.cboxEventBedsDetailsOcuppied = new System.Windows.Forms.CheckBox();
            this.tbEventBedsDetailsMaxRenters = new System.Windows.Forms.TextBox();
            this.tbEventBedsDetailsRenter = new System.Windows.Forms.TextBox();
            this.tbEventBedsDetailsPrice = new System.Windows.Forms.TextBox();
            this.tbEventBedsDetailsName = new System.Windows.Forms.TextBox();
            this.lblEventBedsDetailsMaxRenters = new System.Windows.Forms.Label();
            this.lblEventBedsDetailsRenter = new System.Windows.Forms.Label();
            this.lblEventBedsDetailsPrice = new System.Windows.Forms.Label();
            this.lblEventBedsDetailsOccupied = new System.Windows.Forms.Label();
            this.lblEventBedsDetailsName = new System.Windows.Forms.Label();
            this.btnEventBedsDelete = new System.Windows.Forms.Button();
            this.btnEventBedsAdd = new System.Windows.Forms.Button();
            this.lboxEventBedsList = new System.Windows.Forms.ListBox();
            this.lblEventBeds = new System.Windows.Forms.Label();
            this.pnlEbsMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEbsEvents)).BeginInit();
            this.pnlEbsEvent.SuspendLayout();
            this.tabEvent.SuspendLayout();
            this.tabEventDetails.SuspendLayout();
            this.tabEventDeelnemers.SuspendLayout();
            this.gboxEventVisitorsDetails.SuspendLayout();
            this.tabEventMaterialen.SuspendLayout();
            this.gboxEventMaterialDetails.SuspendLayout();
            this.tabEventBeds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxEventBedsMap)).BeginInit();
            this.gboxEventBedsDetails.SuspendLayout();
            this.pnlEbsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEbsAdd
            // 
            this.btnEbsAdd.Location = new System.Drawing.Point(12, 524);
            this.btnEbsAdd.Name = "btnEbsAdd";
            this.btnEbsAdd.Size = new System.Drawing.Size(150, 25);
            this.btnEbsAdd.TabIndex = 1;
            this.btnEbsAdd.Text = "Event Toevoegen";
            this.btnEbsAdd.UseVisualStyleBackColor = true;
            this.btnEbsAdd.Click += new System.EventHandler(this.btnEbsAdd_Click);
            // 
            // btnEbsRemove
            // 
            this.btnEbsRemove.Location = new System.Drawing.Point(168, 524);
            this.btnEbsRemove.Name = "btnEbsRemove";
            this.btnEbsRemove.Size = new System.Drawing.Size(150, 25);
            this.btnEbsRemove.TabIndex = 2;
            this.btnEbsRemove.Text = "Event Verwijderen";
            this.btnEbsRemove.UseVisualStyleBackColor = true;
            // 
            // dgvEbsEvents
            // 
            this.dgvEbsEvents.AllowUserToAddRows = false;
            this.dgvEbsEvents.AllowUserToDeleteRows = false;
            this.dgvEbsEvents.AllowUserToResizeColumns = false;
            this.dgvEbsEvents.AllowUserToResizeRows = false;
            this.dgvEbsEvents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEbsEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEbsEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnLocation,
            this.ColumnBeginDate,
            this.ColumnEndDate});
            this.dgvEbsEvents.Location = new System.Drawing.Point(13, 13);
            this.dgvEbsEvents.MultiSelect = false;
            this.dgvEbsEvents.Name = "dgvEbsEvents";
            this.dgvEbsEvents.ReadOnly = true;
            this.dgvEbsEvents.RowHeadersVisible = false;
            this.dgvEbsEvents.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEbsEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEbsEvents.Size = new System.Drawing.Size(759, 505);
            this.dgvEbsEvents.TabIndex = 3;
            this.dgvEbsEvents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEbsEvents_MouseDoubleClick);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 50;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Event Naam";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 300;
            // 
            // ColumnLocation
            // 
            this.ColumnLocation.HeaderText = "Lokatie";
            this.ColumnLocation.Name = "ColumnLocation";
            this.ColumnLocation.ReadOnly = true;
            this.ColumnLocation.Width = 200;
            // 
            // ColumnBeginDate
            // 
            this.ColumnBeginDate.HeaderText = "Begin Datum";
            this.ColumnBeginDate.Name = "ColumnBeginDate";
            this.ColumnBeginDate.ReadOnly = true;
            this.ColumnBeginDate.Width = 103;
            // 
            // ColumnEndDate
            // 
            this.ColumnEndDate.HeaderText = "Eind Datum";
            this.ColumnEndDate.Name = "ColumnEndDate";
            this.ColumnEndDate.ReadOnly = true;
            this.ColumnEndDate.Width = 103;
            // 
            // pnlEbsEvent
            // 
            this.pnlEbsEvent.Controls.Add(this.btnEventTerug);
            this.pnlEbsEvent.Controls.Add(this.lblEbsTabEvent);
            this.pnlEbsEvent.Controls.Add(this.tabEvent);
            this.pnlEbsEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEbsEvent.Location = new System.Drawing.Point(0, 0);
            this.pnlEbsEvent.Name = "pnlEbsEvent";
            this.pnlEbsEvent.Size = new System.Drawing.Size(784, 561);
            this.pnlEbsEvent.TabIndex = 4;
            this.pnlEbsEvent.Visible = false;
            // 
            // btnEventTerug
            // 
            this.btnEventTerug.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEventTerug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEventTerug.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventTerug.Location = new System.Drawing.Point(7, 7);
            this.btnEventTerug.Name = "btnEventTerug";
            this.btnEventTerug.Size = new System.Drawing.Size(75, 25);
            this.btnEventTerug.TabIndex = 2;
            this.btnEventTerug.Text = "Terug";
            this.btnEventTerug.UseVisualStyleBackColor = true;
            this.btnEventTerug.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblEbsTabEvent
            // 
            this.lblEbsTabEvent.AutoSize = true;
            this.lblEbsTabEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEbsTabEvent.Location = new System.Drawing.Point(300, 10);
            this.lblEbsTabEvent.Name = "lblEbsTabEvent";
            this.lblEbsTabEvent.Size = new System.Drawing.Size(202, 20);
            this.lblEbsTabEvent.TabIndex = 1;
            this.lblEbsTabEvent.Text = "99241 - Social Media Event";
            // 
            // tabEvent
            // 
            this.tabEvent.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabEvent.Controls.Add(this.tabEventDetails);
            this.tabEvent.Controls.Add(this.tabEventDeelnemers);
            this.tabEvent.Controls.Add(this.tabEventMaterialen);
            this.tabEvent.Controls.Add(this.tabEventBeds);
            this.tabEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEvent.ItemSize = new System.Drawing.Size(44, 20);
            this.tabEvent.Location = new System.Drawing.Point(7, 35);
            this.tabEvent.Name = "tabEvent";
            this.tabEvent.Padding = new System.Drawing.Point(5, 2);
            this.tabEvent.SelectedIndex = 0;
            this.tabEvent.Size = new System.Drawing.Size(770, 523);
            this.tabEvent.TabIndex = 0;
            // 
            // tabEventDetails
            // 
            this.tabEventDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEventDetails.Controls.Add(this.tbEventDetailsCounter);
            this.tabEventDetails.Controls.Add(this.dtpEventDetailsEndDate);
            this.tabEventDetails.Controls.Add(this.dtpEventDetailsBeginDate);
            this.tabEventDetails.Controls.Add(this.tbEventDetailsLocation);
            this.tabEventDetails.Controls.Add(this.tbEventDetailsNaam);
            this.tabEventDetails.Controls.Add(this.lblEventDetailsOpen);
            this.tabEventDetails.Controls.Add(this.lblEventDetailsTitel);
            this.tabEventDetails.Controls.Add(this.lblEventDetailsVisitorcount);
            this.tabEventDetails.Controls.Add(this.cboxEventDetailsOpen);
            this.tabEventDetails.Controls.Add(this.lblEventDetailsEndDate);
            this.tabEventDetails.Controls.Add(this.lblEventDetailsBeginDate);
            this.tabEventDetails.Controls.Add(this.lblEventDetailsLocation);
            this.tabEventDetails.Controls.Add(this.lblEventDetailsName);
            this.tabEventDetails.Location = new System.Drawing.Point(4, 24);
            this.tabEventDetails.Name = "tabEventDetails";
            this.tabEventDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventDetails.Size = new System.Drawing.Size(762, 495);
            this.tabEventDetails.TabIndex = 0;
            this.tabEventDetails.Text = "Details";
            this.tabEventDetails.UseVisualStyleBackColor = true;
            // 
            // tbEventDetailsCounter
            // 
            this.tbEventDetailsCounter.BackColor = System.Drawing.SystemColors.Control;
            this.tbEventDetailsCounter.Location = new System.Drawing.Point(180, 297);
            this.tbEventDetailsCounter.Name = "tbEventDetailsCounter";
            this.tbEventDetailsCounter.ReadOnly = true;
            this.tbEventDetailsCounter.Size = new System.Drawing.Size(220, 22);
            this.tbEventDetailsCounter.TabIndex = 12;
            // 
            // dtpEventDetailsEndDate
            // 
            this.dtpEventDetailsEndDate.Location = new System.Drawing.Point(180, 215);
            this.dtpEventDetailsEndDate.Name = "dtpEventDetailsEndDate";
            this.dtpEventDetailsEndDate.Size = new System.Drawing.Size(220, 22);
            this.dtpEventDetailsEndDate.TabIndex = 11;
            // 
            // dtpEventDetailsBeginDate
            // 
            this.dtpEventDetailsBeginDate.Location = new System.Drawing.Point(180, 175);
            this.dtpEventDetailsBeginDate.Name = "dtpEventDetailsBeginDate";
            this.dtpEventDetailsBeginDate.Size = new System.Drawing.Size(220, 22);
            this.dtpEventDetailsBeginDate.TabIndex = 10;
            // 
            // tbEventDetailsLocation
            // 
            this.tbEventDetailsLocation.Location = new System.Drawing.Point(180, 137);
            this.tbEventDetailsLocation.Name = "tbEventDetailsLocation";
            this.tbEventDetailsLocation.Size = new System.Drawing.Size(220, 22);
            this.tbEventDetailsLocation.TabIndex = 9;
            // 
            // tbEventDetailsNaam
            // 
            this.tbEventDetailsNaam.Location = new System.Drawing.Point(180, 94);
            this.tbEventDetailsNaam.Name = "tbEventDetailsNaam";
            this.tbEventDetailsNaam.Size = new System.Drawing.Size(220, 22);
            this.tbEventDetailsNaam.TabIndex = 8;
            // 
            // lblEventDetailsOpen
            // 
            this.lblEventDetailsOpen.AutoSize = true;
            this.lblEventDetailsOpen.Location = new System.Drawing.Point(15, 260);
            this.lblEventDetailsOpen.Name = "lblEventDetailsOpen";
            this.lblEventDetailsOpen.Size = new System.Drawing.Size(121, 16);
            this.lblEventDetailsOpen.TabIndex = 7;
            this.lblEventDetailsOpen.Text = "Reservering Open:";
            // 
            // lblEventDetailsTitel
            // 
            this.lblEventDetailsTitel.AutoSize = true;
            this.lblEventDetailsTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDetailsTitel.Location = new System.Drawing.Point(10, 60);
            this.lblEventDetailsTitel.Name = "lblEventDetailsTitel";
            this.lblEventDetailsTitel.Size = new System.Drawing.Size(93, 26);
            this.lblEventDetailsTitel.TabIndex = 6;
            this.lblEventDetailsTitel.Text = "Details:";
            // 
            // lblEventDetailsVisitorcount
            // 
            this.lblEventDetailsVisitorcount.AutoSize = true;
            this.lblEventDetailsVisitorcount.Location = new System.Drawing.Point(15, 300);
            this.lblEventDetailsVisitorcount.Name = "lblEventDetailsVisitorcount";
            this.lblEventDetailsVisitorcount.Size = new System.Drawing.Size(98, 16);
            this.lblEventDetailsVisitorcount.TabIndex = 5;
            this.lblEventDetailsVisitorcount.Text = "Aanmeldingen:";
            // 
            // cboxEventDetailsOpen
            // 
            this.cboxEventDetailsOpen.AutoSize = true;
            this.cboxEventDetailsOpen.Location = new System.Drawing.Point(180, 262);
            this.cboxEventDetailsOpen.Name = "cboxEventDetailsOpen";
            this.cboxEventDetailsOpen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboxEventDetailsOpen.Size = new System.Drawing.Size(15, 14);
            this.cboxEventDetailsOpen.TabIndex = 4;
            this.cboxEventDetailsOpen.UseVisualStyleBackColor = true;
            // 
            // lblEventDetailsEndDate
            // 
            this.lblEventDetailsEndDate.AutoSize = true;
            this.lblEventDetailsEndDate.Location = new System.Drawing.Point(15, 220);
            this.lblEventDetailsEndDate.Name = "lblEventDetailsEndDate";
            this.lblEventDetailsEndDate.Size = new System.Drawing.Size(117, 16);
            this.lblEventDetailsEndDate.TabIndex = 3;
            this.lblEventDetailsEndDate.Text = "Event Eind Datum:";
            // 
            // lblEventDetailsBeginDate
            // 
            this.lblEventDetailsBeginDate.AutoSize = true;
            this.lblEventDetailsBeginDate.Location = new System.Drawing.Point(15, 180);
            this.lblEventDetailsBeginDate.Name = "lblEventDetailsBeginDate";
            this.lblEventDetailsBeginDate.Size = new System.Drawing.Size(125, 16);
            this.lblEventDetailsBeginDate.TabIndex = 2;
            this.lblEventDetailsBeginDate.Text = "Event Begin Datum:";
            // 
            // lblEventDetailsLocation
            // 
            this.lblEventDetailsLocation.AutoSize = true;
            this.lblEventDetailsLocation.Location = new System.Drawing.Point(15, 140);
            this.lblEventDetailsLocation.Name = "lblEventDetailsLocation";
            this.lblEventDetailsLocation.Size = new System.Drawing.Size(92, 16);
            this.lblEventDetailsLocation.TabIndex = 1;
            this.lblEventDetailsLocation.Text = "Event Lokatie:";
            // 
            // lblEventDetailsName
            // 
            this.lblEventDetailsName.AutoSize = true;
            this.lblEventDetailsName.Location = new System.Drawing.Point(15, 100);
            this.lblEventDetailsName.Name = "lblEventDetailsName";
            this.lblEventDetailsName.Size = new System.Drawing.Size(85, 16);
            this.lblEventDetailsName.TabIndex = 0;
            this.lblEventDetailsName.Text = "Event Naam:";
            // 
            // tabEventDeelnemers
            // 
            this.tabEventDeelnemers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEventDeelnemers.Controls.Add(this.gboxEventVisitorsDetails);
            this.tabEventDeelnemers.Controls.Add(this.lboxEventVisitorsList);
            this.tabEventDeelnemers.Controls.Add(this.tbEventVisitorsSearch);
            this.tabEventDeelnemers.Controls.Add(this.lblEventVisitors);
            this.tabEventDeelnemers.Location = new System.Drawing.Point(4, 24);
            this.tabEventDeelnemers.Name = "tabEventDeelnemers";
            this.tabEventDeelnemers.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventDeelnemers.Size = new System.Drawing.Size(762, 495);
            this.tabEventDeelnemers.TabIndex = 1;
            this.tabEventDeelnemers.Text = "Deelnemers";
            this.tabEventDeelnemers.UseVisualStyleBackColor = true;
            // 
            // gboxEventVisitorsDetails
            // 
            this.gboxEventVisitorsDetails.Controls.Add(this.cboxEventVisitorsDetailsPaid);
            this.gboxEventVisitorsDetails.Controls.Add(this.cboxEventVisitorsDetailsPresent);
            this.gboxEventVisitorsDetails.Controls.Add(this.dtpEventVisitorsDetailsBookingDate);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbEventVisitorsDetailsStreetNr);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbEventVisitorsDetailsBednr);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbEventVisitorsDetailsZipcode);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbEventVisitorsDetailsStreet);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbEventVisitorsDetailsLastname);
            this.gboxEventVisitorsDetails.Controls.Add(this.tbEventVisitorsDetailsSurname);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnEventVisitorsDetailsDeleteMaterial);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnEventVisitorsDetailsChangeMaterial);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnEventVisitorsDetailsAddMaterial);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnEventVisitorsDetailsDeleteMember);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnEventVisitorsDetailsChangeMember);
            this.gboxEventVisitorsDetails.Controls.Add(this.btnEventVisitorsDetailsAddMember);
            this.gboxEventVisitorsDetails.Controls.Add(this.lboxEventVisitorsDetailsMaterials);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsMaterials);
            this.gboxEventVisitorsDetails.Controls.Add(this.lboxEventVisitorsDetailsMembers);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsMembers);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsBookingDate);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsBednr);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsZipcode);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsAddress);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsLastname);
            this.gboxEventVisitorsDetails.Controls.Add(this.lblEventVisitorsDetailsSurname);
            this.gboxEventVisitorsDetails.Location = new System.Drawing.Point(340, 10);
            this.gboxEventVisitorsDetails.Name = "gboxEventVisitorsDetails";
            this.gboxEventVisitorsDetails.Size = new System.Drawing.Size(410, 481);
            this.gboxEventVisitorsDetails.TabIndex = 3;
            this.gboxEventVisitorsDetails.TabStop = false;
            this.gboxEventVisitorsDetails.Text = "Details";
            // 
            // cboxEventVisitorsDetailsPaid
            // 
            this.cboxEventVisitorsDetailsPaid.AutoSize = true;
            this.cboxEventVisitorsDetailsPaid.Location = new System.Drawing.Point(234, 176);
            this.cboxEventVisitorsDetailsPaid.Name = "cboxEventVisitorsDetailsPaid";
            this.cboxEventVisitorsDetailsPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxEventVisitorsDetailsPaid.Size = new System.Drawing.Size(98, 20);
            this.cboxEventVisitorsDetailsPaid.TabIndex = 31;
            this.cboxEventVisitorsDetailsPaid.Text = "       :Betaald";
            this.cboxEventVisitorsDetailsPaid.UseVisualStyleBackColor = true;
            // 
            // cboxEventVisitorsDetailsPresent
            // 
            this.cboxEventVisitorsDetailsPresent.AutoSize = true;
            this.cboxEventVisitorsDetailsPresent.Location = new System.Drawing.Point(22, 176);
            this.cboxEventVisitorsDetailsPresent.Name = "cboxEventVisitorsDetailsPresent";
            this.cboxEventVisitorsDetailsPresent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboxEventVisitorsDetailsPresent.Size = new System.Drawing.Size(103, 20);
            this.cboxEventVisitorsDetailsPresent.TabIndex = 30;
            this.cboxEventVisitorsDetailsPresent.Text = "     :Aanwezig";
            this.cboxEventVisitorsDetailsPresent.UseVisualStyleBackColor = true;
            // 
            // dtpEventVisitorsDetailsBookingDate
            // 
            this.dtpEventVisitorsDetailsBookingDate.Location = new System.Drawing.Point(160, 148);
            this.dtpEventVisitorsDetailsBookingDate.Name = "dtpEventVisitorsDetailsBookingDate";
            this.dtpEventVisitorsDetailsBookingDate.Size = new System.Drawing.Size(243, 22);
            this.dtpEventVisitorsDetailsBookingDate.TabIndex = 29;
            // 
            // tbEventVisitorsDetailsStreetNr
            // 
            this.tbEventVisitorsDetailsStreetNr.Location = new System.Drawing.Point(347, 70);
            this.tbEventVisitorsDetailsStreetNr.Name = "tbEventVisitorsDetailsStreetNr";
            this.tbEventVisitorsDetailsStreetNr.Size = new System.Drawing.Size(57, 22);
            this.tbEventVisitorsDetailsStreetNr.TabIndex = 28;
            // 
            // tbEventVisitorsDetailsBednr
            // 
            this.tbEventVisitorsDetailsBednr.Location = new System.Drawing.Point(160, 120);
            this.tbEventVisitorsDetailsBednr.Name = "tbEventVisitorsDetailsBednr";
            this.tbEventVisitorsDetailsBednr.Size = new System.Drawing.Size(243, 22);
            this.tbEventVisitorsDetailsBednr.TabIndex = 27;
            // 
            // tbEventVisitorsDetailsZipcode
            // 
            this.tbEventVisitorsDetailsZipcode.Location = new System.Drawing.Point(160, 95);
            this.tbEventVisitorsDetailsZipcode.Name = "tbEventVisitorsDetailsZipcode";
            this.tbEventVisitorsDetailsZipcode.Size = new System.Drawing.Size(244, 22);
            this.tbEventVisitorsDetailsZipcode.TabIndex = 26;
            // 
            // tbEventVisitorsDetailsStreet
            // 
            this.tbEventVisitorsDetailsStreet.Location = new System.Drawing.Point(160, 70);
            this.tbEventVisitorsDetailsStreet.Name = "tbEventVisitorsDetailsStreet";
            this.tbEventVisitorsDetailsStreet.Size = new System.Drawing.Size(181, 22);
            this.tbEventVisitorsDetailsStreet.TabIndex = 25;
            // 
            // tbEventVisitorsDetailsLastname
            // 
            this.tbEventVisitorsDetailsLastname.Location = new System.Drawing.Point(160, 43);
            this.tbEventVisitorsDetailsLastname.Name = "tbEventVisitorsDetailsLastname";
            this.tbEventVisitorsDetailsLastname.Size = new System.Drawing.Size(243, 22);
            this.tbEventVisitorsDetailsLastname.TabIndex = 23;
            // 
            // tbEventVisitorsDetailsSurname
            // 
            this.tbEventVisitorsDetailsSurname.Location = new System.Drawing.Point(160, 15);
            this.tbEventVisitorsDetailsSurname.Name = "tbEventVisitorsDetailsSurname";
            this.tbEventVisitorsDetailsSurname.Size = new System.Drawing.Size(243, 22);
            this.tbEventVisitorsDetailsSurname.TabIndex = 22;
            // 
            // btnEventVisitorsDetailsDeleteMaterial
            // 
            this.btnEventVisitorsDetailsDeleteMaterial.Location = new System.Drawing.Point(312, 452);
            this.btnEventVisitorsDetailsDeleteMaterial.Name = "btnEventVisitorsDetailsDeleteMaterial";
            this.btnEventVisitorsDetailsDeleteMaterial.Size = new System.Drawing.Size(91, 23);
            this.btnEventVisitorsDetailsDeleteMaterial.TabIndex = 21;
            this.btnEventVisitorsDetailsDeleteMaterial.Text = "Verwijderen";
            this.btnEventVisitorsDetailsDeleteMaterial.UseVisualStyleBackColor = true;
            // 
            // btnEventVisitorsDetailsChangeMaterial
            // 
            this.btnEventVisitorsDetailsChangeMaterial.Location = new System.Drawing.Point(218, 452);
            this.btnEventVisitorsDetailsChangeMaterial.Name = "btnEventVisitorsDetailsChangeMaterial";
            this.btnEventVisitorsDetailsChangeMaterial.Size = new System.Drawing.Size(88, 23);
            this.btnEventVisitorsDetailsChangeMaterial.TabIndex = 20;
            this.btnEventVisitorsDetailsChangeMaterial.Text = "Aanpassen";
            this.btnEventVisitorsDetailsChangeMaterial.UseVisualStyleBackColor = true;
            // 
            // btnEventVisitorsDetailsAddMaterial
            // 
            this.btnEventVisitorsDetailsAddMaterial.Location = new System.Drawing.Point(113, 452);
            this.btnEventVisitorsDetailsAddMaterial.Name = "btnEventVisitorsDetailsAddMaterial";
            this.btnEventVisitorsDetailsAddMaterial.Size = new System.Drawing.Size(99, 23);
            this.btnEventVisitorsDetailsAddMaterial.TabIndex = 19;
            this.btnEventVisitorsDetailsAddMaterial.Text = "Toevoegen";
            this.btnEventVisitorsDetailsAddMaterial.UseVisualStyleBackColor = true;
            // 
            // btnEventVisitorsDetailsDeleteMember
            // 
            this.btnEventVisitorsDetailsDeleteMember.Location = new System.Drawing.Point(312, 333);
            this.btnEventVisitorsDetailsDeleteMember.Name = "btnEventVisitorsDetailsDeleteMember";
            this.btnEventVisitorsDetailsDeleteMember.Size = new System.Drawing.Size(91, 23);
            this.btnEventVisitorsDetailsDeleteMember.TabIndex = 18;
            this.btnEventVisitorsDetailsDeleteMember.Text = "Verwijderen";
            this.btnEventVisitorsDetailsDeleteMember.UseVisualStyleBackColor = true;
            // 
            // btnEventVisitorsDetailsChangeMember
            // 
            this.btnEventVisitorsDetailsChangeMember.Location = new System.Drawing.Point(218, 333);
            this.btnEventVisitorsDetailsChangeMember.Name = "btnEventVisitorsDetailsChangeMember";
            this.btnEventVisitorsDetailsChangeMember.Size = new System.Drawing.Size(88, 23);
            this.btnEventVisitorsDetailsChangeMember.TabIndex = 17;
            this.btnEventVisitorsDetailsChangeMember.Text = "Aanpassen";
            this.btnEventVisitorsDetailsChangeMember.UseVisualStyleBackColor = true;
            // 
            // btnEventVisitorsDetailsAddMember
            // 
            this.btnEventVisitorsDetailsAddMember.Location = new System.Drawing.Point(113, 333);
            this.btnEventVisitorsDetailsAddMember.Name = "btnEventVisitorsDetailsAddMember";
            this.btnEventVisitorsDetailsAddMember.Size = new System.Drawing.Size(99, 23);
            this.btnEventVisitorsDetailsAddMember.TabIndex = 16;
            this.btnEventVisitorsDetailsAddMember.Text = "Toevoegen";
            this.btnEventVisitorsDetailsAddMember.UseVisualStyleBackColor = true;
            // 
            // lboxEventVisitorsDetailsMaterials
            // 
            this.lboxEventVisitorsDetailsMaterials.FormattingEnabled = true;
            this.lboxEventVisitorsDetailsMaterials.ItemHeight = 16;
            this.lboxEventVisitorsDetailsMaterials.Location = new System.Drawing.Point(113, 362);
            this.lboxEventVisitorsDetailsMaterials.Name = "lboxEventVisitorsDetailsMaterials";
            this.lboxEventVisitorsDetailsMaterials.Size = new System.Drawing.Size(291, 84);
            this.lboxEventVisitorsDetailsMaterials.TabIndex = 15;
            // 
            // lblEventVisitorsDetailsMaterials
            // 
            this.lblEventVisitorsDetailsMaterials.AutoSize = true;
            this.lblEventVisitorsDetailsMaterials.Location = new System.Drawing.Point(22, 362);
            this.lblEventVisitorsDetailsMaterials.Name = "lblEventVisitorsDetailsMaterials";
            this.lblEventVisitorsDetailsMaterials.Size = new System.Drawing.Size(71, 16);
            this.lblEventVisitorsDetailsMaterials.TabIndex = 14;
            this.lblEventVisitorsDetailsMaterials.Text = "Materialen";
            // 
            // lboxEventVisitorsDetailsMembers
            // 
            this.lboxEventVisitorsDetailsMembers.FormattingEnabled = true;
            this.lboxEventVisitorsDetailsMembers.ItemHeight = 16;
            this.lboxEventVisitorsDetailsMembers.Location = new System.Drawing.Point(113, 243);
            this.lboxEventVisitorsDetailsMembers.Name = "lboxEventVisitorsDetailsMembers";
            this.lboxEventVisitorsDetailsMembers.Size = new System.Drawing.Size(290, 84);
            this.lboxEventVisitorsDetailsMembers.TabIndex = 13;
            // 
            // lblEventVisitorsDetailsMembers
            // 
            this.lblEventVisitorsDetailsMembers.AutoSize = true;
            this.lblEventVisitorsDetailsMembers.Location = new System.Drawing.Point(22, 243);
            this.lblEventVisitorsDetailsMembers.Name = "lblEventVisitorsDetailsMembers";
            this.lblEventVisitorsDetailsMembers.Size = new System.Drawing.Size(49, 16);
            this.lblEventVisitorsDetailsMembers.TabIndex = 12;
            this.lblEventVisitorsDetailsMembers.Text = "Leden:";
            // 
            // lblEventVisitorsDetailsBookingDate
            // 
            this.lblEventVisitorsDetailsBookingDate.AutoSize = true;
            this.lblEventVisitorsDetailsBookingDate.Location = new System.Drawing.Point(22, 153);
            this.lblEventVisitorsDetailsBookingDate.Name = "lblEventVisitorsDetailsBookingDate";
            this.lblEventVisitorsDetailsBookingDate.Size = new System.Drawing.Size(129, 16);
            this.lblEventVisitorsDetailsBookingDate.TabIndex = 10;
            this.lblEventVisitorsDetailsBookingDate.Text = "Reserveringsdatum:";
            // 
            // lblEventVisitorsDetailsBednr
            // 
            this.lblEventVisitorsDetailsBednr.AutoSize = true;
            this.lblEventVisitorsDetailsBednr.Location = new System.Drawing.Point(22, 123);
            this.lblEventVisitorsDetailsBednr.Name = "lblEventVisitorsDetailsBednr";
            this.lblEventVisitorsDetailsBednr.Size = new System.Drawing.Size(103, 16);
            this.lblEventVisitorsDetailsBednr.TabIndex = 9;
            this.lblEventVisitorsDetailsBednr.Text = "Kampeerplaats:";
            // 
            // lblEventVisitorsDetailsZipcode
            // 
            this.lblEventVisitorsDetailsZipcode.AutoSize = true;
            this.lblEventVisitorsDetailsZipcode.Location = new System.Drawing.Point(22, 98);
            this.lblEventVisitorsDetailsZipcode.Name = "lblEventVisitorsDetailsZipcode";
            this.lblEventVisitorsDetailsZipcode.Size = new System.Drawing.Size(69, 16);
            this.lblEventVisitorsDetailsZipcode.TabIndex = 8;
            this.lblEventVisitorsDetailsZipcode.Text = "Postcode:";
            // 
            // lblEventVisitorsDetailsAddress
            // 
            this.lblEventVisitorsDetailsAddress.AutoSize = true;
            this.lblEventVisitorsDetailsAddress.Location = new System.Drawing.Point(22, 73);
            this.lblEventVisitorsDetailsAddress.Name = "lblEventVisitorsDetailsAddress";
            this.lblEventVisitorsDetailsAddress.Size = new System.Drawing.Size(47, 16);
            this.lblEventVisitorsDetailsAddress.TabIndex = 7;
            this.lblEventVisitorsDetailsAddress.Text = "Adres:";
            // 
            // lblEventVisitorsDetailsLastname
            // 
            this.lblEventVisitorsDetailsLastname.AutoSize = true;
            this.lblEventVisitorsDetailsLastname.Location = new System.Drawing.Point(22, 46);
            this.lblEventVisitorsDetailsLastname.Name = "lblEventVisitorsDetailsLastname";
            this.lblEventVisitorsDetailsLastname.Size = new System.Drawing.Size(83, 16);
            this.lblEventVisitorsDetailsLastname.TabIndex = 5;
            this.lblEventVisitorsDetailsLastname.Text = "Achternaam:";
            // 
            // lblEventVisitorsDetailsSurname
            // 
            this.lblEventVisitorsDetailsSurname.AutoSize = true;
            this.lblEventVisitorsDetailsSurname.Location = new System.Drawing.Point(22, 16);
            this.lblEventVisitorsDetailsSurname.Name = "lblEventVisitorsDetailsSurname";
            this.lblEventVisitorsDetailsSurname.Size = new System.Drawing.Size(74, 16);
            this.lblEventVisitorsDetailsSurname.TabIndex = 4;
            this.lblEventVisitorsDetailsSurname.Text = "Voornaam:";
            // 
            // lboxEventVisitorsList
            // 
            this.lboxEventVisitorsList.FormattingEnabled = true;
            this.lboxEventVisitorsList.ItemHeight = 16;
            this.lboxEventVisitorsList.Location = new System.Drawing.Point(7, 56);
            this.lboxEventVisitorsList.Name = "lboxEventVisitorsList";
            this.lboxEventVisitorsList.Size = new System.Drawing.Size(299, 436);
            this.lboxEventVisitorsList.TabIndex = 2;
            // 
            // tbEventVisitorsSearch
            // 
            this.tbEventVisitorsSearch.Location = new System.Drawing.Point(7, 27);
            this.tbEventVisitorsSearch.Name = "tbEventVisitorsSearch";
            this.tbEventVisitorsSearch.Size = new System.Drawing.Size(299, 22);
            this.tbEventVisitorsSearch.TabIndex = 1;
            // 
            // lblEventVisitors
            // 
            this.lblEventVisitors.AutoSize = true;
            this.lblEventVisitors.Location = new System.Drawing.Point(7, 7);
            this.lblEventVisitors.Name = "lblEventVisitors";
            this.lblEventVisitors.Size = new System.Drawing.Size(85, 16);
            this.lblEventVisitors.TabIndex = 0;
            this.lblEventVisitors.Text = "Deelnemers:";
            // 
            // tabEventMaterialen
            // 
            this.tabEventMaterialen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEventMaterialen.Controls.Add(this.gboxEventMaterialDetails);
            this.tabEventMaterialen.Controls.Add(this.btnEventMaterialDeleteMaterial);
            this.tabEventMaterialen.Controls.Add(this.btnEventMaterialAddMaterial);
            this.tabEventMaterialen.Controls.Add(this.lboxEventMaterialList);
            this.tabEventMaterialen.Controls.Add(this.lblEventMaterial);
            this.tabEventMaterialen.Location = new System.Drawing.Point(4, 24);
            this.tabEventMaterialen.Name = "tabEventMaterialen";
            this.tabEventMaterialen.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventMaterialen.Size = new System.Drawing.Size(762, 495);
            this.tabEventMaterialen.TabIndex = 2;
            this.tabEventMaterialen.Text = "Materialen";
            this.tabEventMaterialen.UseVisualStyleBackColor = true;
            // 
            // gboxEventMaterialDetails
            // 
            this.gboxEventMaterialDetails.Controls.Add(this.tbEventMaterialDetailsAvailable);
            this.gboxEventMaterialDetails.Controls.Add(this.tbEventMaterialDetailsDailyrent);
            this.gboxEventMaterialDetails.Controls.Add(this.tbEventMaterialDetailsPrice);
            this.gboxEventMaterialDetails.Controls.Add(this.tbEventMaterialDetailsName);
            this.gboxEventMaterialDetails.Controls.Add(this.tbEventMaterialDetailsId);
            this.gboxEventMaterialDetails.Controls.Add(this.btnEventMaterialDetailsDeleteRenter);
            this.gboxEventMaterialDetails.Controls.Add(this.btnEventMaterialDetailsChangeRenter);
            this.gboxEventMaterialDetails.Controls.Add(this.btnEventMaterialDetailsAddRenter);
            this.gboxEventMaterialDetails.Controls.Add(this.lboxEventMaterialDetailsRentersList);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsRenters);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsAvailable);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsDailyrent);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsPrice);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsName);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsId);
            this.gboxEventMaterialDetails.Location = new System.Drawing.Point(340, 10);
            this.gboxEventMaterialDetails.Name = "gboxEventMaterialDetails";
            this.gboxEventMaterialDetails.Size = new System.Drawing.Size(409, 479);
            this.gboxEventMaterialDetails.TabIndex = 4;
            this.gboxEventMaterialDetails.TabStop = false;
            this.gboxEventMaterialDetails.Text = "Details";
            // 
            // tbEventMaterialDetailsAvailable
            // 
            this.tbEventMaterialDetailsAvailable.Location = new System.Drawing.Point(147, 150);
            this.tbEventMaterialDetailsAvailable.Name = "tbEventMaterialDetailsAvailable";
            this.tbEventMaterialDetailsAvailable.Size = new System.Drawing.Size(256, 22);
            this.tbEventMaterialDetailsAvailable.TabIndex = 14;
            // 
            // tbEventMaterialDetailsDailyrent
            // 
            this.tbEventMaterialDetailsDailyrent.Location = new System.Drawing.Point(147, 120);
            this.tbEventMaterialDetailsDailyrent.Name = "tbEventMaterialDetailsDailyrent";
            this.tbEventMaterialDetailsDailyrent.Size = new System.Drawing.Size(256, 22);
            this.tbEventMaterialDetailsDailyrent.TabIndex = 13;
            // 
            // tbEventMaterialDetailsPrice
            // 
            this.tbEventMaterialDetailsPrice.Location = new System.Drawing.Point(147, 90);
            this.tbEventMaterialDetailsPrice.Name = "tbEventMaterialDetailsPrice";
            this.tbEventMaterialDetailsPrice.Size = new System.Drawing.Size(256, 22);
            this.tbEventMaterialDetailsPrice.TabIndex = 12;
            // 
            // tbEventMaterialDetailsName
            // 
            this.tbEventMaterialDetailsName.Location = new System.Drawing.Point(147, 60);
            this.tbEventMaterialDetailsName.Name = "tbEventMaterialDetailsName";
            this.tbEventMaterialDetailsName.Size = new System.Drawing.Size(256, 22);
            this.tbEventMaterialDetailsName.TabIndex = 11;
            // 
            // tbEventMaterialDetailsId
            // 
            this.tbEventMaterialDetailsId.Location = new System.Drawing.Point(147, 30);
            this.tbEventMaterialDetailsId.Name = "tbEventMaterialDetailsId";
            this.tbEventMaterialDetailsId.Size = new System.Drawing.Size(256, 22);
            this.tbEventMaterialDetailsId.TabIndex = 10;
            // 
            // btnEventMaterialDetailsDeleteRenter
            // 
            this.btnEventMaterialDetailsDeleteRenter.Location = new System.Drawing.Point(288, 448);
            this.btnEventMaterialDetailsDeleteRenter.Name = "btnEventMaterialDetailsDeleteRenter";
            this.btnEventMaterialDetailsDeleteRenter.Size = new System.Drawing.Size(115, 23);
            this.btnEventMaterialDetailsDeleteRenter.TabIndex = 9;
            this.btnEventMaterialDetailsDeleteRenter.Text = "Verwijderen";
            this.btnEventMaterialDetailsDeleteRenter.UseVisualStyleBackColor = true;
            // 
            // btnEventMaterialDetailsChangeRenter
            // 
            this.btnEventMaterialDetailsChangeRenter.Location = new System.Drawing.Point(156, 448);
            this.btnEventMaterialDetailsChangeRenter.Name = "btnEventMaterialDetailsChangeRenter";
            this.btnEventMaterialDetailsChangeRenter.Size = new System.Drawing.Size(117, 23);
            this.btnEventMaterialDetailsChangeRenter.TabIndex = 8;
            this.btnEventMaterialDetailsChangeRenter.Text = "Aanpassen";
            this.btnEventMaterialDetailsChangeRenter.UseVisualStyleBackColor = true;
            // 
            // btnEventMaterialDetailsAddRenter
            // 
            this.btnEventMaterialDetailsAddRenter.Location = new System.Drawing.Point(25, 449);
            this.btnEventMaterialDetailsAddRenter.Name = "btnEventMaterialDetailsAddRenter";
            this.btnEventMaterialDetailsAddRenter.Size = new System.Drawing.Size(120, 23);
            this.btnEventMaterialDetailsAddRenter.TabIndex = 7;
            this.btnEventMaterialDetailsAddRenter.Text = "Toevoegen";
            this.btnEventMaterialDetailsAddRenter.UseVisualStyleBackColor = true;
            // 
            // lboxEventMaterialDetailsRentersList
            // 
            this.lboxEventMaterialDetailsRentersList.FormattingEnabled = true;
            this.lboxEventMaterialDetailsRentersList.ItemHeight = 16;
            this.lboxEventMaterialDetailsRentersList.Location = new System.Drawing.Point(25, 231);
            this.lboxEventMaterialDetailsRentersList.Name = "lboxEventMaterialDetailsRentersList";
            this.lboxEventMaterialDetailsRentersList.Size = new System.Drawing.Size(378, 212);
            this.lboxEventMaterialDetailsRentersList.TabIndex = 6;
            // 
            // lblEventMaterialDetailsRenters
            // 
            this.lblEventMaterialDetailsRenters.AutoSize = true;
            this.lblEventMaterialDetailsRenters.Location = new System.Drawing.Point(22, 211);
            this.lblEventMaterialDetailsRenters.Name = "lblEventMaterialDetailsRenters";
            this.lblEventMaterialDetailsRenters.Size = new System.Drawing.Size(66, 16);
            this.lblEventMaterialDetailsRenters.TabIndex = 5;
            this.lblEventMaterialDetailsRenters.Text = "Huurders:";
            // 
            // lblEventMaterialDetailsAvailable
            // 
            this.lblEventMaterialDetailsAvailable.AutoSize = true;
            this.lblEventMaterialDetailsAvailable.Location = new System.Drawing.Point(20, 150);
            this.lblEventMaterialDetailsAvailable.Name = "lblEventMaterialDetailsAvailable";
            this.lblEventMaterialDetailsAvailable.Size = new System.Drawing.Size(87, 16);
            this.lblEventMaterialDetailsAvailable.TabIndex = 4;
            this.lblEventMaterialDetailsAvailable.Text = "Beschikbaar:";
            // 
            // lblEventMaterialDetailsDailyrent
            // 
            this.lblEventMaterialDetailsDailyrent.AutoSize = true;
            this.lblEventMaterialDetailsDailyrent.Location = new System.Drawing.Point(20, 120);
            this.lblEventMaterialDetailsDailyrent.Name = "lblEventMaterialDetailsDailyrent";
            this.lblEventMaterialDetailsDailyrent.Size = new System.Drawing.Size(89, 16);
            this.lblEventMaterialDetailsDailyrent.TabIndex = 3;
            this.lblEventMaterialDetailsDailyrent.Text = "Huur per dag:";
            // 
            // lblEventMaterialDetailsPrice
            // 
            this.lblEventMaterialDetailsPrice.AutoSize = true;
            this.lblEventMaterialDetailsPrice.Location = new System.Drawing.Point(20, 90);
            this.lblEventMaterialDetailsPrice.Name = "lblEventMaterialDetailsPrice";
            this.lblEventMaterialDetailsPrice.Size = new System.Drawing.Size(37, 16);
            this.lblEventMaterialDetailsPrice.TabIndex = 2;
            this.lblEventMaterialDetailsPrice.Text = "Prijs:";
            // 
            // lblEventMaterialDetailsName
            // 
            this.lblEventMaterialDetailsName.AutoSize = true;
            this.lblEventMaterialDetailsName.Location = new System.Drawing.Point(20, 60);
            this.lblEventMaterialDetailsName.Name = "lblEventMaterialDetailsName";
            this.lblEventMaterialDetailsName.Size = new System.Drawing.Size(48, 16);
            this.lblEventMaterialDetailsName.TabIndex = 1;
            this.lblEventMaterialDetailsName.Text = "Naam:";
            // 
            // lblEventMaterialDetailsId
            // 
            this.lblEventMaterialDetailsId.AutoSize = true;
            this.lblEventMaterialDetailsId.Location = new System.Drawing.Point(20, 30);
            this.lblEventMaterialDetailsId.Name = "lblEventMaterialDetailsId";
            this.lblEventMaterialDetailsId.Size = new System.Drawing.Size(24, 16);
            this.lblEventMaterialDetailsId.TabIndex = 0;
            this.lblEventMaterialDetailsId.Text = "ID:";
            // 
            // btnEventMaterialDeleteMaterial
            // 
            this.btnEventMaterialDeleteMaterial.Location = new System.Drawing.Point(195, 444);
            this.btnEventMaterialDeleteMaterial.Name = "btnEventMaterialDeleteMaterial";
            this.btnEventMaterialDeleteMaterial.Size = new System.Drawing.Size(112, 42);
            this.btnEventMaterialDeleteMaterial.TabIndex = 3;
            this.btnEventMaterialDeleteMaterial.Text = "Materiaal Verwijderen";
            this.btnEventMaterialDeleteMaterial.UseVisualStyleBackColor = true;
            // 
            // btnEventMaterialAddMaterial
            // 
            this.btnEventMaterialAddMaterial.Location = new System.Drawing.Point(10, 443);
            this.btnEventMaterialAddMaterial.Name = "btnEventMaterialAddMaterial";
            this.btnEventMaterialAddMaterial.Size = new System.Drawing.Size(112, 44);
            this.btnEventMaterialAddMaterial.TabIndex = 2;
            this.btnEventMaterialAddMaterial.Text = "Materiaal Toevoegen";
            this.btnEventMaterialAddMaterial.UseVisualStyleBackColor = true;
            // 
            // lboxEventMaterialList
            // 
            this.lboxEventMaterialList.FormattingEnabled = true;
            this.lboxEventMaterialList.ItemHeight = 16;
            this.lboxEventMaterialList.Location = new System.Drawing.Point(7, 27);
            this.lboxEventMaterialList.Name = "lboxEventMaterialList";
            this.lboxEventMaterialList.Size = new System.Drawing.Size(300, 404);
            this.lboxEventMaterialList.TabIndex = 1;
            // 
            // lblEventMaterial
            // 
            this.lblEventMaterial.AutoSize = true;
            this.lblEventMaterial.Location = new System.Drawing.Point(7, 7);
            this.lblEventMaterial.Name = "lblEventMaterial";
            this.lblEventMaterial.Size = new System.Drawing.Size(74, 16);
            this.lblEventMaterial.TabIndex = 0;
            this.lblEventMaterial.Text = "Materialen:";
            // 
            // tabEventBeds
            // 
            this.tabEventBeds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEventBeds.Controls.Add(this.lblEventBedsMap);
            this.tabEventBeds.Controls.Add(this.pboxEventBedsMap);
            this.tabEventBeds.Controls.Add(this.gboxEventBedsDetails);
            this.tabEventBeds.Controls.Add(this.btnEventBedsDelete);
            this.tabEventBeds.Controls.Add(this.btnEventBedsAdd);
            this.tabEventBeds.Controls.Add(this.lboxEventBedsList);
            this.tabEventBeds.Controls.Add(this.lblEventBeds);
            this.tabEventBeds.Location = new System.Drawing.Point(4, 24);
            this.tabEventBeds.Name = "tabEventBeds";
            this.tabEventBeds.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventBeds.Size = new System.Drawing.Size(762, 495);
            this.tabEventBeds.TabIndex = 3;
            this.tabEventBeds.Text = "Kampeerplaatsen";
            this.tabEventBeds.UseVisualStyleBackColor = true;
            // 
            // lblEventBedsMap
            // 
            this.lblEventBedsMap.AutoSize = true;
            this.lblEventBedsMap.Location = new System.Drawing.Point(409, 180);
            this.lblEventBedsMap.Name = "lblEventBedsMap";
            this.lblEventBedsMap.Size = new System.Drawing.Size(80, 16);
            this.lblEventBedsMap.TabIndex = 6;
            this.lblEventBedsMap.Text = "Plattegrond:";
            // 
            // pboxEventBedsMap
            // 
            this.pboxEventBedsMap.Location = new System.Drawing.Point(409, 199);
            this.pboxEventBedsMap.Name = "pboxEventBedsMap";
            this.pboxEventBedsMap.Size = new System.Drawing.Size(333, 259);
            this.pboxEventBedsMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxEventBedsMap.TabIndex = 5;
            this.pboxEventBedsMap.TabStop = false;
            // 
            // gboxEventBedsDetails
            // 
            this.gboxEventBedsDetails.Controls.Add(this.cboxEventBedsDetailsOcuppied);
            this.gboxEventBedsDetails.Controls.Add(this.tbEventBedsDetailsMaxRenters);
            this.gboxEventBedsDetails.Controls.Add(this.tbEventBedsDetailsRenter);
            this.gboxEventBedsDetails.Controls.Add(this.tbEventBedsDetailsPrice);
            this.gboxEventBedsDetails.Controls.Add(this.tbEventBedsDetailsName);
            this.gboxEventBedsDetails.Controls.Add(this.lblEventBedsDetailsMaxRenters);
            this.gboxEventBedsDetails.Controls.Add(this.lblEventBedsDetailsRenter);
            this.gboxEventBedsDetails.Controls.Add(this.lblEventBedsDetailsPrice);
            this.gboxEventBedsDetails.Controls.Add(this.lblEventBedsDetailsOccupied);
            this.gboxEventBedsDetails.Controls.Add(this.lblEventBedsDetailsName);
            this.gboxEventBedsDetails.Location = new System.Drawing.Point(409, 27);
            this.gboxEventBedsDetails.Name = "gboxEventBedsDetails";
            this.gboxEventBedsDetails.Size = new System.Drawing.Size(333, 142);
            this.gboxEventBedsDetails.TabIndex = 4;
            this.gboxEventBedsDetails.TabStop = false;
            this.gboxEventBedsDetails.Text = "Info";
            // 
            // cboxEventBedsDetailsOcuppied
            // 
            this.cboxEventBedsDetailsOcuppied.AutoSize = true;
            this.cboxEventBedsDetailsOcuppied.Location = new System.Drawing.Point(117, 44);
            this.cboxEventBedsDetailsOcuppied.Name = "cboxEventBedsDetailsOcuppied";
            this.cboxEventBedsDetailsOcuppied.Size = new System.Drawing.Size(15, 14);
            this.cboxEventBedsDetailsOcuppied.TabIndex = 9;
            this.cboxEventBedsDetailsOcuppied.UseVisualStyleBackColor = true;
            // 
            // tbEventBedsDetailsMaxRenters
            // 
            this.tbEventBedsDetailsMaxRenters.Location = new System.Drawing.Point(116, 110);
            this.tbEventBedsDetailsMaxRenters.Name = "tbEventBedsDetailsMaxRenters";
            this.tbEventBedsDetailsMaxRenters.Size = new System.Drawing.Size(211, 22);
            this.tbEventBedsDetailsMaxRenters.TabIndex = 8;
            // 
            // tbEventBedsDetailsRenter
            // 
            this.tbEventBedsDetailsRenter.Location = new System.Drawing.Point(116, 86);
            this.tbEventBedsDetailsRenter.Name = "tbEventBedsDetailsRenter";
            this.tbEventBedsDetailsRenter.Size = new System.Drawing.Size(211, 22);
            this.tbEventBedsDetailsRenter.TabIndex = 7;
            // 
            // tbEventBedsDetailsPrice
            // 
            this.tbEventBedsDetailsPrice.Location = new System.Drawing.Point(116, 62);
            this.tbEventBedsDetailsPrice.Name = "tbEventBedsDetailsPrice";
            this.tbEventBedsDetailsPrice.Size = new System.Drawing.Size(211, 22);
            this.tbEventBedsDetailsPrice.TabIndex = 6;
            // 
            // tbEventBedsDetailsName
            // 
            this.tbEventBedsDetailsName.Location = new System.Drawing.Point(116, 17);
            this.tbEventBedsDetailsName.Name = "tbEventBedsDetailsName";
            this.tbEventBedsDetailsName.Size = new System.Drawing.Size(211, 22);
            this.tbEventBedsDetailsName.TabIndex = 5;
            // 
            // lblEventBedsDetailsMaxRenters
            // 
            this.lblEventBedsDetailsMaxRenters.AutoSize = true;
            this.lblEventBedsDetailsMaxRenters.Location = new System.Drawing.Point(15, 110);
            this.lblEventBedsDetailsMaxRenters.Name = "lblEventBedsDetailsMaxRenters";
            this.lblEventBedsDetailsMaxRenters.Size = new System.Drawing.Size(94, 16);
            this.lblEventBedsDetailsMaxRenters.TabIndex = 4;
            this.lblEventBedsDetailsMaxRenters.Text = "Max Huurders:";
            // 
            // lblEventBedsDetailsRenter
            // 
            this.lblEventBedsDetailsRenter.AutoSize = true;
            this.lblEventBedsDetailsRenter.Location = new System.Drawing.Point(15, 86);
            this.lblEventBedsDetailsRenter.Name = "lblEventBedsDetailsRenter";
            this.lblEventBedsDetailsRenter.Size = new System.Drawing.Size(99, 16);
            this.lblEventBedsDetailsRenter.TabIndex = 3;
            this.lblEventBedsDetailsRenter.Text = "Naam Huurder:";
            // 
            // lblEventBedsDetailsPrice
            // 
            this.lblEventBedsDetailsPrice.AutoSize = true;
            this.lblEventBedsDetailsPrice.Location = new System.Drawing.Point(15, 64);
            this.lblEventBedsDetailsPrice.Name = "lblEventBedsDetailsPrice";
            this.lblEventBedsDetailsPrice.Size = new System.Drawing.Size(37, 16);
            this.lblEventBedsDetailsPrice.TabIndex = 2;
            this.lblEventBedsDetailsPrice.Text = "Prijs:";
            // 
            // lblEventBedsDetailsOccupied
            // 
            this.lblEventBedsDetailsOccupied.AutoSize = true;
            this.lblEventBedsDetailsOccupied.Location = new System.Drawing.Point(15, 42);
            this.lblEventBedsDetailsOccupied.Name = "lblEventBedsDetailsOccupied";
            this.lblEventBedsDetailsOccupied.Size = new System.Drawing.Size(45, 16);
            this.lblEventBedsDetailsOccupied.TabIndex = 1;
            this.lblEventBedsDetailsOccupied.Text = "Bezet:";
            // 
            // lblEventBedsDetailsName
            // 
            this.lblEventBedsDetailsName.AutoSize = true;
            this.lblEventBedsDetailsName.Location = new System.Drawing.Point(15, 20);
            this.lblEventBedsDetailsName.Name = "lblEventBedsDetailsName";
            this.lblEventBedsDetailsName.Size = new System.Drawing.Size(48, 16);
            this.lblEventBedsDetailsName.TabIndex = 0;
            this.lblEventBedsDetailsName.Text = "Naam:";
            // 
            // btnEventBedsDelete
            // 
            this.btnEventBedsDelete.Location = new System.Drawing.Point(207, 464);
            this.btnEventBedsDelete.Name = "btnEventBedsDelete";
            this.btnEventBedsDelete.Size = new System.Drawing.Size(100, 23);
            this.btnEventBedsDelete.TabIndex = 3;
            this.btnEventBedsDelete.Text = "Verwijderen";
            this.btnEventBedsDelete.UseVisualStyleBackColor = true;
            // 
            // btnEventBedsAdd
            // 
            this.btnEventBedsAdd.Location = new System.Drawing.Point(6, 464);
            this.btnEventBedsAdd.Name = "btnEventBedsAdd";
            this.btnEventBedsAdd.Size = new System.Drawing.Size(100, 23);
            this.btnEventBedsAdd.TabIndex = 2;
            this.btnEventBedsAdd.Text = "Toevoegen";
            this.btnEventBedsAdd.UseVisualStyleBackColor = true;
            // 
            // lboxEventBedsList
            // 
            this.lboxEventBedsList.FormattingEnabled = true;
            this.lboxEventBedsList.ItemHeight = 16;
            this.lboxEventBedsList.Location = new System.Drawing.Point(7, 27);
            this.lboxEventBedsList.Name = "lboxEventBedsList";
            this.lboxEventBedsList.Size = new System.Drawing.Size(300, 436);
            this.lboxEventBedsList.TabIndex = 1;
            // 
            // lblEventBeds
            // 
            this.lblEventBeds.AutoSize = true;
            this.lblEventBeds.Location = new System.Drawing.Point(7, 7);
            this.lblEventBeds.Name = "lblEventBeds";
            this.lblEventBeds.Size = new System.Drawing.Size(118, 16);
            this.lblEventBeds.TabIndex = 0;
            this.lblEventBeds.Text = "Kampeerplaatsen:";
            // 
            // pnlEbsMain
            // 
            this.pnlEbsMain.Controls.Add(this.dgvEbsEvents);
            this.pnlEbsMain.Controls.Add(this.btnEbsAdd);
            this.pnlEbsMain.Controls.Add(this.btnEbsRemove);
            this.pnlEbsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEbsMain.Location = new System.Drawing.Point(0, 0);
            this.pnlEbsMain.Name = "pnlEbsMain";
            this.pnlEbsMain.Size = new System.Drawing.Size(784, 561);
            this.pnlEbsMain.TabIndex = 5;
            // 
            // EbsHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlEbsEvent);
            this.Controls.Add(this.pnlEbsMain);
            this.Name = "EbsHomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Beheer Systeem";
            this.Load += new System.EventHandler(this.EbsHomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEbsEvents)).EndInit();
            this.pnlEbsEvent.ResumeLayout(false);
            this.pnlEbsEvent.PerformLayout();
            this.tabEvent.ResumeLayout(false);
            this.tabEventDetails.ResumeLayout(false);
            this.tabEventDetails.PerformLayout();
            this.tabEventDeelnemers.ResumeLayout(false);
            this.tabEventDeelnemers.PerformLayout();
            this.gboxEventVisitorsDetails.ResumeLayout(false);
            this.gboxEventVisitorsDetails.PerformLayout();
            this.tabEventMaterialen.ResumeLayout(false);
            this.tabEventMaterialen.PerformLayout();
            this.gboxEventMaterialDetails.ResumeLayout(false);
            this.gboxEventMaterialDetails.PerformLayout();
            this.tabEventBeds.ResumeLayout(false);
            this.tabEventBeds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxEventBedsMap)).EndInit();
            this.gboxEventBedsDetails.ResumeLayout(false);
            this.gboxEventBedsDetails.PerformLayout();
            this.pnlEbsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEbsAdd;
        private System.Windows.Forms.Button btnEbsRemove;
        private System.Windows.Forms.DataGridView dgvEbsEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEndDate;
        private System.Windows.Forms.Panel pnlEbsEvent;
        private System.Windows.Forms.TabControl tabEvent;
        private System.Windows.Forms.TabPage tabEventDetails;
        private System.Windows.Forms.TabPage tabEventDeelnemers;
        private System.Windows.Forms.Label lblEbsTabEvent;
        private System.Windows.Forms.TabPage tabEventMaterialen;
        private System.Windows.Forms.TabPage tabEventBeds;
        private System.Windows.Forms.Button btnEventTerug;
        private System.Windows.Forms.Panel pnlEbsMain;
        private System.Windows.Forms.Label lblEventDetailsTitel;
        private System.Windows.Forms.Label lblEventDetailsVisitorcount;
        private System.Windows.Forms.CheckBox cboxEventDetailsOpen;
        private System.Windows.Forms.Label lblEventDetailsEndDate;
        private System.Windows.Forms.Label lblEventDetailsBeginDate;
        private System.Windows.Forms.Label lblEventDetailsLocation;
        private System.Windows.Forms.Label lblEventDetailsName;
        private System.Windows.Forms.TextBox tbEventDetailsCounter;
        private System.Windows.Forms.DateTimePicker dtpEventDetailsEndDate;
        private System.Windows.Forms.DateTimePicker dtpEventDetailsBeginDate;
        private System.Windows.Forms.TextBox tbEventDetailsLocation;
        private System.Windows.Forms.TextBox tbEventDetailsNaam;
        private System.Windows.Forms.Label lblEventDetailsOpen;
        private System.Windows.Forms.GroupBox gboxEventVisitorsDetails;
        private System.Windows.Forms.TextBox tbEventVisitorsDetailsBednr;
        private System.Windows.Forms.TextBox tbEventVisitorsDetailsZipcode;
        private System.Windows.Forms.TextBox tbEventVisitorsDetailsStreet;
        private System.Windows.Forms.TextBox tbEventVisitorsDetailsLastname;
        private System.Windows.Forms.TextBox tbEventVisitorsDetailsSurname;
        private System.Windows.Forms.Button btnEventVisitorsDetailsDeleteMaterial;
        private System.Windows.Forms.Button btnEventVisitorsDetailsChangeMaterial;
        private System.Windows.Forms.Button btnEventVisitorsDetailsAddMaterial;
        private System.Windows.Forms.Button btnEventVisitorsDetailsDeleteMember;
        private System.Windows.Forms.Button btnEventVisitorsDetailsChangeMember;
        private System.Windows.Forms.Button btnEventVisitorsDetailsAddMember;
        private System.Windows.Forms.ListBox lboxEventVisitorsDetailsMaterials;
        private System.Windows.Forms.Label lblEventVisitorsDetailsMaterials;
        private System.Windows.Forms.ListBox lboxEventVisitorsDetailsMembers;
        private System.Windows.Forms.Label lblEventVisitorsDetailsMembers;
        private System.Windows.Forms.Label lblEventVisitorsDetailsBookingDate;
        private System.Windows.Forms.Label lblEventVisitorsDetailsBednr;
        private System.Windows.Forms.Label lblEventVisitorsDetailsZipcode;
        private System.Windows.Forms.Label lblEventVisitorsDetailsAddress;
        private System.Windows.Forms.Label lblEventVisitorsDetailsLastname;
        private System.Windows.Forms.Label lblEventVisitorsDetailsSurname;
        private System.Windows.Forms.ListBox lboxEventVisitorsList;
        private System.Windows.Forms.TextBox tbEventVisitorsSearch;
        private System.Windows.Forms.Label lblEventVisitors;
        private System.Windows.Forms.CheckBox cboxEventVisitorsDetailsPaid;
        private System.Windows.Forms.CheckBox cboxEventVisitorsDetailsPresent;
        private System.Windows.Forms.DateTimePicker dtpEventVisitorsDetailsBookingDate;
        private System.Windows.Forms.TextBox tbEventVisitorsDetailsStreetNr;
        private System.Windows.Forms.ListBox lboxEventMaterialList;
        private System.Windows.Forms.Label lblEventMaterial;
        private System.Windows.Forms.GroupBox gboxEventMaterialDetails;
        private System.Windows.Forms.TextBox tbEventMaterialDetailsAvailable;
        private System.Windows.Forms.TextBox tbEventMaterialDetailsDailyrent;
        private System.Windows.Forms.TextBox tbEventMaterialDetailsPrice;
        private System.Windows.Forms.TextBox tbEventMaterialDetailsName;
        private System.Windows.Forms.TextBox tbEventMaterialDetailsId;
        private System.Windows.Forms.Button btnEventMaterialDetailsDeleteRenter;
        private System.Windows.Forms.Button btnEventMaterialDetailsChangeRenter;
        private System.Windows.Forms.Button btnEventMaterialDetailsAddRenter;
        private System.Windows.Forms.ListBox lboxEventMaterialDetailsRentersList;
        private System.Windows.Forms.Label lblEventMaterialDetailsRenters;
        private System.Windows.Forms.Label lblEventMaterialDetailsAvailable;
        private System.Windows.Forms.Label lblEventMaterialDetailsDailyrent;
        private System.Windows.Forms.Label lblEventMaterialDetailsPrice;
        private System.Windows.Forms.Label lblEventMaterialDetailsName;
        private System.Windows.Forms.Label lblEventMaterialDetailsId;
        private System.Windows.Forms.Button btnEventMaterialDeleteMaterial;
        private System.Windows.Forms.Button btnEventMaterialAddMaterial;
        private System.Windows.Forms.Label lblEventBedsMap;
        private System.Windows.Forms.PictureBox pboxEventBedsMap;
        private System.Windows.Forms.GroupBox gboxEventBedsDetails;
        private System.Windows.Forms.Button btnEventBedsDelete;
        private System.Windows.Forms.Button btnEventBedsAdd;
        private System.Windows.Forms.ListBox lboxEventBedsList;
        private System.Windows.Forms.Label lblEventBeds;
        private System.Windows.Forms.CheckBox cboxEventBedsDetailsOcuppied;
        private System.Windows.Forms.TextBox tbEventBedsDetailsMaxRenters;
        private System.Windows.Forms.TextBox tbEventBedsDetailsRenter;
        private System.Windows.Forms.TextBox tbEventBedsDetailsPrice;
        private System.Windows.Forms.TextBox tbEventBedsDetailsName;
        private System.Windows.Forms.Label lblEventBedsDetailsMaxRenters;
        private System.Windows.Forms.Label lblEventBedsDetailsRenter;
        private System.Windows.Forms.Label lblEventBedsDetailsPrice;
        private System.Windows.Forms.Label lblEventBedsDetailsOccupied;
        private System.Windows.Forms.Label lblEventBedsDetailsName;

    }
}

