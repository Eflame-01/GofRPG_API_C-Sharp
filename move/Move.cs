using System;

namespace GofRPG_API
{
    public interface Move
    {
        public void performMove(Character user, Character target);
        public void performSideEffect(Character target);
        public bool isPrimaryMove();
        public void resetMove();
        bool didMoveMiss(double accuracy, Character target)
        {
            //P(Accuracy Failed) OR P(Target Evaded)
            double accuracyFailed = 1 - accuracy;

            return false;
        }

    }
}