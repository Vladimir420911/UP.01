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

            if (editItem == null)
            {
                MessageBox.Show("Блюдо не найдено", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            NameTextBox.Text = editItem.Name;
            PriceNumericUpDown.Value = editItem.Price;
            DescriptionTextBox.Text = editItem.Description;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string newName = NameTextBox.Text.Trim();
                decimal newPrice = PriceNumericUpDown.Value;
                string newDescription = DescriptionTextBox.Text.Trim();

                // Вызываем метод, который ничего не возвращает
                orderManager_.EditOrderItem(editItem, newName, newPrice, newDescription);

                MessageBox.Show("Блюдо успешно обновлено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении блюда: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
