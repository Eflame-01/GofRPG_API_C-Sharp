using System;

namespace GofRPG_API
{
    public class BattleStatus
    {
        private StatusCondition statusCondition;
        private TurnStatus turnStatus;
        private ProtectionStatus protectionStatus;

        public BattleStatus()
        {

        }

        public StatusCondition getStatusCondition()
        {
            return statusCondition;
        }
        public void setStatusCondition(StatusCondition status)
        {
            statusCondition = status;
        }
        public TurnStatus getTurnStatus()
        {
            return turnStatus;
        }
        public void setTurnStatus(TurnStatus status)
        {
            turnStatus = status;
        }
        public ProtectionStatus getProtectionStatus()
        {
            return protectionStatus;
        }
        public void setProtectionStatus(ProtectionStatus status)
        {
            protectionStatus = status;
        }

        public enum TurnStatus
        {
            SELECTING_ITEM,
            GO_FIRST,
            FIGHTING,
            CANNOT_MOVE,
            NOTHING, 
            FINISHED_TURN
        }

        public enum ProtectionStatus
        {
            PHYSICAL_PROTECT,
            SPECIAL_PROTECT,
            PROTECT,
            COUNTER,
            NOTHING
        }
    }
}