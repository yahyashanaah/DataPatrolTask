using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DataPatrolDesktop
{
    public partial class SummaryForm : Form
    {
        private readonly string _userId;
        private static readonly HttpClient client = new();

        public SummaryForm(string userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void SummaryForm_Load(object sender, EventArgs e)
        {
            try
            {
                var payload = new { userId = _userId };
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7110/request/summary", content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var summary = JsonSerializer.Deserialize<Dictionary<string, int>>(json);

                    listViewSummary.Items.Clear();

                    foreach (var item in summary)
                    {
                        var listItem = new ListViewItem(item.Key);
                        listItem.SubItems.Add(item.Value.ToString());
                        listViewSummary.Items.Add(listItem);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load summary.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
