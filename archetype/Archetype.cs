using System;

namespace GofRPG_API
{
    public abstract class Archetype
    {
        public BaseStat CharacterBaseStat {get; protected set;}
        public BaseStat LevelUpBoost1 {get; protected set;}
        public BaseStat LevelUpBoost2 {get; protected set;}
        public BaseStat LevelUpBoost3 {get; protected set;}
        public BaseStat LevelUpBoost4 {get; protected set;}
        public BaseStat LevelUpBoost5 {get; protected set;}
        public String ArchetypeName {get; protected set;}
        public String MainArchetypeName {get; protected set;}

        public void AddPlayerBaseStats()
        {
            Player player = Player.GetInstance();
            if(player.CharacterLevel == 1)
            {
                player.CharacterBaseStat = CharacterBaseStat;
            }
        }

        public void LevelUpPlayerStats()
        {
            Random rand = new Random();
            double levelUpProbability = rand.NextDouble();

            if(levelUpProbability <= 0.05)
            {
                AddBaseStats(LevelUpBoost1);
            }
            else if(levelUpProbability <= 0.15)
            {
                AddBaseStats(LevelUpBoost2);
            }
            else if(levelUpProbability <= 0.30)
            {
                AddBaseStats(LevelUpBoost3);
            }
            else if(levelUpProbability <= 0.60)
            {
                AddBaseStats(LevelUpBoost4);
            }
            else if(levelUpProbability <= 1.0)
            {
                AddBaseStats(LevelUpBoost5);
            }
        }

        private void AddBaseStats(BaseStat baseStat)
        {
            Player player = Player.GetInstance();
            player.CharacterBaseStat.FullAtk += baseStat.Atk;
            player.CharacterBaseStat.FullDef += baseStat.Def;
            player.CharacterBaseStat.FullEva += baseStat.Eva;
            player.CharacterBaseStat.FullSpd += baseStat.Spd;
            player.CharacterBaseStat.FullHp += baseStat.Hp;
            player.CharacterBaseStat.Atk += baseStat.Atk;
            player.CharacterBaseStat.Def += baseStat.Def;
            player.CharacterBaseStat.Eva += baseStat.Eva;
            player.CharacterBaseStat.Spd += baseStat.Spd;
            player.CharacterBaseStat.Hp += baseStat.Hp;
        }
        
        public static Archetype GetArchetype(String name)
        {
            switch(name)
            {
                case "REGULAR SWORDSMAN":
                return new RegularSwordsman();
                case "DUAL SWORDSMAN":
                return new DualSwordsman();
                case "KNIGHT":
                return new Knight();
                case "HEAVY SHIELDER":
                return new HeavyShielder();
                case "NATURE MANIPULATOR":
                return new NatureManipulator();
                case "ENERGY MANIPULATOR":
                return new EnergyManipulator();
                case "BERSERKER":
                return new Berserker();
                case "MIXED MARTIAL ARTIST":
                return new MixedMartialArtist();
                case "WEAPON SPECIALIST":
                return new WeaponSpecialist();
                case "COMBAT SPECIALIST":
                return new CombatSpecialist();
            }
            return null;
        }
    }
}