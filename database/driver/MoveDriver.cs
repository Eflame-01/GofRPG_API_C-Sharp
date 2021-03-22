using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace GofRPG_API
{
    public class MoveDriver : DatabaseDriver
    {
        public Move GetMove(String name)
        {
            Move move = null;

            //Create the query that allows you to get the data of a specific move based on the name.
            SqlQuery = "SELECT * FROM move WHERE move_name = '" + name + "'";

            //Run the command and gather the data
            SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
            SqlDataReader = SqlCommand.ExecuteReader();
            if(SqlDataReader.Read())
            {
                String moveName = SqlDataReader.GetString(0);
                String moveDescription = SqlDataReader.GetString(1);
                String moveTypeOne = SqlDataReader.GetString(2);
                String moveTypeTwo = SqlDataReader.GetString(3);
                int moveLevel = SqlDataReader.GetInt32(4);
                String moveArchetype = SqlDataReader.GetString(5);
                int moveEnergyPoints = SqlDataReader.GetInt32(6);

                //Make the move based on the general data
                move = MakeMove(moveName, moveDescription, moveTypeOne, moveTypeTwo, moveLevel, moveArchetype, moveEnergyPoints);
            }

            return move;
        }

        public List<Move> GetMoves()
        {
            List<Move> list = new List<Move>();
            Player player = Player.GetInstance();

            //Create the query that allows you to get the list of data of moves based on level and archetype
            SqlQuery = "SELECT * FROM move WHERE move_level <= " + player.CharacterLevel + " AND (move_archetype = " + player.CharacterArchetype.ArchetypeName + " OR move_archetype = " +  player.CharacterArchetype.MainArchetypeName + ")";

            //Run the command and gather the data
            SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
            SqlDataReader = SqlCommand.ExecuteReader();
            while(SqlDataReader.NextResult())
            {
                String moveName = SqlDataReader.GetString(0);
                String moveDescription = SqlDataReader.GetString(1);
                String moveTypeOne = SqlDataReader.GetString(2);
                String moveTypeTwo = SqlDataReader.GetString(3);
                int moveLevel = SqlDataReader.GetInt32(4);
                String moveArchetype = SqlDataReader.GetString(5);
                int moveEnergyPoints = SqlDataReader.GetInt32(6);

                //Make the move based on the general data
                Move move = MakeMove(moveName, moveDescription, moveTypeOne, moveTypeTwo, moveLevel, moveArchetype, moveEnergyPoints);

                //Add the move to the list of moves the player can learn
                list.Add(move);
            }
            return list;
        }

        private Move MakeMove(String name, String description, String typeOne, String typeTwo, int level, String Archetype, int energyPoints)
        {
            //Making the secondary move if this move has one
            Move moveTwo = null;
            SqlCommand commandOne;
            SqlDataReader readerOne;
            switch(typeTwo)
            {
                case "STAT CHANGING":
                SqlQuery = MakeMoveQuery("secondary_move_target, secondary_move_accuracy, is_side_effect, stat_one, stat_two, is_stat_one_boosting, is_stat_two_boosting, stat_one_percent, stat_two_percent", "move INNER JOIN secondary_move ON(move.move_name = secondary_move.move_name) INNER JOIN stat_changing_move ON(move.move_name = stat_changing_move.move_name)", name);
                commandOne = new SqlCommand(SqlQuery, SqlConnection);
                readerOne = commandOne.ExecuteReader();
                if(readerOne.Read())
                {
                    moveTwo = new StatChangingMove(name, description, readerOne.GetDouble(1), readerOne.GetString(0), level, energyPoints, energyPoints, MakeStatBoost(readerOne), MakeStatReduction(readerOne), readerOne.GetBoolean(2));
                }
                break;

                case "STATUS CHANGING":
                SqlQuery = MakeMoveQuery("secondary_move_target, secondary_move_accuracy, is_side_effect, status_condition, burn_damage, poison_damage, poison_incrementer, stun_duration, stun_probability", "move INNER JOIN secondary_move ON(move.move_name = secondary_move.move_name) INNER JOIN status_changing_move ON(move.move_name = status_changing_move.move_name)", name);
                commandOne = new SqlCommand(SqlQuery, SqlConnection);
                readerOne = commandOne.ExecuteReader();
                if(readerOne.Read())
                {
                    moveTwo = new StatusChangingMove(name, description, readerOne.GetDouble(1), readerOne.GetString(0), level, energyPoints, energyPoints, MakeStatusCondition(readerOne), readerOne.GetBoolean(2));
                }
                break;
            }

            //making the primary move
            Move moveOne = null;
            SqlCommand commandTwo;
            SqlDataReader readerTwo;
            switch(typeOne)
            {
                case "REGULAR":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy, power_percent, recoil_damage_percent", "move INNER JOIN primary_move ON(move.move_name = primary_move.move_name) INNER JOIN physical_move ON(move.move_name = physical_move.move_name) INNER JOIN regular_move ON(move.move_name = regular_move.move_name)", name);
                commandTwo = new SqlCommand(SqlQuery, SqlConnection);
                readerTwo = commandTwo.ExecuteReader();
                if(readerTwo.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new RegularMove(moveTwo, name, description, readerTwo.GetDouble(1),  readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2), readerTwo.GetDouble(3));
                    }
                    else
                    {
                        moveOne = new RegularMove(name,  description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2), readerTwo.GetDouble(3));
                    }
                }
                break;

                case "COUNTER":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy, power_percent", "move INNER JOIN physical_move ON(move.move_name = physical_move.move_name) INNER JOIN counter_move ON(move.move_name = counter_move.move_name)", name);
                commandTwo = new SqlCommand(SqlQuery, SqlConnection);
                readerTwo = commandTwo.ExecuteReader();
                if(readerTwo.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new CounterMove(moveTwo, name, description, readerTwo.GetDouble(2), readerTwo.GetString(0), level, energyPoints, energyPoints);
                    }
                    else
                    {
                        moveOne = new CounterMove(name, description, readerTwo.GetDouble(2), readerTwo.GetString(0), level, energyPoints, energyPoints);
                    }
                }
                break;

                case "PRIORITY":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy, power_percent, priority_level", "move INNER JOIN physical_move ON(move.move_name = physical_move.move_name) INNER JOIN priority_move ON(move.move_name = priority_move.move_name)", name);
                commandTwo = new SqlCommand(SqlQuery, SqlConnection);
                readerTwo = commandTwo.ExecuteReader();
                if(readerTwo.Read())
                {
                    int priorityLevel = readerTwo.GetInt32(3);
                    if(moveTwo != null)
                    {
                        switch(priorityLevel)
                        {
                            case 1:
                            moveOne = new Priority1(moveTwo, name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2));
                            break;
                            case 2:
                            moveOne = new Priority2(moveTwo, name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2));
                            break;
                            case 3:
                            moveOne = new Priority3(moveTwo, name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2));
                            break;
                        }
                    }
                    else
                    {
                        switch(priorityLevel)
                        {
                            case 1:
                            moveOne = new Priority1(name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2));
                            break;
                            case 2:
                            moveOne = new Priority2(name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2));
                            break;
                            case 3:
                            moveOne = new Priority3(name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, readerTwo.GetDouble(2));
                            break;
                        }
                    }
                }
                break;

                case "PROTECT":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy, protect_move_type, succession_percent", "move INNER JOIN primary_move ON(move.move_name = primary_move.move_name) INNER JOIN protect_move ON(move.move_name = protect_move.move_name)", name);
                commandTwo = new SqlCommand(SqlQuery, SqlConnection);
                readerTwo = commandTwo.ExecuteReader();
                if(readerTwo.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new ProtectMove(moveTwo, name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, MakeProtectionStatus(readerTwo.GetString(2)), readerTwo.GetDouble(3));
                    }
                    else
                    {
                        moveOne = new ProtectMove(name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, MakeProtectionStatus(readerTwo.GetString(2)), readerTwo.GetDouble(3));
                    }
                }
                break;

                case "KNOCK OUT":
                SqlQuery = MakeMoveQuery("primary_move_target, primary_move_accuracy", "move INNER JOIN primary_move ON(move.move_name = primary_move.move_name) INNER JOIN knock_out_move ON(move.move_name = knock_out_move.move_name)", name);
                commandTwo = new SqlCommand(SqlQuery, SqlConnection);
                readerTwo = commandTwo.ExecuteReader();
                if(readerTwo.Read())
                {
                    if(moveTwo != null)
                    {
                        moveOne = new KnockoutMove(moveTwo, name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints);
                    }
                    else
                    {
                        moveOne = new KnockoutMove(name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints);
                    }
                }
                break;

                case "STAT CHANGING":
                SqlQuery = MakeMoveQuery("secondary_move_target, secondary_move_accuracy, is_side_effect, stat_one, stat_two, is_stat_one_boosting, is_stat_two_boosting, stat_one_percent, stat_two_percent", "move INNER JOIN secondary_move ON (move.move_name = secondary_move.move_name) INNER JOIN stat_changing_move ON (move.move_name = stat_changing_move.move_name)", name);
                commandTwo = new SqlCommand(SqlQuery, SqlConnection);
                readerTwo = commandTwo.ExecuteReader();
                if(readerTwo.Read())
                {
                    moveOne = new StatChangingMove(name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, MakeStatBoost(readerTwo), MakeStatReduction(readerTwo), readerTwo.GetBoolean(2));
                }
                break;

                case "STATUS CHANGING":
                SqlQuery = MakeMoveQuery("secondary_move_target, secondary_move_accuracy, is_side_effect, status_condition, burn_damage, poison_damage, poison_incrementer, stun_duration, stun_probability", "move INNER JOIN secondary_move ON (move.move_name = secondary_move.move_name) INNER JOIN status_changing_move ON (move.move_name = status_changing_move.move_name)", name);
                commandTwo = new SqlCommand(SqlQuery, SqlConnection);
                readerTwo = commandTwo.ExecuteReader();
                if(readerTwo.Read())
                {
                    moveOne = new StatusChangingMove(name, description, readerTwo.GetDouble(1), readerTwo.GetString(0), level, energyPoints, energyPoints, MakeStatusCondition(readerTwo), readerTwo.GetBoolean(2));
                }
                break;
            }

            return moveOne;
        }

        private String MakeMoveQuery(String attributes, String location, String name)
        {
            return "SELECT " + attributes + " FROM " + location + " WHERE move.move_name = '" + name + "'";
        }

        private StatusCondition MakeStatusCondition(SqlDataReader reader)
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

        private Stat MakeStatBoost(SqlDataReader reader)
        {
            Stat statBoost = null;
            if(reader.GetBoolean(5))
            {
                statBoost = Stat.GetStat(reader.GetString(3), reader.GetDouble(7), 0);
            }
            else if(reader.GetBoolean(6))
            {
                statBoost = Stat.GetStat(reader.GetString(4), reader.GetDouble(8), 0);
            }
            return statBoost;
        }

        private Stat MakeStatReduction(SqlDataReader reader)
        {
            Stat statReduction = null;
            if(!reader.GetBoolean(5))
            {
                statReduction = Stat.GetStat(reader.GetString(3), 0, reader.GetDouble(7));
            }
            else if(!reader.GetBoolean(6))
            {
                statReduction = Stat.GetStat(reader.GetString(4), 0, reader.GetDouble(8));
            }
            return statReduction;
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