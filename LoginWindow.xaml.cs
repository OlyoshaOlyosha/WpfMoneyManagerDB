using System.Windows;

namespace MoneyManagerX
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginFrame.Content = new LoginPage();
        }
    }
}
