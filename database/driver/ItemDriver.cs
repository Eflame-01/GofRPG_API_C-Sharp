using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public class ItemDriver : DatabaseDriver
    {
        public Item GetItem(String name)
        {
            Item item = null;

            if(MySqlConnection.State.ToString().Equals("Closed"))
            {
                InitDriver();
            }

            SqlQuery = "SELECT * FROM item WHERE item_name = '" + name + "'";
            MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
            MySqlDataReader = MySqlCommand.ExecuteReader();

            if(MySqlDataReader.Read())
            {
                String itemName = MySqlDataReader.GetString(0);
                String itemDescription = MySqlDataReader.GetString(1);
                String itemType = MySqlDataReader.GetString(2);
                int itemLevel = MySqlDataReader.GetInt32(3);

                
            }

            return item;
        }

        private Item MakeItem(String name, String description, String type, int level)
        {
            Item item = null;

            return item;
        }
    }
}