namespace SPTQL
{
    partial class ConfigEditor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadJson;
        private System.Windows.Forms.Button btnSaveJson;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigEditor));
            this.btnLoadJson = new System.Windows.Forms.Button();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Simple = new System.Windows.Forms.TabPage();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.RawDataForm = new System.Windows.Forms.TabPage();
            this.textBoxRawData = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Simple.SuspendLayout();
            this.RawDataForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadJson
            // 
            this.btnLoadJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLoadJson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadJson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadJson.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnLoadJson.Location = new System.Drawing.Point(7, 5);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(75, 23);
            this.btnLoadJson.TabIndex = 0;
            this.btnLoadJson.Tag = "";
            this.btnLoadJson.Text = "Load JSON";
            this.toolTip1.SetToolTip(this.btnLoadJson, "Loads json and jsonc files.");
            this.btnLoadJson.UseVisualStyleBackColor = false;
            this.btnLoadJson.Click += new System.EventHandler(this.BtnLoadJson_Click);
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnSaveJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveJson.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveJson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveJson.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSaveJson.Location = new System.Drawing.Point(88, 5);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(75, 23);
            this.btnSaveJson.TabIndex = 1;
            this.btnSaveJson.Text = "Save JSON";
            this.toolTip1.SetToolTip(this.btnSaveJson, "Be sure all data is correct before saving.");
            this.btnSaveJson.UseVisualStyleBackColor = false;
            this.btnSaveJson.Click += new System.EventHandler(this.BtnSaveJson_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.btnSaveJson);
            this.panel1.Controls.Add(this.btnLoadJson);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 37);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(169, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Green;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.LinkColor = System.Drawing.Color.Yellow;
            this.linkLabel1.Location = new System.Drawing.Point(442, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(86, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "By: TeejayMerks";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.Simple);
            this.tabControl1.Controls.Add(this.RawDataForm);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(542, 432);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tabControl1, "Simple UI for editing values.");
            // 
            // Simple
            // 
            this.Simple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Simple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Simple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Simple.Controls.Add(this.panelContainer);
            this.Simple.Location = new System.Drawing.Point(4, 25);
            this.Simple.Name = "Simple";
            this.Simple.Padding = new System.Windows.Forms.Padding(3);
            this.Simple.Size = new System.Drawing.Size(534, 403);
            this.Simple.TabIndex = 0;
            this.Simple.Text = "Simple UI";
            this.Simple.UseVisualStyleBackColor = true;
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panelContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.ForeColor = System.Drawing.Color.White;
            this.panelContainer.Location = new System.Drawing.Point(3, 3);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(526, 395);
            this.panelContainer.TabIndex = 2;
            // 
            // RawDataForm
            // 
            this.RawDataForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.RawDataForm.Controls.Add(this.textBoxRawData);
            this.RawDataForm.Location = new System.Drawing.Point(4, 25);
            this.RawDataForm.Name = "RawDataForm";
            this.RawDataForm.Padding = new System.Windows.Forms.Padding(3);
            this.RawDataForm.Size = new System.Drawing.Size(534, 403);
            this.RawDataForm.TabIndex = 1;
            this.RawDataForm.Text = "Code";
            this.RawDataForm.UseVisualStyleBackColor = true;
            // 
            // textBoxRawData
            // 
            this.textBoxRawData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.textBoxRawData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRawData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRawData.ForeColor = System.Drawing.Color.White;
            this.textBoxRawData.Location = new System.Drawing.Point(3, 3);
            this.textBoxRawData.Multiline = true;
            this.textBoxRawData.Name = "textBoxRawData";
            this.textBoxRawData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRawData.Size = new System.Drawing.Size(528, 397);
            this.textBoxRawData.TabIndex = 0;
            // 
            // ConfigEditor
            // 
            this.AllowDrop = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(542, 469);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config Editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Simple.ResumeLayout(false);
            this.RawDataForm.ResumeLayout(false);
            this.RawDataForm.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Simple;
        private System.Windows.Forms.TabPage RawDataForm;
        private System.Windows.Forms.TextBox textBoxRawData;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
    }
}