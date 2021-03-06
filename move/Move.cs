using System;

namespace GofRPG_API
{
    public abstract class Move
    {
        public String MoveName {get; protected set;}
        public String MoveDescription {get; protected set;}
        public double MovePowerPercent {get; set;}
        public double PrimaryMoveAccuracy {get; protected set;}
        public double SecondaryMoveAccuracy{get; protected set;}
        public String MoveType {get; protected set;}
        public String MoveTarget {get; protected set;}
        public int MoveLevel {get; protected set;}
        public int MoveEnergyPoints {get; protected set;}
        public int MoveMaxEnergyPoints {get; protected set;}
        public ArchetypeID MoveArchetype {get; protected set;}
        public abstract void PerformMove(Character user, Character target);
        public abstract void PerformSideEffect(Character target);
        public abstract bool IsPrimaryMove();
        public abstract void ResetMove();
        public bool DidMoveMiss(Character target)
        {
            if(target == null)
            {
                return true;
            }
            Random rand = new Random();
            double accuracyFailed = 1 - PrimaryMoveAccuracy;
            double targetEvaded = (double)target.CharacterBaseStat.Eva / (double)target.CharacterBaseStat.GetBaseStatTotal();
            double probabilityMoveMissed = accuracyFailed + targetEvaded - (accuracyFailed - targetEvaded);
            return (rand.NextDouble() <= probabilityMoveMissed);
        }
        public bool DidSideEffectMiss()
        {
            Random rand = new Random();
            double probabilityMoveMissed = 1.0 - SecondaryMoveAccuracy;
            return (rand.NextDouble() <= probabilityMoveMissed);
        }

        protected Boolean CanUseMove(Character user, Character target)
        {
            //if the user or target do no exist, the move cannot be done
            if(user == null || target == null)
            {
                return false;
            }
            //if the user or target are unable to fight, the move cannot be done
            if(user.CharacterBaseStat.Hp <=  0 || target.CharacterBaseStat.Hp == 0)
            {
                return false;
            }
            return true;
        }

        protected Boolean CanPerformSideEffect(Character target)
        {
            if(target == null)
            {
                return false;
            }
            if(target.CharacterBaseStat.Hp <= 0)
            {
                return false;
            }
            return true;
        }
    }
}