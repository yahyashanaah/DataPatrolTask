using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListenerWindowApp
{
    public partial class Form1 : Form
    {
        private APIClient client;
        public Form1()
        {
            InitializeComponent();
            client = new APIClient();
        }

        private APIClient apiClient = new APIClient();

        private void btnStart_Click(object sender, EventArgs e)
        {
            apiClient.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            apiClient.Stop();
        }

        //private void btnRegister_Click(object sender, EventArgs e)
        //{
        //    string name = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the listener:", "Listener Name", "Listener 1");
        //    if (string.IsNullOrEmpty(name)) return;

        //    string target = Microsoft.VisualBasic.Interaction.InputBox("Enter a number to listen for:", "Target Number", "7");
        //    if (string.IsNullOrEmpty(target)) return;

        //    var listener = new Listener(name, target, lvListeners);
        //    apiClient.Listeners.Add(listener);

        //    MessageBox.Show($"Listener '{name}' registered for number {target}.");
        //}

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = $"Listener {client.Listeners.Count + 1}";
            Random rnd = new Random();
            int targetNumber = rnd.Next(1, 101);

            var listener = new Listener(name, targetNumber);
            client.Listeners.Add(listener);

            UpdateListView(); 
        }


        private void UpdateListView()
        {
            lvListeners.Items.Clear();

            foreach (var listener in client.Listeners)
            {
                var item = new ListViewItem(listener.Name);
                item.SubItems.Add(listener.TargetNumber.ToString());
                item.SubItems.Add(listener.Counter.ToString());
                lvListeners.Items.Add(item);
            }
        }


        private void btnUnregister_Click(object sender, EventArgs e)
        {
            apiClient.Listeners.Clear(); 
            MessageBox.Show("Listeners cleared.");
        }
    }
}
