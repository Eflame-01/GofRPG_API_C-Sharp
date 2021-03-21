using System;

namespace GofRPG_API
{
    public class CombatSpecialist : Archetype
    {
        public CombatSpecialist()
        {
            MainArchetypeName = "SPECIALST";
            ArchetypeName = "COMBAT SPECIALIST";
            CharacterBaseStat = new BaseStat(4, 6, 5, 6, 4);
            LevelUpBoost1 = new BaseStat(6, 6, 1, 6, 6);
            LevelUpBoost2 = new BaseStat(5, 5, 3, 6, 6);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(5, 5, 7, 4, 4);
            LevelUpBoost5 = new BaseStat(6, 6, 7, 3, 3);
        }
    }
}