using System;

namespace GofRPG_API
{
    public interface StatusCondition
    {
        //Methods to be overridden 
        public String getStatusConditionName();
        public void implementStatusCondition();
        public void removeStatusCondition();
    }
}