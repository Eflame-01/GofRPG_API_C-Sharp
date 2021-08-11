using System;

namespace GofRPG_API
{
    public class HitPoints : Stat
    {
        public HitPoints(double boost, double reduction)
        {
            StatName = "HIT POINTS";
            BoostPercent = boost;
            ReductionPercent = reduction;

        }
        public HitPoints()
        {
            StatName = "HIT POINTS";
            BoostPercent = 0.05;
            ReductionPercent = 0;
        }
        
       public override void BoostStat(Character character)
       {
           if(!CanUpdateStat() || BoostPercent <= 0)
           {
               return;
           }
           int boostVal = Math.Clamp((int) (character.CharacterBaseStat.Hp * BoostPercent), 1, character.CharacterBaseStat.Hp);
           character.CharacterBaseStat.Hp += boostVal;
           StatAmount = boostVal * -1; //amount to decrement when reverting the stat.
       }
        public override void ReduceStat(Character character)
        {
            if(!CanUpdateStat() || ReductionPercent <= 0)
            {
                return;
            }
            int reductionVal = Math.Clamp((int) (character.CharacterBaseStat.Hp * ReductionPercent), 1, character.CharacterBaseStat.Hp - 1);
            character.CharacterBaseStat.Hp -= reductionVal;
            StatAmount = reductionVal; //amount to increment when reverting the stat.
        }

        public override void RevertStat(Character character)
        {
            character.CharacterBaseStat.Hp += StatAmount;
        }
    }
}