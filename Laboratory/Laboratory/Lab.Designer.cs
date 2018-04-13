namespace Laboratory
{
    partial class Lab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lab));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.aboutBtn = new System.Windows.Forms.PictureBox();
            this.settingsButton = new System.Windows.Forms.PictureBox();
            this.addModButton = new System.Windows.Forms.PictureBox();
            this.exitPicButton = new System.Windows.Forms.PictureBox();
            this.loadVBFPicButton = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.modList = new System.Windows.Forms.ListView();
            this.rankColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.modVersionLabel = new System.Windows.Forms.Label();
            this.modAuthorText = new System.Windows.Forms.Label();
            this.modNameText = new System.Windows.Forms.TextBox();
            this.listFilesButton = new System.Windows.Forms.PictureBox();
            this.removeModButton = new System.Windows.Forms.PictureBox();
            this.toggleModButton = new System.Windows.Forms.PictureBox();
            this.moveDownButton = new System.Windows.Forms.PictureBox();
            this.moveUpButton = new System.Windows.Forms.PictureBox();
            this.modDescriptionText = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.applyChangesButton = new System.Windows.Forms.Button();
            this.openVBFDialog = new System.Windows.Forms.OpenFileDialog();
            this.addModDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addModButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPicButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadVBFPicButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listFilesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeModButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleModButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveDownButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveUpButton)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.aboutBtn);
            this.splitContainer1.Panel1.Controls.Add(this.settingsButton);
            this.splitContainer1.Panel1.Controls.Add(this.addModButton);
            this.splitContainer1.Panel1.Controls.Add(this.exitPicButton);
            this.splitContainer1.Panel1.Controls.Add(this.loadVBFPicButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 681);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 0;
            // 
            // aboutBtn
            // 
            this.aboutBtn.Image = global::Laboratory.Properties.Resources.aboutme;
            this.aboutBtn.Location = new System.Drawing.Point(330, 3);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(100, 41);
            this.aboutBtn.TabIndex = 5;
            this.aboutBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.aboutBtn, "Information.");
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Enabled = false;
            this.settingsButton.Location = new System.Drawing.Point(224, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(100, 41);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.TabStop = false;
            this.toolTip1.SetToolTip(this.settingsButton, "Changes settings.");
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // addModButton
            // 
            this.addModButton.Enabled = false;
            this.addModButton.Location = new System.Drawing.Point(118, 3);
            this.addModButton.Name = "addModButton";
            this.addModButton.Size = new System.Drawing.Size(100, 41);
            this.addModButton.TabIndex = 2;
            this.addModButton.TabStop = false;
            this.toolTip1.SetToolTip(this.addModButton, "Adds a new mod.");
            this.addModButton.Click += new System.EventHandler(this.addModButton_Click);
            // 
            // exitPicButton
            // 
            this.exitPicButton.Image = global::Laboratory.Properties.Resources.bye;
            this.exitPicButton.Location = new System.Drawing.Point(436, 3);
            this.exitPicButton.Name = "exitPicButton";
            this.exitPicButton.Size = new System.Drawing.Size(100, 41);
            this.exitPicButton.TabIndex = 1;
            this.exitPicButton.TabStop = false;
            this.toolTip1.SetToolTip(this.exitPicButton, "Exit");
            this.exitPicButton.Click += new System.EventHandler(this.exitPicButton_Click);
            // 
            // loadVBFPicButton
            // 
            this.loadVBFPicButton.Image = global::Laboratory.Properties.Resources.openvbf;
            this.loadVBFPicButton.Location = new System.Drawing.Point(12, 3);
            this.loadVBFPicButton.Name = "loadVBFPicButton";
            this.loadVBFPicButton.Size = new System.Drawing.Size(100, 41);
            this.loadVBFPicButton.TabIndex = 0;
            this.loadVBFPicButton.TabStop = false;
            this.toolTip1.SetToolTip(this.loadVBFPicButton, "Opens a VBF file.");
            this.loadVBFPicButton.Click += new System.EventHandler(this.loadVBFPicButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.logLabel);
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Panel2.Controls.Add(this.statusLabel);
            this.splitContainer2.Panel2.Controls.Add(this.applyChangesButton);
            this.splitContainer2.Size = new System.Drawing.Size(1264, 630);
            this.splitContainer2.SplitterDistance = 593;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.modList);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1264, 593);
            this.splitContainer3.SplitterDistance = 273;
            this.splitContainer3.TabIndex = 1;
            // 
            // modList
            // 
            this.modList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rankColumn,
            this.nameHeader,
            this.isEnabled});
            this.modList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modList.FullRowSelect = true;
            this.modList.GridLines = true;
            this.modList.HideSelection = false;
            this.modList.Location = new System.Drawing.Point(0, 0);
            this.modList.MultiSelect = false;
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(273, 593);
            this.modList.TabIndex = 0;
            this.modList.UseCompatibleStateImageBehavior = false;
            this.modList.View = System.Windows.Forms.View.Details;
            this.modList.SelectedIndexChanged += new System.EventHandler(this.modList_SelectedIndexChanged);
            // 
            // rankColumn
            // 
            this.rankColumn.Text = "Priority";
            this.rankColumn.Width = 43;
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Mod Name";
            this.nameHeader.Width = 201;
            // 
            // isEnabled
            // 
            this.isEnabled.Text = "✓";
            this.isEnabled.Width = 24;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.modVersionLabel);
            this.splitContainer4.Panel1.Controls.Add(this.modAuthorText);
            this.splitContainer4.Panel1.Controls.Add(this.modNameText);
            this.splitContainer4.Panel1.Controls.Add(this.listFilesButton);
            this.splitContainer4.Panel1.Controls.Add(this.removeModButton);
            this.splitContainer4.Panel1.Controls.Add(this.toggleModButton);
            this.splitContainer4.Panel1.Controls.Add(this.moveDownButton);
            this.splitContainer4.Panel1.Controls.Add(this.moveUpButton);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.modDescriptionText);
            this.splitContainer4.Size = new System.Drawing.Size(987, 593);
            this.splitContainer4.SplitterDistance = 45;
            this.splitContainer4.TabIndex = 0;
            // 
            // modVersionLabel
            // 
            this.modVersionLabel.AutoSize = true;
            this.modVersionLabel.Location = new System.Drawing.Point(806, 6);
            this.modVersionLabel.Name = "modVersionLabel";
            this.modVersionLabel.Size = new System.Drawing.Size(0, 13);
            this.modVersionLabel.TabIndex = 8;
            this.toolTip1.SetToolTip(this.modVersionLabel, "No mod selected.");
            // 
            // modAuthorText
            // 
            this.modAuthorText.AutoSize = true;
            this.modAuthorText.Location = new System.Drawing.Point(806, 27);
            this.modAuthorText.Name = "modAuthorText";
            this.modAuthorText.Size = new System.Drawing.Size(0, 13);
            this.modAuthorText.TabIndex = 7;
            this.toolTip1.SetToolTip(this.modAuthorText, "No mod selected.");
            // 
            // modNameText
            // 
            this.modNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modNameText.Location = new System.Drawing.Point(233, 3);
            this.modNameText.Name = "modNameText";
            this.modNameText.ReadOnly = true;
            this.modNameText.Size = new System.Drawing.Size(566, 38);
            this.modNameText.TabIndex = 6;
            this.toolTip1.SetToolTip(this.modNameText, "No mod selected.\r\n");
            // 
            // listFilesButton
            // 
            this.listFilesButton.Enabled = false;
            this.listFilesButton.Location = new System.Drawing.Point(187, 3);
            this.listFilesButton.Name = "listFilesButton";
            this.listFilesButton.Size = new System.Drawing.Size(40, 40);
            this.listFilesButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.listFilesButton.TabIndex = 5;
            this.listFilesButton.TabStop = false;
            this.toolTip1.SetToolTip(this.listFilesButton, "Lists mod files.");
            this.listFilesButton.Click += new System.EventHandler(this.listFilesButton_Click);
            // 
            // removeModButton
            // 
            this.removeModButton.Enabled = false;
            this.removeModButton.Location = new System.Drawing.Point(141, 3);
            this.removeModButton.Name = "removeModButton";
            this.removeModButton.Size = new System.Drawing.Size(40, 40);
            this.removeModButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.removeModButton.TabIndex = 4;
            this.removeModButton.TabStop = false;
            this.toolTip1.SetToolTip(this.removeModButton, "Removes a mod.");
            this.removeModButton.Click += new System.EventHandler(this.removeModButton_Click);
            // 
            // toggleModButton
            // 
            this.toggleModButton.Enabled = false;
            this.toggleModButton.Location = new System.Drawing.Point(95, 3);
            this.toggleModButton.Name = "toggleModButton";
            this.toggleModButton.Size = new System.Drawing.Size(40, 40);
            this.toggleModButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toggleModButton.TabIndex = 3;
            this.toggleModButton.TabStop = false;
            this.toolTip1.SetToolTip(this.toggleModButton, "Toggles a mod.");
            this.toggleModButton.Click += new System.EventHandler(this.toggleModButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Image = global::Laboratory.Properties.Resources.arrowdown;
            this.moveDownButton.Location = new System.Drawing.Point(49, 3);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(40, 40);
            this.moveDownButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.moveDownButton.TabIndex = 2;
            this.moveDownButton.TabStop = false;
            this.toolTip1.SetToolTip(this.moveDownButton, "Move mod down.");
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Image = global::Laboratory.Properties.Resources.arrowup;
            this.moveUpButton.Location = new System.Drawing.Point(3, 3);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(40, 40);
            this.moveUpButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.moveUpButton.TabIndex = 1;
            this.moveUpButton.TabStop = false;
            this.toolTip1.SetToolTip(this.moveUpButton, "Move mod up.");
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // modDescriptionText
            // 
            this.modDescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modDescriptionText.Location = new System.Drawing.Point(0, 0);
            this.modDescriptionText.Multiline = true;
            this.modDescriptionText.Name = "modDescriptionText";
            this.modDescriptionText.ReadOnly = true;
            this.modDescriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.modDescriptionText.Size = new System.Drawing.Size(987, 544);
            this.modDescriptionText.TabIndex = 1;
            // 
            // logLabel
            // 
            this.logLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(912, 10);
            this.logLabel.Name = "logLabel";
            this.logLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logLabel.Size = new System.Drawing.Size(16, 13);
            this.logLabel.TabIndex = 2;
            this.logLabel.Text = "...";
            this.logLabel.Click += new System.EventHandler(this.logLabel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1177, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(279, 8);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(77, 17);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Not loaded";
            // 
            // applyChangesButton
            // 
            this.applyChangesButton.Enabled = false;
            this.applyChangesButton.Location = new System.Drawing.Point(3, 5);
            this.applyChangesButton.Name = "applyChangesButton";
            this.applyChangesButton.Size = new System.Drawing.Size(270, 23);
            this.applyChangesButton.TabIndex = 0;
            this.applyChangesButton.Text = "Apply Changes";
            this.applyChangesButton.UseVisualStyleBackColor = true;
            this.applyChangesButton.Click += new System.EventHandler(this.applyChangesButton_Click);
            // 
            // Lab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Lab";
            this.Text = "Draklor Laboratory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lab_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aboutBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addModButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPicButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadVBFPicButton)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listFilesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeModButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleModButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveDownButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveUpButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView modList;
        private System.Windows.Forms.ColumnHeader rankColumn;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.PictureBox exitPicButton;
        private System.Windows.Forms.PictureBox loadVBFPicButton;
        private System.Windows.Forms.Button applyChangesButton;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PictureBox removeModButton;
        private System.Windows.Forms.PictureBox toggleModButton;
        private System.Windows.Forms.PictureBox moveDownButton;
        private System.Windows.Forms.PictureBox moveUpButton;
        private System.Windows.Forms.TextBox modDescriptionText;
        private System.Windows.Forms.PictureBox addModButton;
        private System.Windows.Forms.PictureBox listFilesButton;
        private System.Windows.Forms.Label modAuthorText;
        private System.Windows.Forms.TextBox modNameText;
        private System.Windows.Forms.OpenFileDialog openVBFDialog;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.FolderBrowserDialog addModDialog;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox settingsButton;
        private System.Windows.Forms.Label modVersionLabel;
        private System.Windows.Forms.ColumnHeader isEnabled;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox aboutBtn;
    }
}

