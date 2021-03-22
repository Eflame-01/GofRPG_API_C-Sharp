using System;

namespace GofRPG_API
{
    public interface StatusCondition
    {
        String GetStatusConditionName();
        void ImplementStatusCondition(Character character);
        void RemoveStatusCondition(Character character);
    }
}