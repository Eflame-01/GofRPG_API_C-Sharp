using System;

namespace GofRPG_API
{
    public class RegularSwordsman : Archetype
    {
        public RegularSwordsman()
        {
            ArchetypeID = ArchetypeID.REGULAR_SWORDSMAN;
            MainArchetypeName = "SWORDSMAN";
            ArchetypeName = "REGULAR SOWRDSMAN";
            CharacterBaseStat = new BaseStat(8, 3, 3, 6, 5);
            LevelUpBoost1 = new BaseStat(3, 7, 5, 4, 6);
            LevelUpBoost2 = new BaseStat(4, 6, 5, 3, 7);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(6, 4, 5, 3, 7);
            LevelUpBoost5 = new BaseStat(7, 3, 5, 6, 4);
        }
    }
}