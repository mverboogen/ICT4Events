namespace Event_Beheer_Systeem
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
            this.tabEventDeelnemers = new System.Windows.Forms.TabPage();
            this.tabEventMaterialen = new System.Windows.Forms.TabPage();
            this.tabEventPlaatsen = new System.Windows.Forms.TabPage();
            this.pnlEbsMain = new System.Windows.Forms.Panel();
            this.lblEventDetailsName = new System.Windows.Forms.Label();
            this.lblEventDetailsLocation = new System.Windows.Forms.Label();
            this.lblEventDetailsBeginDate = new System.Windows.Forms.Label();
            this.lblEventDetailsEndDate = new System.Windows.Forms.Label();
            this.cboxEventDetailsOpen = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEventDetailsTitel = new System.Windows.Forms.Label();
            this.lblEventDetailsOpen = new System.Windows.Forms.Label();
            this.tbEventDetailsNaam = new System.Windows.Forms.TextBox();
            this.tbEventDetailsLocation = new System.Windows.Forms.TextBox();
            this.dtpEventDetailsBeginDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEventDetailsEndDate = new System.Windows.Forms.DateTimePicker();
            this.tbEventDetailsCounter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEbsEvents)).BeginInit();
            this.pnlEbsEvent.SuspendLayout();
            this.tabEvent.SuspendLayout();
            this.tabEventDetails.SuspendLayout();
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
            this.tabEvent.Controls.Add(this.tabEventPlaatsen);
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
            this.tabEventDetails.Controls.Add(this.label5);
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
            // tabEventDeelnemers
            // 
            this.tabEventDeelnemers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEventDeelnemers.Location = new System.Drawing.Point(4, 24);
            this.tabEventDeelnemers.Name = "tabEventDeelnemers";
            this.tabEventDeelnemers.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventDeelnemers.Size = new System.Drawing.Size(762, 495);
            this.tabEventDeelnemers.TabIndex = 1;
            this.tabEventDeelnemers.Text = "Deelnemers";
            this.tabEventDeelnemers.UseVisualStyleBackColor = true;
            // 
            // tabEventMaterialen
            // 
            this.tabEventMaterialen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEventMaterialen.Location = new System.Drawing.Point(4, 24);
            this.tabEventMaterialen.Name = "tabEventMaterialen";
            this.tabEventMaterialen.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventMaterialen.Size = new System.Drawing.Size(762, 495);
            this.tabEventMaterialen.TabIndex = 2;
            this.tabEventMaterialen.Text = "Materialen";
            this.tabEventMaterialen.UseVisualStyleBackColor = true;
            // 
            // tabEventPlaatsen
            // 
            this.tabEventPlaatsen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEventPlaatsen.Location = new System.Drawing.Point(4, 24);
            this.tabEventPlaatsen.Name = "tabEventPlaatsen";
            this.tabEventPlaatsen.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventPlaatsen.Size = new System.Drawing.Size(762, 495);
            this.tabEventPlaatsen.TabIndex = 3;
            this.tabEventPlaatsen.Text = "Kampeerplaatsen";
            this.tabEventPlaatsen.UseVisualStyleBackColor = true;
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
            // lblEventDetailsName
            // 
            this.lblEventDetailsName.AutoSize = true;
            this.lblEventDetailsName.Location = new System.Drawing.Point(15, 100);
            this.lblEventDetailsName.Name = "lblEventDetailsName";
            this.lblEventDetailsName.Size = new System.Drawing.Size(85, 16);
            this.lblEventDetailsName.TabIndex = 0;
            this.lblEventDetailsName.Text = "Event Naam:";
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
            // lblEventDetailsBeginDate
            // 
            this.lblEventDetailsBeginDate.AutoSize = true;
            this.lblEventDetailsBeginDate.Location = new System.Drawing.Point(15, 180);
            this.lblEventDetailsBeginDate.Name = "lblEventDetailsBeginDate";
            this.lblEventDetailsBeginDate.Size = new System.Drawing.Size(125, 16);
            this.lblEventDetailsBeginDate.TabIndex = 2;
            this.lblEventDetailsBeginDate.Text = "Event Begin Datum:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Aanmeldingen:";
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
            // lblEventDetailsOpen
            // 
            this.lblEventDetailsOpen.AutoSize = true;
            this.lblEventDetailsOpen.Location = new System.Drawing.Point(15, 260);
            this.lblEventDetailsOpen.Name = "lblEventDetailsOpen";
            this.lblEventDetailsOpen.Size = new System.Drawing.Size(121, 16);
            this.lblEventDetailsOpen.TabIndex = 7;
            this.lblEventDetailsOpen.Text = "Reservering Open:";
            // 
            // tbEventDetailsNaam
            // 
            this.tbEventDetailsNaam.Location = new System.Drawing.Point(180, 94);
            this.tbEventDetailsNaam.Name = "tbEventDetailsNaam";
            this.tbEventDetailsNaam.Size = new System.Drawing.Size(220, 22);
            this.tbEventDetailsNaam.TabIndex = 8;
            // 
            // tbEventDetailsLocation
            // 
            this.tbEventDetailsLocation.Location = new System.Drawing.Point(180, 137);
            this.tbEventDetailsLocation.Name = "tbEventDetailsLocation";
            this.tbEventDetailsLocation.Size = new System.Drawing.Size(220, 22);
            this.tbEventDetailsLocation.TabIndex = 9;
            // 
            // dtpEventDetailsBeginDate
            // 
            this.dtpEventDetailsBeginDate.Location = new System.Drawing.Point(180, 175);
            this.dtpEventDetailsBeginDate.Name = "dtpEventDetailsBeginDate";
            this.dtpEventDetailsBeginDate.Size = new System.Drawing.Size(220, 22);
            this.dtpEventDetailsBeginDate.TabIndex = 10;
            // 
            // dtpEventDetailsEndDate
            // 
            this.dtpEventDetailsEndDate.Location = new System.Drawing.Point(180, 215);
            this.dtpEventDetailsEndDate.Name = "dtpEventDetailsEndDate";
            this.dtpEventDetailsEndDate.Size = new System.Drawing.Size(220, 22);
            this.dtpEventDetailsEndDate.TabIndex = 11;
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
        private System.Windows.Forms.TabPage tabEventPlaatsen;
        private System.Windows.Forms.Button btnEventTerug;
        private System.Windows.Forms.Panel pnlEbsMain;
        private System.Windows.Forms.Label lblEventDetailsTitel;
        private System.Windows.Forms.Label label5;
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

    }
}

