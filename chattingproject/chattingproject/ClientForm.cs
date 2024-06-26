﻿using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace chattingproject
{
    public partial class ClientForm : Form
    {
        private int emoji_index = 0;
        //imagelist의 인덱스의 끝 번호입니다.
        private int emoji_index_max = 5;
        private TcpClient _client;
        private NetworkStream _stream;
        private string _nickname;
        private bool _connected;

        public ClientForm()
        {
            InitializeComponent();
            //pb_emoji(picturebox)의 index를 imagelist와 동기화 하는 작업입니다.
            pb_emoji.Image = imageList1.Images[0];
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // 기본 닉네임 설정
            _nickname = "익명";
            // 실시간 시계 타이머 설정
            clockTimer.Interval = 1000;// 1초마다 틱
            clockTimer.Tick += UpdateClock;
            clockTimer.Start();
            MessagesFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            MessagesFlowLayoutPanel.WrapContents = false;
            MessagesFlowLayoutPanel.AutoScroll = true;
        }

        // 실시간 시계를 업데이트하는 메서드
        private void UpdateClock(object sender, EventArgs e)
        {
            CurrentTimeLabel.Text = "Current Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // 닉네임 텍스트 박스를 클릭할 때 모든 텍스트를 선택하는 이벤트 핸들러
        private void NicknameTextBox_Click(object sender, EventArgs e)
        {
            NicknameTextBox.SelectAll();
        }

        // 서버에 연결하는 버튼 클릭 이벤트 핸들러
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                _client = new TcpClient("127.0.0.1", 8888);
                _stream = _client.GetStream();
                _connected = true;
                Thread thread = new Thread(ReceiveMessages);
                thread.IsBackground = true;
                thread.Start();
                ConnectButton.Enabled = false;
                SendButton.Enabled = true;
                MessageTextBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetNicknameButton_Click(object sender, EventArgs e)
        {
            _nickname = string.IsNullOrWhiteSpace(NicknameTextBox.Text) ? "익명" : NicknameTextBox.Text;
            NicknameTextBox.Enabled = false;
            SetNicknameButton.Enabled = false;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        // 메시지 입력 후 Enter 키를 누르면 메시지 전송
        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                e.SuppressKeyPress = true;// Enter 키 입력 소리를 없애기 위해
            }
        }

        private void SendMessage()
        {
            try
            {
                if (!_connected) return;
                string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{_nickname}|{MessageTextBox.Text}";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                _stream.Write(buffer, 0, buffer.Length);
                AppendMessage(message);// 로컬 메시지 리스트에 메시지 추가
                MessageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            while (_connected)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int byteCount = _stream.Read(buffer, 0, buffer.Length);
                    if (byteCount == 0) break;

                    string messageHeader = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    string[] headerParts = messageHeader.Split('|');
                    if (headerParts.Length >= 4 && headerParts[2] == "emoji")
                    {
                        int imageLength = int.Parse(headerParts[3]);
                        byte[] imageBuffer = new byte[imageLength];
                        int totalBytesRead = 0;
                        while (totalBytesRead < imageLength)
                        {
                            int bytesRead = _stream.Read(imageBuffer, totalBytesRead, imageLength - totalBytesRead);
                            if (bytesRead == 0) throw new IOException("Connection closed.");
                            totalBytesRead += bytesRead;
                        }
                        Image receivedImage = ByteArrayToImage(imageBuffer);
                        AppendEmoji(receivedImage, headerParts[1], headerParts[0]);
                    }
                    else
                    {
                        AppendMessage(messageHeader);
                        HandleSpecialMessage(messageHeader); // 추가된 메서드 호출
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _connected = false;
                    break;
                }
            }
        }


        // 수신한 이모지를 클라이언트 UI에 추가하는 메서드 
        private void AppendEmoji(Image emoji, string senderName, string timestamp)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Image, string, string>(AppendEmoji), new object[] { emoji, senderName, timestamp });
                return;
            }

            Label messageLabel = new Label
            {
                Text = $"{timestamp} [{senderName}]: ",
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox emojiPictureBox = new PictureBox
            {
                Image = emoji,
                SizeMode = PictureBoxSizeMode.AutoSize,
                BorderStyle = BorderStyle.FixedSingle
            };

            MessagesFlowLayoutPanel.Controls.Add(messageLabel);
            MessagesFlowLayoutPanel.Controls.Add(emojiPictureBox);
            MessagesFlowLayoutPanel.ScrollControlIntoView(emojiPictureBox);
        }

        // 수신한 메시지를 클라이언트 UI에 추가하는 메서드
        private void AppendMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMessage), new object[] { message });
                return;
            }

            string[] parts = message.Split('|');
            if (parts.Length == 3)
            {
                string timestamp = parts[0];
                string senderName = parts[1];
                string content = parts[2];

                Label messageLabel = new Label
                {
                    Text = $"{timestamp} [{senderName}]: {content}",
                    AutoSize = true,
                    BorderStyle = BorderStyle.FixedSingle
                };

                MessagesFlowLayoutPanel.Controls.Add(messageLabel);
                MessagesFlowLayoutPanel.ScrollControlIntoView(messageLabel);
            }
        }

        // 캘린더 이벤트 설정 버튼 클릭 이벤트 핸들러
        private void SetCalendarEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_connected) return;
                string eventDetails = $"{CalendarEventDateTimePicker.Value:yyyy-MM-dd HH:mm}|{_nickname}|{CalendarEventTextBox.Text}";
                string message = $"CALENDAR|{eventDetails}";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                _stream.Write(buffer, 0, buffer.Length);
                CalendarEventTextBox.Clear();
                AddCalendarEvent(eventDetails); // 로컬 캘린더 이벤트 추가
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // 수신한 특수 메시지를 처리하는 메서드
        private void HandleSpecialMessage(string message)
        {
            if (message.StartsWith("CALENDAR|"))
            {
                string eventDetails = message.Substring("CALENDAR|".Length);
                AddCalendarEvent(eventDetails);
            }
            else if (message.StartsWith("ALERT|"))
            {
                string alertDetails = message.Substring("ALERT|".Length);
                ShowAlert(alertDetails);
            }
        }

        // 로컬 캘린더 이벤트를 추가하는 메서드
        private void AddCalendarEvent(string eventDetails)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddCalendarEvent), new object[] { eventDetails });
                return;
            }

            CalendarEventsListBox.Items.Add(eventDetails);
        }

        // 알림 창을 표시하는 메서드
        private void ShowAlert(string alertDetails)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowAlert), new object[] { alertDetails });
                return;
            }

            string[] parts = alertDetails.Split('|');
            if (parts.Length == 3)
            {
                string timestamp = parts[0];
                string senderName = parts[1];
                string content = parts[2];

                Form alertForm = new Form
                {
                    Width = 300,
                    Height = 200,
                    Text = "Event Alert"
                };

                Label alertLabel = new Label
                {
                    Text = $"{timestamp}\n{senderName}\n{content}",
                    AutoSize = true,
                    Location = new Point(10, 10)
                };

                Button confirmButton = new Button
                {
                    Text = "Confirm",
                    Location = new Point(100, 130),
                    Width = 75
                };
                confirmButton.Click += (s, e) =>
                {
                    alertForm.Close();
                    MarkEventAsComplete(content);
                };

                alertForm.Controls.Add(alertLabel);
                alertForm.Controls.Add(confirmButton);

                alertForm.ShowDialog();
            }
        }

        private void MarkEventAsComplete(string content)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(MarkEventAsComplete), new object[] { content });
                return;
            }

            for (int i = 0; i < CalendarEventsListBox.Items.Count; i++)
            {
                if (CalendarEventsListBox.Items[i].ToString().Contains(content))
                {
                    CalendarEventsListBox.Items[i] = CalendarEventsListBox.Items[i].ToString() + " ✓";
                    break;
                }
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (emoji_index > 0)
            {
                emoji_index -= 1;
                pb_emoji.Image = imageList1.Images[emoji_index];
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (emoji_index < emoji_index_max)
            {
                emoji_index += 1;
                pb_emoji.Image = imageList1.Images[emoji_index];
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void btn_emoji_send_Click(object sender, EventArgs e)
        {
            if (pb_emoji.Image != null)
            {
                SendEmoji(pb_emoji.Image);
            }
        }

        private void SendEmoji(Image emoji)
        {
            try
            {
                if (!_connected) return;
                byte[] imageBytes = ImageToByteArray(emoji);
                string messageHeader = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{_nickname}|emoji|{imageBytes.Length}";
                byte[] headerBuffer = Encoding.UTF8.GetBytes(messageHeader);

                AppendEmoji(emoji, _nickname, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                _stream.Write(headerBuffer, 0, headerBuffer.Length);
                _stream.Write(imageBytes, 0, imageBytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // FlowLayoutPanel에서 텍스트를 가져와 클립보드에 복사하는 메서드
        private void CopyTextToClipboard()
        {
            string text = GetTextFromFlowLayoutPanel();
            Clipboard.SetText(text);
            MessageBox.Show("텍스트가 클립보드에 복사되었습니다.");
        }

        // FlowLayoutPanel에서 텍스트를 가져오는 메서드
        private string GetTextFromFlowLayoutPanel()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Control control in MessagesFlowLayoutPanel.Controls)
            {
                if (control is Label label)
                {
                    sb.AppendLine(label.Text);
                }
                else if (control is PictureBox)
                {
                    sb.AppendLine("[이미지]");
                }
            }
            return sb.ToString();
        }
        // 텍스트 전체복사 기능 클릭입니다.(위 2개의 메서드와 연동됩니다.)
        private void btn_copy_Click(object sender, EventArgs e)
        {
            CopyTextToClipboard();
        }
        private void UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image uploadedImage = Image.FromFile(openFileDialog.FileName);
                pb_image_recent.Image = uploadedImage;
            }
        }

        private void btn_image_upload_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void btn_image_send_Click(object sender, EventArgs e)
        {
            SendEmoji(pb_image_recent.Image);
        }

        private void btnCalendarSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            sw = new StreamWriter("Log.txt");
            int nCount = CalendarEventsListBox.Items.Count;
            for (int i = 0; i < nCount; i++)
            {
                CalendarEventsListBox.Items[i] += "\r\n";
                sw.Write(CalendarEventsListBox.Items[i]);
            }
            sw.Close();
        }

        private void btnOpenNotepad_Click(object sender, EventArgs e)
        {
            NotepadForm notepadForm = new NotepadForm();
            notepadForm.ShowDialog();
        }
    }
}
