using MatrixMultiplicationPerformance.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using ILGPU.IR.Transformations;
using ILGPU;
using System.Diagnostics.Metrics;
using System.IO;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Timers;


namespace MatrixMultiplicationPerformance.MatrixAlgorithmPerformance
{
    internal class MatrixPerformance
    { 
        public static float cpuUsage<T>(Func<T> matrixOperation)
        {
            float startCpuUsage = 0;
            float endCpuUsage = 0;
            float usage = 0;
            PerformanceCounter counter = new PerformanceCounter();

            counter.CategoryName = "Processor";
            counter.CounterName = "% Processor Time";
            counter.InstanceName = "_Total";

            try
            {
                dynamic firstValue = counter.NextValue();
                Thread.Sleep(1000);
                startCpuUsage = counter.NextValue();
                matrixOperation.Invoke();
                endCpuUsage = counter.NextValue();

            }
            finally {
                usage = endCpuUsage - startCpuUsage;
            }

            return usage;
        }
        public static double timeUsage<T>(Func<T> matrixOperation)
        {
            double totalMilliseconds = 0;
            int iterations = 4;

            /*How JIT Compilation Works:
                1. Compilation at Runtime: When a method is called for the first time, the JIT compiler translates the IL code of that method into optimized machine code.
                1. Caching: After the method is compiled, the native code is cached, so subsequent calls to the method can execute directly without recompilation.*/

            // Warm-up to mitigate JIT overhead 
            matrixOperation.Invoke();


            
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                matrixOperation.Invoke();
            }
            finally
            {
                stopwatch.Stop();

                totalMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
            }
            

            //var avg = totalMilliseconds / iterations;
            return totalMilliseconds;
        }
    }
}
