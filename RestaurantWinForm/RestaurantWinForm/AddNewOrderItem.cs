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
    public partial class AddNewOrderItem : Form
    {
        private OrderManager _orderManager;
        public AddNewOrderItem()
        {
            InitializeComponent();
            _orderManager = new OrderManager();
            UpdateMenuGrid(); // Обновляем список блюд при загрузке
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Получаем данные из полей ввода
            string name = txtName.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string description = txtDescription.Text.Trim();

            try
            {
                // Валидация цены (проверяем, что это число)
                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Цена должна быть числом!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ВСЮ ОСТАЛЬНУЮ ВАЛИДАЦИЮ ДЕЛАЕТ САМ МЕТОД AddNewOrderItem!
                _orderManager.AddNewOrderItem(name, price, description);

                // Успешное сообщение в отдельном окне
                MessageBox.Show("Блюдо успешно добавлено в меню!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем поля и обновляем список
                ClearForm();
                UpdateMenuGrid();
            }
            catch (Exception ex)
            {
                // Ловим любую ошибку из метода AddNewOrderItem
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }

        private void UpdateMenuGrid()
        {
            var menu = _orderManager.GetMenu();
            dgvMenu.DataSource = menu;
            dgvMenu.AutoGenerateColumns = true;
        }

        // Валидация цены (только цифры и точка)
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
    
}
