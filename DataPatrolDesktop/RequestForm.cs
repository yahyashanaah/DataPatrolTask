using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace DataPatrolDesktop
{
    public partial class RequestForm : Form
    {
        private readonly string _userId;
        private static readonly HttpClient client = new();

        public RequestForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRequestCode.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            var payload = new
            {
                UserId = _userId,
                RequestCode = int.Parse(txtRequestCode.Text),
                Description = txtDescription.Text
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7110/request/create", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Request submitted successfully!");
                txtRequestCode.Text = "";
                txtDescription.Text = "";
            }
            else
            {
                MessageBox.Show("Error submitting request.");
            }
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            var summaryForm = new SummaryForm(_userId);
            summaryForm.Show();
        }
    }
}
