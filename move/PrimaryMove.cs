using System;

namespace GofRPG_API
{
    public abstract class PrimaryMove : Move
    {
        public Move SecondaryMove {get; set;}
        public override void PerformSideEffect(Character target)
        {
            return;
        }
        public override bool IsPrimaryMove()
        {
            return true;
        }
        public override void ResetMove()
        {
            if(SecondaryMove != null)
            {
                SecondaryMove.ResetMove();
            }
        }
    }
}