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
            authManager.Register("user1", "login1", "123", UserRole.Waiter);
            authManager.Register("user2", "login2", "1234", UserRole.Cook);
            authManager.Register("admin1", "admin", "12345", UserRole.Admin);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            LoginResult result = authManager.Login(login, password);
            if(result == LoginResult.PasswordOrLoginIsWhiteSpace)
            {
                MessageBox.Show("Поля логин и пароль не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(result == LoginResult.WrongLogin)
            {
                MessageBox.Show("Неверный логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(result == LoginResult.WrongPassword)
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(result == LoginResult.Success)
            {
                this.Hide();
                if (authManager.CurrentUser.Role == UserRole.Cook)
                {
                    var form = new CookForm();
                    form.Show();
                }

                if(authManager.CurrentUser.Role == UserRole.Waiter)
                {
                    var form = new WaiterForm();
                    form.Show();
                }
                if(authManager.CurrentUser.Role == UserRole.Admin)
                {
                    var form = new AdminForm(authManager);
                    form.Show();
                }
            }

        }
    }
}
