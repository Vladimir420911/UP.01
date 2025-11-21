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
        public AdminForm(AuthManager authManager, AuthForm authForm)
        {
            InitializeComponent();
            authManager_ = authManager;
            authForm_ = authForm;

            users_ = authManager_.GetAllUsers();
            StaffListBox.DataSource = users_;
            StaffListBox.DisplayMember = "UserName";
        }

        private void AddUserMenuButton_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(authManager_);
            if(addUserForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Новый пользователь добавлен");
            }
        }

        private void LogoutMenuButton_Click(object sender, EventArgs e)
        {
            authManager_.Logout();
            this.Close();
            authForm_.Show();
        }
    }
}
