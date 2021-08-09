using System;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public class ItemDriver : DatabaseDriver
    {
        private String _foodItemQuery = "heal_amount FROM food_item WHERE item_name = \"";
        private String _healingItemQuery = "SELECT heal_percent FROM healing_item WHERE item_name = \"";
        private String _medicalItemQuery = "SELECT status_cure, heal_amount FROM stat_changing_item WHERE item_name = \"";
        private String _priorityItemQuery = "SELECT priority_percentage FROM priority_item  WHERE item_name = \"";
        private String _statChangingItemQuery = "SELECT stat_one, stat_two, is_stat_one_boosted, is_stat_two_boosted, stat_one_percentage, stat_two_percentage FROM stat_changing_item WHERE item_name = \"";

        public Item GetItem(String name)
        {
            Item item = null;

            if(MySqlConnection.State.ToString().Equals("Closed"))
            {
                InitDriver();
            }

            SqlQuery = "SELECT * FROM item WHERE item_name = \"" + name + "\"";
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
                SqlQuery = _foodItemQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new FoodItem(name, description, level, MySqlDataReader.GetInt32("heal_amount"));
                    MySqlDataReader.Close();
                }
                break;

                case "HEALING":
                SqlQuery = _healingItemQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new HealingItem(name, description, level, MySqlDataReader.GetDouble("heal_percent"));
                    MySqlDataReader.Close();
                }
                break;

                case "MEDICAL":
                SqlQuery = _medicalItemQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new MedicalItem(name, description, level, MySqlDataReader.GetInt32("heal_amount"), MySqlDataReader.GetString("status_condition"));
                    MySqlDataReader.Close();
                }
                break;

                case "PRIORITY":
                SqlQuery = _priorityItemQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    item = new PriorityItem(name, description, level, MySqlDataReader.GetDouble("priority_percentage"));
                    MySqlDataReader.Close();
                }
                break;

                case "STAT CHANGING":
                SqlQuery = _statChangingItemQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    String statOne = MySqlDataReader.GetString("stat_one");
                    String statTwo = MySqlDataReader.GetString("stat_two");
                    bool isStatOneBoosted = MySqlDataReader.GetBoolean("is_stat_one_boosted");
                    bool isStatTwoBoosted = MySqlDataReader.GetBoolean("is_stat_two_boosted");
                    double statOnePercent = MySqlDataReader.GetDouble("stat_one_percentage");
                    double statTwoPercent = MySqlDataReader.GetDouble("stat_two_percentage");
                    item = new StatChangingItem(name, description, level, MakeStat(statOne, isStatOneBoosted, statOnePercent), MakeStat(statTwo, isStatTwoBoosted, statTwoPercent));
                }
                break;
            }

            return item;
        }
    }
}