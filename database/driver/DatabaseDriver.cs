using System;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public abstract class DatabaseDriver
    {
        //Data members
        private Files _files = new Files();
        protected String SqlQuery {get; set;}
        protected MySqlConnection MySqlConnection {get; private set;}
        protected MySqlCommand MySqlCommand {get; set;}
        protected MySqlDataReader MySqlDataReader {get; set;}
        public DatabaseDriver()
        {
            InitDriver();
        }
        protected void InitDriver(){
            String connectionString = @_files.DecryptFile();
            MySqlConnection = new MySqlConnection(connectionString);
            MySqlConnection.Open();
        }
    }
}