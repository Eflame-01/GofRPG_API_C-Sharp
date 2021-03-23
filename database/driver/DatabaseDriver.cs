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
            // _files.EncryptFile();
            MySqlConnection = new MySqlConnection(connectionString);
            MySqlConnection.Open();
        }

        protected Stat MakeStatBoost(String statOne, bool isStatOneBoosted, double statOnePercent, String statTwo, bool isStatTwoBoosted, double statTwoPercent)
        {
            Stat statBoost = null;
            if(isStatOneBoosted)
            {
                statBoost = Stat.GetStat(statOne, statOnePercent, 0);
            }
            else if(isStatTwoBoosted)
            {
                statBoost = Stat.GetStat(statTwo, statTwoPercent, 0);
            }
            return statBoost;
        }

        protected Stat MakeStatReduction(String statOne, bool isStatOneBoosted, double statOnePercent, String statTwo, bool isStatTwoBoosted, double statTwoPercent)
        {
            Stat statReduction = null;
            if(!isStatOneBoosted)
            {
                statReduction = Stat.GetStat(statOne, 0, statOnePercent);
            }
            else if(!isStatTwoBoosted)
            {
                statReduction = Stat.GetStat(statTwo, 0, statTwoPercent);
            }
            return statReduction;
        }
    }
}