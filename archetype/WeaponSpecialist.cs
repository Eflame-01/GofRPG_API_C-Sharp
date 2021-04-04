using System;

namespace GofRPG_API
{
    public class WeaponSpecialist : Archetype
    {
        public WeaponSpecialist()
        {
            ArchetypeID = ArchetypeID.WEAPON_SPECIALIST;
            MainArchetypeName = "SPECIALST";
            ArchetypeName = "WEAPON SPECIALIST";
            CharacterBaseStat = new BaseStat(6, 4, 5, 4, 6);
            LevelUpBoost1 = new BaseStat(6, 6, 1, 6, 6);
            LevelUpBoost2 = new BaseStat(5, 5, 3, 5, 7);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(5, 4, 6, 3, 7);
            LevelUpBoost5 = new BaseStat(3, 3, 7, 6, 6);
        }
    }
}