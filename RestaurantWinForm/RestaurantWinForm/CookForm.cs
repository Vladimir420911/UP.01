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
    public partial class CookForm: Form
    {
        private OrderManager manager;
        private Order selectedOrder;

        public CookForm()
        {
            InitializeComponent();

            manager = new OrderManager();
            LoadOrders();

            // Подписываемся на события
            OrdersTable.SelectionChanged += OrdersTable_SelectionChanged;
        }

        private void OrdersTable_SelectionChanged(object sender, EventArgs e)
        {
            if (OrdersTable.SelectedRows.Count > 0)
            {
                var selectedRow = OrdersTable.SelectedRows[0];
                selectedOrder = selectedRow.DataBoundItem as Order;

                if (selectedOrder != null)
                {
                    DisplayOrderItems(selectedOrder);
                    UpdateButtonsState();
                }
            }
            else
            {
                selectedOrder = null;
                ClearOrderItems();
                UpdateButtonsState();
            }
        }

        private void StartCookingButton_Click(object sender, EventArgs e)
        {
            if (selectedOrder != null && selectedOrder.Status == OrderStatus.Accepted)
            {
                try
                {
                    var result = manager.UpdateOrderStatus(selectedOrder.OrderId, OrderStatus.Cooking);
                    if (result == "Статус изменен")
                    {
                        MessageBox.Show($"Заказ #{selectedOrder.OrderId} начал готовиться", "Статус изменен",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders(); // Обновляем список
                    }
                    else
                    {
                        MessageBox.Show(result, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка изменения статуса: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            if (selectedOrder != null && selectedOrder.Status == OrderStatus.Cooking)
            {
                try
                {
                    var result = manager.UpdateOrderStatus(selectedOrder.OrderId, OrderStatus.Ready);
                    if (result == "Статус изменен")
                    {
                        MessageBox.Show($"Заказ #{selectedOrder.OrderId} готов к выдаче!", "Заказ готов",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders(); // Обновляем список (заказ уйдет из таблицы)
                    }
                    else
                    {
                        MessageBox.Show(result, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка изменения статуса: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void LoadOrders()
        {
            try
            {
                // Загружаем только заказы со статусом Accepted и Cooking
                var orders = manager.GetOrders()
                    .Where(o => o.Status == OrderStatus.Accepted || o.Status == OrderStatus.Cooking)
                    .ToList();

                OrdersTable.DataSource = orders;
                OrdersTable.AutoGenerateColumns = true;

                // Настраиваем столбцы
                if (OrdersTable.Columns.Count > 0)
                {
                    OrdersTable.Columns["OrderId"].HeaderText = "№ Заказа";
                    OrdersTable.Columns["SeatId"].HeaderText = "Место";
                    OrdersTable.Columns["TotalPrice"].HeaderText = "Сумма";
                    OrdersTable.Columns["Status"].HeaderText = "Статус";

                    // Скрываем сложные колонки
                    if (OrdersTable.Columns["Items"] != null)
                        OrdersTable.Columns["Items"].Visible = false;
                }

                UpdateButtonsState();
                ClearOrderItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrderItems(Order order)
        {
            OrderItemsList.Items.Clear();

            if (order.Items != null && order.Items.Count > 0)
            {
                OrderItemsList.Items.Add($"=== Заказ #{order.OrderId} ===");
                OrderItemsList.Items.Add($"Место: {order.SeatId}");
                OrderItemsList.Items.Add($"Статус: {GetStatusText(order.Status)}");
                OrderItemsList.Items.Add("----------------------------");
                OrderItemsList.Items.Add("Блюда для приготовления:");
                OrderItemsList.Items.Add("");

                foreach (var item in order.Items)
                {
                    var orderItem = item.Key;
                    var quantity = item.Value;
                    OrderItemsList.Items.Add($"{orderItem.Name}");
                    OrderItemsList.Items.Add($"  Количество: {quantity} шт.");
                    OrderItemsList.Items.Add($"  Цена: {orderItem.Price} руб.");
                    OrderItemsList.Items.Add("");
                }

                OrderItemsList.Items.Add("----------------------------");
                OrderItemsList.Items.Add($"ИТОГО: {order.TotalPrice} руб.");
            }
            else
            {
                OrderItemsList.Items.Add("Нет блюд для приготовления");
            }
        }

        private void ClearOrderItems()
        {
            OrderItemsList.Items.Clear();
            OrderItemsList.Items.Add("Выберите заказ для просмотра деталей");
        }

        private void UpdateButtonsState()
        {
            if (selectedOrder != null)
            {
                StartCookingButton.Enabled = (selectedOrder.Status == OrderStatus.Accepted);
                ReadyButton.Enabled = (selectedOrder.Status == OrderStatus.Cooking);

                // Обновляем текст кнопок для ясности
                StartCookingButton.Text = selectedOrder.Status == OrderStatus.Accepted ?
                    "Начать готовку" : "Готовится...";
                ReadyButton.Text = "Готово";
            }
            else
            {
                StartCookingButton.Enabled = false;
                ReadyButton.Enabled = false;
                StartCookingButton.Text = "Начать готовку";
                ReadyButton.Text = "Готово";
            }
        }

        private string GetStatusText(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Accepted: return "Принят";
                case OrderStatus.Cooking: return "Готовится";
                case OrderStatus.Ready: return "Готов";
                default: return status.ToString();
            }
        }
    }
}
