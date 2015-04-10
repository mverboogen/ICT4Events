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
            this.ColumnNaam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEbsEvent = new System.Windows.Forms.Panel();
            this.btnEventTerug = new System.Windows.Forms.Button();
            this.lblEbsTabEvent = new System.Windows.Forms.Label();
            this.tabEbsEvent = new System.Windows.Forms.TabControl();
            this.tabEventDetails = new System.Windows.Forms.TabPage();
            this.tabEventDeelnemers = new System.Windows.Forms.TabPage();
            this.tabEventMaterialen = new System.Windows.Forms.TabPage();
            this.tabEventPlaatsen = new System.Windows.Forms.TabPage();
            this.pnlMainForm = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEbsEvents)).BeginInit();
            this.pnlEbsEvent.SuspendLayout();
            this.tabEbsEvent.SuspendLayout();
            this.pnlMainForm.SuspendLayout();
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
            this.ColumnNaam,
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
            // ColumnNaam
            // 
            this.ColumnNaam.HeaderText = "Event Naam";
            this.ColumnNaam.Name = "ColumnNaam";
            this.ColumnNaam.ReadOnly = true;
            this.ColumnNaam.Width = 300;
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
            this.pnlEbsEvent.Controls.Add(this.tabEbsEvent);
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
            // tabEbsEvent
            // 
            this.tabEbsEvent.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabEbsEvent.Controls.Add(this.tabEventDetails);
            this.tabEbsEvent.Controls.Add(this.tabEventDeelnemers);
            this.tabEbsEvent.Controls.Add(this.tabEventMaterialen);
            this.tabEbsEvent.Controls.Add(this.tabEventPlaatsen);
            this.tabEbsEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEbsEvent.ItemSize = new System.Drawing.Size(44, 20);
            this.tabEbsEvent.Location = new System.Drawing.Point(7, 35);
            this.tabEbsEvent.Name = "tabEbsEvent";
            this.tabEbsEvent.Padding = new System.Drawing.Point(5, 2);
            this.tabEbsEvent.SelectedIndex = 0;
            this.tabEbsEvent.Size = new System.Drawing.Size(770, 523);
            this.tabEbsEvent.TabIndex = 0;
            // 
            // tabEventDetails
            // 
            this.tabEventDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // pnlMainForm
            // 
            this.pnlMainForm.Controls.Add(this.dgvEbsEvents);
            this.pnlMainForm.Controls.Add(this.btnEbsAdd);
            this.pnlMainForm.Controls.Add(this.btnEbsRemove);
            this.pnlMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainForm.Location = new System.Drawing.Point(0, 0);
            this.pnlMainForm.Name = "pnlMainForm";
            this.pnlMainForm.Size = new System.Drawing.Size(784, 561);
            this.pnlMainForm.TabIndex = 5;
            // 
            // EbsHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlMainForm);
            this.Controls.Add(this.pnlEbsEvent);
            this.Name = "EbsHomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Beheer Systeem";
            this.Load += new System.EventHandler(this.EbsHomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEbsEvents)).EndInit();
            this.pnlEbsEvent.ResumeLayout(false);
            this.pnlEbsEvent.PerformLayout();
            this.tabEbsEvent.ResumeLayout(false);
            this.pnlMainForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEbsAdd;
        private System.Windows.Forms.Button btnEbsRemove;
        private System.Windows.Forms.DataGridView dgvEbsEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNaam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEndDate;
        private System.Windows.Forms.Panel pnlEbsEvent;
        private System.Windows.Forms.TabControl tabEbsEvent;
        private System.Windows.Forms.TabPage tabEventDetails;
        private System.Windows.Forms.TabPage tabEventDeelnemers;
        private System.Windows.Forms.Label lblEbsTabEvent;
        private System.Windows.Forms.TabPage tabEventMaterialen;
        private System.Windows.Forms.TabPage tabEventPlaatsen;
        private System.Windows.Forms.Button btnEventTerug;
        private System.Windows.Forms.Panel pnlMainForm;

    }
}

