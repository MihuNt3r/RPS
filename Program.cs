using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS
{
    class Program 
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Not enough arguments");
                return;
            }
            if (args.Length % 2 == 0)
            {
                Console.WriteLine("Even number of arguments");
                return;
            }
            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Duplicate arguments");
                return;
            }


            Game game = new Game(args);
            string key = Random.GetKey();
            string computerMove = Random.GetRandomMove(args);
            string hmac = Random.GetHMAC(computerMove, key);

            Console.WriteLine("HMAC: " + hmac);
            ShowCommands(game.MovesDictionary);

            string playersMove;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "?")
                {
                    PrintTable(game, args);
                }
                else if (input == "0")
                {
                    return;
                }
                else
                {
                    int move;
                    try
                    {
                        move = Int32.Parse(input);
                        if (game.MovesDictionary.TryGetValue(move, out playersMove))
                        {
                            break;
                        }

                        Console.WriteLine("Error. Try again");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }
            }

            Console.WriteLine("Your move: " + playersMove);
            Console.WriteLine("Computers move: " + computerMove);

            Result result = game.ChooseWinner(playersMove, computerMove);
            ShowResult(result);

            Console.WriteLine("Key: " + key);
        }

        

        public static void ShowCommands(Dictionary<int, string> movesDictionary)
        {
            Console.WriteLine("Available moves: ");
            foreach (var move in movesDictionary)
            {
                Console.WriteLine(move.Key + " - " + move.Value);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public static void ShowResult(Result result)
        {
            if (result == Result.Win)
            {
                Console.WriteLine("You won");
            }

            if (result == Result.Lose)
            {
                Console.WriteLine("You lost");
            }

            if (result == Result.Draw)
            {
                Console.WriteLine("It's a draw");
            }
        }
        public static void PrintTable(Game game, string [] moves)
        {
            Console.WriteLine(Table.CreateTable(game, moves));
        }
    }
}
