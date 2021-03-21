using System;

namespace GofRPG_API
{
    public class BattleStatus
    {

        public StatusCondition StatusCondition {get; set;}
        public TurnStatus TurnStatus {get; set;}
        public ProtectionStatus ProtectionStatus {get; set;}

        public BattleStatus()
        {
            StatusCondition = null;
            TurnStatus = TurnStatus.NOTHING;
            ProtectionStatus = ProtectionStatus.NOTHING;
        }
    }
}