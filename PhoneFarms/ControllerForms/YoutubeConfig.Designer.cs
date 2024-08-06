namespace PhoneFarms.ControllerForms
{
    partial class YoutubeConfig
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtVideoURL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVideoTime = new System.Windows.Forms.TextBox();
            this.btnWatchYoutube = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(178, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 22);
            this.textBox1.TabIndex = 0;
            // 
            // txtVideoURL
            // 
            this.txtVideoURL.AutoSize = true;
            this.txtVideoURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoURL.Location = new System.Drawing.Point(24, 26);
            this.txtVideoURL.Name = "txtVideoURL";
            this.txtVideoURL.Size = new System.Drawing.Size(82, 16);
            this.txtVideoURL.TabIndex = 1;
            this.txtVideoURL.Text = "Video URL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Video Total Time";
            // 
            // txtVideoTime
            // 
            this.txtVideoTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoTime.Location = new System.Drawing.Point(178, 90);
            this.txtVideoTime.Name = "txtVideoTime";
            this.txtVideoTime.Size = new System.Drawing.Size(119, 22);
            this.txtVideoTime.TabIndex = 3;
            // 
            // btnWatchYoutube
            // 
            this.btnWatchYoutube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWatchYoutube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWatchYoutube.Location = new System.Drawing.Point(502, 23);
            this.btnWatchYoutube.Name = "btnWatchYoutube";
            this.btnWatchYoutube.Size = new System.Drawing.Size(161, 103);
            this.btnWatchYoutube.TabIndex = 4;
            this.btnWatchYoutube.Text = "Watch now";
            this.btnWatchYoutube.UseVisualStyleBackColor = true;
            this.btnWatchYoutube.Click += new System.EventHandler(this.btnWatchYoutube_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "seconds";
            // 
            // YoutubeConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 156);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnWatchYoutube);
            this.Controls.Add(this.txtVideoTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVideoURL);
            this.Controls.Add(this.textBox1);
            this.Name = "YoutubeConfig";
            this.Text = "YoutubeConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtVideoURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVideoTime;
        private System.Windows.Forms.Button btnWatchYoutube;
        private System.Windows.Forms.Label label2;
    }
}