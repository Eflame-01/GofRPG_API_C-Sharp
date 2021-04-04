using System;

namespace GofRPG_API
{
    public class NatureManipulator : Archetype
    {
        public NatureManipulator()
        {
            ArchetypeID = ArchetypeID.NATURE_MANIPULATOR;
            MainArchetypeName = "MYSTIC";
            ArchetypeName = "NATURE MANIPULATOR";
            CharacterBaseStat = new BaseStat(6, 5, 2, 2, 10);
            LevelUpBoost1 = new BaseStat(6, 4, 5, 7, 3);
            LevelUpBoost2 = new BaseStat(7, 3, 5, 6, 4);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(3, 7, 5, 4, 6);
            LevelUpBoost5 = new BaseStat(4, 6, 5, 3, 7);
        }
    }
}