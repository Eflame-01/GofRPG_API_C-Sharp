using System;

namespace GofRPG_API
{
    public abstract class Move
    {
        public abstract void performMove(Character user, Character target);
        public abstract void performSideEffect(Character target);
        public abstract bool isPrimaryMove();
        public abstract void resetMove();
        bool didMoveMiss(double accuracy, Character target)
        {
            //P(Accuracy Failed) OR P(Target Evaded)
            double accuracyFailed = 1 - accuracy;

            return false;
        }

    }
}