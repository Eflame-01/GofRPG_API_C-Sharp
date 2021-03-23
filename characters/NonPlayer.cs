using System;

namespace GofRPG_API
{
    public class NonPlayer : Character
    {
        public NonPlayer(String name, String sex, int gold, int level, Archetype archetype, MoveSet moveSet, String type, BaseStat baseStat, BattleStatus battleStatus, Item item, String id)
        {
            CharacterName = name;
            CharacterSex = sex;
            CharacterGold = gold;
            CharacterLevel = level;
            CharacterArchetype = archetype;
            CharacterMoveSet = moveSet;
            CharacterBaseStat = baseStat;
            CharacterBattleStatus = battleStatus;
            CharacterItem = item;
            SetCharacterType(type);
            CharacterID = id;
        }
        public void SetCharacterID(String id)
        {
            CharacterID = id;
        }
        public void SetCharacterType(string type)
        {
            if(type.Equals("ALLY") || type.Equals("ENEMY") || type.Equals("STRANGER"))
            {
                CharacterType = type;
            }
            else
            {
                CharacterType = "STRANGER";
            }
        }
    }
}