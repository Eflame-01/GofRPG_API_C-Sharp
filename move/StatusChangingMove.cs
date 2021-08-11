using System;

namespace GofRPG_API
{
    public class StatusChangingMove : SecondaryMove
    {
        public StatusCondition StatusCondition {get; set;}
        public StatusChangingMove(String name, String description, double accuracy, String target, int level, int energyPoints, int maxEnergyPoints, StatusCondition statusCondition, bool isSideEffect)
        {
            MoveName = name;
            MoveDescription = description;
            if(isSideEffect)
            {
                SecondaryMoveAccuracy = accuracy;
            }
            else
            {
                PrimaryMoveAccuracy = accuracy;
            }
            MoveTarget = target;
            MoveLevel = level;
            MoveEnergyPoints = energyPoints;
            MoveMaxEnergyPoints = maxEnergyPoints;
            StatusCondition = statusCondition;
            IsSideEffect = isSideEffect;
            MoveType = "STATUS CHANGING";
        }
        public override void PerformMove(Character user, Character target)
        {
            if(CanUseMove(user, target) && !IsSideEffect && target.CharacterBattleStatus.StatusCondition == null)
            {
                target.CharacterBattleStatus.StatusCondition = StatusCondition;
            }
        }
        public override void PerformSideEffect(Character target)
        {
            if(CanPerformSideEffect(target) && IsSideEffect && target.CharacterBattleStatus.StatusCondition != null)
            {
                target.CharacterBattleStatus.StatusCondition = StatusCondition;
            }
        }
    }
}