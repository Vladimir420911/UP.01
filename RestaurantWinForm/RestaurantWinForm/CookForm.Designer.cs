namespace RestaurantWinForm
{
    partial class CookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CookForm));
            this.OrdersTable = new System.Windows.Forms.DataGridView();
            this.OrderItemsList = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StartCookingButton = new System.Windows.Forms.ToolStripButton();
            this.ReadyButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrdersTable
            // 
            this.OrdersTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrdersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersTable.Location = new System.Drawing.Point(12, 36);
            this.OrdersTable.Name = "OrdersTable";
            this.OrdersTable.Size = new System.Drawing.Size(548, 383);
            this.OrdersTable.TabIndex = 0;
            // 
            // OrderItemsList
            // 
            this.OrderItemsList.FormattingEnabled = true;
            this.OrderItemsList.Location = new System.Drawing.Point(577, 39);
            this.OrderItemsList.Name = "OrderItemsList";
            this.OrderItemsList.Size = new System.Drawing.Size(211, 381);
            this.OrderItemsList.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartCookingButton,
            this.ReadyButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StartCookingButton
            // 
            this.StartCookingButton.AutoSize = false;
            this.StartCookingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartCookingButton.Image = ((System.Drawing.Image)(resources.GetObject("StartCookingButton.Image")));
            this.StartCookingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartCookingButton.Name = "StartCookingButton";
            this.StartCookingButton.Size = new System.Drawing.Size(32, 32);
            this.StartCookingButton.Text = "Начать готовку";
            this.StartCookingButton.Click += new System.EventHandler(this.StartCookingButton_Click);
            // 
            // ReadyButton
            // 
            this.ReadyButton.AutoSize = false;
            this.ReadyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReadyButton.Image = ((System.Drawing.Image)(resources.GetObject("ReadyButton.Image")));
            this.ReadyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(32, 32);
            this.ReadyButton.Text = "Готово";
            this.ReadyButton.Click += new System.EventHandler(this.ReadyButton_Click);
            // 
            // CookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.OrderItemsList);
            this.Controls.Add(this.OrdersTable);
            this.Name = "CookForm";
            this.Text = "Интерфейс повара";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CookForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrdersTable;
        private System.Windows.Forms.ListBox OrderItemsList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton StartCookingButton;
        private System.Windows.Forms.ToolStripButton ReadyButton;
    }
}

