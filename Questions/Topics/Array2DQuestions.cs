using System;

namespace Questions
{
    public class Array2DQuestions
    {
        /*
         * 2D arrays or matrix
         * declaring 
         * var arr = new int[row][col];
         * 
         * Following is an example of matrix of size int[2][3]
         * 1 2 3 4
         * 2 3 4 5
         * 3 4 5 6
         */

        /// <summary>
        /// operations like creation, searching, print
        /// </summary>
        public static void Operations()
        {

            var arr = ReadMatrix();
            Helper.WriteLine("Enter element to search in array");
            var ele = Helper.ReadN();
            Console.WriteLine($"Found element: {LinearSearch(arr, ele)}");
            PrintMatrix(arr);

        }

        private static bool LinearSearch(int[,] arr, int target)
        {
            var isPresent = false;

            var rowCount = arr.GetLength(0);
            var colCount = arr.GetLength(1);
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (arr[i, j] == target)
                    {
                        isPresent = true;
                        break;
                    }
                }
            }

            return isPresent;
        }

        /// <summary>
        /// Print elements of matrix in spiral order
        /// </summary>
        /// Input: 
        /// 1  2  3  4
        /// 5  6  7  8
        /// 9  10 11 12
        /// 13 14 15 16
        /// output:

        /// 1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10
        internal static void SpiralOrderTraversal()
        {
            var matrix = ReadMatrix();
            SpiralOrderTraversal(matrix);
        }

        private static void SpiralOrderTraversal(int[,] arr)
        {
            var rowStart = 0;
            var rowEnd = arr.GetLength(0)-1;

            var colStart = 0;
            var colEnd = arr.GetLength(1)-1;

            // 1 2 3
            // 4 5 6
            // 7 8 9
            while (rowStart <= rowEnd && colStart <= colEnd)
            {
                // Print top 
                if (!(rowStart <= rowEnd && colStart <= colEnd)) break;
                for (int i = colStart; i <= colEnd; i++)
                {
                    Console.Write(arr[rowStart, i] + "  ");
                }
                rowStart++;

                // Print right 
                if (!(rowStart <= rowEnd && colStart <= colEnd)) break;
                for (int i = rowStart; i <= rowEnd; i++)
                {
                    Console.Write(arr[i, colEnd] + "  ");
                }
                colEnd--;

                // Print bottom
                if (!(rowStart <= rowEnd && colStart <= colEnd)) break;
                for (int i = colEnd; i >= colStart; i--)
                {
                    Console.Write(arr[rowEnd, i] + "  ");
                }
                rowEnd--;

                //print left
                if (!(rowStart <= rowEnd && colStart <= colEnd)) break;
                for (int i = rowEnd; i >= rowStart; i--)
                {
                    Console.Write(arr[i, colStart] + "  ");
                }
                colStart++;

            }
        }


        /// <summary>
        /// Get transpose of a matrix
        /// </summary>
        /// Approach: 
        ///     if NxN 
        ///     take left-> right diagonal
        ///     swap all elements less smaller than that diagonal
        ///     else
        ///         create new array
        ///             arr[row,col] = arr[col,row]
               
        /*
         * I: 
         * 1  2  3  4
         * 5  6  7  8
         * 9  10 11 12
         * 13 14 15 16
         * 
         * O: 
         * 1 5 9  13
         * 2 6 10 14
         * 3 7 11 15
         * 4 8 12 16
         */
        public static void MatrixTranspose()
        {
            var arr = ReadMatrix();
            var rowCount = arr.GetLength(0);
            var colCount = arr.GetLength(1);

            if (rowCount == colCount) MatrixTranspose_NxN(arr);
            else arr = MatrixTranspose(arr);
            PrintMatrix(arr);
        }

        private static void MatrixTranspose_NxN(int[,] arr)
        {
            var rowCount = arr.GetLength(0);
            var colCount = arr.GetLength(1);

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    var temp = arr[row, col];
                    arr[row, col] = arr[col, row];
                    arr[col, row] = temp;
                }
            }
        }

        private static int[,] MatrixTranspose(int[,] arr)
        {
            var rowCount = arr.GetLength(0);
            var colCount = arr.GetLength(1);

            var transposed = new int[colCount, rowCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    transposed[col, row] = arr[row, col];
                }
            }

            return transposed;
        }

        /// <summary>
        /// Given two 2d arrays, n1xn2 & n2xn3, multiply the matrices
        /// note: col of one matrix must be equal to row of other matrix
        /// output will be n1xn3
        /// 
        /// 1 2 3
        /// 4 5 6
        /// 
        /// 7  8
        /// 9  10
        /// 11 12
        /// 
        /// m1 is 2x3 and m2 is 3x2
        /// output will be 2x2
        /// 
        /// Steps: row of first matrix will be multiplied by column of second matrix
        /// 
        /// m3(0,0) = m1(0,0)*m2(0,0) +  m1(0,1)*m2(1,0) +  m1(0,2)*m2(2,0)
        ///         = 1*7 + 2*9 + 3*11
        /// m3(0,1) = m1(0,0)*m2(0,1) +  m1(0,1)*m2(1,1) +  m1(0,2)*m2(2,2)
        ///         = 1*8 + 2*10 + 3*12
        /// m3(1,0) = m1(1,0)*m2(0,0) +  m1(1,1)*m2(1,0) +  m1(1,2)*m2(2,0)
        ///         = 4*7 + 5*9+ 6*11
        /// m3(1,1) = m1(1,0)*m2(0,1) +  m1(1,1)*m2(1,1) +  m1(1,2)*m2(2,1)
        ///         = 4*8+ 5*10+ 6*12
        /// </summary>
        /// 
        public static void MatrixMultiplication()
        {
            var m1 = ReadMatrix();
            var m2 = ReadMatrix();

            var output = MatrixMultiplication(m1,m2);
            PrintMatrix(output);
        }

        /// 1 2 3
        /// 4 5 6
        /// 
        /// 7  8
        /// 9  10
        /// 11 12
        private static int[,] MatrixMultiplication(int[,] m1, int[,] m2)
        {
            var m1Row = m1.GetLength(0);
            var m1Col = m1.GetLength(1);

            var m2Row = m2.GetLength(0);
            var m2Col = m2.GetLength(1);

            if (m1Col != m2Row) throw new Exception("invalid matrices");

            var output = new int[m1Row, m2Col];

            for (int i = 0; i < m1Row; i++)
            {
                for (int j = 0; j < m2Col; j++)
                {
                    for (int k = 0; k < m1Col; k++)
                    {
                        output[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return output;

        }


        /// <summary>
        /// Given a matrix, such that all rows and columns are in sorted order
        /// picking any element with [row, col], it will be smaller than any elements in the current row and in current column
        /// Check if element n exists in matrix
        /// Constraints complexity should be < Log(m*n)
        /// </summary>
        /*
         * Input: 
         * 1  4  7  11
         * 2  5  8  12
         * 3  6  9  16
         * 10 13 13 17
         * 
         * Approach:
         *  1. start from top right or bottom left element
         *  2. Until element is found or index is invalid
         *      (if starting from top right)
         *      if element is < target then row++
         *      else column--
         */
        public static void MatrixSearch()
        {
            var matrix = ReadMatrix();
            var n = Helper.ReadN();

            Helper.WriteLine(MatrixSearch(matrix, n));

        }

        private static bool MatrixSearch(int[,] arr, int target)
        {
            var isPresent = false;

            var rowEnd = arr.GetLength(0);
            var colEnd = arr.GetLength(1);

            var row = 0;
            var col = colEnd-1;


            while (row < rowEnd && col >= 0)
            {
                if (arr[row,col] == target)
                {
                    return true;
                }
                else if (arr[row, col] > target)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }

            return isPresent;
        }

        #region helper
        private static int[,] ReadMatrix()
        {
            Helper.WriteLine("Enter row & col");
            var row = Helper.ReadN();
            var col = Helper.ReadN();

            Helper.WriteLine("Enter matrix");

            var arr = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                var rowArr = Helper.ReadElementsInOneLine();
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = rowArr[j];
                }
            }

            return arr;
        }

        private static void PrintMatrix(int[,] arr)
        {
            var rowCount = arr.GetLength(0);
            var colCount = arr.GetLength(1);
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();

            }
        }
        #endregion
    }
}


/*
        /// <summary>
        /// Array
        /// </summary>
        public static void Array()
        {
            var arr = Helper.ReadElementsInOneLine();
            var n = arr.Length;

            var ans = Array(arr);
            Helper.WriteLine(ans);
        }

        private static int Array(int[] arr)
        {
            return 1;
        }
 */