namespace RestaurantWinForm
{
    partial class AdminForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.управлениеПерсоналомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUserMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.StaffListBox = new System.Windows.Forms.ListBox();
            this.LogoutMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.управлениеПерсоналомToolStripMenuItem,
            this.LogoutMenuButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // управлениеПерсоналомToolStripMenuItem
            // 
            this.управлениеПерсоналомToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUserMenuButton});
            this.управлениеПерсоналомToolStripMenuItem.Name = "управлениеПерсоналомToolStripMenuItem";
            this.управлениеПерсоналомToolStripMenuItem.Size = new System.Drawing.Size(157, 20);
            this.управлениеПерсоналомToolStripMenuItem.Text = "Управление персоналом";
            // 
            // AddUserMenuButton
            // 
            this.AddUserMenuButton.Name = "AddUserMenuButton";
            this.AddUserMenuButton.Size = new System.Drawing.Size(192, 22);
            this.AddUserMenuButton.Text = "Добавить сотрудника";
            this.AddUserMenuButton.Click += new System.EventHandler(this.AddUserMenuButton_Click);
            // 
            // StaffListBox
            // 
            this.StaffListBox.FormattingEnabled = true;
            this.StaffListBox.Location = new System.Drawing.Point(12, 36);
            this.StaffListBox.Name = "StaffListBox";
            this.StaffListBox.Size = new System.Drawing.Size(158, 394);
            this.StaffListBox.TabIndex = 1;
            // 
            // LogoutMenuButton
            // 
            this.LogoutMenuButton.Name = "LogoutMenuButton";
            this.LogoutMenuButton.Size = new System.Drawing.Size(54, 20);
            this.LogoutMenuButton.Text = "Выйти";
            this.LogoutMenuButton.Click += new System.EventHandler(this.LogoutMenuButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StaffListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem управлениеПерсоналомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddUserMenuButton;
        private System.Windows.Forms.ListBox StaffListBox;
        private System.Windows.Forms.ToolStripMenuItem LogoutMenuButton;
    }
}