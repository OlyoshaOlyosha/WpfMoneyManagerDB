using System.Data.SqlClient;

namespace MoneyManagerX.Model
{
    public class Database
    {
        private SqlConnection connection = new SqlConnection(
            "Data Source=MAIBENBEN-PC;Initial Catalog=MoneyManagerDB;Integrated Security=True;");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
