using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplicationPerformance.MatrixLogic
{
    internal class MatrixGenerate
    {
        private static readonly Random random = new Random();
        public T[,] GenerateMatrix<T>(int size)
        {
            T[,] matrix = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    object value;

                    if (typeof(T) == typeof(int))
                    {
                        value = random.Next(1, 101);
                    }
                    else if (typeof(T) == typeof(short) || typeof(T) == typeof(Int16))
                    {
                        value = (short)random.Next(1, 101);
                    }
                    else if (typeof(T) == typeof(long) || typeof(T) == typeof(Int64))
                    {
                        value = (long)random.Next(1, 101);
                    }
                    else if (typeof(T) == typeof(float))
                    {
                        // Generate a float value between 1.0 and 100.0
                        value = (float)(random.NextDouble() * 99.0 + 1.0);
                    }
                    else if (typeof(T) == typeof(double))
                    {
                        // Generate a double value between 1.0 and 100.0
                        value = random.NextDouble() * 99.0 + 1.0;
                    }
                    else
                    {
                        throw new InvalidOperationException("Unsupported type for matrix generation.");
                    }
                    matrix[i, j] = (T)Convert.ChangeType(value, typeof(T));
                }
                
            }
            return matrix;
        }
    }
}
