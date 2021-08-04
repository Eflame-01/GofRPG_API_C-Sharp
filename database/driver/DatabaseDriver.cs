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

        //Constructor
        public DatabaseDriver()
        {
            InitDriver();
        }

        protected void InitDriver(){
            String connectionString = @_files.DecryptFile();
            // _files.EncryptFile(); TODO: i forogt why this is commented out, test this out first
            MySqlConnection = new MySqlConnection(connectionString);
            MySqlConnection.Open();
        }

        protected Stat MakeStat(String name, bool isStatBoosted, double statChangePercent)
        {
            Stat stat = null;

            switch(name)
            {
                case "ATK":
                if(statChangePercent <= 0){
                    stat = new Attack();
                    break;
                }
                if(isStatBoosted)
                {
                    stat = new Attack(statChangePercent, 0);
                }
                else{
                    stat = new Attack(0, statChangePercent);
                }
                break;
                case "DEF":
                if(statChangePercent <= 0){
                    stat = new Defense();
                    break;
                }
                if(isStatBoosted)
                {
                    stat = new Defense(statChangePercent, 0);
                }
                else{
                    stat = new Defense(0, statChangePercent);
                }
                break;
                case "EVA":
                if(statChangePercent <= 0){
                    stat = new Evasion();
                    break;
                }
                if(isStatBoosted)
                {
                    stat = new Evasion(statChangePercent, 0);
                }
                else{
                    stat = new Evasion(0, statChangePercent);
                }
                break;
                case "SPD":
                if(statChangePercent <= 0){
                    stat = new Speed();
                    break;
                }
                if(isStatBoosted)
                {
                    stat = new Speed(statChangePercent, 0);
                }
                else{
                    stat = new Speed(0, statChangePercent);
                }
                break;
                case "HP":
                if(statChangePercent <= 0){
                    stat = new HitPoints();
                    break;
                }
                if(isStatBoosted)
                {
                    stat = new HitPoints(statChangePercent, 0);
                }
                else{
                    stat = new HitPoints(0, statChangePercent);
                }
                break;
            }

            return stat;
        }
    }
}