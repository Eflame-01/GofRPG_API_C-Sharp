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
            ReductionPercent = 0.05;
        }
        
       public override void boostStat(Character character)
       {
            int boostVal = (int) (character.CharacterBaseStat.Eva * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Eva += boostVal;
            }
            else
            {
               character.CharacterBaseStat.Eva += 1;
            }
       }

        public override void reduceStat(Character character)
        {
            int boostVal = (int) (character.CharacterBaseStat.Eva * BoostPercent);
            if(boostVal > 0)
            {
               character.CharacterBaseStat.Eva -= boostVal;
            }
            else
            {
               character.CharacterBaseStat.Eva -= 1;
            }
        }
    }
}