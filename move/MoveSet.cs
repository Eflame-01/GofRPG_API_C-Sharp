using System.Collections.Generic;
using System;


namespace GofRPG_API
{
    public class MoveSet
    {
        public List<Move> MovesLearned {get; private set;}
        public Move[] BattleMoves {get; private set;}

        public MoveSet()
        {
            MovesLearned = new List<Move>();
            BattleMoves = new Move[4];
        }

        public void SwitchTwoMovesInList(int indexOne, int indexTwo)
        {
            Move moveOne = MovesLearned[indexOne];
            Move moveTwo = MovesLearned[indexTwo];
            MovesLearned[indexOne] = moveTwo;
            MovesLearned[indexTwo] = moveOne;
        }
        public void SwitchTwoMovesInSlot(int indexOne, int indexTwo)
        {
            Move moveOne = BattleMoves[indexOne];
            Move moveTwo = BattleMoves[indexTwo];
            BattleMoves[indexOne] = moveTwo;
            BattleMoves[indexTwo] = moveOne;
        }

        public void AddMove(Move move)
        {
            AddMoveToBattleSlot(move);
            AddMoveToList(move);
        }
        
        private bool IsMoveInBattleSlot(Move move)
        {
            for(int i = 0; i < BattleMoves.Length; i++)
            {
                //if the move in the slot is not null, and move name is the same as move.MoveName, then that move is in the battle slot. Return true.
                if(BattleMoves[i] != null && BattleMoves[i].MoveName.Equals(move.MoveName))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsMoveInList(Move move)
        {
            foreach(Move m in MovesLearned)
            {
                if(m.MoveName.Equals(move.MoveName))
                {
                    return true;
                }
            }
            return false;
        }
        private void AddMoveToBattleSlot(Move move)
        {
            if(IsMoveInBattleSlot(move))
            {
                return;
            }
            for(int i = 0; i < BattleMoves.Length; i++)
            {   
                if(BattleMoves[i] == null)
                {
                    BattleMoves[i] = move;
                    break;
                }
            }
        }
        private void AddMoveToList(Move move)
        {
            if(IsMoveInList(move))
            {
                return;
            }
            MovesLearned.Add(move);
        }
    }
}