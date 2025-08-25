using MoneyManagerX.Model;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MoneyManagerX
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Database database = new Database();

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrationSuccess())
            {
                MessageBox.Show("ГОООЛ");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Ну-ну");
            }


        }

        private bool RegistrationSuccess()
        {
            var name = NameTextBox.Text;
            var login = RegLoginTextBox.Text;
            var password = RegPasswordTextBox.Password;

            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                password = builder.ToString();
            };

            if (InsertUser(name, login, password))
            {
                return true;
            }

            return false;
        }

        private bool InsertUser(string name, string login, string password)
        {
            string query = $"INSERT INTO Users(name, login, password) VALUES('{name}','{login}','{password}')";

            try
            {
                SqlCommand command = new SqlCommand(query, database.GetConnection());

                database.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
