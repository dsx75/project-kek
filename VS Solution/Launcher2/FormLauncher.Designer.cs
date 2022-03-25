namespace TaidanaKage.Kek;

partial class FormLauncher
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.groupBoxClients = new System.Windows.Forms.GroupBox();
            this.buttonManageClients = new System.Windows.Forms.Button();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.groupBoxRulesets = new System.Windows.Forms.GroupBox();
            this.buttonManageRulesets = new System.Windows.Forms.Button();
            this.comboBoxRulesets = new System.Windows.Forms.ComboBox();
            this.groupBoxWorlds = new System.Windows.Forms.GroupBox();
            this.buttonManageWorlds = new System.Windows.Forms.Button();
            this.comboBoxWorlds = new System.Windows.Forms.ComboBox();
            this.groupBoxPlay = new System.Windows.Forms.GroupBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.groupBoxAccounts = new System.Windows.Forms.GroupBox();
            this.buttonManageAccounts = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.groupBoxWorldVersions = new System.Windows.Forms.GroupBox();
            this.buttonWorldVersions = new System.Windows.Forms.Button();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxServerStatus = new System.Windows.Forms.GroupBox();
            this.labelKekWorldServerStatus = new System.Windows.Forms.Label();
            this.labelWowWorldServerStatus = new System.Windows.Forms.Label();
            this.labelWowMetaServerStatus = new System.Windows.Forms.Label();
            this.labelKekWorldServer = new System.Windows.Forms.Label();
            this.labelWowWorldServer = new System.Windows.Forms.Label();
            this.labelWowMetaServer = new System.Windows.Forms.Label();
            this.groupBoxClients.SuspendLayout();
            this.groupBoxRulesets.SuspendLayout();
            this.groupBoxWorlds.SuspendLayout();
            this.groupBoxPlay.SuspendLayout();
            this.groupBoxAccounts.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxWorldVersions.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.groupBoxServerStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxClients
            // 
            this.groupBoxClients.Controls.Add(this.buttonManageClients);
            this.groupBoxClients.Controls.Add(this.comboBoxClients);
            this.groupBoxClients.Location = new System.Drawing.Point(20, 120);
            this.groupBoxClients.Name = "groupBoxClients";
            this.groupBoxClients.Size = new System.Drawing.Size(530, 80);
            this.groupBoxClients.TabIndex = 2;
            this.groupBoxClients.TabStop = false;
            this.groupBoxClients.Text = "1. Select WoW client";
            // 
            // buttonManageClients
            // 
            this.buttonManageClients.Location = new System.Drawing.Point(440, 30);
            this.buttonManageClients.Name = "buttonManageClients";
            this.buttonManageClients.Size = new System.Drawing.Size(75, 23);
            this.buttonManageClients.TabIndex = 1;
            this.buttonManageClients.Text = "Manage";
            this.buttonManageClients.UseVisualStyleBackColor = true;
            this.buttonManageClients.Click += new System.EventHandler(this.buttonManageClients_Click);
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(10, 30);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(410, 23);
            this.comboBoxClients.TabIndex = 0;
            this.comboBoxClients.SelectedIndexChanged += new System.EventHandler(this.comboBoxClients_SelectedIndexChanged);
            // 
            // groupBoxRulesets
            // 
            this.groupBoxRulesets.Controls.Add(this.buttonManageRulesets);
            this.groupBoxRulesets.Controls.Add(this.comboBoxRulesets);
            this.groupBoxRulesets.Location = new System.Drawing.Point(20, 220);
            this.groupBoxRulesets.Name = "groupBoxRulesets";
            this.groupBoxRulesets.Size = new System.Drawing.Size(530, 70);
            this.groupBoxRulesets.TabIndex = 3;
            this.groupBoxRulesets.TabStop = false;
            this.groupBoxRulesets.Text = "2. Select ruleset";
            // 
            // buttonManageRulesets
            // 
            this.buttonManageRulesets.Location = new System.Drawing.Point(440, 30);
            this.buttonManageRulesets.Name = "buttonManageRulesets";
            this.buttonManageRulesets.Size = new System.Drawing.Size(75, 23);
            this.buttonManageRulesets.TabIndex = 1;
            this.buttonManageRulesets.Text = "Manage";
            this.buttonManageRulesets.UseVisualStyleBackColor = true;
            this.buttonManageRulesets.Click += new System.EventHandler(this.buttonManageRulesets_Click);
            // 
            // comboBoxRulesets
            // 
            this.comboBoxRulesets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRulesets.FormattingEnabled = true;
            this.comboBoxRulesets.Location = new System.Drawing.Point(10, 30);
            this.comboBoxRulesets.Name = "comboBoxRulesets";
            this.comboBoxRulesets.Size = new System.Drawing.Size(410, 23);
            this.comboBoxRulesets.TabIndex = 0;
            this.comboBoxRulesets.SelectedIndexChanged += new System.EventHandler(this.comboBoxRulesets_SelectedIndexChanged);
            // 
            // groupBoxWorlds
            // 
            this.groupBoxWorlds.Controls.Add(this.buttonManageWorlds);
            this.groupBoxWorlds.Controls.Add(this.comboBoxWorlds);
            this.groupBoxWorlds.Location = new System.Drawing.Point(20, 320);
            this.groupBoxWorlds.Name = "groupBoxWorlds";
            this.groupBoxWorlds.Size = new System.Drawing.Size(530, 70);
            this.groupBoxWorlds.TabIndex = 4;
            this.groupBoxWorlds.TabStop = false;
            this.groupBoxWorlds.Text = "3. Select world";
            // 
            // buttonManageWorlds
            // 
            this.buttonManageWorlds.Location = new System.Drawing.Point(440, 30);
            this.buttonManageWorlds.Name = "buttonManageWorlds";
            this.buttonManageWorlds.Size = new System.Drawing.Size(75, 23);
            this.buttonManageWorlds.TabIndex = 1;
            this.buttonManageWorlds.Text = "Manage";
            this.buttonManageWorlds.UseVisualStyleBackColor = true;
            this.buttonManageWorlds.Click += new System.EventHandler(this.buttonManageWorlds_Click);
            // 
            // comboBoxWorlds
            // 
            this.comboBoxWorlds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorlds.FormattingEnabled = true;
            this.comboBoxWorlds.Location = new System.Drawing.Point(10, 30);
            this.comboBoxWorlds.Name = "comboBoxWorlds";
            this.comboBoxWorlds.Size = new System.Drawing.Size(410, 23);
            this.comboBoxWorlds.TabIndex = 0;
            this.comboBoxWorlds.SelectedIndexChanged += new System.EventHandler(this.comboBoxWorlds_SelectedIndexChanged);
            // 
            // groupBoxPlay
            // 
            this.groupBoxPlay.Controls.Add(this.buttonStop);
            this.groupBoxPlay.Controls.Add(this.buttonPlay);
            this.groupBoxPlay.Location = new System.Drawing.Point(20, 420);
            this.groupBoxPlay.Name = "groupBoxPlay";
            this.groupBoxPlay.Size = new System.Drawing.Size(220, 80);
            this.groupBoxPlay.TabIndex = 5;
            this.groupBoxPlay.TabStop = false;
            this.groupBoxPlay.Text = "4. Play the game";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(120, 30);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click_1);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(20, 30);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // groupBoxAccounts
            // 
            this.groupBoxAccounts.Controls.Add(this.buttonManageAccounts);
            this.groupBoxAccounts.Location = new System.Drawing.Point(70, 20);
            this.groupBoxAccounts.Name = "groupBoxAccounts";
            this.groupBoxAccounts.Size = new System.Drawing.Size(120, 70);
            this.groupBoxAccounts.TabIndex = 6;
            this.groupBoxAccounts.TabStop = false;
            this.groupBoxAccounts.Text = "Accounts";
            // 
            // buttonManageAccounts
            // 
            this.buttonManageAccounts.Location = new System.Drawing.Point(20, 30);
            this.buttonManageAccounts.Name = "buttonManageAccounts";
            this.buttonManageAccounts.Size = new System.Drawing.Size(75, 25);
            this.buttonManageAccounts.TabIndex = 0;
            this.buttonManageAccounts.Text = "Manage";
            this.buttonManageAccounts.UseVisualStyleBackColor = true;
            this.buttonManageAccounts.Click += new System.EventHandler(this.buttonManageAccounts_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.buttonAbout);
            this.groupBoxInfo.Location = new System.Drawing.Point(360, 20);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(120, 70);
            this.groupBoxInfo.TabIndex = 7;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(20, 30);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(75, 25);
            this.buttonAbout.TabIndex = 0;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // groupBoxWorldVersions
            // 
            this.groupBoxWorldVersions.Controls.Add(this.buttonWorldVersions);
            this.groupBoxWorldVersions.Location = new System.Drawing.Point(210, 20);
            this.groupBoxWorldVersions.Name = "groupBoxWorldVersions";
            this.groupBoxWorldVersions.Size = new System.Drawing.Size(120, 70);
            this.groupBoxWorldVersions.TabIndex = 4;
            this.groupBoxWorldVersions.TabStop = false;
            this.groupBoxWorldVersions.Text = "World versions";
            // 
            // buttonWorldVersions
            // 
            this.buttonWorldVersions.Location = new System.Drawing.Point(20, 30);
            this.buttonWorldVersions.Name = "buttonWorldVersions";
            this.buttonWorldVersions.Size = new System.Drawing.Size(75, 25);
            this.buttonWorldVersions.TabIndex = 1;
            this.buttonWorldVersions.Text = "View";
            this.buttonWorldVersions.UseVisualStyleBackColor = true;
            this.buttonWorldVersions.Click += new System.EventHandler(this.buttonWorldVersions_Click);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.textBox1);
            this.groupBoxLog.Location = new System.Drawing.Point(590, 10);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(580, 570);
            this.groupBoxLog.TabIndex = 8;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(10, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(560, 540);
            this.textBox1.TabIndex = 0;
            // 
            // groupBoxServerStatus
            // 
            this.groupBoxServerStatus.Controls.Add(this.labelKekWorldServerStatus);
            this.groupBoxServerStatus.Controls.Add(this.labelWowWorldServerStatus);
            this.groupBoxServerStatus.Controls.Add(this.labelWowMetaServerStatus);
            this.groupBoxServerStatus.Controls.Add(this.labelKekWorldServer);
            this.groupBoxServerStatus.Controls.Add(this.labelWowWorldServer);
            this.groupBoxServerStatus.Controls.Add(this.labelWowMetaServer);
            this.groupBoxServerStatus.Location = new System.Drawing.Point(330, 420);
            this.groupBoxServerStatus.Name = "groupBoxServerStatus";
            this.groupBoxServerStatus.Size = new System.Drawing.Size(220, 160);
            this.groupBoxServerStatus.TabIndex = 9;
            this.groupBoxServerStatus.TabStop = false;
            this.groupBoxServerStatus.Text = "Server status";
            // 
            // labelKekWorldServerStatus
            // 
            this.labelKekWorldServerStatus.AutoSize = true;
            this.labelKekWorldServerStatus.ForeColor = System.Drawing.Color.Red;
            this.labelKekWorldServerStatus.Location = new System.Drawing.Point(120, 110);
            this.labelKekWorldServerStatus.Name = "labelKekWorldServerStatus";
            this.labelKekWorldServerStatus.Size = new System.Drawing.Size(51, 15);
            this.labelKekWorldServerStatus.TabIndex = 5;
            this.labelKekWorldServerStatus.Text = "Stopped";
            // 
            // labelWowWorldServerStatus
            // 
            this.labelWowWorldServerStatus.AutoSize = true;
            this.labelWowWorldServerStatus.ForeColor = System.Drawing.Color.Red;
            this.labelWowWorldServerStatus.Location = new System.Drawing.Point(120, 70);
            this.labelWowWorldServerStatus.Name = "labelWowWorldServerStatus";
            this.labelWowWorldServerStatus.Size = new System.Drawing.Size(51, 15);
            this.labelWowWorldServerStatus.TabIndex = 4;
            this.labelWowWorldServerStatus.Text = "Stopped";
            // 
            // labelWowMetaServerStatus
            // 
            this.labelWowMetaServerStatus.AutoSize = true;
            this.labelWowMetaServerStatus.ForeColor = System.Drawing.Color.Red;
            this.labelWowMetaServerStatus.Location = new System.Drawing.Point(120, 30);
            this.labelWowMetaServerStatus.Name = "labelWowMetaServerStatus";
            this.labelWowMetaServerStatus.Size = new System.Drawing.Size(51, 15);
            this.labelWowMetaServerStatus.TabIndex = 3;
            this.labelWowMetaServerStatus.Text = "Stopped";
            // 
            // labelKekWorldServer
            // 
            this.labelKekWorldServer.AutoSize = true;
            this.labelKekWorldServer.Location = new System.Drawing.Point(20, 110);
            this.labelKekWorldServer.Name = "labelKekWorldServer";
            this.labelKekWorldServer.Size = new System.Drawing.Size(62, 15);
            this.labelKekWorldServer.TabIndex = 2;
            this.labelKekWorldServer.Text = "KeK World";
            // 
            // labelWowWorldServer
            // 
            this.labelWowWorldServer.AutoSize = true;
            this.labelWowWorldServer.Location = new System.Drawing.Point(20, 70);
            this.labelWowWorldServer.Name = "labelWowWorldServer";
            this.labelWowWorldServer.Size = new System.Drawing.Size(71, 15);
            this.labelWowWorldServer.TabIndex = 1;
            this.labelWowWorldServer.Text = "WoW World";
            // 
            // labelWowMetaServer
            // 
            this.labelWowMetaServer.AutoSize = true;
            this.labelWowMetaServer.Location = new System.Drawing.Point(20, 30);
            this.labelWowMetaServer.Name = "labelWowMetaServer";
            this.labelWowMetaServer.Size = new System.Drawing.Size(66, 15);
            this.labelWowMetaServer.TabIndex = 0;
            this.labelWowMetaServer.Text = "WoW Meta";
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.groupBoxServerStatus);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxWorldVersions);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.groupBoxAccounts);
            this.Controls.Add(this.groupBoxPlay);
            this.Controls.Add(this.groupBoxWorlds);
            this.Controls.Add(this.groupBoxRulesets);
            this.Controls.Add(this.groupBoxClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormLauncher";
            this.Text = "KeK Launcher";
            this.groupBoxClients.ResumeLayout(false);
            this.groupBoxRulesets.ResumeLayout(false);
            this.groupBoxWorlds.ResumeLayout(false);
            this.groupBoxPlay.ResumeLayout(false);
            this.groupBoxAccounts.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxWorldVersions.ResumeLayout(false);
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.groupBoxServerStatus.ResumeLayout(false);
            this.groupBoxServerStatus.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private GroupBox groupBoxClients;
    private ComboBox comboBoxClients;
    private Button buttonManageClients;
    private GroupBox groupBoxRulesets;
    private Button buttonManageRulesets;
    private ComboBox comboBoxRulesets;
    private GroupBox groupBoxWorlds;
    private Button buttonManageWorlds;
    private ComboBox comboBoxWorlds;
    private GroupBox groupBoxPlay;
    private Button buttonStop;
    private Button buttonPlay;
    private GroupBox groupBoxAccounts;
    private Button buttonManageAccounts;
    private GroupBox groupBoxInfo;
    private Button buttonAbout;
    private GroupBox groupBoxWorldVersions;
    private Button buttonWorldVersions;
    private GroupBox groupBoxLog;
    private TextBox textBox1;
    private GroupBox groupBoxServerStatus;
    private Label labelKekWorldServer;
    private Label labelWowWorldServer;
    private Label labelWowMetaServer;
    private Label labelKekWorldServerStatus;
    private Label labelWowWorldServerStatus;
    private Label labelWowMetaServerStatus;
}
