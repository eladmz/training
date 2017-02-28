using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    /**
     * There is a matrix nxn, format the matrix s.t for each element, if its a zero then its entire row and column should
     * also be zero.
     */
    class SetRowAndColumnToZeroInMatrix
    {
        public int[,] zeroifyRowCol(int[,] matrix)
        {
            int matrixLength = matrix.Length;
            bool[] row = new bool[matrixLength];
            bool[] col = new bool[matrixLength];

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        row[i] = true;
                        col[j] = true;
                    }
                }
            }

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (row[i] || col[j])
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }
    }
}
