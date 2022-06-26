namespace Aquarium.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addFishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularFishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goldfishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anglerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFishToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addFishToolStripMenuItem
            // 
            this.addFishToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularFishToolStripMenuItem,
            this.goldfishToolStripMenuItem,
            this.anglerToolStripMenuItem});
            this.addFishToolStripMenuItem.Name = "addFishToolStripMenuItem";
            this.addFishToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addFishToolStripMenuItem.Text = "Add";
            // 
            // regularFishToolStripMenuItem
            // 
            this.regularFishToolStripMenuItem.Name = "regularFishToolStripMenuItem";
            this.regularFishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.regularFishToolStripMenuItem.Text = "Fish";
            this.regularFishToolStripMenuItem.Click += new System.EventHandler(this.regularFishToolStripMenuItem_Click);
            // 
            // goldfishToolStripMenuItem
            // 
            this.goldfishToolStripMenuItem.Name = "goldfishToolStripMenuItem";
            this.goldfishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.goldfishToolStripMenuItem.Text = "Goldfish";
            this.goldfishToolStripMenuItem.Click += new System.EventHandler(this.goldfishToolStripMenuItem_Click);
            // 
            // anglerToolStripMenuItem
            // 
            this.anglerToolStripMenuItem.Name = "anglerToolStripMenuItem";
            this.anglerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.anglerToolStripMenuItem.Text = "Angler";
            this.anglerToolStripMenuItem.Click += new System.EventHandler(this.anglerToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Aquarium.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Aquarium";
            this.ClientSizeChanged += new System.EventHandler(this.MainForm_ClientSizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularFishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goldfishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anglerToolStripMenuItem;
    }
}

