using System;

namespace GofRPG_API
{
    public interface StatusCondition
    {
        public String getStatusConditionName();
        public void implementStatusCondition(Character character);
        public void removeStatusCondition(Character character);
    }
}