using System;
using Microsoft.Data.SqlClient;

namespace GofRPG_API
{
    public abstract class DatabaseDriver
    {
        //Data members
        private Files _files = new Files();
        protected String SqlQuery {get; set;}
        protected String ConnectionString {get; private set;}
        public DatabaseDriver()
        {
            InitDriver();
        }
        private void InitDriver(){
            ConnectionString = @_files.DecryptFile();
        }
    }
}