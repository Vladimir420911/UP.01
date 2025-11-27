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
    public partial class AddOrderForm : Form
    {
        OrderManager manager_;
        private BindingList<OrderItem> menuItems;
        private Dictionary<OrderItem, int> selectedItems;
        public AddOrderForm(OrderManager manager)
        {
            InitializeComponent();
            manager_ = manager;
            selectedItems = new Dictionary<OrderItem, int>();
            InitializeForm();
        }

        private void InitializeForm()
        {
            try
            {
                // Загружаем меню
                menuItems = manager_.GetMenu();
                MenuListBox.DataSource = menuItems;
                MenuListBox.DisplayMember = "Name";

                // Заполняем комбобокс с номерами столов
                for (int i = 1; i <= 20; i++)
                {
                    SeatsComboBox.Items.Add(i);
                }
                SeatsComboBox.SelectedIndex = 0;

                UpdateSelectedItemsList();
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            if (MenuListBox.SelectedItem is OrderItem selectedItem)
            {
                // Добавляем или увеличиваем количество блюда
                if (selectedItems.ContainsKey(selectedItem))
                {
                    selectedItems[selectedItem]++;
                }
                else
                {
                    selectedItems[selectedItem] = 1;
                }

                UpdateSelectedItemsList();
                UpdateTotal();
            }
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            if (SelectedItemsListBox.SelectedItem is OrderItem selectedItem)
            {
                if (selectedItems.ContainsKey(selectedItem))
                {
                    if (selectedItems[selectedItem] > 1)
                    {
                        // Уменьшаем количество
                        selectedItems[selectedItem]--;
                    }
                    else
                    {
                        // Удаляем блюдо полностью
                        selectedItems.Remove(selectedItem);
                    }

                    UpdateSelectedItemsList();
                    UpdateTotal();
                }
            }
        }

        private void RemoveAllButton_Click(object sender, EventArgs e)
        {
            if (SelectedItemsListBox.SelectedItem is OrderItem selectedItem)
            {
                selectedItems.Remove(selectedItem);
                UpdateSelectedItemsList();
                UpdateTotal();
            }
        }

        private void UpdateSelectedItemsList()
        {
            SelectedItemsListBox.DataSource = null;
            SelectedItemsListBox.DataSource = selectedItems.Keys.ToList();
            SelectedItemsListBox.DisplayMember = "Name";

            // Обновляем отображение количества в списке
            foreach (OrderItem item in SelectedItemsListBox.Items)
            {
                // Можно добавить отображение количества, если нужно
            }
        }

        private void UpdateTotal()
        {
            decimal total = selectedItems.Sum(item => item.Key.Price * item.Value);
            TotalLabel.Text = $"Итого: {total:C}";

            // Показываем количество выбранных блюд в кнопке
            int totalItems = selectedItems.Sum(item => item.Value);
            AddButton.Text = $"Создать заказ ({totalItems} шт.)";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем выбран ли стол
                if (SeatsComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите номер стола", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем есть ли выбранные блюда
                if (selectedItems.Count == 0)
                {
                    MessageBox.Show("Добавьте хотя бы одно блюдо", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Создаем заказ напрямую с Dictionary<OrderItem, int>
                int seatId = (int)SeatsComboBox.SelectedItem;

                var order = new Order
                {
                    OrderId = 0, // Будет установлен в БД
                    SeatId = seatId,
                    Items = selectedItems,
                    TotalPrice = selectedItems.Sum(item => item.Key.Price * item.Value),
                    Status = OrderStatus.Accepted
                };

                // Сохраняем заказ в БД
                var result = manager_.AddOrder(order);
                if (result == "Заказ принят")
                {
                    MessageBox.Show("Заказ успешно создан", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Ошибка создания заказа: {result}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectedItemsListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is OrderItem item && selectedItems.ContainsKey(item))
            {
                int quantity = selectedItems[item];
                e.Value = $"{item.Name} x{quantity} - {item.Price * quantity:C}";
            }
        }
    }
}
