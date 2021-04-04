using System;

namespace GofRPG_API
{
    public class MixedMartialArtist : Archetype
    {
        public MixedMartialArtist()
        {
            ArchetypeID = ArchetypeID.MIXED_MARTIAL_ARTIST;
            MainArchetypeName = "BRAWLER";
            ArchetypeName = "MIXED MARTIAL ARTIST";
            CharacterBaseStat = new BaseStat(6, 5, 2, 7, 4);
            LevelUpBoost1 = new BaseStat(3, 7, 5, 4, 6);
            LevelUpBoost2 = new BaseStat(4, 6, 5, 3, 7);
            LevelUpBoost3 = new BaseStat(5, 5, 5, 5, 5);
            LevelUpBoost4 = new BaseStat(6, 4, 5, 7, 3);
            LevelUpBoost5 = new BaseStat(6, 4, 5, 6, 4);
        }
    }
}