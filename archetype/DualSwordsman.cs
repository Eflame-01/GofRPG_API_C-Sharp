using System;

namespace GofRPG_API
{
    public class DualSwordsman : Archetype
    {
        public DualSwordsman()
        {
            MainArchetypeName = "SWORDSMAN";
            ArchetypeName = "DUAL SWORDSMAN";
            CharacterBaseStat = new BaseStat(10, 3, 3, 5, 4);
            LevelUpBoost1 = new BaseStat(2, 8, 5, 4, 6);
            LevelUpBoost2 = new BaseStat(4, 6, 5, 2, 8);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(6, 4, 5, 8, 2);
            LevelUpBoost5 = new BaseStat(8, 2, 5, 6, 4);
        }
    }
}