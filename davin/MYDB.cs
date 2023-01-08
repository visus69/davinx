using System;
using System.Data.Entity;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Davin
{
    public class MYDB : DbContext
    {
        
        public MYDB()
            : base("name=MYDB")
        {
        }

        private MySqlConnection connection = new MySqlConnection(
            "server=localhost;port=3306;username=root;password=;database=davin");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public DataTable getData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand= command;
            adapter.Fill(table);

            return table;
        }

        public int setData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            openConnection();
            
            int commandState = command.ExecuteNonQuery();

            closeConnection();

            return commandState;
        }
       
    }

   
}