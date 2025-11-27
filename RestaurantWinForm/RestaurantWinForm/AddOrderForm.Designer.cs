namespace RestaurantWinForm
{
    partial class AddOrderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SeatsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.MenuListBox = new System.Windows.Forms.ListBox();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.SelectedItemsListBox = new System.Windows.Forms.ListBox();
            this.RemoveAllButton = new System.Windows.Forms.Button();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "столик";
            // 
            // SeatsComboBox
            // 
            this.SeatsComboBox.FormattingEnabled = true;
            this.SeatsComboBox.Location = new System.Drawing.Point(376, 274);
            this.SeatsComboBox.Name = "SeatsComboBox";
            this.SeatsComboBox.Size = new System.Drawing.Size(145, 21);
            this.SeatsComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "блюда";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(545, 274);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(187, 51);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Создать заказ";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // MenuListBox
            // 
            this.MenuListBox.FormattingEnabled = true;
            this.MenuListBox.Location = new System.Drawing.Point(12, 26);
            this.MenuListBox.Name = "MenuListBox";
            this.MenuListBox.Size = new System.Drawing.Size(311, 212);
            this.MenuListBox.TabIndex = 5;
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(12, 258);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(91, 51);
            this.AddItemButton.TabIndex = 6;
            this.AddItemButton.Text = "Выбрать";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Location = new System.Drawing.Point(109, 258);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Size = new System.Drawing.Size(93, 51);
            this.RemoveItemButton.TabIndex = 7;
            this.RemoveItemButton.Text = "Убрать";
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // SelectedItemsListBox
            // 
            this.SelectedItemsListBox.FormattingEnabled = true;
            this.SelectedItemsListBox.Location = new System.Drawing.Point(376, 25);
            this.SelectedItemsListBox.Name = "SelectedItemsListBox";
            this.SelectedItemsListBox.Size = new System.Drawing.Size(356, 212);
            this.SelectedItemsListBox.TabIndex = 8;
            this.SelectedItemsListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.SelectedItemsListBox_Format);
            // 
            // RemoveAllButton
            // 
            this.RemoveAllButton.Location = new System.Drawing.Point(209, 258);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Size = new System.Drawing.Size(114, 51);
            this.RemoveAllButton.TabIndex = 9;
            this.RemoveAllButton.Text = "Убрать все";
            this.RemoveAllButton.UseVisualStyleBackColor = true;
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(373, 308);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(0, 13);
            this.TotalLabel.TabIndex = 10;
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 352);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.RemoveAllButton);
            this.Controls.Add(this.SelectedItemsListBox);
            this.Controls.Add(this.RemoveItemButton);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.MenuListBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SeatsComboBox);
            this.Controls.Add(this.label1);
            this.Name = "AddOrderForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SeatsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox MenuListBox;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.Button RemoveItemButton;
        private System.Windows.Forms.ListBox SelectedItemsListBox;
        private System.Windows.Forms.Button RemoveAllButton;
        private System.Windows.Forms.Label TotalLabel;
    }
}