using System;

namespace GofRPG_API
{
    public class Flinch : StatusCondition
    {
        public Flinch()
        {

        }

        public String GetStatusConditionName()
        {
            return "FLICH";
        }
        public void ImplementStatusCondition(Character character)
        {
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