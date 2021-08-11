using System;

namespace GofRPG_API
{
    public class Defense : Stat
    {
        public Defense(double boost, double reduction)
        {
            StatName = "DEFENSE";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }
        public Defense()
        {
            StatName = "DEFENSE";
            BoostPercent = 0.05;
            ReductionPercent = 0;
        }
        
       public override void BoostStat(Character character)
       {
           if(!CanUpdateStat() || BoostPercent <= 0)
           {
               return;
           }
           int boostVal = Math.Clamp((int) (character.CharacterBaseStat.Def * BoostPercent), 1, character.CharacterBaseStat.Def);
           character.CharacterBaseStat.Def += boostVal;
           StatAmount = boostVal * -1; //amount to decrement when reverting the stat.
       }
        public override void ReduceStat(Character character)
        {
            if(!CanUpdateStat() || ReductionPercent <= 0)
            {
                return;
            }
            int reductionVal = Math.Clamp((int) (character.CharacterBaseStat.Def * ReductionPercent), 1, character.CharacterBaseStat.Def - 1);
            character.CharacterBaseStat.Def -= reductionVal;
            StatAmount = reductionVal; //amount to increment when reverting the stat.
        }

        public override void RevertStat(Character character)
        {
            character.CharacterBaseStat.Def += StatAmount;
        }
    }
}