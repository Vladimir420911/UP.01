using ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantWinForm
{
    public partial class EditOrderItemForm : Form
    {
        OrderManager orderManager_;
        private OrderItem editItem;
        public EditOrderItemForm(OrderManager orderManager, int id)
        {
            InitializeComponent();
            orderManager_ = orderManager;
            editItem = orderManager_.GetItemById(id);

            NameTextBox.Text = editItem.Name;
            PriceNumericUpDown.Value = editItem.Price;
            DescriptionTextBox.Text = editItem.Description;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newName = NameTextBox.Text;
            decimal newPrice = PriceNumericUpDown.Value;
            string newDescription = DescriptionTextBox.Text;

            OrderItem item = orderManager_.EditOrderItem(editItem, newName, newPrice, newDescription);

            if(item != null)
            {
                orderManager_.AddOrderItemToMenu(item);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
