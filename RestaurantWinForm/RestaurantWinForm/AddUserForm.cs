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
    public partial class AddUserForm : Form
    {
        private AuthManager authManager_;
        private List<string> roles;
        public AddUserForm(AuthManager authManager)
        {
            InitializeComponent();
            authManager_ = authManager;

            roles = new List<string>();
            roles.Add("Администратор");
            roles.Add("Повар");
            roles.Add("Официант");

            RoleComboBox.DataSource = roles;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string roleStr = RoleComboBox.Text;
            UserRole role = UserRole.Admin;

            switch(roleStr)
            {
                case "Администратор":
                    role = UserRole.Admin;
                    break;
                case "Повар":
                    role = UserRole.Cook;
                    break;
                case "Официант":
                    role = UserRole.Waiter;
                    break;
            }

            RegistrationResult res = authManager_.Register(username, login, password, role);
            if(res == RegistrationResult.ExistingUsername)
            {
                MessageBox.Show("Пользователь с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(res == RegistrationResult.ExistingLogin)
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(res == RegistrationResult.EmptyFields)
            {
                MessageBox.Show("Поля не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(res == RegistrationResult.Success)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
