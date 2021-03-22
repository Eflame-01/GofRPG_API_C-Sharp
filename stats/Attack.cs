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
        }

        public Attack()
        {
            StatName = "ATTACK";
            BoostPercent = 0.05;
            ReductionPercent = 0.05;
        }
        
       public override void BoostStat(Character character)
       {
           int boostVal = (int) (character.CharacterBaseStat.Atk * BoostPercent);
           if(boostVal > 0)
           {
               character.CharacterBaseStat.Atk += boostVal;
           }
           else
           {
               character.CharacterBaseStat.Atk += 1;
           }
       }

        public override void ReduceStat(Character character)
        {
            int boostVal = (int) (character.CharacterBaseStat.Atk * BoostPercent);
            if(boostVal > 0)
            {
                character.CharacterBaseStat.Atk -= boostVal;
            }
            else
            {
               character.CharacterBaseStat.Atk -= 1;
            }
        }
    }
}