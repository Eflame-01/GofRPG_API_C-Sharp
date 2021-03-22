using System;

namespace GofRPG_API
{
    public class Flinch : StatusCondition
    {
        public String StatusName
        {
            get
            {
                return "FLINCH";
            }
        }

        //Constructor
        public Flinch()
        {

        }

        public String GetStatusConditionName()
        {
            return StatusName;
        }

        public void ImplementStatusCondition(Character character)
        {
            //TODO: set the turn status to cannot move, then remove the status condition
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                character.CharacterBattleStatus.TurnStatus = TurnStatus.CANNOT_MOVE;
            }
            RemoveStatusCondition(character);
        }

        public void RemoveStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }
    }
}