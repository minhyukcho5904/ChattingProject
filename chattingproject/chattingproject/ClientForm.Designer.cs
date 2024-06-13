namespace chattingproject
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ListBox MessagesListBox;
        private System.Windows.Forms.Button SetCalendarEventButton;
        private System.Windows.Forms.DateTimePicker CalendarEventDateTimePicker;
        private System.Windows.Forms.TextBox CalendarEventTextBox;
        private System.Windows.Forms.TextBox NicknameTextBox;
        private System.Windows.Forms.Button SetNicknameButton;
        private System.Windows.Forms.ListBox CalendarEventsListBox; // 추가된 일정 확인을 위한 ListBox
        private System.Windows.Forms.Label CurrentTimeLabel; // 실시간 시계를 표시하기 위한 Label
        private System.Windows.Forms.Timer clockTimer; // 실시간 시계 타이머

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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessagesListBox = new System.Windows.Forms.ListBox();
            this.SetCalendarEventButton = new System.Windows.Forms.Button();
            this.CalendarEventDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CalendarEventTextBox = new System.Windows.Forms.TextBox();
            this.NicknameTextBox = new System.Windows.Forms.TextBox();
            this.SetNicknameButton = new System.Windows.Forms.Button();
            this.CalendarEventsListBox = new System.Windows.Forms.ListBox();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer();
            this.SuspendLayout();

            // ConnectButton
            this.ConnectButton.Location = new System.Drawing.Point(12, 12);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);

            // MessageTextBox
            this.MessageTextBox.Location = new System.Drawing.Point(12, 95);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(776, 20);
            this.MessageTextBox.TabIndex = 1;
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);

            // SendButton
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(713, 121);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);

            // MessagesListBox
            this.MessagesListBox.FormattingEnabled = true;
            this.MessagesListBox.Location = new System.Drawing.Point(12, 150);
            this.MessagesListBox.Name = "MessagesListBox";
            this.MessagesListBox.Size = new System.Drawing.Size(776, 342);
            this.MessagesListBox.TabIndex = 3;

            // SetCalendarEventButton
            this.SetCalendarEventButton.Location = new System.Drawing.Point(713, 527);
            this.SetCalendarEventButton.Name = "SetCalendarEventButton";
            this.SetCalendarEventButton.Size = new System.Drawing.Size(75, 23);
            this.SetCalendarEventButton.TabIndex = 6;
            this.SetCalendarEventButton.Text = "Set Event";
            this.SetCalendarEventButton.UseVisualStyleBackColor = true;
            this.SetCalendarEventButton.Click += new System.EventHandler(this.SetCalendarEventButton_Click);

            // CalendarEventDateTimePicker
            this.CalendarEventDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CalendarEventDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.CalendarEventDateTimePicker.Location = new System.Drawing.Point(12, 527);
            this.CalendarEventDateTimePicker.Name = "CalendarEventDateTimePicker";
            this.CalendarEventDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.CalendarEventDateTimePicker.TabIndex = 7;

            // CalendarEventTextBox
            this.CalendarEventTextBox.Location = new System.Drawing.Point(218, 527);
            this.CalendarEventTextBox.Name = "CalendarEventTextBox";
            this.CalendarEventTextBox.Size = new System.Drawing.Size(489, 20);
            this.CalendarEventTextBox.TabIndex = 8;

            // NicknameTextBox
            this.NicknameTextBox.Location = new System.Drawing.Point(12, 67);
            this.NicknameTextBox.Name = "NicknameTextBox";
            this.NicknameTextBox.Size = new System.Drawing.Size(176, 20);
            this.NicknameTextBox.TabIndex = 9;

            // SetNicknameButton
            this.SetNicknameButton.Location = new System.Drawing.Point(194, 65);
            this.SetNicknameButton.Name = "SetNicknameButton";
            this.SetNicknameButton.Size = new System.Drawing.Size(75, 23);
            this.SetNicknameButton.TabIndex = 10;
            this.SetNicknameButton.Text = "Set Nickname";
            this.SetNicknameButton.UseVisualStyleBackColor = true;
            this.SetNicknameButton.Click += new System.EventHandler(this.SetNicknameButton_Click);

            // CalendarEventsListBox
            this.CalendarEventsListBox.FormattingEnabled = true;
            this.CalendarEventsListBox.Location = new System.Drawing.Point(12, 553);
            this.CalendarEventsListBox.Name = "CalendarEventsListBox";
            this.CalendarEventsListBox.Size = new System.Drawing.Size(776, 95);
            this.CalendarEventsListBox.TabIndex = 11;

            // CurrentTimeLabel
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(12, 45);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(73, 13);
            this.CurrentTimeLabel.TabIndex = 12;
            this.CurrentTimeLabel.Text = "Current Time: ";

            // ClientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 661);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.CalendarEventsListBox);
            this.Controls.Add(this.SetNicknameButton);
            this.Controls.Add(this.NicknameTextBox);
            this.Controls.Add(this.CalendarEventTextBox);
            this.Controls.Add(this.CalendarEventDateTimePicker);
            this.Controls.Add(this.SetCalendarEventButton);
            this.Controls.Add(this.MessagesListBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ConnectButton);
            this.Name = "ClientForm";
            this.Text = "Chat Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}