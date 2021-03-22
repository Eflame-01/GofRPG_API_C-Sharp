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
            ReductionPercent = 0.05;
        }
        
       public override void BoostStat(Character character)
       {
            int boostVal = (int) (character.CharacterBaseStat.Def * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Def += boostVal;
            }
            else
            {
               character.CharacterBaseStat.Def += 1;
            }
       }

        public override void ReduceStat(Character character)
        {
            int boostVal = (int) (character.CharacterBaseStat.Def * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Def -= boostVal;
            }
            else
            {
               character.CharacterBaseStat.Def -= 1;
            }
        }
    }
}