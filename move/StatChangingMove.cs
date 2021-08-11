using System;

namespace GofRPG_API
{
    public class StatChangingMove : SecondaryMove
    {
        Stat StatOne {get; set;}
        Stat StatTwo {get; set;}
        public StatChangingMove(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, Stat statOne, Stat statTwo, bool isSideEffect)
        {
            MoveName = name;
            MoveDescription = description;
            if(isSideEffect)
            {
                SecondaryMoveAccuracy = accuracy;
            }
            else{
                PrimaryMoveAccuracy = accuracy;
            }
            MoveTarget = target;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            StatOne = statOne;
            StatTwo = statTwo;
            IsSideEffect = isSideEffect;
            MoveType = "STAT CHANGING";
        }
        public override void PerformMove(Character user, Character target)
        {
            if(CanUseMove(user, target) && !IsSideEffect)
            {
                if(StatOne != null)
                {
                    StatOne.BoostStat(target);
                    StatOne.ReduceStat(target);
                }
                if(StatTwo != null)
                {
                    StatTwo.BoostStat(target);
                    StatTwo.ReduceStat(target);
                }
            }
        }

        public override void PerformSideEffect(Character target)
        {
            if(CanPerformSideEffect( target) && IsSideEffect)
            {
                if(StatOne != null)
                {
                    StatOne.BoostStat(target);
                    StatOne.ReduceStat(target);
                }
                if(StatTwo != null)
                {
                    StatTwo.BoostStat(target);
                    StatTwo.ReduceStat(target);
                }
            }
        }
    }
}