using System;
using System.Collections.Generic;
using System.IO;
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

        private void StartButton_Click(object sender, EventArgs e)
        {
            _serverThread = new Thread(StartServer);
            _serverThread.Start();
            _isRunning = true;
            StartButton.Enabled = false;
            StopButton.Enabled = true;
        }

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
                        if (message.Contains("|emoji|"))
                        {
                            int imageLength = int.Parse(message.Split('|')[3]);
                            byte[] imageBuffer = new byte[imageLength];
                            int totalBytesRead = 0;
                            while (totalBytesRead < imageLength)
                            {
                                int bytesRead = stream.Read(imageBuffer, totalBytesRead, imageLength - totalBytesRead);
                                if (bytesRead == 0) throw new IOException("Connection closed.");
                                totalBytesRead += bytesRead;
                            }
                            BroadcastImage(message, imageBuffer, client);
                        }
                        else
                        {
                            BroadcastMessage(message, client);
                            HandleSpecialMessage(message);
                        }
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

        private void BroadcastImage(string header, byte[] imageBuffer, TcpClient excludeClient)
        {
            byte[] headerBuffer = Encoding.UTF8.GetBytes(header);

            lock (_lock)
            {
                foreach (var client in _clients)
                {
                    if (client != excludeClient)
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(headerBuffer, 0, headerBuffer.Length);
                        stream.Write(imageBuffer, 0, imageBuffer.Length);
                    }
                }
            }
        }

        private void Log(string message)
        {
            LogListBox.Items.Add(message);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopServer();
        }

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

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }

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

        private void LogListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
