using System.Collections.Generic;

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
        
        public bool IsMoveInBattleSlot(Move move)
        {
            for(int i = 0; i < BattleMoves.Length; i++)
            {
                if(BattleMoves[i] == null)
                {
                    continue;
                }
                else
                {
                    if(BattleMoves[i].MoveName.Equals(move.MoveName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsMoveInList(Move move)
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
        public void AddMoveToBattleSlot(Move move)
        {
            if(BattleMoves.GetLength(1) == BattleMoves.Length || IsMoveInBattleSlot(move))
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
        public void AddMoveToList(Move move)
        {
            if(IsMoveInList(move))
            {
                return;
            }
            MovesLearned.Add(move);
        }
    }
}