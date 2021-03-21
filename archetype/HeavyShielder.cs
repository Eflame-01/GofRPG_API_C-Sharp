using System;

namespace GofRPG_API
{
    public class HeavyShielder : Archetype
    {
        public HeavyShielder()
        {
            MainArchetypeName = "DEFENDER";
            ArchetypeName = "HEAVY SHIELDER";
            CharacterBaseStat = new BaseStat(4, 9, 3, 4, 5);
            LevelUpBoost1 = new BaseStat(8, 2, 5, 6, 4);
            LevelUpBoost2 = new BaseStat(6, 4, 5, 8, 2);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(4, 6, 5, 2, 8);
            LevelUpBoost5 = new BaseStat(2, 8, 5, 4, 6);
        }
    }
}