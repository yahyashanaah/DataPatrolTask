using System.Windows.Forms;

namespace ListenerWindowApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUnregister;
        private System.Windows.Forms.ListView lvListeners;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUnregister = new System.Windows.Forms.Button();
            this.lvListeners = new System.Windows.Forms.ListView();

            this.SuspendLayout();

           
            // btnStart
            
            this.btnStart.Location = new System.Drawing.Point(20, 20);
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            
            // btnStop
            this.btnStop.Location = new System.Drawing.Point(140, 20);
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

           
            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(260, 20);
            this.btnRegister.Size = new System.Drawing.Size(100, 30);
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            
            // btnUnregister
            this.btnUnregister.Location = new System.Drawing.Point(380, 20);
            this.btnUnregister.Size = new System.Drawing.Size(100, 30);
            this.btnUnregister.Text = "Unregister";
            this.btnUnregister.UseVisualStyleBackColor = true;
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);

            
            // lvListeners
          
            this.lvListeners.Location = new System.Drawing.Point(20, 70);
            this.lvListeners.Size = new System.Drawing.Size(460, 300);
            this.lvListeners.View = System.Windows.Forms.View.Details;
            this.lvListeners.FullRowSelect = true;
            this.lvListeners.Columns.Add("Name", 100);
            this.lvListeners.Columns.Add("Target Number", 120);
            this.lvListeners.Columns.Add("Counter", 100);
            this.lvListeners.View = View.Details;
            this.lvListeners.FullRowSelect = true;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnUnregister);
            this.Controls.Add(this.lvListeners);
            this.Name = "Form1";
            this.Text = "Listener Window App";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
