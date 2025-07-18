namespace DataPatrolDesktop
{
    partial class RequestForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtRequestCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnViewSummary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtRequestCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnViewSummary = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Request Code
            this.lblCode.Text = "Request Code:";
            this.lblCode.Location = new System.Drawing.Point(20, 20);
            this.lblCode.Size = new System.Drawing.Size(100, 23);
            this.txtRequestCode.Location = new System.Drawing.Point(130, 20);
            this.txtRequestCode.Size = new System.Drawing.Size(150, 23);

            // Description
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(20, 60);
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.txtDescription.Location = new System.Drawing.Point(130, 60);
            this.txtDescription.Size = new System.Drawing.Size(150, 60);
            this.txtDescription.Multiline = true;

            // Submit
            this.btnSubmit.Text = "Submit Request";
            this.btnSubmit.Location = new System.Drawing.Point(20, 140);
            this.btnSubmit.Size = new System.Drawing.Size(120, 30);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // View Summary
            this.btnViewSummary.Text = "View Summary";
            this.btnViewSummary.Location = new System.Drawing.Point(160, 140);
            this.btnViewSummary.Size = new System.Drawing.Size(120, 30);
            this.btnViewSummary.Click += new System.EventHandler(this.btnViewSummary_Click);

            // Form setup
            this.ClientSize = new System.Drawing.Size(320, 200);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtRequestCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnViewSummary);
            this.Text = "Request Form";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
