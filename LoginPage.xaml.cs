using MoneyManagerX.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace MoneyManagerX
{
    public partial class LoginPage : Page
    {
        Window loginWindow;
        Database database = new Database();
        User user;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Authorize())
            {
                ManagerWindow managerWindow = new ManagerWindow(user);
                managerWindow.Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }

        }

        private bool Authorize()
        {
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Password;
            if (login.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены для авторизации");
            }
            else if (CheckData(login, password))
            {
                return true;
            }
            return false;
        }

        private bool CheckData(string login, string password)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT UserID, name FROM Users WHERE login = '{login}' AND password = '{password}'";

            try
            {
                SqlCommand command = new SqlCommand(query, database.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    var id = table.Rows[0].Field<int>("userId");
                    var name = table.Rows[0].Field<string>("name");
                    user = new User(id, name);
                    MessageBox.Show($"Вход пожаловать, {table.Rows[0].Field<string>("name")}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
