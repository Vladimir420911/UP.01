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
    public partial class AuthForm : Form
    {
        private AuthManager authManager;
        public AuthForm()
        {
            InitializeComponent();
            authManager = new AuthManager();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                string login = LoginTextBox.Text;
                string password = PasswordTextBox.Text;

                LoginResult result = authManager.Login(login, password);

                if (result == LoginResult.PasswordOrLoginIsWhiteSpace)
                {
                    MessageBox.Show("Поля логин и пароль не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (result == LoginResult.WrongLogin)
                {
                    MessageBox.Show("Неверный логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (result == LoginResult.WrongPassword)
                {
                    MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (result == LoginResult.Success)
                {
                    this.Hide();
                    if (authManager.CurrentUser.Role == UserRole.Cook)
                    {
                        var form = new CookForm();
                        form.Show();
                    }

                    if (authManager.CurrentUser.Role == UserRole.Waiter)
                    {
                        var form = new WaiterForm();
                        form.Show();
                    }
                    if (authManager.CurrentUser.Role == UserRole.Admin)
                    {
                        var form = new AdminForm(authManager, this);
                        form.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
