using System;

namespace GofRPG_API
{
    public enum TurnStatus
    {
        SELECTING_ITEM,
        GO_FIRST,
        FIGHTING,
        CANNOT_MOVE,
        NOTHING, 
        FINISHED_TURN
    }
}