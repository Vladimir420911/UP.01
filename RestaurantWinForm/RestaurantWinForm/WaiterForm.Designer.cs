namespace RestaurantWinForm
{
    partial class WaiterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaiterForm));
            this.OrdersTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddOrderButton = new System.Windows.Forms.ToolStripButton();
            this.userControl11 = new ReceiptControl.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrdersTable
            // 
            this.OrdersTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrdersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersTable.Location = new System.Drawing.Point(12, 28);
            this.OrdersTable.Name = "OrdersTable";
            this.OrdersTable.Size = new System.Drawing.Size(538, 266);
            this.OrdersTable.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddOrderButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 35);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddOrderButton
            // 
            this.AddOrderButton.AutoSize = false;
            this.AddOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddOrderButton.Image = ((System.Drawing.Image)(resources.GetObject("AddOrderButton.Image")));
            this.AddOrderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddOrderButton.Name = "AddOrderButton";
            this.AddOrderButton.Size = new System.Drawing.Size(32, 32);
            this.AddOrderButton.Text = "Добавить заказ";
            this.AddOrderButton.Click += new System.EventHandler(this.AddOrderButton_Click);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(569, 38);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(219, 256);
            this.userControl11.TabIndex = 2;
            // 
            // WaiterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 325);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.OrdersTable);
            this.Name = "WaiterForm";
            this.Text = "Интерфейс официанта";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WaiterForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrdersTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddOrderButton;
        private ReceiptControl.UserControl1 userControl11;
    }
}