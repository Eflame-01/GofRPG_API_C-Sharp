using System;

namespace GofRPG_API
{
    public class EnergyManipulator : Archetype
    {
        public EnergyManipulator()
        {
            MainArchetypeName = "MYSTIC";
            ArchetypeName = "ENERGY MANIPULATOR";
            CharacterBaseStat = new BaseStat(6, 6, 2, 3, 8);
            LevelUpBoost1 = new BaseStat(7, 3, 5, 6, 4);
            LevelUpBoost2 = new BaseStat(6, 4, 5, 7, 3);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(4, 6, 5, 3, 7);
            LevelUpBoost5 = new BaseStat(4, 6, 5, 4, 6);
        }
    }
}