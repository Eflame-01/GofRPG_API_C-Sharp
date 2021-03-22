using System;

namespace GofRPG_API
{
    public class StatChangingMove : SecondaryMove
    {
        Stat StatBoost {get; set;}
        Stat StatReduction {get; set;}
        public StatChangingMove(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, Stat statBoost, Stat statReduction, bool isSideEffect)
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
            StatBoost = statBoost;
            StatReduction = statReduction;
            IsSideEffect = isSideEffect;
            MoveType = "STAT CHANGING";
        }
        public override void PerformMove(Character user, Character target)
        {
            if(user == null || target == null || IsSideEffect)
            {
                return;
            }
            if(StatBoost != null)
            {
                StatBoost.BoostStat(target);
            }
            if(StatReduction != null){
                StatReduction.ReduceStat(target);
            }
        }

        public override void PerformSideEffect(Character target)
        {
            if(target == null || !IsSideEffect)
            {
                return;
            }
            if(StatBoost != null)
            {
                StatBoost.BoostStat(target);
            }
            if(StatReduction != null){
                StatReduction.ReduceStat(target);
            }
        }
    }
}