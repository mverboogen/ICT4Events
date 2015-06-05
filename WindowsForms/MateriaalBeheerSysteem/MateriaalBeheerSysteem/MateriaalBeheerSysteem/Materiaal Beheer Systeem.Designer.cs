namespace MateriaalBeheerSysteem
{
    partial class Form1
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
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.lboxMaterials = new System.Windows.Forms.ListBox();
            this.lblEventMaterial = new System.Windows.Forms.Label();
            this.tbAvailible = new System.Windows.Forms.TextBox();
            this.tbDailyRent = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnDeleteRenter = new System.Windows.Forms.Button();
            this.btnAddRenter = new System.Windows.Forms.Button();
            this.lboxMaterialRenters = new System.Windows.Forms.ListBox();
            this.lblEventMaterialDetailsAvailable = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsDailyrent = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsPrice = new System.Windows.Forms.Label();
            this.lblEventMaterialDetailsName = new System.Windows.Forms.Label();
            this.gboxEventMaterialDetails = new System.Windows.Forms.GroupBox();
            this.lblEventMaterialDetailsRenters = new System.Windows.Forms.Label();
            this.gboxEventMaterialDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Location = new System.Drawing.Point(200, 444);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(112, 42);
            this.btnDeleteMaterial.TabIndex = 8;
            this.btnDeleteMaterial.Text = "Materiaal Verwijderen";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(15, 443);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(112, 44);
            this.btnAddMaterial.TabIndex = 7;
            this.btnAddMaterial.Text = "Materiaal Toevoegen";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // lboxMaterials
            // 
            this.lboxMaterials.FormattingEnabled = true;
            this.lboxMaterials.Location = new System.Drawing.Point(12, 27);
            this.lboxMaterials.Name = "lboxMaterials";
            this.lboxMaterials.Size = new System.Drawing.Size(300, 394);
            this.lboxMaterials.TabIndex = 6;
            this.lboxMaterials.SelectedIndexChanged += new System.EventHandler(this.lboxMaterials_SelectedIndexChanged);
            // 
            // lblEventMaterial
            // 
            this.lblEventMaterial.AutoSize = true;
            this.lblEventMaterial.Location = new System.Drawing.Point(12, 7);
            this.lblEventMaterial.Name = "lblEventMaterial";
            this.lblEventMaterial.Size = new System.Drawing.Size(59, 13);
            this.lblEventMaterial.TabIndex = 5;
            this.lblEventMaterial.Text = "Materialen:";
            // 
            // tbAvailible
            // 
            this.tbAvailible.Location = new System.Drawing.Point(147, 116);
            this.tbAvailible.Name = "tbAvailible";
            this.tbAvailible.Size = new System.Drawing.Size(256, 20);
            this.tbAvailible.TabIndex = 14;
            // 
            // tbDailyRent
            // 
            this.tbDailyRent.Location = new System.Drawing.Point(147, 86);
            this.tbDailyRent.Name = "tbDailyRent";
            this.tbDailyRent.Size = new System.Drawing.Size(256, 20);
            this.tbDailyRent.TabIndex = 13;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(147, 56);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(256, 20);
            this.tbPrice.TabIndex = 12;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(147, 26);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(256, 20);
            this.tbName.TabIndex = 11;
            // 
            // btnDeleteRenter
            // 
            this.btnDeleteRenter.Location = new System.Drawing.Point(288, 448);
            this.btnDeleteRenter.Name = "btnDeleteRenter";
            this.btnDeleteRenter.Size = new System.Drawing.Size(115, 23);
            this.btnDeleteRenter.TabIndex = 9;
            this.btnDeleteRenter.Text = "Verwijderen";
            this.btnDeleteRenter.UseVisualStyleBackColor = true;
            this.btnDeleteRenter.Click += new System.EventHandler(this.btnDeleteRenter_Click);
            // 
            // btnAddRenter
            // 
            this.btnAddRenter.Location = new System.Drawing.Point(25, 449);
            this.btnAddRenter.Name = "btnAddRenter";
            this.btnAddRenter.Size = new System.Drawing.Size(120, 23);
            this.btnAddRenter.TabIndex = 7;
            this.btnAddRenter.Text = "Toevoegen";
            this.btnAddRenter.UseVisualStyleBackColor = true;
            this.btnAddRenter.Click += new System.EventHandler(this.btnAddRenter_Click);
            // 
            // lboxMaterialRenters
            // 
            this.lboxMaterialRenters.FormattingEnabled = true;
            this.lboxMaterialRenters.Location = new System.Drawing.Point(25, 151);
            this.lboxMaterialRenters.Name = "lboxMaterialRenters";
            this.lboxMaterialRenters.Size = new System.Drawing.Size(378, 290);
            this.lboxMaterialRenters.TabIndex = 6;
            // 
            // lblEventMaterialDetailsAvailable
            // 
            this.lblEventMaterialDetailsAvailable.AutoSize = true;
            this.lblEventMaterialDetailsAvailable.Location = new System.Drawing.Point(20, 116);
            this.lblEventMaterialDetailsAvailable.Name = "lblEventMaterialDetailsAvailable";
            this.lblEventMaterialDetailsAvailable.Size = new System.Drawing.Size(69, 13);
            this.lblEventMaterialDetailsAvailable.TabIndex = 4;
            this.lblEventMaterialDetailsAvailable.Text = "Beschikbaar:";
            // 
            // lblEventMaterialDetailsDailyrent
            // 
            this.lblEventMaterialDetailsDailyrent.AutoSize = true;
            this.lblEventMaterialDetailsDailyrent.Location = new System.Drawing.Point(20, 86);
            this.lblEventMaterialDetailsDailyrent.Name = "lblEventMaterialDetailsDailyrent";
            this.lblEventMaterialDetailsDailyrent.Size = new System.Drawing.Size(72, 13);
            this.lblEventMaterialDetailsDailyrent.TabIndex = 3;
            this.lblEventMaterialDetailsDailyrent.Text = "Huur per dag:";
            // 
            // lblEventMaterialDetailsPrice
            // 
            this.lblEventMaterialDetailsPrice.AutoSize = true;
            this.lblEventMaterialDetailsPrice.Location = new System.Drawing.Point(20, 56);
            this.lblEventMaterialDetailsPrice.Name = "lblEventMaterialDetailsPrice";
            this.lblEventMaterialDetailsPrice.Size = new System.Drawing.Size(29, 13);
            this.lblEventMaterialDetailsPrice.TabIndex = 2;
            this.lblEventMaterialDetailsPrice.Text = "Prijs:";
            // 
            // lblEventMaterialDetailsName
            // 
            this.lblEventMaterialDetailsName.AutoSize = true;
            this.lblEventMaterialDetailsName.Location = new System.Drawing.Point(20, 26);
            this.lblEventMaterialDetailsName.Name = "lblEventMaterialDetailsName";
            this.lblEventMaterialDetailsName.Size = new System.Drawing.Size(38, 13);
            this.lblEventMaterialDetailsName.TabIndex = 1;
            this.lblEventMaterialDetailsName.Text = "Naam:";
            // 
            // gboxEventMaterialDetails
            // 
            this.gboxEventMaterialDetails.Controls.Add(this.tbAvailible);
            this.gboxEventMaterialDetails.Controls.Add(this.tbDailyRent);
            this.gboxEventMaterialDetails.Controls.Add(this.tbPrice);
            this.gboxEventMaterialDetails.Controls.Add(this.tbName);
            this.gboxEventMaterialDetails.Controls.Add(this.btnDeleteRenter);
            this.gboxEventMaterialDetails.Controls.Add(this.btnAddRenter);
            this.gboxEventMaterialDetails.Controls.Add(this.lboxMaterialRenters);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsRenters);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsAvailable);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsDailyrent);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsPrice);
            this.gboxEventMaterialDetails.Controls.Add(this.lblEventMaterialDetailsName);
            this.gboxEventMaterialDetails.Location = new System.Drawing.Point(345, 10);
            this.gboxEventMaterialDetails.Name = "gboxEventMaterialDetails";
            this.gboxEventMaterialDetails.Size = new System.Drawing.Size(409, 479);
            this.gboxEventMaterialDetails.TabIndex = 9;
            this.gboxEventMaterialDetails.TabStop = false;
            this.gboxEventMaterialDetails.Text = "Details";
            // 
            // lblEventMaterialDetailsRenters
            // 
            this.lblEventMaterialDetailsRenters.AutoSize = true;
            this.lblEventMaterialDetailsRenters.Location = new System.Drawing.Point(22, 211);
            this.lblEventMaterialDetailsRenters.Name = "lblEventMaterialDetailsRenters";
            this.lblEventMaterialDetailsRenters.Size = new System.Drawing.Size(53, 13);
            this.lblEventMaterialDetailsRenters.TabIndex = 5;
            this.lblEventMaterialDetailsRenters.Text = "Huurders:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 492);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.btnAddMaterial);
            this.Controls.Add(this.lboxMaterials);
            this.Controls.Add(this.lblEventMaterial);
            this.Controls.Add(this.gboxEventMaterialDetails);
            this.Name = "Form1";
            this.Text = "Materiaal Beheer Systeem";
            this.gboxEventMaterialDetails.ResumeLayout(false);
            this.gboxEventMaterialDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.ListBox lboxMaterials;
        private System.Windows.Forms.Label lblEventMaterial;
        private System.Windows.Forms.TextBox tbAvailible;
        private System.Windows.Forms.TextBox tbDailyRent;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnDeleteRenter;
        private System.Windows.Forms.Button btnAddRenter;
        private System.Windows.Forms.ListBox lboxMaterialRenters;
        private System.Windows.Forms.Label lblEventMaterialDetailsAvailable;
        private System.Windows.Forms.Label lblEventMaterialDetailsDailyrent;
        private System.Windows.Forms.Label lblEventMaterialDetailsPrice;
        private System.Windows.Forms.Label lblEventMaterialDetailsName;
        private System.Windows.Forms.GroupBox gboxEventMaterialDetails;
        private System.Windows.Forms.Label lblEventMaterialDetailsRenters;
    }
}

