namespace DataPatrolDesktop
{
    partial class SummaryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewSummary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewSummary = new System.Windows.Forms.ListView();
            this.SuspendLayout();

            // listViewSummary
            this.listViewSummary.Location = new System.Drawing.Point(20, 20);
            this.listViewSummary.Size = new System.Drawing.Size(400, 300);
            this.listViewSummary.View = System.Windows.Forms.View.Details;
            this.listViewSummary.Columns.Add("Status", 200);
            this.listViewSummary.Columns.Add("Count", 100);

            // SummaryForm
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Controls.Add(this.listViewSummary);
            this.Text = "Summary";

            this.Load += new System.EventHandler(this.SummaryForm_Load);

            this.ResumeLayout(false);
        }
    }
}
