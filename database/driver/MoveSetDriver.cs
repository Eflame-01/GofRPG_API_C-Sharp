using System;
using MySql.Data.MySqlClient;

namespace GofRPG_API
{
    public class MoveSetDriver : DatabaseDriver
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
                String moveOneName = MySqlDataReader.GetString(1);
                String moveTwoName = MySqlDataReader.GetString(2);
                String moveThreeName = MySqlDataReader.GetString(3);
                String moveFourName = MySqlDataReader.GetString(4);

                Move moveOne = _moveDriver.GetMove(moveOneName);
                Move moveTwo = _moveDriver.GetMove(moveTwoName);
                Move moveThree = _moveDriver.GetMove(moveThreeName);
                Move moveFour = _moveDriver.GetMove(moveFourName);

                moveSet.AddMoveToBattleSlot(moveOne);
                moveSet.AddMoveToList(moveOne);
                moveSet.AddMoveToBattleSlot(moveTwo);
                moveSet.AddMoveToList(moveTwo);
                moveSet.AddMoveToBattleSlot(moveThree);
                moveSet.AddMoveToList(moveThree);
                moveSet.AddMoveToBattleSlot(moveFour);
                moveSet.AddMoveToList(moveFour);
            }
            return moveSet;
        }
    }
}