using System;
using System.Collections.Generic;

namespace Questions
{
    public static class BacktrackingQuestions
    {

        /*
         * Backtracking
         * backtracking is an algorithmic technique for solving recursive
         * problems by trying to build every possible solution incrementally and
         * removing those solutions that fail to satisfy the constraints of the problem
         * at any given time
         * 
         */

        /// ------------------------------------
        /// <summary>
        /// Consider grid of NxN blocks, with obstacles that can not be traversed througg
        /// find a way to get from 0,0 to n-1,n-1
        /// </summary>
        public static void RatInAMaze()
        {
            Helper.WriteLine("Enter n");
            var size = Helper.ReadN();

            Helper.WriteLine("Enter matrix");
            var maze = new char[,]
                {
                    { '.', 'x', '.', 'x', '.' },
                    { '.', '.', '.', '.', '.' },
                    { 'x', '.', 'x', '.', 'x' },
                    { '.', 'x', 'x', '.', '.' },
                    { '.', '.', '.', 'x', '.' }
                };

            

            RatInAMaze(maze, size, 0, 0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (maze[i, j] == '1')
                    {
                        Helper.WriteLine($"{i}, {j}");
                    }
                }
            }
        }

        private static bool RatInAMaze(char[,] maze, int n, int row, int col)
        {
            if (
                row >= n || 
                col >= n || 
                row < 0 || 
                col < 0 ||
                maze[row,col] == 'x' ||
                maze[row, col] == '1' ||
                maze[row, col] == '0'
                )
                return false;

            maze[row, col] = '1';

            if (row == (n - 1) && col == (n-1))
                return true;

            bool isTopViable = RatInAMaze(maze, n, row - 1, col);
            bool isRightViable = RatInAMaze(maze, n, row, col+1);
            bool isBottomViable = RatInAMaze(maze, n, row + 1, col);
            bool isLeftViable = RatInAMaze(maze, n, row, col - 1);

            if (isTopViable || isRightViable || isBottomViable || isLeftViable)
            {
                return true;
            }
            else
            {
                maze[row, col] = '0';
                return false;
            }
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Return N ^ P using recursion
        /// </summary>
        public static void NQueen()
        {
            var size = Helper.ReadN();
            var chessBoard = new int[size,size];

            NQueen(chessBoard, size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (chessBoard[i, j] == 1)
                    {
                        Console.Write($"1 ");
                    }
                    else
                    {
                        Console.Write($"0 ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static bool NQueen(int[,] board, int size, int row = 0)
        {
            if (row >= size) return true;
            int col = 0;

            while (col < size)
            {
                if (board[row,col] != 2)
                {
                    board[row, col] = 1;
                    // Better approach might be to implement isSafe function rather than updating board
                    PositionQueen(board, size, row, col, false);
                    var isViable = NQueen(board, size, row+1);
                    
                    if (isViable)
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = 0;
                        PositionQueen(board, size, row, col, true);
                    }
                }
                col++;
            }

            return false;
        }

        /*
         *  0 1 2 3
         *  0 1 2 3
         *  0 1 2 3
         *  0 1 2 3
         */
        private static void PositionQueen(int[,] board, int size, int row, int col, bool isReset)
        {
            int value = 2;
            if (isReset) value = 0;

            // bottom
            for(int i=row+1; i<size; i++)
            {
                board[i, col] = value;
            }

            // left diagonal
            int j = col - 1;
            for(int i=row+1; i<size; i++)
            {

                if (j >= 0)
                {
                    board[i, j] = value;
                    j--;
                }
            }

            // right diagonals
            j = col + 1;
            for (int i = row + 1; i < size; i++)
            {
                if ( j < size)
                {
                    board[i, j] = value;
                    j++;
                }
            }
        }
        // ------------------------------------
    }
}

// Template 

/*
 
/// ------------------------------------
/// <summary>
/// Question: 
/// </summary>
public static void SumTillN()
{
    var n = Helper.ReadN();
    var result = SumTillN(n);
    Helper.WriteLine(result);
}

private static int SumTillN(int n)
{
    if (n == 1)
        return n;

    return n + SumTillN(n - 1);
}
// ------------------------------------


*/