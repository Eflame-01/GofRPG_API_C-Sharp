using System;

namespace GofRPG_API
{
    public abstract class SecondaryMove : Move
    {
        public bool IsSideEffect {get; set;}
        public override bool IsPrimaryMove()
        {
            //TODO: if its not a side effect, return true, if it is, return false
            return !IsSideEffect;
        }
        public override void ResetMove()
        {
            return;
        }
    }
}