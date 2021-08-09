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
                Item item = null;
                if(!MySqlDataReader.IsDBNull(7))
                {
                    item = _itemDriver.GetItem(MySqlDataReader.GetString(7));
                }
                MoveSet moveSet = _moveSetDriver.GetMoveSet(characterID);
                BaseStat baseStat = _baseStatDriver.GetBaseStat(characterID);

                npc = new NonPlayer(name, sex, gold, level, archetype, moveSet, type, baseStat, new BattleStatus(), item, characterID);
            }
            return npc;
        }
    }
    class BaseStatDriver : DatabaseDriver
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

    class MoveSetDriver : DatabaseDriver
    {
        private MoveDriver _moveDriver = new MoveDriver();
        public MoveSet GetMoveSet(String characterID)
        {
            MoveSet moveSet = new MoveSet();
            
            if(MySqlConnection.State.Equals("Closed"))
            {
                InitDriver();
            }

            SqlQuery = "SELECT * FROM move_set WHERE character_id = '" + characterID + "'";
            MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
            MySqlDataReader = MySqlCommand.ExecuteReader();

            if(MySqlDataReader.Read())
            {
                for(int i = 1; i <= 4; i++)
                {
                    if(!MySqlDataReader.IsDBNull(i))
                    {
                        String moveName = MySqlDataReader.GetString(i);
                        Move move = _moveDriver.GetMove(moveName);
                        moveSet.AddMove(move);
                    }
                }
            }
            return moveSet;
        }
    }
}