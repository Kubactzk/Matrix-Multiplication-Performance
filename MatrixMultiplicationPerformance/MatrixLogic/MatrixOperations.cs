using ILGPU.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixMultiplicationPerformance.Logic
{
    internal class MatrixOperations
    {
        double[,] doubleA, doubleB;
        int[,] intA,intB;
        Int64[,] int64A, int64B;

        public MatrixOperations(double[,] doubleA, double[,] doubleB, int[,] intA, int[,] intB, Int64[,] int64A, Int64[,] int64B)
        {
            if(doubleA.GetLength(1) != doubleB.GetLength(0) || intA.GetLength(1) != intB.GetLength(0))
            {
                throw new InvalidOperationException("Number of columns in A must match number of rows in B for matrix multiplication.");
            }
            this.doubleA = doubleA;
            this.doubleB = doubleB;
            this.intA = intA;
            this.intB = intB;
            this.int64A = int64A;
            this.int64B = int64B;
        }
        public double[,] doublemultiply()
        {
            double[,] result = new double[doubleA.GetLength(0), doubleB.GetLength(1)];
            for (int i = 0; i < doubleA.GetLength(0); i++)
            {
                for(int j = 0; j < doubleB.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < doubleB.GetLength(0); k++)
                    {
                        result[i, j] += doubleA[i, k] * doubleB[k, j];
                    }    
                }
            }
            return result;
        }

        public double[,] doublemultiplyParallel()
        {
            double[,] result = new double[doubleA.GetLength(0), doubleB.GetLength(1)];
            Parallel.For(0, doubleA.GetLength(0), i => {
                for (int j = 0; j < doubleB.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < doubleB.GetLength(0); k++)
                    {
                        result[i, j] += doubleA[i, k] * doubleB[k, j];
                    }
                }
            });
            
            return result;
        }

        public int[,] intmultiply()
        {
            int[,] result = new int[intA.GetLength(0), intB.GetLength(1)];
            for (int i = 0; i < intA.GetLength(0); i++)
            {
                for (int j = 0; j < intB.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < intB.GetLength(0); k++)
                    {
                        result[i, j] += intA[i, k] * intB[k, j];
                    }
                }
            }
            return result;
        }

        public int[,] intmultiplyParallel()
        {
            int[,] result = new int[intA.GetLength(0), intB.GetLength(1)];
            Parallel.For(0, intA.GetLength(0), i => {
                for (int j = 0; j < intB.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < intB.GetLength(0); k++)
                    {
                        result[i, j] += intA[i, k] * intB[k, j];
                    }
                }
            });
            return result;
        }

        public Int64[,] int64multiply()
        {
            Int64[,] result = new Int64[int64A.GetLength(0), int64B.GetLength(1)];
            for (int i = 0; i < int64A.GetLength(0); i++)
            {
                for (int j = 0; j < int64B.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < int64B.GetLength(0); k++)
                    {
                        result[i, j] += int64A[i, k] * int64B[k, j];
                    }
                }
            }
            return result;
        }

        public Int64[,] int64multiplyParallel()
        {
            Int64[,] result = new Int64[int64A.GetLength(0), int64B.GetLength(1)];
            Parallel.For(0, int64A.GetLength(0), i => {
                for (int j = 0; j < int64B.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < int64B.GetLength(0); k++)
                    {
                        result[i, j] += int64A[i, k] * int64B[k, j];
                    }
                }
            });
            return result;
        }
    }
}
