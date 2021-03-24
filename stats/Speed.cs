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
            ReductionPercent = 0.05;
        }
        
        public override void BoostStat(Character character)
        {
            int boostVal = (int) (character.CharacterBaseStat.Spd * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Spd += boostVal;
            }
            else
            {
               character.CharacterBaseStat.Spd += 1;
            }
        }
        public override void ReduceStat(Character character)
        {
            int boostVal = (int) (character.CharacterBaseStat.Spd * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Spd -= boostVal;
            }
            else
            {
               character.CharacterBaseStat.Spd -= 1;
            }
        }
    }
}