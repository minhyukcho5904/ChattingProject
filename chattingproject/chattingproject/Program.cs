using System;
using System.Windows.Forms;

namespace chattingproject
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 폼 선택
            string choice = ShowFormSelectionDialog();
            if (choice == "Server")
            {
                Application.Run(new ServerForm());
            }
            else if (choice == "Client")
            {
                Application.Run(new ClientForm());
            }
        }

        static string ShowFormSelectionDialog()
        {
            // 폼 선택 다이얼로그 표시
            Form selectionForm = new Form()
            {
                Width = 300,
                Height = 150,
                Text = "Select Form to Run"
            };

            Button serverButton = new Button()
            {
                Text = "Server",
                Left = 50,
                Width = 80,
                Top = 30,
                DialogResult = DialogResult.OK
            };
            serverButton.Click += (sender, e) => { selectionForm.Tag = "Server"; selectionForm.Close(); };

            Button clientButton = new Button()
            {
                Text = "Client",
                Left = 150,
                Width = 80,
                Top = 30,
                DialogResult = DialogResult.OK
            };
            clientButton.Click += (sender, e) => { selectionForm.Tag = "Client"; selectionForm.Close(); };

            selectionForm.Controls.Add(serverButton);
            selectionForm.Controls.Add(clientButton);

            selectionForm.ShowDialog();

            return selectionForm.Tag as string;
        }
    }
}