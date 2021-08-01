using System;

namespace GofRPG_API
{
    public class Knight : Archetype
    {
        public Knight()
        {
            ArchetypeID = ArchetypeID.KNIGHT;
            MainArchetypeName = "DEFENDER";
            ArchetypeName = "KNIGHT";
            CharacterBaseStat = new BaseStat(4, 8, 3, 4, 6);
            LevelUpBoost1 = new BaseStat(7, 3, 5, 6, 4);
            LevelUpBoost2 = new BaseStat(6, 4, 5, 7, 3);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(4, 6, 5, 7, 3);
            LevelUpBoost5 = new BaseStat(3, 7, 5, 4, 6);
        }
    }
}