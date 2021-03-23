using System;
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

                MySqlDataReader.Close();
                item = MakeItem(itemName, itemDescription, itemType, itemLevel);
            }

            return item;
        }

        private Item MakeItem(String name, String description, String type, int level)
        {
            Item item = null;

            switch(type)
            {
                case "KEY":
                item = new KeyItem(name, description, level);
                break;
                
                case "FOOD":
                SqlQuery = "SELECT heal_amount FROM food_item WHERE food_item.item_name = '" + name + "'";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new FoodItem(name, description, level, MySqlDataReader.GetInt32(0));
                    MySqlDataReader.Close();
                }
                break;

                case "HEALING":
                SqlQuery = "SELECT heal_percent FROM healing_item WHERE healing_item.item_name = '" + name + "'";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new HealingItem(name, description, level, MySqlDataReader.GetDouble(0));
                    MySqlDataReader.Close();
                }
                break;

                case "MEDICAL":
                SqlQuery = "SELECT status_cure, heal_amount FROM medical_item WHERE medical_item.item_name = '" + name + "'";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new MedicalItem(name, description, level, MySqlDataReader.GetInt32(1), MySqlDataReader.GetString(0));
                    MySqlDataReader.Close();
                }
                break;

                case "PRIORITY":
                SqlQuery = "SELECT priority_percentage FROM priority_item WHERE priority_item = '" + name + "'";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new PriorityItem(name, description, level, MySqlDataReader.GetDouble(0));
                    MySqlDataReader.Close();
                }
                break;

                case "STAT CHANGING":
                SqlQuery = "SELECT stat_one, stat_two, is_stat_one_boosted, is_stat_two_boosted, stat_one_percentage, stat_two_percentage FROM stat_changing_item WHERE stat_changing_item.item_name = '" + name + "'";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    String statOne = MySqlDataReader.GetString(0);
                    String statTwo = MySqlDataReader.GetString(1);
                    bool isStatOneBoosted = MySqlDataReader.GetBoolean(2);
                    bool isStatTwoBoosted = MySqlDataReader.GetBoolean(3);
                    double statOnePercent = MySqlDataReader.GetDouble(4);
                    double statTwoPercent = MySqlDataReader.GetDouble(5);
                    item = new StatChangingItem(name, description, level, MakeStatBoost(statOne, isStatOneBoosted, statOnePercent, statTwo, isStatTwoBoosted, statTwoPercent), MakeStatReduction(statOne, isStatOneBoosted, statOnePercent, statTwo, isStatTwoBoosted, statTwoPercent));
                }
                break;
            }

            return item;
        }
    }
}