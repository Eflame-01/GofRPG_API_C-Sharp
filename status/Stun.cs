using System;

namespace GofRPG_API
{
    public class Stun : StatusCondition
    {
        //Data Members
        public String name = "STUN";
        private int stunDuration;
        private double stunProbability;

        //Constructors
        public Stun(int duration, double probability)
        {
            stunDuration = setStunDuration(duration);
            stunProbability = setStunProbability(probability);
        }
        public Stun()
        {
            stunDuration = 3;
            stunProbability = 0.25;
        }

        //Override Methods
        public String getStatusConditionName()
        {
            return name;
        }
        public void implementStatusCondition()
        {
            //TODO: check to see if you should prevent the player from moving using the stun duration and stun probability variables
        }
        public void removeStatusCondition()
        {
            //TODO: remove this status condition from the character
        }

        //Private Methods
        private int setStunDuration(int duration)
        {
            if(duration < 3){
                duration = 3;
            }
            else if(duration > 10){
                duration = 10;
            }
            return duration;
        }
        private double setStunProbability(double probability)
        {
            if(probability < 0.25){
                probability = 0.25;
            }
            else if(probability > 0.75){
                probability = 0.75;
            }
            return probability;
        }
    }
}