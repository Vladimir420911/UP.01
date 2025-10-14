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
            this.SeatComboBox = new System.Windows.Forms.ComboBox();
            this.SeatLabel = new System.Windows.Forms.Label();
            this.OrderItemListBox = new System.Windows.Forms.ListBox();
            this.OrderItemLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SeatComboBox
            // 
            this.SeatComboBox.FormattingEnabled = true;
            this.SeatComboBox.Location = new System.Drawing.Point(12, 31);
            this.SeatComboBox.Name = "SeatComboBox";
            this.SeatComboBox.Size = new System.Drawing.Size(121, 21);
            this.SeatComboBox.TabIndex = 0;
            // 
            // SeatLabel
            // 
            this.SeatLabel.AutoSize = true;
            this.SeatLabel.Location = new System.Drawing.Point(9, 15);
            this.SeatLabel.Name = "SeatLabel";
            this.SeatLabel.Size = new System.Drawing.Size(43, 13);
            this.SeatLabel.TabIndex = 1;
            this.SeatLabel.Text = "Столик";
            // 
            // OrderItemListBox
            // 
            this.OrderItemListBox.FormattingEnabled = true;
            this.OrderItemListBox.Location = new System.Drawing.Point(13, 88);
            this.OrderItemListBox.Name = "OrderItemListBox";
            this.OrderItemListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.OrderItemListBox.Size = new System.Drawing.Size(120, 95);
            this.OrderItemListBox.TabIndex = 2;
            // 
            // OrderItemLabel
            // 
            this.OrderItemLabel.AutoSize = true;
            this.OrderItemLabel.Location = new System.Drawing.Point(13, 69);
            this.OrderItemLabel.Name = "OrderItemLabel";
            this.OrderItemLabel.Size = new System.Drawing.Size(40, 13);
            this.OrderItemLabel.TabIndex = 3;
            this.OrderItemLabel.Text = "Блюда";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 207);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(121, 40);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 267);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(121, 41);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 340);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.OrderItemLabel);
            this.Controls.Add(this.OrderItemListBox);
            this.Controls.Add(this.SeatLabel);
            this.Controls.Add(this.SeatComboBox);
            this.Name = "AddOrderForm";
            this.Text = "AddOrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SeatComboBox;
        private System.Windows.Forms.Label SeatLabel;
        private System.Windows.Forms.ListBox OrderItemListBox;
        private System.Windows.Forms.Label OrderItemLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
    }
}