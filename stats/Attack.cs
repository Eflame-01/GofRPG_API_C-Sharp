using System;

namespace GofRPG_API
{
    public class Attack : Stat
    {
        public Attack(double boost, double reduction)
        {
            StatName = "ATTACK";
            BoostPercent = boost;
            ReductionPercent = reduction;
            StatAmount = 0;
        }
        public Attack()
        {
            StatName = "ATTACK";
            BoostPercent = 0.05;
            ReductionPercent = 0;
            StatAmount = 0;
        }
        
       public override void BoostStat(Character character)
       {
           if(!CanUpdateStat() || BoostPercent <= 0)
           {
               return;
           }
           int boostVal = Math.Clamp((int) (character.CharacterBaseStat.Atk * BoostPercent), 1, character.CharacterBaseStat.Atk);
           character.CharacterBaseStat.Atk += boostVal;
           StatAmount = boostVal * -1; //amount to decrement when reverting the stat.
       }
        public override void ReduceStat(Character character)
        {
            if(!CanUpdateStat() || ReductionPercent <= 0)
            {
                return;
            }
            int reductionVal = Math.Clamp((int) (character.CharacterBaseStat.Atk * ReductionPercent), 1, character.CharacterBaseStat.Atk - 1);
            character.CharacterBaseStat.Atk -= reductionVal;
            StatAmount = reductionVal; //amount to increment when reverting the stat.
        }

        public override void RevertStat(Character character)
        {
            character.CharacterBaseStat.Atk += StatAmount;
        }
    }
}