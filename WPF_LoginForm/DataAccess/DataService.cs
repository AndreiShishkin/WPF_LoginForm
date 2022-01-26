using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WPF_LoginForm.DataAccess
{
    class DataService
    {
        string connectionString = @"
Integrated Security=true;
Initial Catalog=ModerUIChat;
server=AndreiPC\SQLEXPRESS;";

        public int GetAccount(string login, string pass)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString)) 
            {
                var Command = new SqlCommand(SqlQuery.countLogin, connection);
                Command.Parameters.AddWithValue("@Login", login);
                Command.Parameters.AddWithValue("@pass", pass);
            connection.Open();
                object obj = Command.ExecuteScalar();
                if (obj != null)
                    result = (int)obj;
            }
            return result;
        }
    }
}
