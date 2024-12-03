using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace MatrixMultiplicationPerformance.MatrixAlgorithmPerformance
{
    internal class SaveResultToTxT
    {
        public void writeToTxt(string path, string name, string[]? titles, int[]? sizes, List<double[]> data)
        {
            using( StreamWriter sw = new StreamWriter(path+name))
            {
                if (titles != null)
                {
                    foreach (string title in titles)
                    {
                        sw.Write(title + " ");
                    }
                    sw.WriteLine();
                }
                if (sizes != null)
                {
                    foreach (int size in sizes)
                    {
                        sw.Write(size + " ");
                    }
                    sw.WriteLine();
                }
                foreach (var row in data )
                {
                    foreach(var item in row)
                    {
                        sw.Write(item + " ");
                    }
                    sw.WriteLine();
                }
            }
        }

        public void writeHistogramData(string path, string name, List<double> data, List<double> dataParallel)
        {
            using (StreamWriter sw = new StreamWriter(path + name))
            {
                foreach(var item in data)
                {
                    sw.Write(item + " ");
                }
                Console.WriteLine();
                foreach (var itemParallel in dataParallel)
                {
                    sw.Write(itemParallel + " ");
                }
            }
        }
    }
}
