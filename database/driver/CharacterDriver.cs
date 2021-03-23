using System;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public class CharacterDriver : DatabaseDriver
    {
        private MoveSetDriver _moveSetDriver = new MoveSetDriver();
        private BaseStatDriver _baseStatDriver = new BaseStatDriver();
        private ItemDriver _itemDriver = new ItemDriver();
        public NonPlayer GetNPC(String characterID)
        {
            NonPlayer npc = null;

            if(MySqlConnection.State.Equals("Closed"))
            {
                InitDriver();
            }

            SqlQuery = "SELECT * FROM non_player_character WHERE character_id = '" + characterID + "'";
            MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
            MySqlDataReader = MySqlCommand.ExecuteReader();
            if(MySqlDataReader.Read())
            {
                String name = MySqlDataReader.GetString(1);
                String sex = MySqlDataReader.GetString(2);
                String type = MySqlDataReader.GetString(3);
                Archetype archetype = Archetype.GetArchetype(MySqlDataReader.GetString(4));
                int gold = MySqlDataReader.GetInt32(5);
                int level = MySqlDataReader.GetInt32(6);
                Item item = _itemDriver.GetItem(MySqlDataReader.GetString(7));
                MoveSet moveSet = _moveSetDriver.GetMoveSet(characterID);
                BaseStat baseStat = _baseStatDriver.GetBaseStat(characterID);

                npc = new NonPlayer(name, sex, gold, level, archetype, moveSet, type, baseStat, new BattleStatus(), item, characterID);
            }
            return npc;
        }
    }
}