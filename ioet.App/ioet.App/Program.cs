using Syroot.Windows.IO;
using System;

namespace ioet.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string downloadsPath = $"{new KnownFolder(KnownFolderType.Downloads).Path}\\data.txt";
            Console.WriteLine("Downloads folder path: " + downloadsPath);

            string[] lines = System.IO.File.ReadAllLines(downloadsPath);

            // Display the file contents by using a foreach loop.
            Console.WriteLine("Contents of WriteLines2.txt = ");

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
