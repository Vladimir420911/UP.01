using MySql.Data;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class AuthManager : IStaffRepository
    {
        private string _connectionString = "server=localhost;user=root;database=restarauntdb;password=1234567890;port=3306;";
        public Staff CurrentUser { get; private set; }

        public Staff GetUserByLogin(string login)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT s.StaffId, s.UserName, s.Login, s.Password, r.RoleName 
                    FROM Staff s 
                    INNER JOIN UserRoles r ON s.RoleId = r.RoleId 
                    WHERE s.Login = @Login";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Staff(
                                reader.GetInt32("StaffId"),
                                reader.GetString("Password"))
                            {
                                UserName = reader.GetString("UserName"),
                                Login = reader.GetString("Login"),
                                Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString("RoleName"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public LoginResult Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                CurrentUser = null;
                return LoginResult.PasswordOrLoginIsWhiteSpace;
            }

            var staff = GetUserByLogin(login);
            if (staff == null)
            {
                CurrentUser = null;
                return LoginResult.WrongLogin;
            }

            if (staff != null && staff.Password_ != password)
            {
                CurrentUser = null;
                return LoginResult.WrongPassword;
            }

            CurrentUser = staff;
            return LoginResult.Success;
        }

        public RegistrationResult Register(string username, string login, string password, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return RegistrationResult.EmptyFields;
            }

            // Проверка существующего логина
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Staff WHERE Login = @Login OR UserName = @UserName";

                using (var checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Login", login);
                    checkCmd.Parameters.AddWithValue("@UserName", username);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        return RegistrationResult.ExistingLogin;
                    }
                }

                // Регистрация нового пользователя
                string insertQuery = @"
                    INSERT INTO Staff (UserName, Login, Password, RoleId) 
                    VALUES (@UserName, @Login, @Password, @RoleId)";

                using (var insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@UserName", username);
                    insertCmd.Parameters.AddWithValue("@Login", login);
                    insertCmd.Parameters.AddWithValue("@Password", password);
                    insertCmd.Parameters.AddWithValue("@RoleId", (int)role + 1); // +1 т.к. в БД RoleId начинается с 1

                    int result = insertCmd.ExecuteNonQuery();
                    return result > 0 ? RegistrationResult.Success : RegistrationResult.EmptyFields;
                }
            }
        }

        public BindingList<Staff> GetAllUsers()
        {
            var users = new BindingList<Staff>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT s.StaffId, s.UserName, s.Login, s.Password, r.RoleName 
                    FROM Staff s 
                    INNER JOIN UserRoles r ON s.RoleId = r.RoleId";

                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new Staff(
                            reader.GetInt32("StaffId"),
                            reader.GetString("Password"))
                        {
                            UserName = reader.GetString("UserName"),
                            Login = reader.GetString("Login"),
                            Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString("RoleName"))
                        });
                    }
                }
            }

            return users;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
