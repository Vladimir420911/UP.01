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
    public partial class AdminForm : Form
    {
        private AuthManager authManager_;
        private AuthForm authForm_;
        private BindingList<Staff> users_;
        private OrderManager orderManager;
        public AdminForm(AuthManager authManager, AuthForm authForm)
        {
            InitializeComponent();
            authManager_ = authManager;
            authForm_ = authForm;
            orderManager = new OrderManager();

            MenuTable.DataSource = orderManager.GetMenu();

            users_ = authManager.GetAllUsers();
            StaffListBox.DataSource = users_;
            StaffListBox.DisplayMember = "UserName";
        }

        private void AddUserMenuButton_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(authManager_);
            if(addUserForm.ShowDialog() == DialogResult.OK)
            {
                StaffListBox.DataSource = authManager_.GetAllUsers();
                MessageBox.Show("Новый пользователь добавлен");
            }
        }

        private void LogoutMenuButton_Click(object sender, EventArgs e)
        {
            authManager_.Logout();
            this.Close();
            authForm_.Show();
        }

        private void EditOrderItemButton_Click(object sender, EventArgs e)
        {
            if (MenuTable.SelectedRows.Count > 0)
            {
                var selectedRow = MenuTable.SelectedRows[0];
                var orderItem = selectedRow.DataBoundItem as OrderItem;

                if (orderItem != null)
                {
                    int itemId = orderItem.ID_; // Правильный ID из объекта
                    EditOrderItemForm form = new EditOrderItemForm(orderManager, itemId);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Обновляем таблицу после редактирования
                        MenuTable.DataSource = orderManager.GetMenu();
                        MessageBox.Show("Блюдо успешно обновлено");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите блюдо для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddOrderItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrderItem form = new AddOrderItem();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Обновить таблицу после добавления
                    MenuTable.DataSource = orderManager.GetMenu();
                    MessageBox.Show("Блюдо успешно добавлено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(authManager_.CurrentUser != null)
            {
                Application.Exit();
            }
        }
    }
}
