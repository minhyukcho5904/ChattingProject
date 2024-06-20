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
            this.btn_copy = new System.Windows.Forms.Button();
            this.pb_image_recent = new System.Windows.Forms.PictureBox();
            this.btn_image_upload = new System.Windows.Forms.Button();
            this.btn_image_send = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalendarSave = new System.Windows.Forms.Button();
            this.btnOpenNotepad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_emoji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image_recent)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(14, 11);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(88, 22);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Enabled = false;
            this.MessageTextBox.Location = new System.Drawing.Point(14, 88);
            this.MessageTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(904, 21);
            this.MessageTextBox.TabIndex = 1;
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTextBox_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(832, 112);
            this.SendButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(88, 22);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SetCalendarEventButton
            // 
            this.SetCalendarEventButton.Location = new System.Drawing.Point(832, 486);
            this.SetCalendarEventButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.SetCalendarEventButton.Name = "SetCalendarEventButton";
            this.SetCalendarEventButton.Size = new System.Drawing.Size(88, 22);
            this.SetCalendarEventButton.TabIndex = 6;
            this.SetCalendarEventButton.Text = "Set Event";
            this.SetCalendarEventButton.UseVisualStyleBackColor = true;
            this.SetCalendarEventButton.Click += new System.EventHandler(this.SetCalendarEventButton_Click);
            // 
            // CalendarEventDateTimePicker
            // 
            this.CalendarEventDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.CalendarEventDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CalendarEventDateTimePicker.Location = new System.Drawing.Point(14, 486);
            this.CalendarEventDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.CalendarEventDateTimePicker.Name = "CalendarEventDateTimePicker";
            this.CalendarEventDateTimePicker.Size = new System.Drawing.Size(232, 21);
            this.CalendarEventDateTimePicker.TabIndex = 7;
            // 
            // CalendarEventTextBox
            // 
            this.CalendarEventTextBox.Location = new System.Drawing.Point(255, 486);
            this.CalendarEventTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.CalendarEventTextBox.Name = "CalendarEventTextBox";
            this.CalendarEventTextBox.Size = new System.Drawing.Size(570, 21);
            this.CalendarEventTextBox.TabIndex = 8;
            // 
            // NicknameTextBox
            // 
            this.NicknameTextBox.Location = new System.Drawing.Point(14, 62);
            this.NicknameTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.NicknameTextBox.Name = "NicknameTextBox";
            this.NicknameTextBox.Size = new System.Drawing.Size(204, 21);
            this.NicknameTextBox.TabIndex = 9;
            this.NicknameTextBox.Text = "닉네임을 입력해 주세요";
            this.NicknameTextBox.Click += new System.EventHandler(this.NicknameTextBox_Click);
            // 
            // SetNicknameButton
            // 
            this.SetNicknameButton.Location = new System.Drawing.Point(227, 60);
            this.SetNicknameButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.SetNicknameButton.Name = "SetNicknameButton";
            this.SetNicknameButton.Size = new System.Drawing.Size(88, 22);
            this.SetNicknameButton.TabIndex = 10;
            this.SetNicknameButton.Text = "Set Nickname";
            this.SetNicknameButton.UseVisualStyleBackColor = true;
            this.SetNicknameButton.Click += new System.EventHandler(this.SetNicknameButton_Click);
            // 
            // CalendarEventsListBox
            // 
            this.CalendarEventsListBox.FormattingEnabled = true;
            this.CalendarEventsListBox.ItemHeight = 12;
            this.CalendarEventsListBox.Location = new System.Drawing.Point(14, 510);
            this.CalendarEventsListBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.CalendarEventsListBox.Name = "CalendarEventsListBox";
            this.CalendarEventsListBox.Size = new System.Drawing.Size(904, 88);
            this.CalendarEventsListBox.TabIndex = 11;
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(14, 42);
            this.CurrentTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(87, 12);
            this.CurrentTimeLabel.TabIndex = 12;
            this.CurrentTimeLabel.Text = "Current Time: ";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Sprite57.png");
            this.imageList1.Images.SetKeyName(1, "image_bored.png");
            this.imageList1.Images.SetKeyName(2, "sp_superbored.png");
            this.imageList1.Images.SetKeyName(3, "sp_fire.png");
            this.imageList1.Images.SetKeyName(4, "sp_heart.png");
            this.imageList1.Images.SetKeyName(5, "sp_check.png");
            // 
            // pb_emoji
            // 
            this.pb_emoji.Location = new System.Drawing.Point(945, 138);
            this.pb_emoji.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_emoji.Name = "pb_emoji";
            this.pb_emoji.Size = new System.Drawing.Size(38, 28);
            this.pb_emoji.TabIndex = 13;
            this.pb_emoji.TabStop = false;
            // 
            // btn_prev
            // 
            this.btn_prev.Location = new System.Drawing.Point(945, 163);
            this.btn_prev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(29, 27);
            this.btn_prev.TabIndex = 14;
            this.btn_prev.Text = "◀";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(979, 164);
            this.btn_next.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(28, 26);
            this.btn_next.TabIndex = 15;
            this.btn_next.Text = "▶";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_emoji_send
            // 
            this.btn_emoji_send.Location = new System.Drawing.Point(1012, 163);
            this.btn_emoji_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_emoji_send.Name = "btn_emoji_send";
            this.btn_emoji_send.Size = new System.Drawing.Size(119, 26);
            this.btn_emoji_send.TabIndex = 16;
            this.btn_emoji_send.Text = "send";
            this.btn_emoji_send.UseVisualStyleBackColor = true;
            this.btn_emoji_send.Click += new System.EventHandler(this.btn_emoji_send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(942, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "이모티콘 보내기";
            // 
            // MessagesFlowLayoutPanel
            // 
            this.MessagesFlowLayoutPanel.AutoScroll = true;
            this.MessagesFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MessagesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MessagesFlowLayoutPanel.Location = new System.Drawing.Point(14, 138);
            this.MessagesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MessagesFlowLayoutPanel.Name = "MessagesFlowLayoutPanel";
            this.MessagesFlowLayoutPanel.Size = new System.Drawing.Size(906, 325);
            this.MessagesFlowLayoutPanel.TabIndex = 18;
            this.MessagesFlowLayoutPanel.WrapContents = false;
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(945, 566);
            this.btn_copy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(125, 31);
            this.btn_copy.TabIndex = 19;
            this.btn_copy.Text = "내용 전체복사";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // pb_image_recent
            // 
            this.pb_image_recent.Cursor = System.Windows.Forms.Cursors.Default;
            this.pb_image_recent.Location = new System.Drawing.Point(945, 215);
            this.pb_image_recent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_image_recent.Name = "pb_image_recent";
            this.pb_image_recent.Size = new System.Drawing.Size(158, 145);
            this.pb_image_recent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_image_recent.TabIndex = 20;
            this.pb_image_recent.TabStop = false;
            // 
            // btn_image_upload
            // 
            this.btn_image_upload.AllowDrop = true;
            this.btn_image_upload.Location = new System.Drawing.Point(945, 379);
            this.btn_image_upload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_image_upload.Name = "btn_image_upload";
            this.btn_image_upload.Size = new System.Drawing.Size(158, 27);
            this.btn_image_upload.TabIndex = 21;
            this.btn_image_upload.Text = "이미지 업로드";
            this.btn_image_upload.UseVisualStyleBackColor = true;
            this.btn_image_upload.Click += new System.EventHandler(this.btn_image_upload_Click);
            // 
            // btn_image_send
            // 
            this.btn_image_send.Location = new System.Drawing.Point(945, 411);
            this.btn_image_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_image_send.Name = "btn_image_send";
            this.btn_image_send.Size = new System.Drawing.Size(158, 24);
            this.btn_image_send.TabIndex = 22;
            this.btn_image_send.Text = "이미지 보내기";
            this.btn_image_send.UseVisualStyleBackColor = true;
            this.btn_image_send.Click += new System.EventHandler(this.btn_image_send_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(942, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "최근에 업로드한 이미지";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(945, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "(미리보기에서는 사이즈가 다를 수 있습니다.)";
            // 
            // btnCalendarSave
            // 
            this.btnCalendarSave.Location = new System.Drawing.Point(1076, 566);
            this.btnCalendarSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalendarSave.Name = "btnCalendarSave";
            this.btnCalendarSave.Size = new System.Drawing.Size(125, 31);
            this.btnCalendarSave.TabIndex = 25;
            this.btnCalendarSave.Text = "일정 저장";
            this.btnCalendarSave.UseVisualStyleBackColor = true;
            this.btnCalendarSave.Click += new System.EventHandler(this.btnCalendarSave_Click);
            // 
            // btnOpenNotepad
            // 
            this.btnOpenNotepad.Location = new System.Drawing.Point(944, 11);
            this.btnOpenNotepad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenNotepad.Name = "btnOpenNotepad";
            this.btnOpenNotepad.Size = new System.Drawing.Size(125, 31);
            this.btnOpenNotepad.TabIndex = 26;
            this.btnOpenNotepad.Text = "메모장";
            this.btnOpenNotepad.UseVisualStyleBackColor = true;
            this.btnOpenNotepad.Click += new System.EventHandler(this.btnOpenNotepad_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 610);
            this.Controls.Add(this.btnOpenNotepad);
            this.Controls.Add(this.btnCalendarSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_image_send);
            this.Controls.Add(this.btn_image_upload);
            this.Controls.Add(this.pb_image_recent);
            this.Controls.Add(this.btn_copy);
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
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "ClientForm";
            this.Text = "Chat Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_emoji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image_recent)).EndInit();
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
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.PictureBox pb_image_recent;
        private System.Windows.Forms.Button btn_image_upload;
        private System.Windows.Forms.Button btn_image_send;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalendarSave;
        private System.Windows.Forms.Button btnOpenNotepad;
    }
}