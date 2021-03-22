using System;
using Microsoft.Data.SqlClient;

namespace GofRPG_API
{
    public abstract class DatabaseDriver
    {
        //Data members
        private Files _files = new Files();
        protected SqlConnection SqlConnection {get; set;}
        protected String SqlQuery {get; set;}
        protected SqlCommand SqlCommand {get; set;}
        protected SqlDataReader SqlDataReader {get; set;}
        public DatabaseDriver()
        {
            InitDriver();
        }
        private void InitDriver(){
            //Decrypt file needed to gain access to the database
            String connectionString = _files.DecryptFile();

            //Gain access to the database
            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();
            
            //Encrypt the file that was needed to gain access to the database
            _files.EncryptFile();
        }
    }
}