using System;

namespace GofRPG_API
{
    public class Evasion : Stat
    {
        public Evasion(double boost, double reduction)
        {
            StatName = "EVASION";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }
        public Evasion()
        {
            StatName = "EVASION";
            BoostPercent = 0.05;
            ReductionPercent = 0;
        }
        
       public override void BoostStat(Character character)
       {
           if(!CanUpdateStat() || BoostPercent <= 0)
           {
               return;
           }
           int boostVal = Math.Clamp((int) (character.CharacterBaseStat.Eva * BoostPercent), 1, character.CharacterBaseStat.Eva);
           character.CharacterBaseStat.Eva += boostVal;
           StatAmount = boostVal * -1; //amount to decrement when reverting the stat.
       }
        public override void ReduceStat(Character character)
        {
            if(!CanUpdateStat() || ReductionPercent <= 0)
            {
                return;
            }
            int reductionVal = Math.Clamp((int) (character.CharacterBaseStat.Eva * ReductionPercent), 1, character.CharacterBaseStat.Eva - 1);
            character.CharacterBaseStat.Eva -= reductionVal;
            StatAmount = reductionVal; //amount to increment when reverting the stat.
        }
        public override void RevertStat(Character character)
        {
            character.CharacterBaseStat.Eva += StatAmount;
        }
    }
}