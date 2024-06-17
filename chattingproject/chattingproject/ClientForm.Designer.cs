namespace chattingproject
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button SendButton;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.ConnectButton = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SetCalendarEventButton = new System.Windows.Forms.Button();
            this.CalendarEventDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CalendarEventTextBox = new System.Windows.Forms.TextBox();
            this.NicknameTextBox = new System.Windows.Forms.TextBox();
            this.SetNicknameButton = new System.Windows.Forms.Button();
            this.CalendarEventsListBox = new System.Windows.Forms.ListBox();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pb_emoji = new System.Windows.Forms.PictureBox();
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_emoji_send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MessagesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_emoji)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(16, 14);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(100, 27);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.Location = new System.Drawing.Point(16, 110);
            this.MessageTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(1033, 25);
            this.MessageTextBox.TabIndex = 1;
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(951, 140);
            this.SendButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(100, 27);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SetCalendarEventButton
            // 
            this.SetCalendarEventButton.Location = new System.Drawing.Point(951, 608);
            this.SetCalendarEventButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SetCalendarEventButton.Name = "SetCalendarEventButton";
            this.SetCalendarEventButton.Size = new System.Drawing.Size(100, 27);
            this.SetCalendarEventButton.TabIndex = 6;
            this.SetCalendarEventButton.Text = "Set Event";
            this.SetCalendarEventButton.UseVisualStyleBackColor = true;
            this.SetCalendarEventButton.Click += new System.EventHandler(this.SetCalendarEventButton_Click);
            // 
            // CalendarEventDateTimePicker
            // 
            this.CalendarEventDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.CalendarEventDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CalendarEventDateTimePicker.Location = new System.Drawing.Point(16, 608);
            this.CalendarEventDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CalendarEventDateTimePicker.Name = "CalendarEventDateTimePicker";
            this.CalendarEventDateTimePicker.Size = new System.Drawing.Size(265, 25);
            this.CalendarEventDateTimePicker.TabIndex = 7;
            // 
            // CalendarEventTextBox
            // 
            this.CalendarEventTextBox.Location = new System.Drawing.Point(291, 608);
            this.CalendarEventTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CalendarEventTextBox.Name = "CalendarEventTextBox";
            this.CalendarEventTextBox.Size = new System.Drawing.Size(651, 25);
            this.CalendarEventTextBox.TabIndex = 8;
            // 
            // NicknameTextBox
            // 
            this.NicknameTextBox.Location = new System.Drawing.Point(16, 77);
            this.NicknameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NicknameTextBox.Name = "NicknameTextBox";
            this.NicknameTextBox.Size = new System.Drawing.Size(233, 25);
            this.NicknameTextBox.TabIndex = 9;
            this.NicknameTextBox.Text = "닉네임을 입력해 주세요";
            this.NicknameTextBox.Click += new System.EventHandler(this.NicknameTextBox_Click);
            // 
            // SetNicknameButton
            // 
            this.SetNicknameButton.Location = new System.Drawing.Point(259, 75);
            this.SetNicknameButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SetNicknameButton.Name = "SetNicknameButton";
            this.SetNicknameButton.Size = new System.Drawing.Size(100, 27);
            this.SetNicknameButton.TabIndex = 10;
            this.SetNicknameButton.Text = "Set Nickname";
            this.SetNicknameButton.UseVisualStyleBackColor = true;
            this.SetNicknameButton.Click += new System.EventHandler(this.SetNicknameButton_Click);
            // 
            // CalendarEventsListBox
            // 
            this.CalendarEventsListBox.FormattingEnabled = true;
            this.CalendarEventsListBox.ItemHeight = 15;
            this.CalendarEventsListBox.Location = new System.Drawing.Point(16, 638);
            this.CalendarEventsListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CalendarEventsListBox.Name = "CalendarEventsListBox";
            this.CalendarEventsListBox.Size = new System.Drawing.Size(1033, 109);
            this.CalendarEventsListBox.TabIndex = 11;
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(16, 52);
            this.CurrentTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(98, 15);
            this.CurrentTimeLabel.TabIndex = 12;
            this.CurrentTimeLabel.Text = "Current Time: ";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1482228.png");
            this.imageList1.Images.SetKeyName(1, "Iconoir-Team-Iconoir-Emoji-ball.512.png");
            // 
            // pb_emoji
            // 
            this.pb_emoji.Location = new System.Drawing.Point(1080, 173);
            this.pb_emoji.Name = "pb_emoji";
            this.pb_emoji.Size = new System.Drawing.Size(214, 199);
            this.pb_emoji.TabIndex = 13;
            this.pb_emoji.TabStop = false;
            // 
            // btn_prev
            // 
            this.btn_prev.Location = new System.Drawing.Point(1080, 377);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(33, 34);
            this.btn_prev.TabIndex = 14;
            this.btn_prev.Text = "◀";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(1119, 377);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(32, 33);
            this.btn_next.TabIndex = 15;
            this.btn_next.Text = "▶";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_emoji_send
            // 
            this.btn_emoji_send.Location = new System.Drawing.Point(1158, 378);
            this.btn_emoji_send.Name = "btn_emoji_send";
            this.btn_emoji_send.Size = new System.Drawing.Size(136, 33);
            this.btn_emoji_send.TabIndex = 16;
            this.btn_emoji_send.Text = "send";
            this.btn_emoji_send.UseVisualStyleBackColor = true;
            this.btn_emoji_send.Click += new System.EventHandler(this.btn_emoji_send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1077, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "이모티콘 보내기";
            // 
            // MessagesFlowLayoutPanel
            // 
            this.MessagesFlowLayoutPanel.AutoScroll = true;
            this.MessagesFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MessagesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MessagesFlowLayoutPanel.Location = new System.Drawing.Point(16, 173);
            this.MessagesFlowLayoutPanel.Name = "MessagesFlowLayoutPanel";
            this.MessagesFlowLayoutPanel.Size = new System.Drawing.Size(1035, 406);
            this.MessagesFlowLayoutPanel.TabIndex = 18;
            this.MessagesFlowLayoutPanel.WrapContents = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 763);
            this.Controls.Add(this.MessagesFlowLayoutPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_emoji_send);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.pb_emoji);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.CalendarEventsListBox);
            this.Controls.Add(this.SetNicknameButton);
            this.Controls.Add(this.NicknameTextBox);
            this.Controls.Add(this.CalendarEventTextBox);
            this.Controls.Add(this.CalendarEventDateTimePicker);
            this.Controls.Add(this.SetCalendarEventButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ConnectButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ClientForm";
            this.Text = "Chat Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_emoji)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pb_emoji;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_emoji_send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel MessagesFlowLayoutPanel;
    }
}