using System;

namespace GofRPG_API
{
    public class Stun : StatusCondition
    {
        public int StunDuration {get; private set;}
        public double StunProbability {get; private set;}
        private int _tempStunDuration = 0;
        private Stat _speedStat = new Speed(0, 0.05);
        private Boolean _implementedSpeedDefbuff = false;

        public Stun(int duration, double probability)
        {
            StunDuration = Math.Clamp(duration, 3, 10);
            StunProbability = Math.Clamp(probability, 0.25, 0.75);
            _tempStunDuration = StunDuration;
        }
        public Stun()
        {
            StunDuration = 3;
            StunProbability = 0.25;
            _tempStunDuration = 3;
        }

        public String GetStatusConditionName()
        {
            return "STUN";
        }
        public void ImplementStatusCondition(Character character)
        {
            if(character.CharacterBattleStatus.StatusCondition.Equals(this) && _tempStunDuration > 0)
            {
                if(_implementedSpeedDefbuff)
                {
                    ImplementSpeedBuff(character);
                }
                if(CharacterIsStunned())
                {
                    character.CharacterBattleStatus.TurnStatus = TurnStatus.CANNOT_MOVE;
                }
                if(--_tempStunDuration <= 0)
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
                _speedStat.RevertStat(character);
                _tempStunDuration = StunDuration;
            }
        }
        private Boolean CharacterIsStunned()
        {
            Random rand = new Random();
            return rand.NextDouble() <= StunProbability;
        }
        private void ImplementSpeedBuff(Character character)
        {
            _speedStat.ReduceStat(character);
            _implementedSpeedDefbuff = true;
        }
    }
}