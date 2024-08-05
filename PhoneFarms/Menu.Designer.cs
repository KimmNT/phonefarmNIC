namespace PhoneFarms
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnPhoneFarms = new System.Windows.Forms.Button();
            this.btnVPN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPhoneFarms
            // 
            this.btnPhoneFarms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhoneFarms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhoneFarms.Location = new System.Drawing.Point(33, 23);
            this.btnPhoneFarms.Name = "btnPhoneFarms";
            this.btnPhoneFarms.Size = new System.Drawing.Size(228, 112);
            this.btnPhoneFarms.TabIndex = 0;
            this.btnPhoneFarms.Text = "Phones Controller";
            this.btnPhoneFarms.UseVisualStyleBackColor = true;
            this.btnPhoneFarms.Click += new System.EventHandler(this.btnPhoneFarms_Click);
            // 
            // btnVPN
            // 
            this.btnVPN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVPN.Location = new System.Drawing.Point(396, 23);
            this.btnVPN.Name = "btnVPN";
            this.btnVPN.Size = new System.Drawing.Size(228, 112);
            this.btnVPN.TabIndex = 1;
            this.btnVPN.Text = "VPS Controller";
            this.btnVPN.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 179);
            this.Controls.Add(this.btnVPN);
            this.Controls.Add(this.btnPhoneFarms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(690, 218);
            this.MaximumSize = new System.Drawing.Size(690, 218);
            this.MinimumSize = new System.Drawing.Size(690, 218);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPhoneFarms;
        private System.Windows.Forms.Button btnVPN;
    }
}