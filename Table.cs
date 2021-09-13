using System.Collections.Generic;
using ConsoleTables;

namespace RPS
{
    public static class Table
    {
        public static string CreateTable(Game game, string[] moves)
        {
            List<string> list = new List<string>();
            list.Add("PC/USER");
            list.AddRange(moves);

            var table = new ConsoleTable(list.ToArray());

            FillTable(table, game, moves);

            return table.ToString();
        }

        private static void FillTable(ConsoleTable table, Game game, string[] moves)
        {
            foreach (var move in game.MovesDictionary)
            {
                string computerMove = move.Value;

                List<string> row = new List<string>();
                row.Add(computerMove);

                for (int i = 0; i < moves.Length; i++)
                {
                    Result result = game.ChooseWinner(moves[i], computerMove);

                    if (result == Result.Win)
                    {
                        row.Add("WIN");
                    }

                    if (result == Result.Lose)
                    {
                        row.Add("LOSE");
                    }

                    if (result == Result.Draw)
                    {
                        row.Add("DRAW");
                    }
                }

                table.AddRow(row.ToArray());
            }
        }
    }
}
