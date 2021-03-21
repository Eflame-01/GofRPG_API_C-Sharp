using System;

namespace GofRPG_API
{
    public abstract class SecondaryMove : Move
    {
        public bool IsSideEffect {get; set;}
        public override bool IsPrimaryMove()
        {
            return false;
        }
        public override void ResetMove()
        {
            return;
        }
    }
}