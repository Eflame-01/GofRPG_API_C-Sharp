using System;

namespace GofRPG_API
{
    public class StatChangingItem : Item
    {
        public Stat StatBoost {get; private set;}
        public Stat StatReduction {get; private set;}
        public int StatBoostDifference {get; private set;}
        public int StatReductionDifference {get; private set;}

        public StatChangingItem(String name, String description, int level, Stat statBoost, Stat statReduction)
        {
            ItemName = name;
            ItemDescription = description;
            ItemID = "STAT CHANGING";
            ItemLevel = level;
            StatBoost = statBoost;
            StatReduction = statReduction;
        }

        public override void UseItem(Character character)
        {
            //TODO: get the base stat of the player
            int stat1 = GetStat(StatBoost, character);
            int stat2 = GetStat(StatReduction, character);
            //TODO: boost/reduce stat of player based on points
            if(StatBoost != null)
            {
                StatBoost.BoostStat(character);
            }
            if(StatReduction != null)
            {
                StatReduction.ReduceStat(character);
            }
            //TODO: calculate the difference and add it to stat boost difference/stat reduction difference
            int boostedStat = GetStat(StatBoost, character);
            int reducedStat = GetStat(StatReduction, character);
            StatBoostDifference = (stat1 - boostedStat); //becomes negative value to subtract it from the base stat later
            StatReductionDifference = (stat2 - reducedStat); //becomes positive value to add it to the base stat later
        }

        public override void StopItemUse(Character character)
        {
            //TODO: subtract the amount of points from the use by the stat boost difference
            RevertStat(StatBoost, character, true);
            //TODO: add the amount of points from the user by the stat reduction difference
            RevertStat(StatReduction, character, false);
        }

        private int GetStat(Stat stat, Character character)
        {
            if(stat == null)
            {
                return 0;
            }
            switch(stat.StatName)
            {
                case "ATTACK":
                return character.CharacterBaseStat.Atk;
                case "DEFENSE":
                return character.CharacterBaseStat.Def;
                case "EVASION":
                return character.CharacterBaseStat.Eva;
                case "HIT POINTS":
                return character.CharacterBaseStat.Hp;
                case "SPEED":
                return character.CharacterBaseStat.Spd;
            }
            return 0;
        }

        private void RevertStat(Stat stat, Character character, bool boosted)
        {
            if(stat == null)
            {
                return;
            }
            switch(stat.StatName)
            {
                case "ATTACK":
                if(boosted)
                {
                    character.CharacterBaseStat.Atk += StatBoostDifference;
                }
                else
                {
                    character.CharacterBaseStat.Atk += StatReductionDifference;
                }
                break;
                case "DEFENSE":
                if(boosted)
                {
                    character.CharacterBaseStat.Atk += StatBoostDifference;
                }
                else
                {
                    character.CharacterBaseStat.Atk += StatReductionDifference;
                }
                break;
                case "EVASION":
                if(boosted)
                {
                    character.CharacterBaseStat.Atk += StatBoostDifference;
                }
                else
                {
                    character.CharacterBaseStat.Atk += StatReductionDifference;
                }
                break;
                case "HIT POINTS":
                if(boosted)
                {
                    character.CharacterBaseStat.Atk += StatBoostDifference;
                }
                else
                {
                    character.CharacterBaseStat.Atk += StatReductionDifference;
                }
                break;
                case "SPEED":
                if(boosted)
                {
                    character.CharacterBaseStat.Atk += StatBoostDifference;
                }
                else
                {
                    character.CharacterBaseStat.Atk += StatReductionDifference;
                }
                break;
            }
        }
    }
}