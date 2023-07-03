using System;

namespace SudokuSolver
{
    class Program
    {
        static int[,] board = new int[9, 9];

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Sudoku board (use '0' for empty cells):");
            // جدول دلخواهو میدیم


            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    if (line[j] == null)
                    {

                        board[i, j] = 0;
                    }
                    else
                        board[i, j] = line[j] - '0';
                }
            }

            if (SolveSudoku(0, 0))
            {
                Console.WriteLine("Solution:");
                PrintBoard ();
            }
            else
            {
                Console.WriteLine("No solution found.");
            }
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine(board[i, j]);
                }
            }
        }

        static bool SolveSudoku(int row, int col)
        {
            if (row == 9)
                return true;

            if (col == 9)
                return SolveSudoku(row + 1, 0);

            if (board[row, col] != 0)
                return SolveSudoku(row, col + 1);


            for (int num = 1; num <= 9; num++)
            {
                if (IsValid(row, col, num))
                {
                    board[row, col] = num;

                    if (SolveSudoku(row, col + 1))
                        return true;

                    board[row, col] = 0;
                }
            }

            return false;
        }

        static bool IsValid(int row, int col, int num)
        {
            // بررسی سطر
            for (int i = 0; i < 9; i++)
                if (board[row, i] == num)
                    return false;

            // بررسی ستون
            for (int i = 0; i < 9; i++)
                if (board[i, col] == num)
                    return false;

            // بررسی بلوک ۳x۳
            int blockRow = row / 3 * 3;
            int blockCol;
            return true;
        }
    }
}