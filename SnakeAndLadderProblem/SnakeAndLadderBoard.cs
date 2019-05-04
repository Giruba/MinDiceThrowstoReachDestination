using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAndLadderProblem
{
    class SnakeAndLadderBoard
    {
        int boardSize;
        int[] snakeAndLadderBoard;

        public SnakeAndLadderBoard(int boardSize) {
            this.boardSize = boardSize;
            snakeAndLadderBoard = new int[boardSize];
        }

        public int GetSnakeAndLadderBoardSize() {
            return boardSize;
        }

        public int[] GetSnakeAndLadderBoard() {
            return snakeAndLadderBoard;
        }

        public void SetSnakeAndLadderBoardSize(int size) {
            boardSize = size;
        }

        public void SetSnakeAndLadderBoard(int[] board) {
            snakeAndLadderBoard = board;
        }

        public void GetMinimumDiceThrowsToReachDestintion() {
            _InitializeBoard();
            GetSnakeAndLadderPositions("ladder");
            GetSnakeAndLadderPositions("snake");
            int minDiceThrows = _GetMinimumDiceThrowsToReachDestintion();
            Console.WriteLine("Minimum number of throws required is "+minDiceThrows);
        }

        private void _InitializeBoard() {
            for (int index = 0; index < boardSize; index++) {
                snakeAndLadderBoard[index] = -1;
            }
        }

        public void GetSnakeAndLadderPositions(String theThing) {
            Console.WriteLine("Enter the number of " + theThing +"s");
            try
            {
                int numberOfLadders = int.Parse(Console.ReadLine().Trim());
                for (int ladder = 0; ladder < numberOfLadders; ladder++)
                {
                    Console.WriteLine("Enter the " + theThing + " index and destination index " +
                        "separated by space, comma or semi-colon");
                    String[] elements = Console.ReadLine().Trim().Split(' ', ',', ';');
                    int ladderStartIndex = int.Parse(elements[0]);
                    int ladderDestinationIndex = int.Parse(elements[1]);
                    snakeAndLadderBoard[ladderStartIndex] = ladderDestinationIndex;
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
        }

        private int _GetMinimumDiceThrowsToReachDestintion() {
            int[] visited = new int[boardSize];
            Queue<VertexWithDistance> queue = new Queue<VertexWithDistance>();
            queue.Enqueue(new VertexWithDistance(0, 0));
            visited[0] = 1;

            while (queue.Count != 0) {
                VertexWithDistance queueItem = queue.Dequeue();
                int dequeuedVertex = queueItem.GetVertex();
                int dequeuedVertexDisatance = queueItem.GetVertexDistance();
                //verify if we have reached the destination
                if (dequeuedVertex == boardSize - 1) {
                    break;
                }

                //Check for the 6 adjacent vertices
                for (int adjacentVertex = dequeuedVertex + 1; adjacentVertex <= (dequeuedVertex + 6)
                    && adjacentVertex < boardSize; adjacentVertex++) {

                    //If adjacent vertex is not visited, visit it
                    if (visited[adjacentVertex] == 0) {
                        visited[adjacentVertex] = 1;

                        int adjVertexDistance = dequeuedVertexDisatance + 1;

                        //Let the current value of adjVertex be the adjacentVertex value
                        int adjVertex = adjacentVertex;
                        /* If the adjacent vertex holds a snake or ladder,
                         * another vertex can be reached
                         */
                        if (snakeAndLadderBoard[adjacentVertex] != -1) {
                            adjacentVertex = snakeAndLadderBoard[adjacentVertex];
                        }

                        queue.Enqueue(new VertexWithDistance(adjacentVertex, adjVertexDistance));
                    }
                }
            }
            return queue.Peek().GetVertexDistance();
        }

    }
}
