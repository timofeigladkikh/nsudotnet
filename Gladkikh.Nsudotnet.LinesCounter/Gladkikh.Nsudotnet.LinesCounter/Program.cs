using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladkikh.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                var linesCounter = new LinesCounter(args[0]);
                linesCounter.CountLines();
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("Type, please, extension of files in which you wanna count the number of rows");
                Console.ReadKey();
                return;
            }
        }
    }
}
