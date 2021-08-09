using System;
using System.Collections.Generic;

namespace GofRPG_API
{
    public class BattleStatus
    {
        public StatusCondition StatusCondition {get; set;}
        public TurnStatus TurnStatus {get; set;}
        public ProtectionStatus ProtectionStatus {get; set;}
        public Move ChosenMove {get; set;}
        public List<Character> ChosenTargets {get; private set;}

        public BattleStatus()
        {
            StatusCondition = null;
            TurnStatus = TurnStatus.NOTHING;
            ProtectionStatus = ProtectionStatus.NOTHING;
            ChosenMove = null;
            ChosenTargets = new List<Character>();
        }
    }
}