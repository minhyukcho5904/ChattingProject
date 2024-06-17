namespace chattingproject
{
    partial class ServerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ListBox LogListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(16, 14);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 27);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Server";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(124, 14);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(100, 27);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop Server";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // LogListBox
            // 
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.ItemHeight = 15;
            this.LogListBox.Location = new System.Drawing.Point(16, 47);
            this.LogListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(1033, 454);
            this.LogListBox.TabIndex = 2;
            this.LogListBox.SelectedIndexChanged += new System.EventHandler(this.LogListBox_SelectedIndexChanged);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 519);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ServerForm";
            this.Text = "Chat Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.ResumeLayout(false);

        }
    }
}