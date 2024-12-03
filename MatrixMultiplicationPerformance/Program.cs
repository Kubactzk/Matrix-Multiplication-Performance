using MatrixMultiplicationPerformance.Logic;
using MatrixMultiplicationPerformance.MatrixAlgorithmPerformance;
using MatrixMultiplicationPerformance.MatrixLogic;
using OxyPlot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace MatrixMultiplicationPerformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //num of iterations
            int iterations = 500;
            //data to txt file
            string path = "D:\\Studia\\ISA-magister\\sem_2\\Obliczenia_wys_wydajnosci\\Projekt\\temat1\\MatrixMultiplicationPerformance\\PlottingData\\";
            string name = "Data.txt";
            string[] titles = { "intBenchmark", "intBenchmarkParallel", "int64Benchmark", "int64BenchmarkParallel", "doubleBenchmark", "doubleBenchmarkParallel" };
            string[] titlesHist = {"intBenchmark", "intBenchmarkParallel"}; //"doubleBenchmark", "doubleBenchmarkParallel", "int64Benchmark", "int64BenchmarkParallel"

            //matrix sizes
            int[] sizes = { 80, 100, 200, 400, 600, 800, 1000, 1200, 1400, 1600, 1800, 2000 };
            int[] sizesHist = { 3, 20, 40, 60, 80, 100, 200, 400, 600, 800 };
            //matrix lists + generation
            List<int[,]> intMatricesA = new List<int[,]>();
            List<Int16[,]> int16MatricesA = new List<Int16[,]>();
            List<Int64[,]> int64MatricesA = new List<Int64[,]>();
            List<double[,]> doubleMatricesA = new List<double[,]>();

            List<int[,]> intMatricesB = new List<int[,]>();
            List<Int16[,]> int16MatricesB = new List<Int16[,]>();
            List<Int64[,]> int64MatricesB = new List<Int64[,]>();
            List<double[,]> doubleMatricesB = new List<double[,]>();


           /* // benchmarks histogram
            int arraySize = iterations;
            double[] intBenchmark = new double[arraySize];
            double[] intBenchmarkParallel = new double[arraySize];
            double[] int16Benchmark = new double[arraySize];
            double[] int16BenchmarkParallel = new double[arraySize];
            double[] int64Benchmark = new double[arraySize];
            double[] int64BenchmarkParallel = new double[arraySize];
            double[] doubleBenchmark = new double[arraySize];
            double[] doubleBenchmarkParallel = new double[arraySize];*/

            //initialize generator class
            MatrixGenerate generator = new MatrixGenerate();

            double counter = 0;
            double counterParallel = 0;
            //algorithm
            
            //generate random samples
            foreach (int size in sizes)
            {
                intMatricesA.Add(generator.GenerateMatrix<int>(size));
                int16MatricesA.Add(generator.GenerateMatrix<Int16>(size));
                int64MatricesA.Add(generator.GenerateMatrix<Int64>(size));
                doubleMatricesA.Add(generator.GenerateMatrix<double>(size));

                intMatricesB.Add(generator.GenerateMatrix<int>(size));
                int16MatricesB.Add(generator.GenerateMatrix<Int16>(size));
                int64MatricesB.Add(generator.GenerateMatrix<Int64>(size));
                doubleMatricesB.Add(generator.GenerateMatrix<double>(size));
            }

            /*int num = 0;

            for (int i = 7; i < sizesHist.Length; i++)
            {
                int num1 = 0;
                var operation = new Multiplication<int>(intMatricesA[i], intMatricesB[i]);
                Console.WriteLine("-----------------------------------" + num++);
                for (int k = 0; k < iterations; k++)
                {
                    Console.WriteLine(num1++);
                    intBenchmark[k] = MatrixPerformance.timeUsage(() => operation.multiply());
                    intBenchmarkParallel[k] = MatrixPerformance.timeUsage(() => operation.multiplyParallel());
                }
                int[] temp = new int[1];
                temp[0] = sizesHist[i];
                List<double[]> allBenchmarks = new List<double[]>();
                allBenchmarks.Add(intBenchmark);
                allBenchmarks.Add(intBenchmarkParallel);
                SaveResultToTxT saveResultToTxT = new SaveResultToTxT();
                saveResultToTxT.writeToTxt(path, $"DataHist{sizesHist[i]}.txt", titlesHist, temp, allBenchmarks);
            }*/


            /*for (int i = 0; i < sizes.Length; i++)
            {
                var operation = new Multiplication<Int64>(int64MatricesA[i], int64MatricesB[i]);
                for (int k = 0; k < iterations; k++)
                {
                    double ElapsedTime = MatrixPerformance.timeUsage(() => operation.multiply());
                    double ElapsedTimeParallel = MatrixPerformance.timeUsage(() => operation.multiplyParallel());
                    int64Benchmark[k] = ElapsedTime;
                    int64BenchmarkParallel[k] = ElapsedTimeParallel;
                }
            }*/

            /*for (int i = 0; i < sizes.Length; i++)
            {
                var operation = new Multiplication<double>(doubleMatricesA[i], doubleMatricesB[i]);
                for (int k = 0; k < iterations; k++)
                {
                    double ElapsedTime = MatrixPerformance.timeUsage(() => operation.multiply());
                    double ElapsedTimeParallel = MatrixPerformance.timeUsage(() => operation.multiplyParallel());
                    doubleBenchmark[k] = ElapsedTime;
                    doubleBenchmarkParallel[k] = ElapsedTimeParallel;
                }
            }*/

            //generate lined data

            // benchmarks lineral
            /*int arraySize = sizes.Length;
            double[] intBenchmark = new double[arraySize];
            double[] intBenchmarkParallel = new double[arraySize];
            double[] int16Benchmark = new double[arraySize];
            double[] int16BenchmarkParallel = new double[arraySize];
            double[] int64Benchmark = new double[arraySize];
            double[] int64BenchmarkParallel = new double[arraySize];
            double[] doubleBenchmark = new double[arraySize];
            double[] doubleBenchmarkParallel = new double[arraySize];*/


            //code using <Multiplication.cs>
            /*Console.WriteLine("Int started");
            for (int i = 0; i < sizes.Length; i++)
            {
                var operation = new Multiplication<int>(intMatricesA[i], intMatricesB[i]);
                intBenchmark[i] = MatrixPerformance.timeUsage(() => operation.multiply());
                intBenchmarkParallel[i] = MatrixPerformance.timeUsage(() => operation.multiplyParallel());
            }
            Console.WriteLine("Int ended");
            Console.WriteLine("Int64 started");
            for (int i = 0; i < sizes.Length; i++)
            {
                var operation = new Multiplication<Int64>(int64MatricesA[i], int64MatricesB[i]);
                double ElapsedTime = MatrixPerformance.timeUsage(() => operation.multiply());
                double ElapsedTimeParallel = MatrixPerformance.timeUsage(() => operation.multiplyParallel());
                int64Benchmark[i] = ElapsedTime;
                int64BenchmarkParallel[i] = ElapsedTimeParallel;
            }
            Console.WriteLine("Int64 ended");
            Console.WriteLine("double started");
            for (int i = 0; i < sizes.Length; i++)
            {
                var operation = new Multiplication<double>(doubleMatricesA[i], doubleMatricesB[i]);
                double ElapsedTime = MatrixPerformance.timeUsage(() => operation.multiply());
                double ElapsedTimeParallel = MatrixPerformance.timeUsage(() => operation.multiplyParallel());
                doubleBenchmark[i] = ElapsedTime;
                doubleBenchmarkParallel[i] = ElapsedTimeParallel;
            }
            Console.WriteLine("double ended");*/

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------
            List<double> intBenchmark = new List<double>();
            List<double> intBenchmarkParallel = new List<double>();
            List<double> int16Benchmark = new List<double>();
            List<double> int16BenchmarkParallel = new List<double>();
            List<double> int64Benchmark = new List<double>();
            List<double> int64BenchmarkParallel = new List<double>();
            List<double> doubleBenchmark = new List<double>();
            List<double> doubleBenchmarkParallel = new List<double>();

            //code using <MatrixOperations.cs> and <MatrixPerformance>

            for (int i = 0; i < sizes.Length; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Operation {sizes[i]} started");
                for (int j = 0; j < 4; j++)
                {
                    var operation = new MatrixOperations(doubleMatricesA[i], doubleMatricesB[i], intMatricesA[i], intMatricesB[i], int64MatricesA[i], int64MatricesB[i]);
                    intBenchmark.Add(MatrixPerformance.timeUsage(operation.intmultiply));
                    intBenchmarkParallel.Add(MatrixPerformance.timeUsage(operation.intmultiplyParallel));
                    int64Benchmark.Add(MatrixPerformance.timeUsage(operation.int64multiply));
                    int64BenchmarkParallel.Add(MatrixPerformance.timeUsage(operation.int64multiplyParallel));
                    doubleBenchmark.Add(MatrixPerformance.timeUsage(operation.doublemultiply));
                    doubleBenchmarkParallel.Add(MatrixPerformance.timeUsage(operation.doublemultiplyParallel));
                    //code using <MatrixOperations.cs> and <MatrixPerformance>
                    intBenchmark[i] = MatrixPerformance.timeUsage(operation.intmultiply);
                    intBenchmarkParallel[i] = MatrixPerformance.timeUsage(operation.intmultiplyParallel);
                    int64Benchmark[i] = MatrixPerformance.timeUsage(operation.int64multiply);
                    int64BenchmarkParallel[i] = MatrixPerformance.timeUsage(operation.int64multiplyParallel);
                    doubleBenchmark[i] = MatrixPerformance.timeUsage(operation.doublemultiply);
                    doubleBenchmarkParallel[i] = MatrixPerformance.timeUsage(operation.doublemultiplyParallel);
                }
                watch.Stop();
                Console.WriteLine($"Multiplication of size {sizes[i]} took {watch.Elapsed.TotalSeconds / 60} min");
                Console.WriteLine();
            }



            // save lined to txt
            List<double[]> allBenchmarks =
            [
                intBenchmark.ToArray(),
                intBenchmarkParallel.ToArray(),
                int64Benchmark.ToArray(),
                int64BenchmarkParallel.ToArray(),
                doubleBenchmark.ToArray(),
                doubleBenchmarkParallel.ToArray(),
            ];


            SaveResultToTxT saveResultToTxT = new SaveResultToTxT();
            //saveResultToTxT.writeToTxt(path, "DataLinedWithoutTypeConversion_WithTimeMeasurmentClassofType_T.txt", titles, sizes, allBenchmarks);
            saveResultToTxT.writeToTxt(path, "FOR_PRESENTATION_LINED.txt", titles, sizes, allBenchmarks);

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------

            //rozproszona, zmiany typów --> jest
            //hybrydizer c# code
            //cuda c# starsza
            //siatka, punkty (lines + markers)
            //efektywność, przyspieszenie
            // min max, mediana
            //szacowanie czasu
            //budżet
            //histogramy do czasu
            //

            //powiązanie pomiędzy przyspieszeniem a rozmiarem danych

            //histogramy
            //czas wykonania nie jest normalny, jest mocno skośny
            //dlaczego górka jest przesunienta w lewo (opóźnienia losowe)
            // jeśli dwie górki jakideś dodatkowe zdarzenie (garbage collector) często da się poprawić, żeby 
            //natura błędów losowych
            //przeskalować osie
            //przyspieszenie w zależności od rozmiaru y - przyspieszenie, x - rozmiary
            //y - przyspieszenie , x - ilość procesorów
            //link do gita, zip, pliki, (który commit gita uznany za oddanie) --> tylko teams (prywatnie)
            //do końca semestru, garfy


            //projekt2
            //uruchamianie danych
        }
    }
}
