namespace Laboratory
{
    partial class SettingsForm
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
            this.showReport = new System.Windows.Forms.CheckBox();
            this.useCustomTemp = new System.Windows.Forms.CheckBox();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.alterTemp = new System.Windows.Forms.Button();
            this.enableLogging = new System.Windows.Forms.CheckBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // showReport
            // 
            this.showReport.AutoSize = true;
            this.showReport.Location = new System.Drawing.Point(12, 12);
            this.showReport.Name = "showReport";
            this.showReport.Size = new System.Drawing.Size(193, 17);
            this.showReport.TabIndex = 0;
            this.showReport.Text = "Show report after applying changes";
            this.showReport.UseVisualStyleBackColor = true;
            this.showReport.CheckedChanged += new System.EventHandler(this.showReport_CheckedChanged);
            // 
            // useCustomTemp
            // 
            this.useCustomTemp.AutoSize = true;
            this.useCustomTemp.Location = new System.Drawing.Point(12, 35);
            this.useCustomTemp.Name = "useCustomTemp";
            this.useCustomTemp.Size = new System.Drawing.Size(177, 17);
            this.useCustomTemp.TabIndex = 1;
            this.useCustomTemp.Text = "Use custom temp folder location";
            this.useCustomTemp.UseVisualStyleBackColor = true;
            this.useCustomTemp.CheckedChanged += new System.EventHandler(this.useCustomTemp_CheckedChanged);
            // 
            // folderPath
            // 
            this.folderPath.Location = new System.Drawing.Point(12, 59);
            this.folderPath.Name = "folderPath";
            this.folderPath.ReadOnly = true;
            this.folderPath.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.folderPath.Size = new System.Drawing.Size(230, 20);
            this.folderPath.TabIndex = 2;
            // 
            // alterTemp
            // 
            this.alterTemp.Location = new System.Drawing.Point(256, 57);
            this.alterTemp.Name = "alterTemp";
            this.alterTemp.Size = new System.Drawing.Size(75, 23);
            this.alterTemp.TabIndex = 3;
            this.alterTemp.Text = "Change";
            this.alterTemp.UseVisualStyleBackColor = true;
            this.alterTemp.Click += new System.EventHandler(this.alterTemp_Click);
            // 
            // enableLogging
            // 
            this.enableLogging.AutoSize = true;
            this.enableLogging.Location = new System.Drawing.Point(12, 86);
            this.enableLogging.Name = "enableLogging";
            this.enableLogging.Size = new System.Drawing.Size(151, 17);
            this.enableLogging.TabIndex = 4;
            this.enableLogging.Text = "Output all logging to log.txt";
            this.enableLogging.UseVisualStyleBackColor = true;
            this.enableLogging.CheckedChanged += new System.EventHandler(this.enableLogging_CheckedChanged);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(130, 115);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 150);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.enableLogging);
            this.Controls.Add(this.alterTemp);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.useCustomTemp);
            this.Controls.Add(this.showReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox showReport;
        private System.Windows.Forms.CheckBox useCustomTemp;
        private System.Windows.Forms.TextBox folderPath;
        private System.Windows.Forms.Button alterTemp;
        private System.Windows.Forms.CheckBox enableLogging;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}