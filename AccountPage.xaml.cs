using MoneyManagerX.Model;
using System.Windows.Controls;

namespace MoneyManagerX
{
    public partial class AccountPage : Page
    {
        public AccountPage(User user)
        {
            InitializeComponent();

            NameTextBlock.Text = $"{user.Name}";
            IDTextBlock.Text = $"ID {user.UserId}";
        }
    }
}
