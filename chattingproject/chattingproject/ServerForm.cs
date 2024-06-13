using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace chattingproject
{
    public partial class ServerForm : Form
    {
        private TcpListener _listener;
        private List<TcpClient> _clients;
        private readonly object _lock = new object();
        private Thread _serverThread;
        private bool _isRunning;

        public ServerForm()
        {
            InitializeComponent();
            _clients = new List<TcpClient>();
        }

        // 서버 시작 버튼 클릭 이벤트 핸들러
        private void StartButton_Click(object sender, EventArgs e)
        {
            _serverThread = new Thread(StartServer);
            _serverThread.Start();
            _isRunning = true;
            StartButton.Enabled = false;
            StopButton.Enabled = true;
        }

        // 서버를 시작하는 메서드
        private void StartServer()
        {
            _listener = new TcpListener(IPAddress.Any, 8888);
            _listener.Start();
            Invoke(new Action(() => Log("Server started...")));

            while (_isRunning)
            {
                if (_listener.Pending())
                {
                    var client = _listener.AcceptTcpClient();
                    lock (_lock)
                    {
                        _clients.Add(client);
                    }
                    Invoke(new Action(() => Log("Client connected")));
                    Thread thread = new Thread(HandleClient);
                    thread.Start(client);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        // 클라이언트 연결을 처리하는 메서드
        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            while (_isRunning)
            {
                try
                {
                    if (stream.DataAvailable)
                    {
                        byte[] buffer = new byte[1024];
                        int byteCount = stream.Read(buffer, 0, buffer.Length);
                        if (byteCount == 0) break;

                        string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                        BroadcastMessage(message, client);
                        HandleSpecialMessage(message); // 추가된 메서드 호출
                    }
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => Log(ex.Message)));
                    break;
                }
            }

            lock (_lock)
            {
                _clients.Remove(client);
            }
            client.Close();
            Invoke(new Action(() => Log("Client disconnected")));
        }

        // 메시지를 모든 클라이언트에게 브로드캐스트하는 메서드
        private void BroadcastMessage(string message, TcpClient excludeClient)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            lock (_lock)
            {
                foreach (var client in _clients)
                {
                    if (client != excludeClient)
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        // 로그를 추가하는 메서드
        private void Log(string message)
        {
            LogListBox.Items.Add(message);
        }

        // 서버 종료 버튼 클릭 이벤트 핸들러
        private void StopButton_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        // 서버를 종료하는 메서드
        private void StopServer()
        {
            _isRunning = false;
            if (_listener != null)
            {
                _listener.Stop();
            }
            lock (_lock)
            {
                foreach (var client in _clients)
                {
                    client.Close();
                }
                _clients.Clear();
            }
            Invoke(new Action(() => Log("Server stopped...")));
            StartButton.Enabled = true;
            StopButton.Enabled = false;
        }

        // 폼이 닫힐 때 서버를 종료하는 이벤트 핸들러
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }

        // 특수 메시지를 처리하는 메서드
        private void HandleSpecialMessage(string message)
        {
            if (message.StartsWith("CALENDAR|"))
            {
                string eventDetails = message.Substring("CALENDAR|".Length);
                DateTime eventTime = DateTime.Parse(eventDetails.Split('|')[0]);
                string memo = eventDetails.Split('|')[2];
                ScheduleNotification(eventTime, memo);
            }
        }

        // 알림을 스케줄링하는 메서드
        private void ScheduleNotification(DateTime eventTime, string memo)
        {
            TimeSpan timeSpan = eventTime - DateTime.Now;
            if (timeSpan.TotalMilliseconds > 0)
            {
                var timer = new System.Threading.Timer(_ =>
                {
                    BroadcastMessage($"ALERT|{DateTime.Now:yyyy-MM-dd HH:mm:ss}|Server|{memo}", null);
                }, null, timeSpan, System.Threading.Timeout.InfiniteTimeSpan);
            }
        }
    }
}