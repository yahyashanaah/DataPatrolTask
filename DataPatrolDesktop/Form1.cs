using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DataPatrolDesktop
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            var payload = new { username = txtUsername.Text };
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7110/reg", content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<JsonElement>(json);
                string userId = data.GetProperty("userId").GetString();

                var requestForm = new RequestForm(userId);
                requestForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed.");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
