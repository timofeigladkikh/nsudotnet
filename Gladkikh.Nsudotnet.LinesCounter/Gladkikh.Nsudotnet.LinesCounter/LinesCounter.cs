using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladkikh.Nsudotnet.LinesCounter
{
    class LinesCounter
    {
        private string extension;

        public LinesCounter(string _extension)
        {
            extension = _extension;
        }

        public void CountLines()
        {
            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*." + extension, SearchOption.AllDirectories);
            int amount = 0;
            
            foreach (var file in files)
            {
                using (var streamReader = new StreamReader(file))
                {
                    int count = 0;
                    bool multiComment = false;
                    string line = "";

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        if (line.Equals("") || line.StartsWith("//")) continue;

                        if (line.StartsWith("/*")) multiComment = true;

                        if (!multiComment)
                        {
                            count++;
                            Console.WriteLine(count);
                        }

                        if (line.EndsWith("*/")) multiComment = false;

                    }
                    amount += count;
                    count = 0;

/*
test                  
*/
                }
            }
            Console.WriteLine("Amount line in files with extension .{0}: {1}", extension, amount);
        }
    }
}