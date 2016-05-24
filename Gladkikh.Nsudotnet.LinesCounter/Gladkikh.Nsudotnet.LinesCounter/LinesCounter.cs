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
                    bool newLine = true;
                    bool multiComment = false;
                    bool comment = false;

                    while (!streamReader.EndOfStream)
                    {
                        char symbol = (char)streamReader.Read();
                        
                        if (symbol == '\r' || symbol == ' ')
                        {
                            continue;
                        }

                        if (symbol == '/' && !comment)
                        {
                            symbol = (char)streamReader.Read();

                            switch (symbol)
                            {
                                case '/':
                                    comment = true;
                                    continue;  
                                case '*':
                                    multiComment = true;
                                    continue;         
                            }
                        }

                        if (multiComment && symbol == '*')
                        {
                            symbol = (char)streamReader.Read();      
                            
                            if (symbol == '/')
                            {
                                multiComment = false;
                                continue;
                            }
                        }
                        
                        if (symbol == '\n')
                        {
                            newLine = true;
                            if (comment)
                            {
                                comment = false;
                            }
                            continue;
                        }

                        if (newLine && !comment && !multiComment)
                        {
                            count++;
                            newLine = false;
                        }
                    }
                    amount += count;
                }
            }
            Console.WriteLine("Amount line in files with extension .{0}: {1}", extension, amount);
        }
    }
}