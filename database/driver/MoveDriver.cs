using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public class MoveDriver : DatabaseDriver
    {
            private String _regularMoveQuery = "SELECT primary_move_target, primary_move_accuracy, power_percent, recoil_damage_percent FROM primary_move INNER JOIN physical_move ON(primary_move.move_name = physical_move.move_name) INNER JOIN regular_move ON(primary_move.move_name = regular_move.move_name) WHERE primary_move.move_name = \"";
            private String _priorityMoveQuery = "SELECT primary_move_target, primary_move_accuracy, power_percent, priority_level FROM primary_move INNER JOIN physical_move ON(primary_move.move_name = physical_move.move_name) INNER JOIN priority_move ON(primary_move.move_name = priority_move.move_name) WHERE primary_move.move_name = \"";
            private String _counterMoveQuery = "SELECT primary_move_target, primary_move_accuracy, power_percent FROM primary_move INNER JOIN physical_move ON(primary_move.move_name = physical_move.move_name) INNER JOIN counter_move ON(primary_move.move_name = counter_move.move_name) WHERE primary_move.move_name = \"";
            private String _knockoutMoveQuery = "SELECT primary_move_target, primary_move_accuracy FROM primary_move INNER JOIN knock_out_move ON(primary_move.move_name = knock_out_move.move_name) WHERE primary_move.move_name = \"";
            private String _protectMoveQuery = "SELECT primary_move_target, primary_move_accuracy, protect_move_type, succession_percent FROM primary_move INNER JOIN protect_move ON(primary_move.move_name = protect_move.move_name) WHERE primary_move.move_name = \"";
            private String _statChangingMoveQuery = "SELECT secondary_move_target, secondary_move_accuracy, is_side_effect, stat_one, stat_two, is_stat_one_boosting, is_stat_two_boosting, stat_one_percent, stat_two_percent FROM secondary_move INNER JOIN stat_changing_move ON(secondary_move.move_name = stat_changing_move.move_name) WHERE secondary_move.move_name = \"";
            private String _statusChangingMoveQuery = "SELECT secondary_move_target, secondary_move_accuracy, is_side_effect, status_condition, burn_damage, poison_damage, poison_incrementer, stun_duration, stun_probability FROM secondary_move INNER JOIN status_changing_move ON(secondary_move.move_name = status_changing_move.move_name) WHERE secondary_move.move_name = \"";


        public Move GetMove(String name)
        {
            //If the Connection to the Database is close, open it
            if(MySqlConnection.State.ToString().Equals("Closed"))
            {
                InitDriver();
            }

            //Init return variable
            Move move = null;

            //Create the query that allows you to get the data of a specific move based on the name.
            SqlQuery = "SELECT * FROM move WHERE move_name = '" + name + "'";

            //Run the command and gather the data
            MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
            MySqlDataReader = MySqlCommand.ExecuteReader();
            if(MySqlDataReader.Read())
            {
                String moveName = MySqlDataReader.GetString(0);
                String moveDescription = MySqlDataReader.GetString(1);
                String moveTypeOne = MySqlDataReader.GetString(2);
                String moveTypeTwo = MySqlDataReader.GetString(3);
                int moveLevel = MySqlDataReader.GetInt32(4);
                String moveArchetype = MySqlDataReader.GetString(5);
                int moveEnergyPoints = MySqlDataReader.GetInt32(6);

                //Close the reader to be safe
                MySqlDataReader.Close();

                //Make the move based on the general data
                move = MakeMove(moveName, moveDescription, moveTypeOne, moveTypeTwo, moveLevel, moveArchetype, moveEnergyPoints);
            }

            return move;
        }

        public List<Move> GetMoves()
        {
            //If the Connection to the Database is close, open it
            if(MySqlConnection.State.ToString().Equals("Closed"))
            {
                InitDriver();
            }

            //Init variables
            List<Move> list = new List<Move>();
            Player player = Player.GetInstance();

            //Create the query that allows you to get the list of data of moves based on level and archetype
            SqlQuery = "SELECT * FROM move WHERE move_level <= " + player.CharacterLevel + " AND (move_archetype = " + player.CharacterArchetype.ArchetypeName + " OR move_archetype = " +  player.CharacterArchetype.MainArchetypeName + ")";

            //Run the command and gather the data
            MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
            MySqlDataReader = MySqlCommand.ExecuteReader();
            while(MySqlDataReader.NextResult())
            {
                String moveName = MySqlDataReader.GetString(0);
                String moveDescription = MySqlDataReader.GetString(1);
                String moveTypeOne = MySqlDataReader.GetString(2);
                String moveTypeTwo = MySqlDataReader.GetString(3);
                int moveLevel = MySqlDataReader.GetInt32(4);
                String moveArchetype = MySqlDataReader.GetString(5);
                int moveEnergyPoints = MySqlDataReader.GetInt32(6);

                //Make the move based on the general data
                Move move = MakeMove(moveName, moveDescription, moveTypeOne, moveTypeTwo, moveLevel, moveArchetype, moveEnergyPoints);

                //Add the move to the list of moves the player can learn
                list.Add(move);
            }
            
            return list;
        }

        private Move MakeMove(String name, String description, String typeOne, String typeTwo, int level, String archetype, int energyPoints)
        {
            //Making the secondary move if this move has one
            Move moveTwo = null;
            switch(typeTwo)
            {
                case "STAT CHANGING":
                SqlQuery = _statChangingMoveQuery;
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    String statOne = MySqlDataReader.GetString(3);
                    String statTwo = MySqlDataReader.GetString(4);
                    bool isStatOneBoosted = MySqlDataReader.GetBoolean(5);
                    bool isStatTwoBoosted = MySqlDataReader.GetBoolean(6);
                    double statOnePercent = MySqlDataReader.GetDouble(7);
                    double statTwoPercent = MySqlDataReader.GetDouble(8);
                    moveTwo = new StatChangingMove(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MakeStatBoost(statOne, isStatOneBoosted, statOnePercent, statTwo, isStatTwoBoosted, statTwoPercent), MakeStatReduction(statOne, isStatOneBoosted, statOnePercent, statTwo, isStatTwoBoosted, statTwoPercent), MySqlDataReader.GetBoolean(2));
                    MySqlDataReader.Close();
                }
                break;

                case "STATUS CHANGING":
                SqlQuery = _statusChangingMoveQuery;
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveTwo = new StatusChangingMove(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MakeStatusCondition(MySqlDataReader), MySqlDataReader.GetBoolean(2));
                    MySqlDataReader.Close();
                }
                break;
            }

            //making the primary move
            Move moveOne = null;
            switch(typeOne)
            {
                case "REGULAR":
                SqlQuery = _regularMoveQuery;
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new RegularMove(moveTwo, name, description, MySqlDataReader.GetDouble(1),  MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2), MySqlDataReader.GetDouble(3));
                    }
                    else
                    {
                        moveOne = new RegularMove(name,  description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2), MySqlDataReader.GetDouble(3));
                    }
                    MySqlDataReader.Close();
                }
                break;

                case "COUNTER":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy, power_percent", "move INNER JOIN physical_move ON(move.move_name = physical_move.move_name) INNER JOIN counter_move ON(move.move_name = counter_move.move_name)", name);
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new CounterMove(moveTwo, name, description, MySqlDataReader.GetDouble(2), MySqlDataReader.GetDouble(0), MySqlDataReader.GetString(0), level, energyPoints, energyPoints);
                    }
                    else
                    {
                        moveOne = new CounterMove(name, description, MySqlDataReader.GetDouble(2), MySqlDataReader.GetDouble(0), MySqlDataReader.GetString(0), level, energyPoints, energyPoints);
                    }
                    MySqlDataReader.Close();
                }
                break;

                case "PRIORITY":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy, power_percent, priority_level", "move INNER JOIN physical_move ON(move.move_name = physical_move.move_name) INNER JOIN priority_move ON(move.move_name = priority_move.move_name)", name);
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    int priorityLevel = MySqlDataReader.GetInt32(3);
                    if(moveTwo != null)
                    {
                        switch(priorityLevel)
                        {
                            case 1:
                            moveOne = new Priority1(moveTwo, name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2));
                            break;
                            case 2:
                            moveOne = new Priority2(moveTwo, name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2));
                            break;
                            case 3:
                            moveOne = new Priority3(moveTwo, name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2));
                            break;
                        }
                    }
                    else
                    {
                        switch(priorityLevel)
                        {
                            case 1:
                            moveOne = new Priority1(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2));
                            break;
                            case 2:
                            moveOne = new Priority2(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2));
                            break;
                            case 3:
                            moveOne = new Priority3(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MySqlDataReader.GetDouble(2));
                            break;
                        }
                    }
                    MySqlDataReader.Close();
                }
                break;

                case "PROTECT":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy, protect_move_type, succession_percent", "move INNER JOIN primary_move ON(move.move_name = primary_move.move_name) INNER JOIN protect_move ON(move.move_name = protect_move.move_name)", name);
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new ProtectMove(moveTwo, name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MakeProtectionStatus(MySqlDataReader.GetString(2)), MySqlDataReader.GetDouble(3));
                    }
                    else
                    {
                        moveOne = new ProtectMove(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MakeProtectionStatus(MySqlDataReader.GetString(2)), MySqlDataReader.GetDouble(3));
                    }
                    MySqlDataReader.Close();
                }
                break;

                case "KNOCK OUT":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy", "move INNER JOIN primary_move ON(move.move_name = primary_move.move_name) INNER JOIN knock_out_move ON(move.move_name = knock_out_move.move_name)", name);
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new KnockoutMove(moveTwo, name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints);
                    }
                    else
                    {
                        moveOne = new KnockoutMove(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints);
                    }
                    MySqlDataReader.Close();
                }
                break;

                case "STAT CHANGING":
                SqlQuery = MakeMoveQuery("secondary_move_target, secondary_move_accuracy, is_side_effect, stat_one, stat_two, is_stat_one_boosting, is_stat_two_boosting, stat_one_percent, stat_two_percent", "move INNER JOIN secondary_move ON (move.move_name = secondary_move.move_name) INNER JOIN stat_changing_move ON (move.move_name = stat_changing_move.move_name)", name);
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    String statOne = MySqlDataReader.GetString(3);
                    String statTwo = MySqlDataReader.GetString(4);
                    bool isStatOneBoosted = MySqlDataReader.GetBoolean(5);
                    bool isStatTwoBoosted = MySqlDataReader.GetBoolean(6);
                    double statOnePercent = MySqlDataReader.GetDouble(7);
                    double statTwoPercent = MySqlDataReader.GetDouble(8);
                    moveTwo = new StatChangingMove(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MakeStatBoost(statOne, isStatOneBoosted, statOnePercent, statTwo, isStatTwoBoosted, statTwoPercent), MakeStatReduction(statOne, isStatOneBoosted, statOnePercent, statTwo, isStatTwoBoosted, statTwoPercent), MySqlDataReader.GetBoolean(2));
                    MySqlDataReader.Close();
                }
                break;

                case "STATUS CHANGING":
                SqlQuery = MakeMoveQuery("secondary_move_target, secondary_move_accuracy, is_side_effect, status_condition, burn_damage, poison_damage, poison_incrementer, stun_duration, stun_probability", "move INNER JOIN secondary_move ON (move.move_name = secondary_move.move_name) INNER JOIN status_changing_move ON (move.move_name = status_changing_move.move_name)", name);
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = new StatusChangingMove(name, description, MySqlDataReader.GetDouble(1), MySqlDataReader.GetString(0), level, energyPoints, energyPoints, MakeStatusCondition(MySqlDataReader), MySqlDataReader.GetBoolean(2));
                    MySqlDataReader.Close();
                }
                break;
            }

            return moveOne;
        }

        private String MakeMoveQuery(String attributes, String location, String name)
        {
            return "SELECT " + attributes + " FROM " + location + " WHERE move.move_name = '" + name + "'";
        }

        private StatusCondition MakeStatusCondition(MySqlDataReader reader)
        {
            StatusCondition statusCondition = null;
            String name = reader.GetString(3);

            double burnDamage = 0;
            double poisonDamage = 0;
            double poisonIncrementer = 0;
            int stunDuration = 0;
            double stunProbability = 0;

            try{
                burnDamage = reader.GetDouble(4);
            }
            catch
            {
            }
            try{
                poisonDamage = reader.GetDouble(5);
            }
            catch
            {
            }
            try{
                poisonIncrementer = reader.GetDouble(6);
            }
            catch
            {
            }
            try{
                stunDuration = reader.GetInt32(7);
            }
            catch
            {
            }
            try
            {
                stunProbability = reader.GetDouble(8);
            }
            catch
            {
            }

            switch(name)
            {
                case "BURN":
                return new Burn(burnDamage);
                case "POISON":
                return new Poison(poisonDamage, poisonIncrementer);
                case "STUN":
                return new Stun(stunDuration, stunProbability);
                case "FLINCH":
                return new Flinch();
            }

            return statusCondition;
        }

        private ProtectionStatus MakeProtectionStatus(String status)
        {
            if(status == null)
            {
                return ProtectionStatus.NOTHING;
            }
            else if(status.Equals("PHYSICAL"))
            {
                return ProtectionStatus.PHYSICAL_PROTECT;
            }
            else if(status.Equals("SPECIAL"))
            {
                return ProtectionStatus.SPECIAL_PROTECT;
            }
            else if(status.Equals("PROTECT"))
            {
                return ProtectionStatus.PROTECT;
            }

            return ProtectionStatus.NOTHING;
        }
    }
}