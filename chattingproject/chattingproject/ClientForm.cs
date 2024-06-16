using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace chattingproject
{
    public partial class ClientForm : Form
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private string _nickname;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // 기본 닉네임 설정
            _nickname = "익명";

            // 실시간 시계 타이머 설정
            clockTimer.Interval = 1000; // 1초마다 틱
            clockTimer.Tick += UpdateClock;
            clockTimer.Start();
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

                // 메시지 수신을 위한 스레드 시작
                Thread thread = new Thread(ReceiveMessages);
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

        // 닉네임 설정 버튼 클릭 이벤트 핸들러
        private void SetNicknameButton_Click(object sender, EventArgs e)
        {
            _nickname = string.IsNullOrWhiteSpace(NicknameTextBox.Text) ? "익명" : NicknameTextBox.Text;
            NicknameTextBox.Enabled = false;
            SetNicknameButton.Enabled = false;
        }

        // 메시지 전송 버튼 클릭 이벤트 핸들러
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
                e.SuppressKeyPress = true; // Enter 키 입력 소리를 없애기 위해
            }
        }

        // 메시지를 서버로 전송하는 메서드
        private void SendMessage()
        {
            try
            {
                string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{_nickname}|{MessageTextBox.Text}";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                _stream.Write(buffer, 0, buffer.Length);
                AppendMessage(message); // 로컬 메시지 리스트에 메시지 추가
                MessageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 서버로부터 메시지를 수신하는 메서드
        private void ReceiveMessages()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int byteCount = _stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    AppendMessage(message);
                    HandleSpecialMessage(message); // 추가된 메서드 호출
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
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
                string senderName = parts[1]; // 이름 변경
                string content = parts[2];
                MessagesListBox.Items.Add($"{timestamp} [{senderName}]: {content}");
            }
        }

        // 캘린더 이벤트 설정 버튼 클릭 이벤트 핸들러
        private void SetCalendarEventButton_Click(object sender, EventArgs e)
        {
            try
            {
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
                string senderName = parts[1]; // 이름 변경
                string content = parts[2];

                // 알림 창 생성
                Form alertForm = new Form()
                {
                    Width = 300,
                    Height = 200,
                    Text = "Event Alert"
                };

                Label alertLabel = new Label()
                {
                    Text = $"{timestamp}\n{senderName}\n{content}",
                    AutoSize = true,
                    Location = new System.Drawing.Point(10, 10)
                };

                Button confirmButton = new Button()
                {
                    Text = "Confirm",
                    Location = new System.Drawing.Point(100, 130),
                    Width = 75
                };
                confirmButton.Click += (s, e) => // 여기서 이름 변경
                {
                    alertForm.Close();
                    MarkEventAsComplete(content); // 일정 완료 표시
                };

                alertForm.Controls.Add(alertLabel);
                alertForm.Controls.Add(confirmButton);

                alertForm.ShowDialog();
            }
        }

        // 일정 완료를 표시하는 메서드
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
    }
}
