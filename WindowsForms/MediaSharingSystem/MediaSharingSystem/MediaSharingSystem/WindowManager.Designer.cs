namespace MediaSharingSystem
{
    partial class WindowManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowManager));
            this.btnNavTimeline = new System.Windows.Forms.Button();
            this.btnNavUpload = new System.Windows.Forms.Button();
            this.btnNavMessages = new System.Windows.Forms.Button();
            this.btnNavVideos = new System.Windows.Forms.Button();
            this.btnNavPictures = new System.Windows.Forms.Button();
            this.tbNavSearch = new System.Windows.Forms.TextBox();
            this.btnNavSearch = new System.Windows.Forms.Button();
            this.cbNavSearchFilter = new System.Windows.Forms.ComboBox();
            this.pnlWindowContent = new System.Windows.Forms.Panel();
            this.pnlWindowCategories = new System.Windows.Forms.Panel();
            this.btnNavAdmins = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNavTimeline
            // 
            this.btnNavTimeline.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavTimeline.BackgroundImage")));
            this.btnNavTimeline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNavTimeline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTimeline.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavTimeline.Location = new System.Drawing.Point(13, 12);
            this.btnNavTimeline.Name = "btnNavTimeline";
            this.btnNavTimeline.Size = new System.Drawing.Size(56, 50);
            this.btnNavTimeline.TabIndex = 0;
            this.btnNavTimeline.UseVisualStyleBackColor = true;
            this.btnNavTimeline.Click += new System.EventHandler(this.btnNavTimeline_Click);
            // 
            // btnNavUpload
            // 
            this.btnNavUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavUpload.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavUpload.Location = new System.Drawing.Point(273, 20);
            this.btnNavUpload.Name = "btnNavUpload";
            this.btnNavUpload.Size = new System.Drawing.Size(120, 35);
            this.btnNavUpload.TabIndex = 1;
            this.btnNavUpload.Text = "Upload";
            this.btnNavUpload.UseVisualStyleBackColor = true;
            this.btnNavUpload.Click += new System.EventHandler(this.btnNavUpload_Click);
            // 
            // btnNavMessages
            // 
            this.btnNavMessages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavMessages.BackgroundImage")));
            this.btnNavMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNavMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMessages.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavMessages.Location = new System.Drawing.Point(207, 12);
            this.btnNavMessages.Name = "btnNavMessages";
            this.btnNavMessages.Size = new System.Drawing.Size(60, 50);
            this.btnNavMessages.TabIndex = 2;
            this.btnNavMessages.UseVisualStyleBackColor = true;
            this.btnNavMessages.Click += new System.EventHandler(this.btnNavMessages_Click);
            // 
            // btnNavVideos
            // 
            this.btnNavVideos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavVideos.BackgroundImage")));
            this.btnNavVideos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNavVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavVideos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavVideos.Location = new System.Drawing.Point(141, 12);
            this.btnNavVideos.Name = "btnNavVideos";
            this.btnNavVideos.Size = new System.Drawing.Size(60, 50);
            this.btnNavVideos.TabIndex = 3;
            this.btnNavVideos.UseVisualStyleBackColor = true;
            this.btnNavVideos.Click += new System.EventHandler(this.btnNavVideos_Click);
            // 
            // btnNavPictures
            // 
            this.btnNavPictures.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnNavPictures.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavPictures.BackgroundImage")));
            this.btnNavPictures.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNavPictures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPictures.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavPictures.Location = new System.Drawing.Point(75, 12);
            this.btnNavPictures.Name = "btnNavPictures";
            this.btnNavPictures.Size = new System.Drawing.Size(60, 50);
            this.btnNavPictures.TabIndex = 4;
            this.btnNavPictures.UseVisualStyleBackColor = true;
            this.btnNavPictures.Click += new System.EventHandler(this.btnNavPictures_Click);
            // 
            // tbNavSearch
            // 
            this.tbNavSearch.Location = new System.Drawing.Point(603, 29);
            this.tbNavSearch.Name = "tbNavSearch";
            this.tbNavSearch.Size = new System.Drawing.Size(224, 20);
            this.tbNavSearch.TabIndex = 5;
            // 
            // btnNavSearch
            // 
            this.btnNavSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSearch.Location = new System.Drawing.Point(915, 20);
            this.btnNavSearch.Name = "btnNavSearch";
            this.btnNavSearch.Size = new System.Drawing.Size(81, 34);
            this.btnNavSearch.TabIndex = 6;
            this.btnNavSearch.Text = "Search";
            this.btnNavSearch.UseVisualStyleBackColor = true;
            this.btnNavSearch.Click += new System.EventHandler(this.btnNavSearch_Click);
            // 
            // cbNavSearchFilter
            // 
            this.cbNavSearchFilter.FormattingEnabled = true;
            this.cbNavSearchFilter.Items.AddRange(new object[] {
            "All",
            "Pictures",
            "Videos",
            "Messages"});
            this.cbNavSearchFilter.Location = new System.Drawing.Point(833, 29);
            this.cbNavSearchFilter.Name = "cbNavSearchFilter";
            this.cbNavSearchFilter.Size = new System.Drawing.Size(76, 21);
            this.cbNavSearchFilter.TabIndex = 7;
            // 
            // pnlWindowContent
            // 
            this.pnlWindowContent.AutoScroll = true;
            this.pnlWindowContent.Location = new System.Drawing.Point(13, 69);
            this.pnlWindowContent.Name = "pnlWindowContent";
            this.pnlWindowContent.Size = new System.Drawing.Size(815, 648);
            this.pnlWindowContent.TabIndex = 8;
            // 
            // pnlWindowCategories
            // 
            this.pnlWindowCategories.AutoScroll = true;
            this.pnlWindowCategories.Location = new System.Drawing.Point(834, 69);
            this.pnlWindowCategories.Name = "pnlWindowCategories";
            this.pnlWindowCategories.Size = new System.Drawing.Size(162, 648);
            this.pnlWindowCategories.TabIndex = 9;
            // 
            // btnNavAdmins
            // 
            this.btnNavAdmins.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNavAdmins.BackgroundImage")));
            this.btnNavAdmins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNavAdmins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAdmins.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavAdmins.Location = new System.Drawing.Point(537, 13);
            this.btnNavAdmins.Name = "btnNavAdmins";
            this.btnNavAdmins.Size = new System.Drawing.Size(60, 50);
            this.btnNavAdmins.TabIndex = 10;
            this.btnNavAdmins.UseVisualStyleBackColor = true;
            this.btnNavAdmins.Click += new System.EventHandler(this.btnNavAdmins_Click);
            // 
            // WindowManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btnNavAdmins);
            this.Controls.Add(this.pnlWindowCategories);
            this.Controls.Add(this.pnlWindowContent);
            this.Controls.Add(this.cbNavSearchFilter);
            this.Controls.Add(this.btnNavSearch);
            this.Controls.Add(this.tbNavSearch);
            this.Controls.Add(this.btnNavPictures);
            this.Controls.Add(this.btnNavVideos);
            this.Controls.Add(this.btnNavMessages);
            this.Controls.Add(this.btnNavUpload);
            this.Controls.Add(this.btnNavTimeline);
            this.Name = "WindowManager";
            this.Text = "Finstatter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNavTimeline;
        private System.Windows.Forms.Button btnNavUpload;
        private System.Windows.Forms.Button btnNavMessages;
        private System.Windows.Forms.Button btnNavVideos;
        private System.Windows.Forms.Button btnNavPictures;
        private System.Windows.Forms.TextBox tbNavSearch;
        private System.Windows.Forms.Button btnNavSearch;
        private System.Windows.Forms.ComboBox cbNavSearchFilter;
        private System.Windows.Forms.Panel pnlWindowContent;
        private System.Windows.Forms.Panel pnlWindowCategories;
        private System.Windows.Forms.Button btnNavAdmins;

    }
}

