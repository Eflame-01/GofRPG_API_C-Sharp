using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public class MoveDriver : DatabaseDriver
    {

            private String _findMoveQuery = "SELECT * FROM move WHERE move_name = \"";
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
            SqlQuery = _findMoveQuery + name + "\"";

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
                SqlQuery = _statChangingMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveTwo = MakeStatChangingMove(MySqlDataReader, null, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;

                case "STATUS CHANGING":
                SqlQuery = _statusChangingMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveTwo = MakeStatusChangingMove(MySqlDataReader, null, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;
            }

            //making the primary move
            Move moveOne = null;
            switch(typeOne)
            {
                case "REGULAR":
                SqlQuery = _regularMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = MakeRegularMove(MySqlDataReader, moveTwo, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;

                case "COUNTER":
                SqlQuery = _counterMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = MakeCounterMove(MySqlDataReader, moveTwo, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;

                case "PRIORITY":
                SqlQuery = _priorityMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = MakePriorityMove(MySqlDataReader, moveTwo, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;

                case "PROTECT":
                SqlQuery = _protectMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = MakeProtectMove(MySqlDataReader, moveTwo, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;

                case "KNOCK OUT":
                SqlQuery = _knockoutMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = MakeKnockoutMove(MySqlDataReader, moveTwo, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;

                case "STAT CHANGING":
                SqlQuery = _statChangingMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = MakeStatChangingMove(MySqlDataReader, null, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;

                case "STATUS CHANGING":
                SqlQuery = _statusChangingMoveQuery + name + "\"";
                MySqlCommand = new MySqlCommand(SqlQuery, MySqlConnection);
                MySqlDataReader = MySqlCommand.ExecuteReader();
                if(MySqlDataReader.Read())
                {
                    moveOne = MakeStatusChangingMove(MySqlDataReader, null, name, description, level, archetype, energyPoints);
                    MySqlDataReader.Close();
                }
                break;
            }

            return moveOne;
        }

        private Move MakeCounterMove(MySqlDataReader reader, Move moveTwo, String name, String description, int level, String archetype, int energyPoints)
        {
            //primary_move_target, primary_move_accuracy, power_percent
            String primaryMoveTarget = reader.GetString("primary_move_target");
            double primaryMoveAccuracy = reader.GetDouble("primary_move_accuracy");
            double powerPercent = reader.GetDouble("power_percent");
            ArchetypeID archetypeID = Archetype.GetArchetypeID(archetype);
            Move move = null;

            if(moveTwo == null)
            {
                move = new CounterMove(name, description, powerPercent, primaryMoveAccuracy, primaryMoveTarget, level, archetypeID, energyPoints, energyPoints);
            }
            else
            {
                move = new CounterMove(moveTwo, name, description, powerPercent, primaryMoveAccuracy, primaryMoveTarget, level, archetypeID, energyPoints, energyPoints);
            }
            return move;
        }

        private Move MakeKnockoutMove(MySqlDataReader reader, Move moveTwo, String name, String description, int level, String archetype, int energyPoints)
        {
            // primary_move_target, primary_move_accuracy
            String primaryMoveTarget = reader.GetString("primary_move_target");
            double primaryMoveAccuracy = reader.GetDouble("primary_move_accuracy");
            Move move = null;

            if(moveTwo == null)
            {
                move = new KnockoutMove(name, description, primaryMoveAccuracy, primaryMoveTarget, level, energyPoints, energyPoints);
            }
            else
            {
                move = new KnockoutMove(moveTwo, name, description, primaryMoveAccuracy, primaryMoveTarget, level, energyPoints, energyPoints);
            }
            return null;
        }

        private Move MakePriorityMove(MySqlDataReader reader, Move moveTwo, String name, String description, int level, String archetype, int energyPoints)
        {
            //primary_move_target, primary_move_accuracy, power_percent, priority_level
            String primaryMoveTarget = MySqlDataReader.GetString("primary_move_target");
            double primaryMoveAccuracy = MySqlDataReader.GetDouble("primary_move_accuracy");
            double powerPercent = MySqlDataReader.GetDouble("power_percent");
            int priorityLevel = MySqlDataReader.GetInt32("priority_level");
            ArchetypeID archetypeID = Archetype.GetArchetypeID(archetype);
            Move move = null;

            if(moveTwo == null)
            {
                move = new PriorityMove(name, description, primaryMoveAccuracy, primaryMoveTarget, level, archetypeID, energyPoints, energyPoints, powerPercent, priorityLevel);
            }
            else
            {
                move = new PriorityMove(moveTwo, name, description, primaryMoveAccuracy, primaryMoveTarget, level, archetypeID, energyPoints, energyPoints, powerPercent, priorityLevel);
            }
            return move;
        }

        private Move MakeProtectMove(MySqlDataReader reader, Move moveTwo, String name, String description, int level, String archetype, int energyPoints)
        {
            // primary_move_target, primary_move_accuracy, protect_move_type, succession_percent 
            String primaryMoveTarget = reader.GetString("primary_move_target");
            double primaryMoveAccuracy = reader.GetDouble("primary_move_accuracy");
            ProtectionStatus protectMoveType = MakeProtectionStatus(reader.GetString("protect_move_type"));
            double successionPercent = reader.GetDouble("succession_percent");
            Move move = null;

            if(moveTwo == null)
            {
                move = new ProtectMove(name, description, primaryMoveAccuracy, primaryMoveTarget, level, energyPoints, energyPoints, protectMoveType, successionPercent);
            }
            else
            {
                move = new ProtectMove(moveTwo, name, description, primaryMoveAccuracy, primaryMoveTarget, level, energyPoints, energyPoints, protectMoveType, successionPercent);
            }

            return move;
        }

        private Move MakeRegularMove(MySqlDataReader reader, Move moveTwo, String name, String description, int level, String archetype, int energyPoints)
        {
            // primary_move_target, primary_move_accuracy, power_percent, recoil_damage_percent
            String primaryMoveTarget = reader.GetString("primary_move_target");
            double primaryMoveAccuracy = reader.GetDouble("primary_move_accuracy");
            double powerPercent = reader.GetDouble("power_percent");
            double recoilDamagePercent = reader.GetDouble("recoil_damage_percent");
            ArchetypeID archetypeID = Archetype.GetArchetypeID(archetype);
            Move move = null;

            if(moveTwo == null)
            {
                move = new RegularMove(name, description, primaryMoveAccuracy, primaryMoveTarget, level, archetypeID, energyPoints, energyPoints, powerPercent, recoilDamagePercent);
            }
            else
            {
                move = new RegularMove(moveTwo, name, description, primaryMoveAccuracy, primaryMoveTarget, level, archetypeID, energyPoints, energyPoints, powerPercent, recoilDamagePercent);
            }

            return move;
        }

        private Move MakeStatChangingMove(MySqlDataReader reader, Move moveTwo, String name, String description, int level, String archetype, int energyPoints)
        {
            String secondaryMoveTarget = reader.GetString("secondary_move_target");
            double secondaryMoveAccuracy = reader.GetDouble("secondary_move_accuracy");
            bool isSideEffect = reader.GetBoolean("is_side_effect");
            String statOne = reader.GetString("stat_one");
            String statTwo = reader.GetString("stat_two");
            bool isStatOneBoosted = reader.GetBoolean("is_stat_one_boosting");
            bool isStatTwoBoosted = reader.GetBoolean("is_stat_two_boosting");
            double statOnePercent = reader.GetDouble("stat_one_percent");
            double statTwoPercent = reader.GetDouble("stat_two_percent");
            Move move= new StatChangingMove(name, description, secondaryMoveAccuracy, secondaryMoveTarget, level, energyPoints, energyPoints, MakeStat(statOne, isStatOneBoosted, statOnePercent), MakeStat(statTwo, isStatTwoBoosted, statTwoPercent), isSideEffect);   
            return move;
        }

        private Move MakeStatusChangingMove(MySqlDataReader reader, Move moveTwo, String name, String description, int level, String archetype, int energyPoints)
        {
            // secondary_move_target, secondary_move_accuracy, is_side_effect, status_condition, burn_damage, poison_damage, poison_incrementer, stun_duration, stun_probability
            String secondaryMoveTarget = MySqlDataReader.GetString("secondary_move_target");
            double secondaryMoveAccuracy = MySqlDataReader.GetDouble("secondary_move_accuracy");
            bool isSideEffect = MySqlDataReader.GetBoolean("is_side_effect");
            String statusConditionText = MySqlDataReader.GetString("status_condition");
            double burnDamage = MySqlDataReader.GetDouble("burn_damage");
            double poisonDamage = MySqlDataReader.GetDouble("poison_damage");
            double poisonIncrementer = MySqlDataReader.GetDouble("poison_incrementer");
            int stunDuration = MySqlDataReader.GetInt32("stun_duration");
            double stunProbability = MySqlDataReader.GetDouble("stun_probability");
            StatusCondition statusCondition = MakeStatusCondition(statusConditionText, burnDamage, poisonDamage, poisonIncrementer, stunDuration, stunProbability);
            Move move = new StatusChangingMove(name, description, secondaryMoveAccuracy, secondaryMoveTarget, level, energyPoints, energyPoints, statusCondition, isSideEffect);
            return null;
        }

        private StatusCondition MakeStatusCondition(String statusConditionName, double burnDamage, double poisonDamage, double poisonIncrementer, int stunDuration, double stunProbability)
        {
            StatusCondition statusCondition = null;
            switch(statusConditionName)
            {
                case "BURN":
                if(burnDamage <= 0)
                {
                    statusCondition = new Burn();
                }
                else
                {
                    statusCondition = new Burn(burnDamage);
                }
                break;
                case "POISON":
                if(poisonDamage <= 0 || poisonIncrementer <= 0)
                {
                    statusCondition = new Poison();
                }
                else
                {
                    statusCondition = new Poison(poisonDamage, poisonIncrementer);
                }
                break;
                case "STUN":
                if(stunDuration <= 0 || stunProbability <= 0)
                {
                    statusCondition = new Stun();
                }
                else
                {
                    statusCondition = new Stun(stunDuration, stunProbability);
                }
                break;
                case "FLINCH":
                statusCondition = new Flinch();
                break;
                default:
                statusCondition = null;
                break;
            }
            return statusCondition;
        }

        private StatusCondition MakeStatusCondition(MySqlDataReader reader)
        {
            StatusCondition statusCondition = null;
            String name = reader.GetString(3);

            double burnDamage = reader.GetDouble(4);
            double poisonDamage = reader.GetDouble(5);
            double poisonIncrementer = reader.GetDouble(6);
            int stunDuration = reader.GetInt32(7);
            double stunProbability = reader.GetDouble(8);

            switch(name)
            {
                case "BURN":
                if(burnDamage <= 0)
                {
                    statusCondition = new Burn();
                }
                else
                {
                    statusCondition = new Burn(burnDamage);
                }
                break;
                case "POISON":
                if(poisonDamage <= 0 || poisonDamage <= 0)
                {
                    statusCondition = new Poison();
                }
                else
                {
                    statusCondition = new Poison(poisonDamage, poisonIncrementer);
                }
                break;
                case "STUN":
                if(stunDuration <= 0 || stunProbability <= 0)
                {
                    statusCondition = new Stun();
                }
                else{
                    statusCondition = new Stun(stunDuration, stunProbability);
                }
                break;
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