using MoneyManagerX.Model;
using System.Windows;
using System.Windows.Input;

namespace MoneyManagerX
{
    public partial class ManagerWindow : Window
    {
        User user;
        public ManagerWindow(User user)
        {
            InitializeComponent();
            this.user = user;

            ManagerFrame.Navigate(new HomePage());
        }

        private void HomeImageClick(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Navigate(new HomePage());
        }

        private void IncomeImageClick(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Navigate(new IncomePage());
        }

        private void SpendingsImageClick(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Navigate(new SpendingsPage());
        }

        private void AccountImageClick(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Navigate(new AccountPage(user));
        }

        private void SettingsImageClick(object sender, MouseButtonEventArgs e)
        {
            ManagerFrame.Navigate(new SettingsPage());
        }
    }
}
