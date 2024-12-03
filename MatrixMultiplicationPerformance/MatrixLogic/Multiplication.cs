using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplicationPerformance.MatrixLogic
{
    internal class Multiplication<T>
    {
        T[,] matrixA, matrixB;

        public Multiplication(T[,] matrixA, T[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                throw new InvalidOperationException("Number of columns in A must match number of rows in B for multiplication.");
            }

            this.matrixA = matrixA;
            this.matrixB = matrixB;
        }

        public T[,] multiply()
        {
            int matrixA_len = matrixA.GetLength(0);
            int matrixB_len = matrixB.GetLength(1);
            T[,] result = new T[matrixA_len, matrixB_len];

            for (int i = 0; i < matrixA_len; i++)
            {
                for (int j = 0; j < matrixB_len; j++)
                {
                    dynamic? sum = default(T);
                    for (int k = 0; k < matrixB.GetLength(0); k++)
                    {
                        sum += (dynamic)matrixA[i, k] * matrixB[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public T[,] multiplyParallel()
        {
            int matrixA_len = matrixA.GetLength(0);
            int matrixB_len = matrixB.GetLength(1);
            T[,] result = new T[matrixA_len, matrixB_len];
            Parallel.For(0, matrixA_len, i => {
                for (int j = 0; j < matrixB_len; j++)
                {
                    dynamic sum = default(T);
                    for (int k = 0; k < matrixB.GetLength(0); k++)
                    {
                        sum += (dynamic)matrixA[i, k] * (dynamic)matrixB[k, j];
                    }
                    result[i, j] = sum;
                }
            });

            return result;
        }
    }
}
