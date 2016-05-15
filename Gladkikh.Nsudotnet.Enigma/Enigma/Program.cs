using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladkikh.Nsudotnet.Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 4 && args[0] == "encrypt")
                {
                    Enigma.encrypt(args[1], args[2], args[3]);
                }
                else if (args.Length == 5 && args[0] == "decrypt")
                {
                    Enigma.decrypt(args[1], args[2], args[3],  args[4]);
                }
                else
                {
                    Console.WriteLine("Wrong arguments. Type, please, one from this:");
                    Console.WriteLine("1)encrypt inputFile algorithm outputFile");
                    Console.WriteLine("2)decrypt inputАile algorithm keyFile outputFile");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
