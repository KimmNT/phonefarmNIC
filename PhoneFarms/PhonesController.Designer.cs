namespace PhoneFarms
{
    partial class PhonesController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhonesController));
            this.dataGridViewDevices = new System.Windows.Forms.DataGridView();
            this.btnGetScreenContent = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnWifiConfig = new System.Windows.Forms.Button();
            this.btnTurnProxy = new System.Windows.Forms.Button();
            this.btnGetInstalled = new System.Windows.Forms.Button();
            this.btnYoutube = new System.Windows.Forms.Button();
            this.lbDeviceCount = new System.Windows.Forms.Label();
            this.btnImportAPK = new System.Windows.Forms.Button();
            this.btnReadButtons = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnFacebookService = new System.Windows.Forms.Button();
            this.btnWebView = new System.Windows.Forms.Button();
            this.btnSwipeCustom = new System.Windows.Forms.Button();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.Controller = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtFindText = new System.Windows.Forms.TextBox();
            this.btnFindText = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.btnGetActivity = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTapY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTapX = new System.Windows.Forms.TextBox();
            this.btnTapping = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnResolution = new System.Windows.Forms.Button();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.btnTimeOut = new System.Windows.Forms.Button();
            this.btnRotation = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnLockType = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            this.Controller.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.Size = new System.Drawing.Size(708, 553);
            this.dataGridViewDevices.TabIndex = 10;
            // 
            // btnGetScreenContent
            // 
            this.btnGetScreenContent.Location = new System.Drawing.Point(6, 6);
            this.btnGetScreenContent.Name = "btnGetScreenContent";
            this.btnGetScreenContent.Size = new System.Drawing.Size(120, 37);
            this.btnGetScreenContent.TabIndex = 13;
            this.btnGetScreenContent.Text = "Read Content";
            this.btnGetScreenContent.UseVisualStyleBackColor = true;
            this.btnGetScreenContent.Click += new System.EventHandler(this.btnTapHelloButton_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(730, 556);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(84, 37);
            this.btnHome.TabIndex = 23;
            this.btnHome.Text = "HOME";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnWifiConfig
            // 
            this.btnWifiConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWifiConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWifiConfig.Location = new System.Drawing.Point(6, 6);
            this.btnWifiConfig.Name = "btnWifiConfig";
            this.btnWifiConfig.Size = new System.Drawing.Size(133, 41);
            this.btnWifiConfig.TabIndex = 24;
            this.btnWifiConfig.Text = "Connect WiFi";
            this.btnWifiConfig.UseVisualStyleBackColor = true;
            this.btnWifiConfig.Click += new System.EventHandler(this.btnWifiConfig_Click);
            // 
            // btnTurnProxy
            // 
            this.btnTurnProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnProxy.Location = new System.Drawing.Point(290, 54);
            this.btnTurnProxy.Name = "btnTurnProxy";
            this.btnTurnProxy.Size = new System.Drawing.Size(133, 41);
            this.btnTurnProxy.TabIndex = 25;
            this.btnTurnProxy.Text = "Turn on Proxy";
            this.btnTurnProxy.UseVisualStyleBackColor = true;
            this.btnTurnProxy.Click += new System.EventHandler(this.btnTurnProxy_Click);
            // 
            // btnGetInstalled
            // 
            this.btnGetInstalled.Location = new System.Drawing.Point(27, 29);
            this.btnGetInstalled.Name = "btnGetInstalled";
            this.btnGetInstalled.Size = new System.Drawing.Size(120, 37);
            this.btnGetInstalled.TabIndex = 26;
            this.btnGetInstalled.Text = "Get Installed Apps";
            this.btnGetInstalled.UseVisualStyleBackColor = true;
            this.btnGetInstalled.Click += new System.EventHandler(this.btnGetInstalled_Click);
            // 
            // btnYoutube
            // 
            this.btnYoutube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYoutube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYoutube.Location = new System.Drawing.Point(145, 6);
            this.btnYoutube.Name = "btnYoutube";
            this.btnYoutube.Size = new System.Drawing.Size(139, 41);
            this.btnYoutube.TabIndex = 28;
            this.btnYoutube.Text = "Youtube";
            this.btnYoutube.UseVisualStyleBackColor = true;
            this.btnYoutube.Click += new System.EventHandler(this.btnYoutube_Click);
            // 
            // lbDeviceCount
            // 
            this.lbDeviceCount.AutoSize = true;
            this.lbDeviceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeviceCount.Location = new System.Drawing.Point(163, 15);
            this.lbDeviceCount.Name = "lbDeviceCount";
            this.lbDeviceCount.Size = new System.Drawing.Size(44, 16);
            this.lbDeviceCount.TabIndex = 30;
            this.lbDeviceCount.Text = "label1";
            // 
            // btnImportAPK
            // 
            this.btnImportAPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportAPK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportAPK.Location = new System.Drawing.Point(290, 6);
            this.btnImportAPK.Name = "btnImportAPK";
            this.btnImportAPK.Size = new System.Drawing.Size(133, 41);
            this.btnImportAPK.TabIndex = 31;
            this.btnImportAPK.Text = "Import APK";
            this.btnImportAPK.UseVisualStyleBackColor = true;
            this.btnImportAPK.Click += new System.EventHandler(this.btnImportAPK_Click);
            // 
            // btnReadButtons
            // 
            this.btnReadButtons.Location = new System.Drawing.Point(6, 58);
            this.btnReadButtons.Name = "btnReadButtons";
            this.btnReadButtons.Size = new System.Drawing.Size(120, 37);
            this.btnReadButtons.TabIndex = 32;
            this.btnReadButtons.Text = "Read Button";
            this.btnReadButtons.UseVisualStyleBackColor = true;
            this.btnReadButtons.Click += new System.EventHandler(this.btnReadButtons_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Total:";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(12, 11);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 34;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnselectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnselectAll.Location = new System.Drawing.Point(12, 11);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(90, 23);
            this.btnUnselectAll.TabIndex = 35;
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Visible = false;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnFacebookService
            // 
            this.btnFacebookService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacebookService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacebookService.Location = new System.Drawing.Point(6, 53);
            this.btnFacebookService.Name = "btnFacebookService";
            this.btnFacebookService.Size = new System.Drawing.Size(133, 41);
            this.btnFacebookService.TabIndex = 36;
            this.btnFacebookService.Text = "Facebook Services";
            this.btnFacebookService.UseVisualStyleBackColor = true;
            this.btnFacebookService.Click += new System.EventHandler(this.btnFacebookService_Click);
            // 
            // btnWebView
            // 
            this.btnWebView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebView.Location = new System.Drawing.Point(145, 54);
            this.btnWebView.Name = "btnWebView";
            this.btnWebView.Size = new System.Drawing.Size(139, 41);
            this.btnWebView.TabIndex = 37;
            this.btnWebView.Text = "Enable WebView";
            this.btnWebView.UseVisualStyleBackColor = true;
            this.btnWebView.Click += new System.EventHandler(this.btnWebView_Click);
            // 
            // btnSwipeCustom
            // 
            this.btnSwipeCustom.Location = new System.Drawing.Point(36, 238);
            this.btnSwipeCustom.Name = "btnSwipeCustom";
            this.btnSwipeCustom.Size = new System.Drawing.Size(308, 66);
            this.btnSwipeCustom.TabIndex = 5;
            this.btnSwipeCustom.Text = "Swipe Custom";
            this.btnSwipeCustom.UseVisualStyleBackColor = true;
            this.btnSwipeCustom.Click += new System.EventHandler(this.btnSwipeCustom_Click);
            // 
            // txtX1
            // 
            this.txtX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtX1.Location = new System.Drawing.Point(108, 134);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(64, 21);
            this.txtX1.TabIndex = 1;
            this.txtX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtX2
            // 
            this.txtX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtX2.Location = new System.Drawing.Point(280, 133);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(64, 21);
            this.txtX2.TabIndex = 3;
            this.txtX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtY2
            // 
            this.txtY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtY2.Location = new System.Drawing.Point(280, 177);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(64, 21);
            this.txtY2.TabIndex = 4;
            this.txtY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtY1
            // 
            this.txtY1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtY1.Location = new System.Drawing.Point(108, 178);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(64, 21);
            this.txtY1.TabIndex = 2;
            this.txtY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Controller
            // 
            this.Controller.Controls.Add(this.tabPage1);
            this.Controller.Controls.Add(this.tabPage2);
            this.Controller.Controls.Add(this.tabPage3);
            this.Controller.Controls.Add(this.tabPage4);
            this.Controller.Controls.Add(this.tabPage5);
            this.Controller.Controls.Add(this.tabPage6);
            this.Controller.Location = new System.Drawing.Point(726, 12);
            this.Controller.Name = "Controller";
            this.Controller.SelectedIndex = 0;
            this.Controller.Size = new System.Drawing.Size(437, 529);
            this.Controller.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtFindText);
            this.tabPage1.Controls.Add(this.btnFindText);
            this.tabPage1.Controls.Add(this.btnGetScreenContent);
            this.tabPage1.Controls.Add(this.btnReadButtons);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtFindText
            // 
            this.txtFindText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindText.Location = new System.Drawing.Point(132, 206);
            this.txtFindText.Name = "txtFindText";
            this.txtFindText.Size = new System.Drawing.Size(272, 24);
            this.txtFindText.TabIndex = 34;
            // 
            // btnFindText
            // 
            this.btnFindText.Location = new System.Drawing.Point(6, 201);
            this.btnFindText.Name = "btnFindText";
            this.btnFindText.Size = new System.Drawing.Size(120, 37);
            this.btnFindText.TabIndex = 33;
            this.btnFindText.Text = "Read Existed Text";
            this.btnFindText.UseVisualStyleBackColor = true;
            this.btnFindText.Click += new System.EventHandler(this.btnFindText_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtAppName);
            this.tabPage2.Controls.Add(this.btnGetActivity);
            this.tabPage2.Controls.Add(this.btnGetInstalled);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 503);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Get App Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtAppName
            // 
            this.txtAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppName.Location = new System.Drawing.Point(27, 113);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(323, 22);
            this.txtAppName.TabIndex = 28;
            // 
            // btnGetActivity
            // 
            this.btnGetActivity.Location = new System.Drawing.Point(27, 158);
            this.btnGetActivity.Name = "btnGetActivity";
            this.btnGetActivity.Size = new System.Drawing.Size(120, 37);
            this.btnGetActivity.TabIndex = 27;
            this.btnGetActivity.Text = "Get App Activity";
            this.btnGetActivity.UseVisualStyleBackColor = true;
            this.btnGetActivity.Click += new System.EventHandler(this.btnGetActivity_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.btnSwipeCustom);
            this.tabPage3.Controls.Add(this.txtY2);
            this.tabPage3.Controls.Add(this.txtX1);
            this.tabPage3.Controls.Add(this.txtY1);
            this.tabPage3.Controls.Add(this.txtX2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(429, 503);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Swipe Custom";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(219, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "Y - end";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(219, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "X - end";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Y - start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "X - start";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.txtTapY);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtTapX);
            this.tabPage4.Controls.Add(this.btnTapping);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(429, 503);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tap Custom";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(207, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Y";
            // 
            // txtTapY
            // 
            this.txtTapY.Location = new System.Drawing.Point(234, 141);
            this.txtTapY.Name = "txtTapY";
            this.txtTapY.Size = new System.Drawing.Size(100, 20);
            this.txtTapY.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "X";
            // 
            // txtTapX
            // 
            this.txtTapX.Location = new System.Drawing.Point(77, 141);
            this.txtTapX.Name = "txtTapX";
            this.txtTapX.Size = new System.Drawing.Size(100, 20);
            this.txtTapX.TabIndex = 29;
            // 
            // btnTapping
            // 
            this.btnTapping.Location = new System.Drawing.Point(54, 211);
            this.btnTapping.Name = "btnTapping";
            this.btnTapping.Size = new System.Drawing.Size(280, 37);
            this.btnTapping.TabIndex = 28;
            this.btnTapping.Text = "Tappit";
            this.btnTapping.UseVisualStyleBackColor = true;
            this.btnTapping.Click += new System.EventHandler(this.btnTapping_Click_1);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.btnWifiConfig);
            this.tabPage5.Controls.Add(this.btnFacebookService);
            this.tabPage5.Controls.Add(this.btnWebView);
            this.tabPage5.Controls.Add(this.btnYoutube);
            this.tabPage5.Controls.Add(this.btnImportAPK);
            this.tabPage5.Controls.Add(this.btnTurnProxy);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(429, 503);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Custom Features";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 41);
            this.button1.TabIndex = 38;
            this.button1.Text = "Reels";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnResolution);
            this.tabPage6.Controls.Add(this.btnLanguage);
            this.tabPage6.Controls.Add(this.btnTimeOut);
            this.tabPage6.Controls.Add(this.btnRotation);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(429, 503);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Setup for new";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnResolution
            // 
            this.btnResolution.Location = new System.Drawing.Point(16, 62);
            this.btnResolution.Name = "btnResolution";
            this.btnResolution.Size = new System.Drawing.Size(133, 41);
            this.btnResolution.TabIndex = 40;
            this.btnResolution.Text = "Change Resolution";
            this.btnResolution.UseVisualStyleBackColor = true;
            this.btnResolution.Click += new System.EventHandler(this.btnResolution_Click);
            // 
            // btnLanguage
            // 
            this.btnLanguage.Location = new System.Drawing.Point(296, 13);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(133, 40);
            this.btnLanguage.TabIndex = 41;
            this.btnLanguage.Text = "Change Language";
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnTimeOut
            // 
            this.btnTimeOut.Location = new System.Drawing.Point(16, 12);
            this.btnTimeOut.Name = "btnTimeOut";
            this.btnTimeOut.Size = new System.Drawing.Size(133, 40);
            this.btnTimeOut.TabIndex = 46;
            this.btnTimeOut.Text = "Change TimeOut";
            this.btnTimeOut.UseVisualStyleBackColor = true;
            this.btnTimeOut.Click += new System.EventHandler(this.btnTimeOut_Click);
            // 
            // btnRotation
            // 
            this.btnRotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotation.Location = new System.Drawing.Point(155, 13);
            this.btnRotation.Name = "btnRotation";
            this.btnRotation.Size = new System.Drawing.Size(133, 39);
            this.btnRotation.TabIndex = 39;
            this.btnRotation.Text = "Disable Rotation";
            this.btnRotation.UseVisualStyleBackColor = true;
            this.btnRotation.Click += new System.EventHandler(this.btnRotation_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(830, 556);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(84, 37);
            this.btnUnlock.TabIndex = 45;
            this.btnUnlock.Text = "UNLOCK";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnLockType
            // 
            this.btnLockType.Location = new System.Drawing.Point(932, 556);
            this.btnLockType.Name = "btnLockType";
            this.btnLockType.Size = new System.Drawing.Size(86, 37);
            this.btnLockType.TabIndex = 46;
            this.btnLockType.Text = "Change LockType";
            this.btnLockType.UseVisualStyleBackColor = true;
            this.btnLockType.Click += new System.EventHandler(this.btnLockType_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1058, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 47;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PhonesController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 605);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLockType);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.Controller);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDeviceCount);
            this.Controls.Add(this.dataGridViewDevices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PhonesController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            this.Controller.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewDevices;
        private System.Windows.Forms.Button btnGetScreenContent;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnWifiConfig;
        private System.Windows.Forms.Button btnTurnProxy;
        private System.Windows.Forms.Button btnGetInstalled;
        private System.Windows.Forms.Button btnYoutube;
        private System.Windows.Forms.Label lbDeviceCount;
        private System.Windows.Forms.Button btnImportAPK;
        private System.Windows.Forms.Button btnReadButtons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnFacebookService;
        private System.Windows.Forms.Button btnWebView;
        private System.Windows.Forms.Button btnSwipeCustom;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.TabControl Controller;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Button btnGetActivity;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnTapping;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTapY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTapX;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRotation;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.TextBox txtFindText;
        private System.Windows.Forms.Button btnFindText;
        private System.Windows.Forms.Button btnResolution;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.Button btnTimeOut;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnLockType;
        private System.Windows.Forms.Button button2;
    }
}

