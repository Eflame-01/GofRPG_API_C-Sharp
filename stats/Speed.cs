using System;

namespace GofRPG_API
{
    public class Speed : Stat
    {
        public Speed(double boost, double reduction)
        {
            StatName = "SPEED";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }
        public Speed()
        {
            StatName = "SPEED";
            BoostPercent = 0.05;
            ReductionPercent = 0;
        }
        
       public override void BoostStat(Character character)
       {
           if(!CanUpdateStat() || BoostPercent <= 0)
           {
               return;
           }
           int boostVal = Math.Clamp((int) (character.CharacterBaseStat.Spd * BoostPercent), 1, character.CharacterBaseStat.Spd);
           character.CharacterBaseStat.Spd += boostVal;
           StatAmount = boostVal * -1; //amount to decrement when reverting the stat.
       }
        public override void ReduceStat(Character character)
        {
            if(!CanUpdateStat() || ReductionPercent <= 0)
            {
                return;
            }
            int reductionVal = Math.Clamp((int) (character.CharacterBaseStat.Spd * ReductionPercent), 1, character.CharacterBaseStat.Spd - 1);
            character.CharacterBaseStat.Spd -= reductionVal;
            StatAmount = reductionVal; //amount to increment when reverting the stat.
        }

        public override void RevertStat(Character character)
        {
            character.CharacterBaseStat.Spd += StatAmount;
        }
    }
}