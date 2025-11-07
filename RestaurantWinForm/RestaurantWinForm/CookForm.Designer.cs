namespace RestaurantWinForm
{
    partial class CookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CookForm));
            this.OrderTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BeginCookingButton = new System.Windows.Forms.ToolStripButton();
            this.OrderReadyButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.OrderTable)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderTable
            // 
            this.OrderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderTable.Location = new System.Drawing.Point(12, 26);
            this.OrderTable.Name = "OrderTable";
            this.OrderTable.Size = new System.Drawing.Size(776, 225);
            this.OrderTable.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BeginCookingButton,
            this.OrderReadyButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BeginCookingButton
            // 
            this.BeginCookingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BeginCookingButton.Image = ((System.Drawing.Image)(resources.GetObject("BeginCookingButton.Image")));
            this.BeginCookingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BeginCookingButton.Name = "BeginCookingButton";
            this.BeginCookingButton.Size = new System.Drawing.Size(23, 22);
            this.BeginCookingButton.Text = "toolStripButton1";
            this.BeginCookingButton.Click += new System.EventHandler(this.BeginCookingButton_Click);
            // 
            // OrderReadyButton
            // 
            this.OrderReadyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OrderReadyButton.Image = ((System.Drawing.Image)(resources.GetObject("OrderReadyButton.Image")));
            this.OrderReadyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OrderReadyButton.Name = "OrderReadyButton";
            this.OrderReadyButton.Size = new System.Drawing.Size(23, 22);
            this.OrderReadyButton.Text = "toolStripButton2";
            this.OrderReadyButton.Click += new System.EventHandler(this.OrderReadyButton_Click);
            // 
            // CookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.OrderTable);
            this.Name = "CookForm";
            this.Text = "CookForm";
            ((System.ComponentModel.ISupportInitialize)(this.OrderTable)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrderTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BeginCookingButton;
        private System.Windows.Forms.ToolStripButton OrderReadyButton;
    }
}