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
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"=== ЧЕК ===");
                    sb.AppendLine($"Заказ #{selectedOrder.OrderId}");
                    sb.AppendLine($"Место: {selectedOrder.SeatId}");
                    sb.AppendLine($"Статус: {selectedOrder.Status}");
                    sb.AppendLine("----------------------------");
                    sb.AppendLine("Позиции:");

                    if (selectedOrder.Items != null && selectedOrder.Items.Count > 0)
                    {
                        foreach (var item in selectedOrder.Items)
                        {
                            var orderItem = item.Key;
                            var quantity = item.Value;
                            sb.AppendLine($"  - {orderItem.Name} x{quantity}");
                            sb.AppendLine($"    {orderItem.Price} руб. × {quantity} = {orderItem.Price * quantity} руб.");
                        }
                    }
                    else
                    {
                        sb.AppendLine("  Нет позиций");
                    }

                    sb.AppendLine("----------------------------");
                    sb.AppendLine($"ИТОГО: {selectedOrder.TotalPrice} руб.");
                    sb.AppendLine("====================");

                    richTextBox1.Text = sb.ToString();
                }
                else
                {
                    richTextBox1.Text = "Заказ не выбран";
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

        private void WaiterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
