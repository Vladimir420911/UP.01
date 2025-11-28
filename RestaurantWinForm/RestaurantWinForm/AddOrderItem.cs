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
    public partial class AddOrderItem : Form
    {
        private OrderManager _orderManager;
        public AddOrderItem()
        {
            InitializeComponent();
            _orderManager = new OrderManager();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Получаем данные из полей ввода
            string name = txtName.Text.Trim();
            decimal price = PriceNumericUpDown.Value;
            string description = txtDescription.Text.Trim();

            try
            {
                _orderManager.AddNewOrderItem(name, price, description);

                // Успешное сообщение в отдельном окне
                MessageBox.Show("Блюдо успешно добавлено в меню!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // Ловим ЛЮБУЮ ошибку из метода AddNewOrderItem
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
