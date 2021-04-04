using System;

namespace GofRPG_API
{
    public class Berserker : Archetype
    {
        public Berserker()
        {
            ArchetypeID = ArchetypeID.BERSERKER;
            MainArchetypeName = "BRAWLER";
            ArchetypeName = "BERSERKER";
            CharacterBaseStat = new BaseStat(7, 5, 2, 8, 3);
            LevelUpBoost1 = new BaseStat(4, 6, 5, 3, 7);
            LevelUpBoost2 = new BaseStat(3, 7, 5, 4, 6);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(7, 3, 5, 6, 4);
            LevelUpBoost5 = new BaseStat(6, 4, 5, 7, 3);
        }
    }
}