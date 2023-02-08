namespace ToastModCleaned.UserInterface
{
    partial class RecieveInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Recieve = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.Players = new System.Windows.Forms.ListBox();
            this.SitOnHead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Recieve
            // 
            this.Recieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Recieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recieve.Location = new System.Drawing.Point(315, 42);
            this.Recieve.Name = "Recieve";
            this.Recieve.Size = new System.Drawing.Size(80, 31);
            this.Recieve.TabIndex = 0;
            this.Recieve.Text = "Recieve";
            this.Recieve.UseVisualStyleBackColor = true;
            // 
            // Send
            // 
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send.Location = new System.Drawing.Point(12, 42);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(80, 31);
            this.Send.TabIndex = 1;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // UserInput
            // 
            this.UserInput.BackColor = System.Drawing.Color.Black;
            this.UserInput.ForeColor = System.Drawing.Color.Cyan;
            this.UserInput.Location = new System.Drawing.Point(12, 12);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(383, 20);
            this.UserInput.TabIndex = 2;
            this.UserInput.Text = "Functions";
            this.UserInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserInput.TextChanged += new System.EventHandler(this.UserInput_TextChanged);
            // 
            // Players
            // 
            this.Players.BackColor = System.Drawing.Color.Black;
            this.Players.ForeColor = System.Drawing.Color.Cyan;
            this.Players.FormattingEnabled = true;
            this.Players.Location = new System.Drawing.Point(12, 79);
            this.Players.Name = "Players";
            this.Players.Size = new System.Drawing.Size(383, 251);
            this.Players.TabIndex = 3;
            this.Players.Click += new System.EventHandler(this.Players_Click);
            this.Players.SelectedIndexChanged += new System.EventHandler(this.Players_SelectedIndexChanged);
            this.Players.DoubleClick += new System.EventHandler(this.Players_DoubleClick);
            // 
            // SitOnHead
            // 
            this.SitOnHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SitOnHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SitOnHead.Location = new System.Drawing.Point(12, 345);
            this.SitOnHead.Name = "SitOnHead";
            this.SitOnHead.Size = new System.Drawing.Size(80, 31);
            this.SitOnHead.TabIndex = 4;
            this.SitOnHead.Text = "HeadSit";
            this.SitOnHead.UseVisualStyleBackColor = true;
            this.SitOnHead.Click += new System.EventHandler(this.SitOnHead_Click);
            // 
            // RecieveInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(414, 388);
            this.Controls.Add(this.SitOnHead);
            this.Controls.Add(this.Players);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Recieve);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.Cyan;
            this.Name = "RecieveInput";
            this.Text = "RecieveInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Recieve;
        private System.Windows.Forms.Button Send;
        public System.Windows.Forms.TextBox UserInput;
        public System.Windows.Forms.ListBox Players;
        private System.Windows.Forms.Button SitOnHead;
    }
}