namespace modbusSQL
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.命令設置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.圖表設置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.檢視ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.幫助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.comport = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.combaudrate = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.command = new System.Windows.Forms.ToolStripTextBox();
            this.歷史紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.設置ToolStripMenuItem,
            this.檢視ToolStripMenuItem,
            this.幫助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1282, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // 設置ToolStripMenuItem
            // 
            this.設置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.命令設置ToolStripMenuItem,
            this.圖表設置ToolStripMenuItem,
            this.歷史紀錄ToolStripMenuItem});
            this.設置ToolStripMenuItem.Name = "設置ToolStripMenuItem";
            this.設置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.設置ToolStripMenuItem.Text = "設置";
            // 
            // 命令設置ToolStripMenuItem
            // 
            this.命令設置ToolStripMenuItem.Name = "命令設置ToolStripMenuItem";
            this.命令設置ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.命令設置ToolStripMenuItem.Text = "命令設置";
            this.命令設置ToolStripMenuItem.Click += new System.EventHandler(this.命令設置ToolStripMenuItem_Click);
            // 
            // 圖表設置ToolStripMenuItem
            // 
            this.圖表設置ToolStripMenuItem.Name = "圖表設置ToolStripMenuItem";
            this.圖表設置ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.圖表設置ToolStripMenuItem.Text = "圖表設置";
            this.圖表設置ToolStripMenuItem.Click += new System.EventHandler(this.圖表設置ToolStripMenuItem_Click);
            // 
            // 檢視ToolStripMenuItem
            // 
            this.檢視ToolStripMenuItem.Name = "檢視ToolStripMenuItem";
            this.檢視ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.檢視ToolStripMenuItem.Text = "檢視";
            // 
            // 幫助ToolStripMenuItem
            // 
            this.幫助ToolStripMenuItem.Name = "幫助ToolStripMenuItem";
            this.幫助ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.幫助ToolStripMenuItem.Text = "幫助";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.comport,
            this.toolStripLabel1,
            this.combaudrate,
            this.toolStripButton3,
            this.toolStripButton4,
            this.command});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1282, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(54, 24);
            this.toolStripButton1.Text = "序列埠";
            // 
            // comport
            // 
            this.comport.Name = "comport";
            this.comport.Size = new System.Drawing.Size(121, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 24);
            this.toolStripLabel1.Text = "鮑率";
            // 
            // combaudrate
            // 
            this.combaudrate.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.combaudrate.Name = "combaudrate";
            this.combaudrate.Size = new System.Drawing.Size(121, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // command
            // 
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(150, 27);
            // 
            // 歷史紀錄ToolStripMenuItem
            // 
            this.歷史紀錄ToolStripMenuItem.Name = "歷史紀錄ToolStripMenuItem";
            this.歷史紀錄ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.歷史紀錄ToolStripMenuItem.Text = "歷史紀錄";
            this.歷史紀錄ToolStripMenuItem.Click += new System.EventHandler(this.歷史紀錄ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 命令設置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 圖表設置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 檢視ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 幫助ToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox comport;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox combaudrate;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripTextBox command;
        private System.Windows.Forms.ToolStripMenuItem 歷史紀錄ToolStripMenuItem;
    }
}

