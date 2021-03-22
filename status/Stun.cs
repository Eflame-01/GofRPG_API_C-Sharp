using System;

namespace GofRPG_API
{
    public class Stun : StatusCondition
    {
        public String StatusName
        {
            get
            {
                return "STUN";
            }
        }
        public int StunDuration {get; set;}
        public double StunProbability {get; set;}

        //Constructors
        public Stun(int duration, double probability)
        {
            StunDuration = SetStunDuration(duration);
            StunProbability = SetStunProbability(probability);
        }
        public Stun()
        {
            StunDuration = 3;
            StunProbability = 0.25;
        }

        //Override Methods
        public String GetStatusConditionName()
        {
            return StatusName;
        }
        public void ImplementStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this) || StunDuration > 0)
            {
                Random rand = new Random();
                if(rand.NextDouble() <= StunProbability)
                {
                    character.CharacterBattleStatus.TurnStatus = TurnStatus.CANNOT_MOVE;
                }
                StunDuration -= 1;
                if(StunDuration <= 0)
                {
                    RemoveStatusCondition(character);
                }
            }
        }
        public void RemoveStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this))
            {
                character.CharacterBattleStatus.StatusCondition = null;
            }
        }

        //Private Methods
        private int SetStunDuration(int duration)
        {
            if(duration < 3){
                duration = 3;
            }
            else if(duration > 10){
                duration = 10;
            }
            return duration;
        }
        private double SetStunProbability(double probability)
        {
            if(probability < 0.25){
                probability = 0.25;
            }
            else if(probability > 0.75){
                probability = 0.75;
            }
            return probability;
        }
    }
}