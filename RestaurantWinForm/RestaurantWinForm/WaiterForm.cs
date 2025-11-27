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
    public partial class WaiterForm : Form
    {
        private OrderManager manager;
        public WaiterForm()
        {
            InitializeComponent();
            manager = new OrderManager();
            LoadOrders();

            OrdersTable.SelectionChanged += OrdersTable_SelectionChanged;
        }

        private void OrdersTable_SelectionChanged(object sender, EventArgs e)
        {
            if (OrdersTable.SelectedRows.Count > 0)
            {
                var selectedRow = OrdersTable.SelectedRows[0];
                var selectedOrder = selectedRow.DataBoundItem as Order;

                if (selectedOrder != null)
                {
                    userControl11.UpdateOrderInfo(selectedOrder);
                }
            }
        }

        private void LoadOrders()
        {
            try
            {
                var orders = manager.GetOrders();
                OrdersTable.DataSource = orders;
                OrdersTable.AutoGenerateColumns = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            AddOrderForm form = new AddOrderForm(manager);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadOrders(); // Обновляем список заказов после добавления
            }
        }
    }
}
