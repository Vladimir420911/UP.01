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
            this.OrderItemLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.OrderItemListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SeatComboBox
            // 
            this.SeatComboBox.FormattingEnabled = true;
            this.SeatComboBox.Location = new System.Drawing.Point(12, 26);
            this.SeatComboBox.Name = "SeatComboBox";
            this.SeatComboBox.Size = new System.Drawing.Size(121, 21);
            this.SeatComboBox.TabIndex = 0;
            // 
            // SeatLabel
            // 
            this.SeatLabel.AutoSize = true;
            this.SeatLabel.Location = new System.Drawing.Point(9, 9);
            this.SeatLabel.Name = "SeatLabel";
            this.SeatLabel.Size = new System.Drawing.Size(43, 13);
            this.SeatLabel.TabIndex = 1;
            this.SeatLabel.Text = "Столик";
            // 
            // OrderItemLabel
            // 
            this.OrderItemLabel.AutoSize = true;
            this.OrderItemLabel.Location = new System.Drawing.Point(10, 51);
            this.OrderItemLabel.Name = "OrderItemLabel";
            this.OrderItemLabel.Size = new System.Drawing.Size(40, 13);
            this.OrderItemLabel.TabIndex = 3;
            this.OrderItemLabel.Text = "Блюда";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(13, 224);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(121, 38);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(14, 184);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(121, 20);
            this.PriceTextBox.TabIndex = 5;
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(11, 168);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(33, 13);
            this.PriceLabel.TabIndex = 6;
            this.PriceLabel.Text = "Цена";
            // 
            // OrderItemListBox
            // 
            this.OrderItemListBox.FormattingEnabled = true;
            this.OrderItemListBox.Location = new System.Drawing.Point(12, 67);
            this.OrderItemListBox.Name = "OrderItemListBox";
            this.OrderItemListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.OrderItemListBox.Size = new System.Drawing.Size(120, 95);
            this.OrderItemListBox.TabIndex = 7;
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 288);
            this.Controls.Add(this.OrderItemListBox);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.OrderItemLabel);
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
        private System.Windows.Forms.Label OrderItemLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.ListBox OrderItemListBox;
    }
}