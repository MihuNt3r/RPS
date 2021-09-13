using System.Collections.Generic;

namespace RPS
{
    public class Game
    {
        private LinkedList<string> _moves;
        private Dictionary<int, string> _movesDictionary;

        public Dictionary<int, string> MovesDictionary => _movesDictionary;

        public Game(params string[] moves)
        {
            _moves = new LinkedList<string>(moves);
            _movesDictionary = new Dictionary<int, string>();
            for (int i = 0, count = 1; i < moves.Length; i++)
            {
                _movesDictionary.Add(count++, moves[i]);
            }
        }
        public Result ChooseWinner(string playersMove, string computersMove)
        {
            if (playersMove == computersMove)
            {
                return Result.Draw;
            }

            LinkedListNode<string> current = _moves.Find(playersMove);
            List<string> strongerMoves = new List<string>();

            GetStrongerMoves(strongerMoves, current);

            if (strongerMoves.Contains(computersMove))
            {
                return Result.Lose;
            }

            return Result.Win;
        }

        private void GetStrongerMoves(List<string> strongerMoves, LinkedListNode<string> current)
        {
            int half = _moves.Count / 2;
            LinkedListNode<string> temp = current;
            for (int i = 0; i < half; i++)
            {
                temp = temp.Next??_moves.First;
                strongerMoves.Add(temp.Value);
            }
        }
    }
}
