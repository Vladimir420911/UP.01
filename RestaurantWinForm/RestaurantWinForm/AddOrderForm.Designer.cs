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
            this.OrderItemDataGridView = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "столик";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SeatsComboBox
            // 
            this.SeatsComboBox.FormattingEnabled = true;
            this.SeatsComboBox.Location = new System.Drawing.Point(23, 29);
            this.SeatsComboBox.Name = "SeatsComboBox";
            this.SeatsComboBox.Size = new System.Drawing.Size(121, 21);
            this.SeatsComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "блюда";
            // 
            // OrderItemDataGridView
            // 
            this.OrderItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderItemDataGridView.Location = new System.Drawing.Point(23, 75);
            this.OrderItemDataGridView.Name = "OrderItemDataGridView";
            this.OrderItemDataGridView.Size = new System.Drawing.Size(240, 150);
            this.OrderItemDataGridView.TabIndex = 3;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(32, 249);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.OrderItemDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SeatsComboBox);
            this.Controls.Add(this.label1);
            this.Name = "AddOrderForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SeatsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView OrderItemDataGridView;
        private System.Windows.Forms.Button AddButton;
    }
}