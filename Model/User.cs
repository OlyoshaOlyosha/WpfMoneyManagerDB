namespace MoneyManagerX.Model
{
    public class User
    {
        private int user_id;
        private string name;
        private string surname;
        private string login;
        private string password;

        public User(int id, string name, string surname, string login, string password)
        {
            user_id = id;
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.password = password;
        }

        public User(int id, string name)
        {
            user_id = id;
            this.name = name;
        }

        public int UserId { get { return user_id; } }
        public string Name { get { return name; } }
        public string Surname { get { return surname; } }
        public string Login { get { return login; } }
        public string Password { get { return password; } }
    }
}
