using System;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public class BaseStatDriver : DatabaseDriver
    {
        public BaseStat GetBaseStat(String characterID)
        {
            BaseStat baseStat = null;

            if(MySqlConnection.State.Equals("Closed"))
            {
                InitDriver();
            }

            SqlQuery = "SELECT * FROM base_stat WHERE character_id = '" + characterID + "'";
            MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
            MySqlDataReader = MySqlCommand.ExecuteReader();

            if(MySqlDataReader.Read())
            {
                int hp = MySqlDataReader.GetInt32(1);
                int atk = MySqlDataReader.GetInt32(2);
                int def = MySqlDataReader.GetInt32(3);
                int eva = MySqlDataReader.GetInt32(4);
                int spd = MySqlDataReader.GetInt32(5);

                baseStat = new BaseStat(atk, def, eva, spd, hp);
            }

            return baseStat;
        }
    }
}