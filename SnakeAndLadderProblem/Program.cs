using System;

namespace SnakeAndLadderProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Snake and Ladder problem!");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Enter the size of the board");
            try{
                int size = int.Parse(Console.ReadLine().Trim());
                new SnakeAndLadderBoard(size).GetMinimumDiceThrowsToReachDestintion();
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            Console.ReadLine();
        }
    }
}
