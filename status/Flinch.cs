using System;

namespace GofRPG_API
{
    public class Flinch : StatusCondition
    {
        //Data Member
        public String name = "FLINCH";

        //Constructor
        public Flinch()
        {

        }

        public String getStatusConditionName()
        {
            return name;
        }

        public void implementStatusCondition()
        {
            //TODO: set the turn status to cannot move, then remove the status condition
        }

        public void removeStatusCondition()
        {
            //TODO: remove the status condition from the character
        }

    }
}