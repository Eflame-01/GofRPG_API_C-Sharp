using System;
using Microsoft.Data.SqlClient;

namespace GofRPG_API
{
    public abstract class DatabaseDriver
    {
        //Data members
        private Files _files = new Files();
        protected SqlConnection SqlConnection;
        protected String SqlQuery;
        protected SqlCommand SqlCommand;
        protected SqlDataReader SqlDataReader;


        private void initDriver(){
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