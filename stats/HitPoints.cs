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
            ReductionPercent = 0.05;
        }
        
       public override void BoostStat(Character character)
       {
            int boostVal = (int) (character.CharacterBaseStat.Hp * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Hp += boostVal;
            }
            else
            {
               character.CharacterBaseStat.Hp += 1;
            }
       }
        public override void ReduceStat(Character character)
        {
            int boostVal = (int) (character.CharacterBaseStat.Hp * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Hp -= boostVal;
            }
            else
            {
               character.CharacterBaseStat.Hp -= 1;
            }
        }
    }
}