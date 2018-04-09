namespace Laboratory
{
    partial class FileListForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.closeButton = new System.Windows.Forms.Button();
            this.scaffoldLabel = new System.Windows.Forms.Label();
            this.notScaffoldLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(487, 383);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 482;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(217, 415);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // scaffoldLabel
            // 
            this.scaffoldLabel.AutoSize = true;
            this.scaffoldLabel.BackColor = System.Drawing.Color.Lime;
            this.scaffoldLabel.Location = new System.Drawing.Point(12, 402);
            this.scaffoldLabel.Name = "scaffoldLabel";
            this.scaffoldLabel.Size = new System.Drawing.Size(35, 13);
            this.scaffoldLabel.TabIndex = 2;
            this.scaffoldLabel.Text = "label1";
            // 
            // notScaffoldLabel
            // 
            this.notScaffoldLabel.AutoSize = true;
            this.notScaffoldLabel.BackColor = System.Drawing.Color.Lime;
            this.notScaffoldLabel.Location = new System.Drawing.Point(12, 425);
            this.notScaffoldLabel.Name = "notScaffoldLabel";
            this.notScaffoldLabel.Size = new System.Drawing.Size(35, 13);
            this.notScaffoldLabel.TabIndex = 3;
            this.notScaffoldLabel.Text = "label1";
            // 
            // FileListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 450);
            this.Controls.Add(this.notScaffoldLabel);
            this.Controls.Add(this.scaffoldLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.listView1);
            this.Name = "FileListForm";
            this.Text = "Mod Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label scaffoldLabel;
        private System.Windows.Forms.Label notScaffoldLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}